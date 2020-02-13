using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HBSDatabase;

namespace HolidayBookingSystem
{
    public static class Utils
    {
        public static String ADMIN_ROLE = "admin";
        public static void RegisterAdmin()
        {
            using (HBSModel _entity = new HBSModel())
            {
                if (_entity.Users.Any(x => x.Username == ADMIN_ROLE))
                    return;
                Role role = new Role()
                {
                    RoleName = ADMIN_ROLE
                };
                
                Department department = new Department()
                {
                    DepartmentName = "Management"
                };
                User admin = new User();
                admin.Username = ADMIN_ROLE;
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("Test123!", out passwordHash, out passwordSalt);
                admin.Pwd = passwordHash;
                admin.PwdSalt = passwordSalt;
                admin.RoleID = role.ID;
                admin.DepartmentID = department.ID;
                _entity.Users.Add(admin);

                role.Users.Add(admin);
                department.Users.Add(admin);
                _entity.Roles.Add(role);
                _entity.Departments.Add(department);

                _entity.SaveChanges();
            }
        }

        public static void RegisterUsers()
        {
            using (HBSModel _entity = new HBSModel())
            {
                Role role = new Role()
                {
                    RoleName = "junior"
                };

                Department department = new Department()
                {
                    DepartmentName = "Construction"
                };
                List<string> users = new List<String>();
                users.Add("madalin");
                users.Add("cristian");
                users.Add("gabriel");
                foreach(string username in users)
                {
                    User newUser = new User();
                    newUser.Username = username;
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);
                    newUser.Pwd = passwordHash;
                    newUser.PwdSalt = passwordSalt;
                    newUser.StartDate = DateTime.Now.Date;
                    newUser.RoleID = role.ID;
                    newUser.DepartmentID = department.ID;
                    _entity.Users.Add(newUser);

                    role.Users.Add(newUser);
                    department.Users.Add(newUser);
                }
                
                _entity.Roles.Add(role);
                _entity.Departments.Add(department);

                _entity.SaveChanges();
            }
        }

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

        public static void popDefaultErrorMessageBox(String message)
        {
            MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hashgen = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hashgen.ComputeHash(Encoding.UTF8.GetBytes(password));
                passwordSalt = hashgen.Key;
            }

        }

    }
}
