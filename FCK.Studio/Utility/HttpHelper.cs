using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace FCK.Studio.Utility
{
    public class HttpHelper
    {
        private Encoding code { get; set; }
        public HttpHelper(Encoding _code)
        {
            code = _code;
        }
        /// <summary>
        /// HttpClient Post方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="requestJson"></param>
        /// <returns></returns>
        public string Post(string url, string requestJson)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpContent httpContent = new StringContent(requestJson);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                HttpResponseMessage response = httpClient.PostAsync(url, httpContent).Result;
                String result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
        /// <summary>
        /// HttpClient Get方法
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string Get(string url)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                String result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }


        public string HttpWebPost(string apiurl, SortedDictionary<string, string> sParaTemp)
        {
            string strRequestData = BuildRequestParaToString(sParaTemp, code);
            byte[] bytesRequestData = code.GetBytes(strRequestData);
            string strUrl = apiurl;
            string strResult = "";
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                myReq.Method = "post";
                myReq.ContentType = "application/x-www-form-urlencoded";
                myReq.ContentLength = bytesRequestData.Length;
                Stream requestStream = myReq.GetRequestStream();
                requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
                requestStream.Close();
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader reader = new StreamReader(myStream, code);
                StringBuilder responseData = new StringBuilder();
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    responseData.Append(line);
                }
                myStream.Close();
                strResult = responseData.ToString();
            }
            catch (Exception exp)
            {
                strResult = exp.Message;
            }

            return strResult;
        }

        public string HttpWebGet(string apiurl)
        {
            StringBuilder rStr = new StringBuilder();
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            StreamReader streamReader = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(apiurl);
                request.Method = "GET";
                request.Timeout = 500;
                response = (HttpWebResponse)request.GetResponse();
                streamReader = new StreamReader(response.GetResponseStream());
                rStr.Append(streamReader.ReadToEnd());
                streamReader.Close();
            }
            catch { }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return rStr.ToString();
        }

        public string BuildRequestParaToString(SortedDictionary<string, string> dicArray, Encoding code)
        {
            StringBuilder prestr = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in dicArray)
            {
                prestr.Append(temp.Key + "=" + WebUtility.UrlEncode(temp.Value) + "&");
            }
            int nLen = prestr.Length;
            prestr.Remove(nLen - 1, 1);
            return prestr.ToString();
        }
    }
}
