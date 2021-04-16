using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hors;

namespace parser_dates.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParserDateController : ControllerBase
    {
        private readonly ILogger<ParserDateController> _logger;

        public ParserDateController(ILogger<ParserDateController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ParserDate Post(Request request)
        {
            var parser = new HorsTextParser();
            var result = parser.Parse(request.Text, DateTime.Now);
            var text = result.Text;
            //var formatText = result.TextWithTokens;
            ParserDate ret;
            if (result.Dates != null && result.Dates.Count > 0)
            {
                var date = result.Dates[0].DateFrom;
                ret = new ParserDate
                {
                    ParsingDate = date.ToString(),
                    OtherText = text
                };
            }
            else
            {
                ret = new ParserDate
                {
                    ParsingDate = "",
                    OtherText = request.Text
                };
            }
            
            return ret;
        }
    }
}
