using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Authentication.Verifycation
{
    public class PhoneNumberManager
    {
        /// <summary>
        /// Verifies whether phone number is in the correct format. Approve nulls.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>Returns true if valid, false otherwise.</returns>
        public static bool VerifyPhoneNumber(string? phoneNumber)
        {
            if(phoneNumber == null) 
                return true;

            char[] charArray = phoneNumber.ToCharArray();

            if(charArray.Length < 4 && charArray.Length > 12)
            {
                return false;
            }

            for(int i = 0; i < charArray.Length; i++)
            {
                if (!char.IsDigit(charArray[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
