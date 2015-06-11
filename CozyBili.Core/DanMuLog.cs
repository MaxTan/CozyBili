using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CozyBili.Core.Models;

namespace CozyBili.Core
{
    public class DanMuLog
    {
        private static DanMuLog Instance;

        private DanMuLog()
        {
        }

        public static DanMuLog GetInstance()
        {
            return Instance = Instance ?? new DanMuLog();
        }

        public void WriteFile(DanMuModel model)
        {
            var filePath = string.Format("log\\{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
            var logContent = string.Format("{0}-{1}-{2}\r\r\n", model.Time, model.UserName, model.Content);
            if (!Directory.Exists("log"))
            {
                Directory.CreateDirectory("log");
            }
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, logContent);
            }
            else
            {
                var log = File.ReadAllText(filePath);
                File.WriteAllText(filePath, log += logContent);
            }
        }
    }
}
