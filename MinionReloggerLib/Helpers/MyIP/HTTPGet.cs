using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace MinionReloggerLib.Helpers.MyIP
{
    internal class HTTPGet
    {
        private string _escapedBody;
        private HttpWebRequest _request;
        private HttpWebResponse _response;

        private string _responseBody;
        private double _responseTime;
        private int _statusCode;

        public string ResponseBody
        {
            get { return _responseBody; }
        }

        public string EscapedBody
        {
            get { return GetEscapedBody(); }
        }

        public int StatusCode
        {
            get { return _statusCode; }
        }

        public double ResponseTime
        {
            get { return _responseTime; }
        }

        public string Headers
        {
            get { return GetHeaders(); }
        }

        public string StatusLine
        {
            get { return GetStatusLine(); }
        }


        public void Request(string url)
        {
            var timer = new Stopwatch();
            var respBody = new StringBuilder();

            _request = (HttpWebRequest) WebRequest.Create(url);

            try
            {
                timer.Start();
                _response = (HttpWebResponse) _request.GetResponse();
                var buf = new byte[8192];
                Stream respStream = _response.GetResponseStream();
                int count = 0;
                do
                {
                    count = respStream.Read(buf, 0, buf.Length);
                    if (count != 0)
                        respBody.Append(Encoding.ASCII.GetString(buf, 0, count));
                } while (count > 0);
                timer.Stop();

                _responseBody = respBody.ToString();
                _statusCode = (int) _response.StatusCode;
                _responseTime = timer.ElapsedMilliseconds/1000.0;
            }
            catch (WebException ex)
            {
                _response = (HttpWebResponse) ex.Response;
                _responseBody = "No Server Response";
                _escapedBody = "No Server Response";
                _responseTime = 0.0;
            }
        }


        private string GetEscapedBody()
        {
            string escapedBody = _responseBody;
            escapedBody = escapedBody.Replace("&", "&amp;");
            escapedBody = escapedBody.Replace("<", "&lt;");
            escapedBody = escapedBody.Replace(">", "&gt;");
            escapedBody = escapedBody.Replace("'", "&apos;");
            escapedBody = escapedBody.Replace("\"", "&quot;");
            _escapedBody = escapedBody;

            return escapedBody;
        }


        private string GetHeaders()
        {
            if (_response == null)
                return "No Server Response";
            var headers = new StringBuilder();
            for (int i = 0; i < _response.Headers.Count; ++i)
                headers.Append(String.Format("{0}: {1}\n",
                                             _response.Headers.Keys[i], _response.Headers[i]));

            return headers.ToString();
        }


        private string GetStatusLine()
        {
            if (_response == null)
                return "No Server Response";
            return String.Format("HTTP/{0} {1} {2}", _response.ProtocolVersion,
                                 (int) _response.StatusCode, _response.StatusDescription);
        }
    }
}