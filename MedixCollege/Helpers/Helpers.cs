using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedixCollege.Helpers
{
    public static class Helpers
    {
        public static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
    }
}
