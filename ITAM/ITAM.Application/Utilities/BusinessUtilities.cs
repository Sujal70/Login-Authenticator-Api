using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LT.Application.Utilities
{
    /// <summary>
    /// extension methods being used across business and api layers
    /// </summary>
    public static class BusinessUtilities
    {
        public static DateTime GetDateForTimeZone(DateTime accountTime, int timeZoneDifference)
        {
            return accountTime.AddSeconds(timeZoneDifference);
        }

        public static string EncryptCorpNo(this object value)
        {
            string encrypcorpNo = value.ToString() + "S" + DateTime.Now.Ticks.ToString();
            StringBuilder encrypcorpNoNew = new(encrypcorpNo.Length);
            for (int i = 0; i < encrypcorpNo.Length; i++)
            {
                encrypcorpNoNew.Append((char)(encrypcorpNo[i] + 32));
            }
            return encrypcorpNoNew.ToString();

        }

        public static bool IsValidEmail(this string emailId)
        {
            try
            {
                var emailAttribute = new EmailAddressAttribute();
                if (emailAttribute.IsValid(emailId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
