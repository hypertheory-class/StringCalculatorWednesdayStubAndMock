using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorUnitTests
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
          if(numbers == "") { return 0; }
            return numbers.Split(',', '\n').Select(int.Parse).Sum();
        }
    }
}
