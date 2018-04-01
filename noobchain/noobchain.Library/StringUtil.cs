using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace noobchain.Library
{
    public class StringUtil
    {
        //Applies Sha256 to a string and returns the result. 
        public static String applySha256(String input)
        {
            try
            {
                SHA256Managed digest = new SHA256Managed();

                //Applies sha256 to our input,
                byte[] hash = digest.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder hexString = new StringBuilder(); // This will contain hash as hexidecimal

                for (int i = 0; i < hash.Length; i++)
                {
                    hexString.Append(String.Format("{0:x2}", hash[i])); // Compute SHA256 Hash in Android/Java and C#: https://code.i-harness.com/en/q/936a50;
                }

                return hexString.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
