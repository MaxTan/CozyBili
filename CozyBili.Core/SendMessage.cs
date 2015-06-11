using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CozyBili.Core
{
    public class SendMessage
    {
        public SendMessage()
        {
            Init();
        }

        public string Host { get; set; }

        private void Init()
        {
            this.Host = "http://live.bilibili.com/msg/send";
        }

        public bool PostMessage(string content,string roomId)
        {
            //Todo
            var handler = new HttpClientHandler { UseCookies = false };
            using (var client = new HttpClient(handler))
            {
                var postContent = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string,string>("color","16777215"),
                    new KeyValuePair<string,string>("fontsize","25"),
                    new KeyValuePair<string,string>("mode","1"),
                    new KeyValuePair<string,string>("roomid",roomId),
                    new KeyValuePair<string,string>("msg",content)
                });
                var postMessage = new HttpRequestMessage(HttpMethod.Post, this.Host);
                postMessage.Headers.Add("Cookie", this.LoadCookie());
                postMessage.Content = postContent;
                var result = client.SendAsync(postMessage).Result;
                if (result.IsSuccessStatusCode)
                {
                    var val = result.Content.ReadAsStringAsync().Result;
                    return JObject.Parse(val)["code"].ToString() == "0";
                }
                return false;
            }
        }

        private string LoadCookie()
        {
            return File.ReadAllText("Cookie.txt");
        }
    }
}
