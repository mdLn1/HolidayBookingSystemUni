using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayBookingSystem
{
    public class Utils
    {
        public void RegisterAdmin()
        {
            using (HBSModel _entity = new HBSModel())
            {
                User admin = new User();
                admin.Username = "admin";
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("Test123!", out passwordHash, out passwordSalt);
                admin.Pwd = passwordHash;
                admin.PwdSalt = passwordSalt;
                _entity.Users.Add(admin);
                _entity.SaveChanges();
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
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

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hashgen = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hashgen.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordSalt = hashgen.Key;
            }

        }

    }
}
