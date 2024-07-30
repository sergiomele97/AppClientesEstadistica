using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace BackendEstadistica.Utilidades
{
    public static class Extensiones
    {
        public static bool IsValidEmail(this string email)
        {
           
            try
            {
                // Define the regular expression pattern for validating email
                // Allows letters, numbers, dots, hyphens and underscores in the local part
                // Allows letters, numbers, dots in the domain part
                string emailPattern = @"^[a-zA-Z0-9._]+@[a-zA-Z0-9.]+\.[a-zA-Z]{2,5}$";

                // Return true if email is in valid e-mail format
                return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {

            }
            return false;
        }
    }
}
