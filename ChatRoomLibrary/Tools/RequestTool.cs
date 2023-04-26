using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ChatRoomLibrary.Models.WS;
using Newtonsoft.Json;

namespace ChatRoomLibrary.Tools
{
    public class RequestTool
    {
        public Reply oReply { get; set; }
        public RequestTool()
        {
            oReply = new Reply();
        }

        public Reply Execute<T>(string url, string method, T oRequest)
        {
            oReply.Result = 0;
            string result = "";

            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = JsonConvert.SerializeObject(oRequest);

                WebRequest request = WebRequest.Create(url);
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8";
                request.Timeout = 60000;

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();

                using (var oStreamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = oStreamReader.ReadToEnd();
                }

                oReply = JsonConvert.DeserializeObject<Reply>(result);
            }
            catch (TimeoutException ex)
            {
                oReply.Message = "Superó el límite de tiempo de espera, intente más tarde";
            }
            catch (Exception ex)
            {
                oReply.Message = "Ocurrió un problema";
            }
            return oReply;
        }
    }
}
