namespace ServiceAccessLayer.Services
{
    using ServiceAccessLayer.Interfaces;
    using Models.Models;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System;

    public class TCRMServices : ITCRMServices
    {
        #region Attributes
        private SoapServices soapServices;
        #endregion

        #region Constructors
        public TCRMServices()
        {
            this.soapServices = new SoapServices();
        }
        #endregion

        #region Private Methods
        private XDocument GenerateXmlRequestQueryTCRM(DateTime date)
        {
            XNamespace soapEnv = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace soapActionPage = "http://action.trm.services.generic.action.superfinanciera.nexura.sc.com.co/";
            XNamespace soapActionMeethod = "queryTCRM";
            XDocument soapRequest = new XDocument(
                    new XElement(soapEnv + "Envelope",
                        new XAttribute(XNamespace.Xmlns + "soap", soapEnv),
                        new XAttribute(XNamespace.Xmlns + "act", soapActionPage),
                        new XElement(soapEnv + "Body",
                            new XElement(soapActionPage + "queryTCRM",
                                new XElement("tcrmQueryAssociatedDate", date.ToString("yyyy-MM-dd"))
                            )
                        )
                    )
                );
            return soapRequest;
        }
        #endregion

        #region Interface Methods

        public async Task<Response> GetCurrentTRM(DateTime date)
        {
            string request = GenerateXmlRequestQueryTCRM(date).ToString();
            Response response = await soapServices.Post<TCRM>(request, "return");

            return response;
        }
        #endregion

    }
}
