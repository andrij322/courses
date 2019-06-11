using System;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace cat_finder
{
    /// <summary>
    /// class for work with WebRequest & WebResponse
    /// </summary>
    public class Connector
    {
        private string requestStr;
        public string RequestStr {
            get { return requestStr; }
            set { requestStr = value; }
        }


        public Connector(string requestStr)
        {
            this.requestStr = requestStr;
        }


        /// <summary>
        /// Response on request
        /// </summary>
        /// <returns>Response string in JSON format</returns>
        public string getResponse()
        {
            try
            {
                string result;
                WebRequest request = WebRequest.Create(requestStr);
                WebResponse response = request.GetResponse();
                using (Stream streamResponse = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(streamResponse))
                    {
                        result = sr.ReadToEnd();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
