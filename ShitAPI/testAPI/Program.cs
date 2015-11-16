using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace testAPI
{
    class Program
    {
        private static Config config = new Config();
        static void Main(string[] args)
        {
            bool open = true;
            string targetURL = config.postURL;
            Console.WriteLine("開發用發訊器 v 1.0");
            Console.WriteLine("api目標為:" + targetURL);
            Console.WriteLine("廁所id ?");
            int toiletID = Convert.ToInt32(Console.ReadLine());
            //設定廁所id
            config.toiletID = toiletID;
            SendCommand newCommand = new SendCommand(config);
            while (open)
            {
                Console.WriteLine("======================================");
                Console.WriteLine("1.發出廁所占用事件。\n2.發出廁所釋放事件。");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        newCommand.occupy();
                        Console.WriteLine("已發送廁所占用事件。");
                        break;
                    case "2":
                        newCommand.release();
                        Console.WriteLine("已發送廁所釋放事件。");
                        break;
                    default:
                        open = false;
                        Console.WriteLine("不在動作清單中的命令。");
                        break;
                }
            }

            
            Console.WriteLine("任意鍵繼續...");
            Console.ReadLine();
        }
    }

}
