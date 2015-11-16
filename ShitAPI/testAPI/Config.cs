using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testAPI
{
    class Config
    {
        //版本
        private string _varsion = "dev v1.0";
        public string varsion
        {
            get { return _varsion; }
            set { _varsion = value; }
        }
        //接收json的url
        private string _postURL = Properties.Settings.Default["postURL"].ToString();
        public string postURL {
            get { return _postURL; }
            set { _postURL = value; }
        }
        //接受第幾間廁所
        private int _toiletID = 0;
        public int toiletID {
            get { return _toiletID; }
            set { _toiletID = value; }
        }
        //command 命令
        private string _command = "none";
        public string command {
            get { return _command ;}
            set { _command = value; }
        }

        

    }
}
