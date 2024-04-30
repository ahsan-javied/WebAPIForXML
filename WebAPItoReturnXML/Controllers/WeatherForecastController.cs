using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;
using WebAPItoReturnXML.DTO;

namespace WebAPItoReturnXML.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetJsonObj")]
        public async Task<IActionResult> GetJson()
        {
            var rspObj = new PunchOutSetupResponseDTO
            {
                Response = new Response
                {
                    Status = new Status
                    {
                        Code = 200,
                        Text = "success",
                    },
                    PunchOutSetupResponse = new PunchOutSetupResponse
                    {
                        StartPage = new StartPage
                        {
                            URL = "https://www. Supplier.com/Account/myaccount.asp?OverrideSID=123",
                        }
                    },
                }
            };

            return Ok(rspObj);
        }

        [HttpPost]
        [Route("SendXML")]
        public async Task<IActionResult> SendXML([FromBody] XElement xml)
        {
            var mapXMLToObj = XmlParser.FromXElement<PunchoutRequestDTO>(xml);


            string responseXml = @"<?xml version=""1.0""?>
                                    <!DOCTYPE cXML SYSTEM ""http://xml.cxml.org/schemas/cXML/1.1.007/cXML.dtd"">
                                    <cXML xml:lang=""en"" payloadID=""7213656@Supplier.com"" timestamp=""2002-01-01T08:46:00-07:00"">
                                        <Response>
                                            <Status code=""200"" text=""success""/>
                                            <PunchOutSetupResponse>
                                                <StartPage>
                                                    <URL>https://www.Supplier.com/Account/myaccount.asp?OverrideSID=123</URL>
                                                </StartPage>
                                            </PunchOutSetupResponse>
                                        </Response>
                                    </cXML>";

            var rspObj = new PunchOutSetupResponseDTO
            {
                Response = new Response
                {
                    Status = new Status
                    {
                        Code = 200,
                        Text = "success",
                    },
                    PunchOutSetupResponse = new PunchOutSetupResponse
                    {
                        StartPage = new StartPage
                        {
                            URL = "https://www. Supplier.com/Account/myaccount.asp?OverrideSID=123",
                        }
                    },
                }
            };

            var responseObj = XmlParser.Serialize<PunchOutSetupResponseDTO>(rspObj);

            return Content(responseObj.ToString(), "application/xml", System.Text.Encoding.UTF8);
        }
    }
}