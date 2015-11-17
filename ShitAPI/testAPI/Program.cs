﻿using System;
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
            Console.WriteLine(config.varsion);
            Console.WriteLine("api目標為:" + targetURL);
            Console.WriteLine("廁所id ?");
            int toiletID = Convert.ToInt32(Console.ReadLine());
            //設定廁所id
            config.toiletID = toiletID;
            SendCommand newCommand = new SendCommand(config);
            while (open)
            {
                Console.WriteLine("======================================");
                Console.WriteLine("1.發出廁所占用事件。\n2.發出廁所釋放事件。\n3.發出廁所鎖門事件。\n4.發出廁所開鎖事件。\n5.發出RFID事件。");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        newCommand.occupy();
                        Console.WriteLine("已發送廁所占用事件。 toilet");
                        break;
                    case "2":
                        newCommand.release();
                        Console.WriteLine("已發送廁所釋放事件。 toilet");
                        break;
                    case "3":
                        newCommand.closelock();
                        Console.WriteLine("已發送廁所鎖門事件。 lock");
                        break;
                    case "4":
                        newCommand.openlock();
                        Console.WriteLine("已發送廁所開鎖事件。 lock");
                        break;
                    case "5":
                        newCommand.beepRFID();
                        Console.WriteLine("已發送RFID事件。 beep");
                        break;
                    default:
                        open = false;
                        Console.WriteLine("不在動作清單中的命令。");
                        break;
                }
            }

            
            Console.WriteLine("任意鍵結束...");
            Console.ReadLine();
        }
    }

}
