using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Net;

namespace CroakTranslator
{
    class Client
    {
        public static string APP_ID = "";
        public static string KEY = "";
        public static string DES = "0";
        public static void GetSetting()
        {
            if (File.Exists(@"config.ini"))
            {
                string[] strs = File.ReadAllLines(@"config.ini");
                if (strs.Length > 2)
                {
                    APP_ID = strs[0];
                    KEY = strs[1];
                    DES = strs[2];
                }
                else  SaveSetting(); 
            }else SaveSetting();

        }

        public static void SaveSetting()
        {
            File.WriteAllText(@"config.ini", APP_ID + "\r\n" + KEY + "\r\n" + DES);
        }

        public static Image TransLate(Image image, string from,string to ,out string res)
        {
            var salt = new Random().Next(10000000, 99999999).ToString();
            string temp;
            image.Save("temp.jpg");
            string tempSign = GetMd5Hash(APP_ID + GetMd5Hash(File.ReadAllBytes("temp.jpg")).ToLower() + salt + "APICUID" + "mac" + KEY);
            try
            {
                Console.WriteLine(new List<string>(language.Keys)[int.Parse(DES)]);
                temp = Client.PostWithImage("https://fanyi-api.baidu.com/api/trans/sdk/picture",
                new Dictionary<string, string> {
                            { "from",from},
                            { "to",to},
                            { "appid",APP_ID},
                            { "salt",salt},
                            { "cuid","APICUID"},
                            { "mac","mac"},
                            { "version","3"},
                            { "paste","1" },
                            { "sign",tempSign},
                }, image);
            }
            catch { res = ""; return null; }
            Image img = ResultProcess(temp, out string r);
            res = r;
            return img;
        }

        public static string PostWithImage(string url, Dictionary<string, string> dic, Image image)
        {
            string result = "";
            StringBuilder builder = new StringBuilder();
            builder.Append(url);
            if (dic.Count > 0)
            {
                builder.Append("?");
                int i = 0;
                foreach (var item in dic)
                {
                    if (i > 0)
                        builder.Append("&");
                    builder.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
            }

            StringBuilder sb = new StringBuilder();
            string boundary = "----------" + DateTime.Now.Ticks.ToString("x");
            sb.Append("--" + boundary);
            sb.Append("\r\n");
            sb.Append("Content-Disposition: form-data; name=\"image\"; filename=\"temp.jpg" + "\"");
            sb.Append("\r\n");
            sb.Append("Content-Type: application/octet-stream");
            sb.Append("\r\n");
            sb.Append("\r\n");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(builder.ToString());
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";

            FileStream fileStream = new FileStream(@"temp.jpg", FileMode.OpenOrCreate, FileAccess.Read);
            byte[] postHeaderBytes = Encoding.UTF8.GetBytes(sb.ToString());
            byte[] boundaryBytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            request.ContentLength = postHeaderBytes.Length + fileStream.Length + boundaryBytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(postHeaderBytes, 0, postHeaderBytes.Length);
            byte[] buffer = new byte[checked((uint)Math.Min(4096, (int)fileStream.Length))];
            int bytesRead;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                requestStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Dispose();
            requestStream.Write(boundaryBytes, 0, boundaryBytes.Length);

            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
            Stream stream = resp.GetResponseStream();
            try
            {
                using StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
            }
            finally
            {
                stream.Close();
            }
            return result;
        }

        public static string GetMd5Hash(String input)
        {
            if (input == null) { return null; }
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();

        }

        public static string GetMd5Hash(byte[] input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(input);
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }

        private static Image ResultProcess(string result, out string res)
        {
            try
            {
                JObject o = JObject.Parse(result);
                res = (string)o["error_code"];
                if (o.TryGetValue("data", out JToken data))
                {
                    JObject obj = (JObject)o["data"];
                    if (obj.TryGetValue("content", out JToken img))
                    {
                        string tmp = (string)o["data"]["pasteImg"];
                        byte[] arr2 = Convert.FromBase64String(tmp);
                        MemoryStream ms2 = new MemoryStream(arr2);
                        return Image.FromStream(ms2);
                    }
                }
                return null;
            }
            catch { }
            res = "";
            return null;
        }

        public static Dictionary<string, string> language = new Dictionary<string, string>() {
            { "中文"    , "zh" },
            { "英语"    , "en"  },
            { "日语"    , "jp"  },
            { "韩语"    , "kor"  },
            { "法语"    , "fra"  },
            { "西班牙语", "spa"  },
            { "俄语"    , "ru"  },
            { "葡萄牙语", "pt"  },
            { "德语"    , "de"  },
            { "意大利语", "it"  },
            { "丹麦语"  , "dan"  },
            { "荷兰语"  , "nl"  },
            { "马来语 " , "may"  },
            { "瑞典语"  , "swe"  },
            { "印尼语"  , "id"  },
            { "波兰语"  , "pl"  },
            { "罗马尼亚语", "rom"  },
            { "土耳其语", "tr"  },
            { "希腊语"  , "el"  },
            { "匈牙利语", "hu"  }
        };
    }
}
