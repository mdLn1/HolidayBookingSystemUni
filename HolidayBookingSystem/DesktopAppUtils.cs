using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HBSDatabase;

namespace HolidayBookingSystem
{
    public static class DesktopAppUtils
    {
        public static void RegisterAdmin()
        {
            using (HBSModel _entity = new HBSModel())
            {
                if (_entity.Users.Any(x => x.Username == GeneralUtils.ADMIN_ROLE))
                    return;
                Role role = new Role()
                {
                    RoleName = GeneralUtils.ADMIN_ROLE
                };
                
                Department department = new Department()
                {
                    DepartmentName = "Management"
                };
                User admin = new User();
                admin.Username = GeneralUtils.ADMIN_ROLE;
                byte[] passwordHash, passwordSalt;
                GeneralUtils.CreatePasswordHash("Test123!", out passwordHash, out passwordSalt);
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

        public static void AddDepartments()
        {
            using(HBSModel entity = new HBSModel())
            {
                if(entity.Departments.Count() <  2)
                {
                    entity.Departments.Add(new Department()
                    {
                        DepartmentName = "Engineering"
                    });
                    entity.Departments.Add(new Department()
                    {
                        DepartmentName = "Plumbing"
                    });
                    entity.Departments.Add(new Department()
                    {
                        DepartmentName = "Roofing"
                    });
                    entity.Departments.Add(new Department()
                    {
                        DepartmentName = "Carpentry"
                    });
                    entity.Departments.Add(new Department()
                    {
                        DepartmentName = "Bricklaying"
                    });
                    entity.Departments.Add(new Department()
                    {
                        DepartmentName = "Office"
                    });
                    entity.SaveChanges();
                }
            }
        }

        public static void AddRoles()
        {
            using (HBSModel _entity = new HBSModel())
            {
                if (_entity.Roles.Count() < 2)
                {
                    _entity.Roles.Add(new Role()
                    {
                        RoleName = "Head"
                    });
                    _entity.Roles.Add(new Role()
                    {
                        RoleName = "Deputy Head"
                    });
                    _entity.Roles.Add(new Role()
                    {
                        RoleName = "Manager"
                    });
                    _entity.Roles.Add(new Role()
                    {
                        RoleName = "Apprentice"
                    });
                    _entity.Roles.Add(new Role()
                    {
                        RoleName = "Senior"
                    });
                    _entity.Roles.Add(new Role()
                    {
                        RoleName = "Junior"
                    });
                    _entity.SaveChanges();
                }
            }
        }

        public static void CreateUsers()
        {
            using (HBSModel _entity = new HBSModel())
            {

                if (_entity.Users.Count() < 2)
                {
                    
                    byte[] passwordHash, passwordSalt;
                    GeneralUtils.CreatePasswordHash("password", out passwordHash, out passwordSalt);
                    _entity.Users.Add(new User()
                    {
                        Username = "madalin",
                        Pwd = passwordHash,
                        PwdSalt = passwordSalt,
                        StartDate = new DateTime(2020, 1, 1),
                        RemainingDays = GeneralUtils.CalculateHolidayAllowanceOnRegistration(new DateTime(2020, 1, 1)),
                        RoleID = 3,
                        DepartmentID = 3
                    });
                    _entity.Users.Add(new User()
                    {
                        Username = "gabriel",
                        Pwd = passwordHash,
                        PwdSalt = passwordSalt,
                        StartDate = new DateTime(2010, 1, 1),
                        RemainingDays = GeneralUtils.CalculateHolidayAllowanceOnRegistration(new DateTime(2010, 1, 1)),
                        RoleID = 4,
                        DepartmentID = 3
                    });
                    _entity.Users.Add(new User()
                    {
                        Username = "alex",
                        Pwd = passwordHash,
                        PwdSalt = passwordSalt,
                        StartDate = new DateTime(2019, 1, 1),
                        RemainingDays = GeneralUtils.CalculateHolidayAllowanceOnRegistration(new DateTime(2019, 1, 1)),
                        RoleID = 6,
                        DepartmentID = 3
                    });
                    _entity.Users.Add(new User()
                    {
                        Username = "chris",
                        Pwd = passwordHash,
                        PwdSalt = passwordSalt,
                        StartDate = new DateTime(2018, 5, 5),
                        RemainingDays = GeneralUtils.CalculateHolidayAllowanceOnRegistration(new DateTime(2018, 5, 5)),
                        RoleID = 7,
                        DepartmentID = 3
                    });
                    _entity.Users.Add(new User()
                    {
                        Username = "bianca",
                        Pwd = passwordHash,
                        PwdSalt = passwordSalt,
                        StartDate = new DateTime(2019, 6, 6),
                        RemainingDays = GeneralUtils.CalculateHolidayAllowanceOnRegistration(new DateTime(2019, 6, 6)),
                        RoleID = 8,
                        DepartmentID = 3
                    });
                    _entity.Users.Add(new User()
                    {
                        Username = "carla",
                        Pwd = passwordHash,
                        PwdSalt = passwordSalt,
                        StartDate = new DateTime(2019, 2, 2),
                        RemainingDays = GeneralUtils.CalculateHolidayAllowanceOnRegistration(new DateTime(2019, 2, 2)),
                        RoleID = 5,
                        DepartmentID = 3
                    });
                    _entity.Users.Add(new User()
                    {
                        Username = "anna",
                        Pwd = passwordHash,
                        PwdSalt = passwordSalt,
                        StartDate = new DateTime(2017, 3, 3),
                        RemainingDays = GeneralUtils.CalculateHolidayAllowanceOnRegistration(new DateTime(2017, 3, 3)),
                        RoleID = 7,
                        DepartmentID = 3
                    });
                    _entity.Users.Add(new User()
                    {
                        Username = "roxanne",
                        Pwd = passwordHash,
                        PwdSalt = passwordSalt,
                        StartDate = new DateTime(2019, 9, 9),
                        RemainingDays = GeneralUtils.CalculateHolidayAllowanceOnRegistration(new DateTime(2019, 9, 9)),
                        RoleID = 6,
                        DepartmentID = 3
                    });
                    _entity.Users.Add(new User()
                    {
                        Username = "kate",
                        Pwd = passwordHash,
                        PwdSalt = passwordSalt,
                        StartDate = new DateTime(2012, 6, 6),
                        RemainingDays = GeneralUtils.CalculateHolidayAllowanceOnRegistration(new DateTime(2012, 6, 6)),
                        RoleID = 5,
                        DepartmentID = 3
                    });

                    _entity.SaveChanges();
                }
            }
        }

        public static void AddHolidayRequests()
        {
            using (HBSModel _entity = new HBSModel())
            {
                if (_entity.HolidayRequests.Count() < 2)
                {
                    _entity.HolidayRequests.Add(new HolidayRequest()
                    {
                        StartDate = new DateTime(2020, 8, 7),
                        EndDate = new DateTime(2020, 8, 21),
                        NumberOfDays = GeneralUtils.CalculateWorkingDays(new DateTime(2020, 8, 7), new DateTime(2020, 8, 21)),
                        RequestStatusID = 1,
                        UserID = 5,
                        ConstraintsBroken = new ConstraintsBroken()
                    });
                    _entity.HolidayRequests.Add(new HolidayRequest()
                    {
                        StartDate = new DateTime(2020, 4, 6),
                        EndDate = new DateTime(2020, 4, 15),
                        NumberOfDays = GeneralUtils.CalculateWorkingDays(new DateTime(2020, 4, 6), new DateTime(2020, 4, 15)),
                        RequestStatusID = 1,
                        UserID = 7,
                        ConstraintsBroken = new ConstraintsBroken()
                    });
                    _entity.HolidayRequests.Add(new HolidayRequest()
                    {
                        StartDate = new DateTime(2020, 8, 7),
                        EndDate = new DateTime(2020, 8, 21),
                        NumberOfDays = GeneralUtils.CalculateWorkingDays(new DateTime(2020, 8, 7), new DateTime(2020, 8, 21)),
                        RequestStatusID = 1,
                        UserID = 8,
                        ConstraintsBroken = new ConstraintsBroken()
                    });
                    _entity.HolidayRequests.Add(new HolidayRequest()
                    {
                        StartDate = new DateTime(2020, 8, 7),
                        EndDate = new DateTime(2020, 8, 21),
                        NumberOfDays = GeneralUtils.CalculateWorkingDays(new DateTime(2020, 8, 7), new DateTime(2020, 8, 21)),
                        RequestStatusID = 1,
                        UserID = 11,
                        ConstraintsBroken = new ConstraintsBroken()
                    });
                    _entity.HolidayRequests.Add(new HolidayRequest()
                    {
                        StartDate = new DateTime(2020, 7, 7),
                        EndDate = new DateTime(2020, 7, 17),
                        NumberOfDays = GeneralUtils.CalculateWorkingDays(new DateTime(2020, 7, 7), new DateTime(2020, 7, 17)),
                        RequestStatusID = 1,
                        UserID = 12,
                        ConstraintsBroken = new ConstraintsBroken()
                    });
                    _entity.HolidayRequests.Add(new HolidayRequest()
                    {
                        StartDate = new DateTime(2020, 8, 2),
                        EndDate = new DateTime(2020, 8, 13),
                        NumberOfDays = GeneralUtils.CalculateWorkingDays(new DateTime(2020, 8, 2), new DateTime(2020, 8, 13)),
                        RequestStatusID = 1,
                        UserID = 13,
                        ConstraintsBroken = new ConstraintsBroken()
                    });
                    _entity.HolidayRequests.Add(new HolidayRequest()
                    {
                        StartDate = new DateTime(2020, 9, 7),
                        EndDate = new DateTime(2020, 9, 11),
                        NumberOfDays = GeneralUtils.CalculateWorkingDays(new DateTime(2020, 9, 7), new DateTime(2020, 9, 11)),
                        RequestStatusID = 1,
                        UserID = 6,
                        ConstraintsBroken = new ConstraintsBroken()
                    });
                    _entity.HolidayRequests.Add(new HolidayRequest()
                    {
                        StartDate = new DateTime(2020, 10, 12),
                        EndDate = new DateTime(2020, 10, 21),
                        NumberOfDays = GeneralUtils.CalculateWorkingDays(new DateTime(2020, 10, 12), new DateTime(2020, 10, 21)),
                        RequestStatusID = 1,
                        UserID = 9,
                        ConstraintsBroken = new ConstraintsBroken()
                    });
                    _entity.SaveChanges();
                }
            }
        }


        public static void AddPeakTimes()
        {
            using (HBSModel _entity = new HBSModel())
            {
                if(_entity.PeakTimes.Count() == 0)
                {
                    _entity.PeakTimes.Add(new PeakTime()
                    {
                        StartDate = new DateTime(2020, 12, 23),
                        EndDate = new DateTime(2021, 1, 3),
                        NoConstraintsApply = true
                    });
                    _entity.PeakTimes.Add(new PeakTime()
                    {
                        StartDate = new DateTime(2020, 7, 15),
                        EndDate = new DateTime(2020, 8, 31),
                        NoConstraintsApply = false
                    });
                    _entity.PeakTimes.Add(new PeakTime()
                    {
                        StartDate = new DateTime(2020, 12, 15),
                        EndDate = new DateTime(2020, 12, 23),
                        NoConstraintsApply = false
                    });
                    _entity.SaveChanges();
                }
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
                    GeneralUtils.CreatePasswordHash("password", out passwordHash, out passwordSalt);
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

        public static void popDefaultErrorMessageBox(String message)
        {
            MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
