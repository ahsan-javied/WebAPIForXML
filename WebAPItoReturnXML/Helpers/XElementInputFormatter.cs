using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebAPItoReturnXML.Helpers
{
    public class XElementInputFormatter : XmlSerializerInputFormatter
    {
        public XElementInputFormatter(MvcOptions options) : base(options)
        {
            SupportedMediaTypes.Add("application/xml");
        }

        protected override bool CanReadType(Type type)
        {
            if (type.IsAssignableFrom(typeof(XElement)))
            {
                return true;
            }

            return base.CanReadType(type);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var xmlDoc = await XDocument.LoadAsync(context.HttpContext.Request.Body, LoadOptions.None, CancellationToken.None);

            return InputFormatterResult.Success(xmlDoc.Root);

        }
    }
}