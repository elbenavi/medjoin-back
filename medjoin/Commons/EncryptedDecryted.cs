using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medjoin.Commons
{
    public class EncryptedDecryted
    {
        public static string Key = "abshdkrekdhasdasd12@fds";

        public static string ConvertToEncrypt(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += Key;
            var passworddBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passworddBytes);
        }

        public static string ConvertToDecrypt(string base64EncodedData)
        {
            if (string.IsNullOrEmpty(base64EncodedData)) return "";
            var passworddBytes = Convert.FromBase64String(base64EncodedData);
            var result = Encoding.UTF8.GetString(passworddBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
        }
    }
}
