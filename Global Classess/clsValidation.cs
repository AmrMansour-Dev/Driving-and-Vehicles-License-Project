using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_Classess
{
    public class clsValidation
    {
        public static bool IsValidEmail(string email)
        {
            // Basic email pattern
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsIntegar(string number)
        {
            string pattern = @"^(0|[1-9]\d*)$";

            return Regex.IsMatch(number, pattern);
        }

        public static bool IsFloat(string number)
        {
            string pattern = @"^(0|[1-9]\d*)(\.\d+)?$";

            return Regex.IsMatch(number, pattern);
        }

        public static bool IsNumber(string Number)
        {
            return IsFloat(Number) || IsIntegar(Number);
        }
    }


}
