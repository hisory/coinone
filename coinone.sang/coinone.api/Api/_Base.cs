using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace coinone.api.Api
{
    public class _Base
    {

        /// <summary>
        /// api 기본 경로.
        /// </summary>
        private const string _c_s_api_url = "https://api.coinone.co.kr";


        public enum web_method { POST, GET, PUT, DELETE }


 
        /// <summary>
        /// api jspon 결과값을 가져오기
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public string Get_Sync_Api(string url, string data, web_method method)
        {
            try
            {
                url = url.Trim();
                url = _c_s_api_url + (url.StartsWith("/") ? "" : "/") + url;

                byte[] postData = Encoding.Default.GetBytes(data.ToString());

                switch (method)
                {
                    case web_method.GET:
                        url = url + (url.EndsWith("?") || data.StartsWith("?") ? "" : "?") + data + "&timestamp=" + System.DateTime.Now.ToFileTimeUtc().ToString();
                        break;
                }


                System.Text.StringBuilder sb_data = new StringBuilder();
                System.Text.StringBuilder sb_result = new StringBuilder();


                System.Net.HttpWebRequest wrq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                wrq.ContentType = "application/json";
                wrq.Method = method.ToString();


                if (method != web_method.GET)
                {
                    wrq.ContentLength = postData.Length;
                    System.IO.Stream newStream = wrq.GetRequestStream();
                    newStream.Write(postData, 0, postData.Length);
                    newStream.Close();
                }

                System.Net.HttpWebResponse wrs = (System.Net.HttpWebResponse)wrq.GetResponse();
                System.IO.Stream strm = wrs.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(strm, Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sb_result.Append(line);
                }

                sr.Close();
                strm.Close();
                wrs.Close();

                return sb_result.ToString();
            }
            catch (Exception ex)
            {
                string sRtn = @"{'timestamp':'{timestamp}','errorCode':'999999','result':'fail'}";

                sRtn = sRtn.Replace("{timestamp}",System.DateTime.Now.ToFileTimeUtc().ToString());
                return sRtn;
            }
        }


        /// <summary>
        /// 기본적인 Json 양식 체크하기
        /// </summary>
        /// <param name="sJson"></param>
        /// <returns></returns>
        public bool IsJsonValidation(string sJson)
        {
            sJson = sJson.Trim();

            if (!sJson.StartsWith("{") || !sJson.EndsWith("}"))
            {
                return false;
            }

            if (!sJson.Contains("timestamp") || !sJson.Contains("errorCode") || !sJson.Contains("result"))
            {
                return false;
            }

            return true;
        
        }

    }
}
