namespace ServiceAccessLayer.Services
{
    using Models.Models;
    using ServiceAccessLayer.Constants;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class SoapServices
    {
        public async Task<Response> Post<T>(string xml,string rootTag)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));

            var response =
                await
                    httpClient.PostAsync(
                    ServiceConstants.UrlTRMService,
                    new StringContent(xml, Encoding.UTF8, "text/xml"));

            if (!response.IsSuccessStatusCode)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = response.StatusCode.ToString(),
                };
            }

            Task<Stream> streamTask = response.Content.ReadAsStreamAsync();
            Stream stream = streamTask.Result;
            var sr = new StreamReader(stream);
            var soapResponse = XDocument.Load(sr);

            var xmlObjectResponse = soapResponse.Descendants(rootTag).FirstOrDefault().ToString();
            var objectResult = DeserializeXmlObject<T>(xmlObjectResponse);
            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
                Result = objectResult
            };
        }

        private T DeserializeXmlObject<T>(string xmlStr)
        {
            var serializer = new XmlSerializer(typeof(T));
            T result;
            using (TextReader reader = new StringReader(xmlStr))
            {
                result = (T)serializer.Deserialize(reader);
            }
            return result;
        }
    }
}
