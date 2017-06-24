using AppCore.ResultForMethods;
using ELTTurkey.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility.Tools
{
    public class SecurityTools
    {
        public Results MD5Hash(string plainText)
        {
            Results res = new Results();

            try
            {
                // byte array representation of that string
                byte[] encodedPassword = new UTF8Encoding().GetBytes(plainText);

                // need MD5 to calculate the hash
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

                // string representation (similar to UNIX format)
                string encoded = BitConverter.ToString(hash)
                   // without dashes
                   .Replace("-", string.Empty)
                   // make lowercase
                   .ToLower();

                res.ResultType = AppCore.CoreEnum.Result_Type.Success;
                res.ReturnObject = encoded;
            }
            catch (Exception ex)
            {
                res.ResultType = AppCore.CoreEnum.Result_Type.Failed;
                res.Message = ex.Message.ToString();
            }

            return res;
        }

        
    }
}
