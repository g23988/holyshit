using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Collections.Specialized;


namespace testAPI
{
    class SendCommand
    {
        //版本
        string version;
        //廁所id
        int toiletID;
        //目標
        string targetURL;
        public SendCommand(Config info){
            toiletID = info.toiletID;
            targetURL = info.postURL;
            version = info.varsion;
        }

        //占用事件
        public void occupy(){
            string result = createList("occupy");
            if (sendMessage(result)) {
                Console.WriteLine(result+" 成功。");
            }
            else
            {
                Console.WriteLine(result + " 失敗。");
            }
        }

        //釋放事件
        public void release() {
            string result = createList("release");
            if (sendMessage(result))
            {
                Console.WriteLine(result + " 成功。");
            }
            else
            {
                Console.WriteLine(result + " 失敗。");
            }
        }

        //傳送事件給web
        private bool sendMessage(string message) {
            bool success = false;
            try
            {
                WebClient wc = new WebClient();
                NameValueCollection nc = new NameValueCollection();
                nc["jsondata"] = message;
                byte[] result = wc.UploadValues(targetURL,nc);
                string resultBack = Encoding.UTF8.GetString(result);
                //Console.WriteLine(resultBack);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
            return success;
        }



        //創造json
        private string createList(string command)
        {
            List<Toilet> jsonlist = new List<Toilet>();
            switch (command)
            {
                case "occupy":
                    jsonlist.Add(new Toilet { version = version,toiletID = toiletID, occupy = true ,command = "toilet"});
                    break;
                case "release":
                    jsonlist.Add(new Toilet { version = version,toiletID = toiletID, occupy = false, command = "toilet" });
                    break;
                default:
                    break;
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string result = serializer.Serialize(jsonlist);
            return result;
        }
    }
  
}
