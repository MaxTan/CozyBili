using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CozyBili.Core;

namespace CozyBili.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var senMsg = new SendMessage();
            senMsg.PostMessage("测试弹幕");
        }
    }
}
