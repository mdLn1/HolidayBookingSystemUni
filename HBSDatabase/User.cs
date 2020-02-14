//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HBSDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.HolidayRequests = new HashSet<HolidayRequest>();
        }
    
        public int id { get; set; }
        public string Username { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> RemainingDays { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public byte[] Pwd { get; set; }
        public byte[] PwdSalt { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HolidayRequest> HolidayRequests { get; set; }
        public virtual Role Role { get; set; }
    }
}
