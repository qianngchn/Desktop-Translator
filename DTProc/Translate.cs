using System;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Globalization;

namespace DTProc
{
    internal class GlobalWebClient : WebClient
    {
        private int timeout;

        public GlobalWebClient(int timeout)
        {
            this.timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.Timeout = timeout;
            request.ReadWriteTimeout = timeout;
            return request;
        }
    }

    public static class Translate
    {
        private struct Translator
        {
            public string Src { get; set; }
            public string Dst { get; set; }
        }

        private struct BaiduResult
        {
            public string Error_code { get; set; }
            public string Error_msg { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public Translator[] Trans_result { get; set; }
        }

        public enum Language
        {
            auto = 0,
            zh = 1,
            en = 2,
            jp = 3,
        }

        private static string GetMD5WithString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return String.Empty;

            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder md5 = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                md5.Append(data[i].ToString("x2"));

            return md5.ToString();
        }

        private static string UrlEncodeUTF8(string str)
        {
            StringBuilder result = new StringBuilder();

            if (!string.IsNullOrEmpty(str))
            {
                byte[] data = Encoding.UTF8.GetBytes(str);

                for (int i = 0; i < data.Length; i++)
                    result.Append(@"%" + data[i].ToString("x2"));
            }

            return result.ToString();
        }

        private static string UnicodeToString(string unicode)
        {
            StringBuilder result = new StringBuilder();

            if (!string.IsNullOrEmpty(unicode))
            {
                string[] data = unicode.Replace("U", "").Replace("u", "").Split('\\');
                for (int i = 1, temp = 0; i < data.Length; i++)
                {
                    if (int.TryParse(data[i], NumberStyles.HexNumber, null, out temp))
                        result.Append((char)temp);
                    else
                        continue;
                }
            }

            return result.ToString();
        }

        private static BaiduResult GetBaiduResultFromJson(string json)
        {
            BaiduResult result = new BaiduResult();
            string name = String.Empty;
            string content = String.Empty;
            StringBuilder transResult = new StringBuilder();

            for (int i = 0; i < json.Length; i++)
            {
                switch(json[i])
                {
                    case '\"':
                        if (json[i - 1] != '\\' && (json[i - 1] == '{' || json[i - 1] == ','))
                        {
                            int start = i + 1;
                            int length = 0;
                            while (json[i + 1] != '\"') { length++; i++; }
                            name = json.Substring(start, length);
                        }
                        if (json[i - 1] != '\\' && json[i - 1] == ':')
                        {
                            int start = i + 1;
                            int length = 0;
                            while (true)
                            {
                                if (json[i + 1] == '\"')
                                    if (json[i] == '\\') { length++; i++; } else break;
                                else
                                {
                                    length++;
                                    i++;
                                }
                            }
                            i++;
                            content = json.Substring(start, length);
                        }
                        break;

                    case '[':
                        if (json[i - 1] == ':')
                        {
                            while (json[i] != '\"') i++;
                            int start = i + 1;
                            int length = 0;
                            while (json[i + 1] != '\"') { length++; i++; }
                            i++;
                            name = json.Substring(start, length);
                        }
                        break;

                    default:
                        break;
                }

                if(!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(content))
                {
                    switch(name)
                    {
                        case "error_code":
                            result.Error_code = content;
                            break;

                        case "error_msg":
                            result.Error_msg = content;
                            break;

                        case "from":
                            result.From = content;
                            break;

                        case "to":
                            result.To = content;
                            break;

                        case "src":
                        case "dst":
                            content = content.Replace("|", "");
                            transResult.Append(@content + @"|");
                            break;

                        default:
                            break;
                    }
                    name = String.Empty;
                    content = String.Empty;
                }
            }
            string[] temp = transResult.ToString().Split('|');
            result.Trans_result = new Translator[temp.Length / 2];
            for (int i = 0; i < temp.Length / 2; i++)
                result.Trans_result[i] = new Translator() { Src = temp[2 * i], Dst = temp[2 * i + 1] };

            return result;
        }

        public static string BaiduTranslate(string src, Language from, Language to, string appid, string password)
        {
            string fromLanguage = from.ToString().ToLower();
            string toLanguage = to.ToString().ToLower();
            string salt = DateTime.Now.Millisecond.ToString();
            string sign = GetMD5WithString(appid + src + salt + password);
            string url = String.Format("http://api.fanyi.baidu.com/api/trans/vip/translate?q={0}&from={1}&to={2}&appid={3}&salt={4}&sign={5}", UrlEncodeUTF8(src), fromLanguage, toLanguage, appid, salt, sign);
            string jsonResult = String.Empty;
            StringBuilder transResult = new StringBuilder();

            GlobalWebClient webClient = new GlobalWebClient(2000);
            try
            {
                jsonResult = webClient.DownloadString(url);
            }
            catch
            {
                transResult.Append("Network is disabled, Please check the network config!");
                return transResult.ToString();
            }
            finally
            {
                webClient.Dispose();
            }

            BaiduResult baiduResult = GetBaiduResultFromJson(jsonResult);
            if (String.IsNullOrEmpty(baiduResult.Error_code))
            {
                for (int i = 0; i < baiduResult.Trans_result.Length; i++)
                {
                    for (int j = 0; j < baiduResult.Trans_result[i].Dst.Length; j++)
                    {
                        if (baiduResult.Trans_result[i].Dst[j] != '\\')
                            transResult.Append(baiduResult.Trans_result[i].Dst[j]);
                        else
                        {
                            if (baiduResult.Trans_result[i].Dst[j + 1] == 'u' || baiduResult.Trans_result[i].Dst[j + 1] == 'U')
                            { transResult.Append(UnicodeToString(@baiduResult.Trans_result[i].Dst.Substring(j, 6))); j += 5; }
                            else
                            { transResult.Append(baiduResult.Trans_result[i].Dst[j + 1]); j++; }
                        }
                    }
                    if (i != baiduResult.Trans_result.Length - 1) transResult.Append("\n");
                }
            }
            else
            {
                transResult.Append("Error_code: " + baiduResult.Error_code + ", Error_msg: " + baiduResult.Error_msg);
            }

            return transResult.ToString();
        }
    }
}
