using System;
using CozyBili.Core;
using CozyBili.Core.Models;

namespace CozyBili
{
    class Program
    {
        static void Main(string[] args)
        {
            string myRoomId = "21065";
            var roomId = args.Length > 0 ? args[0] : myRoomId;
            var title = "CozyBili V1.0";
            var danmu = new LiveDanMu(int.Parse(roomId));
            danmu.OnlineNumChanged += x => Console.Title = string.Format("{0} - {1}号房间 - 当前在线人数{2}", title, roomId, x);
            danmu.ReceiveDanMu += ShowDanMu;
            var senMsg = new SendMessage();
            danmu.Run();

            string content = string.Empty;
            while ((content = Console.ReadLine()) != "stop")
            {
                senMsg.PostMessage(content, roomId);
            }
        }

        static void ShowDanMu(DanMuModel danMuModel)
        {
            Console.Write(danMuModel.Time.ToString("HH:mm:ss"));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(danMuModel.UserName + ":");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(danMuModel.Content);
            Console.ForegroundColor = ConsoleColor.White;

        }

    }
}
