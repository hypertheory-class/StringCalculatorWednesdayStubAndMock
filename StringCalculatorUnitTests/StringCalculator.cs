using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorUnitTests
{
    public class StringCalculator
    {
        private ILogger _logger;
        private IWebService _webService;

        public StringCalculator(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int Add(string numbers)
        {
           
            var response = numbers == "" ? 0 :
             numbers.Split(',', '\n').Select(int.Parse).Sum();

            try
            {
                _logger.Log(response.ToString());
            }
            catch (LoggerException)
            {

                _webService.Notify("An Error Happened");
            }
            return response;

        }
    }
}
