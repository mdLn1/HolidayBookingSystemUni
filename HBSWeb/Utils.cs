using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HBSWeb
{
    public class Utils
    {
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }

                return true;
            }
        }
        public static string genAlert(string type, string msg)
        {
            string returnMsg = "<div='container'><div class='" + type + " alert-danger' role='alert'>" + msg + "</ div ></div>";
            return returnMsg;
        }
    }
}