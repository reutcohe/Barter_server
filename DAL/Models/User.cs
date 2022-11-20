using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class User
    {
        public User()
        {
            CategoryUsers = new HashSet<CategoryUser>();
            Opinions = new HashSet<Opinion>();
            Publications = new HashSet<Publication>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? CityId { get; set; }
        public int AllowingAccess { get; set; }

        public virtual City City { get; set; }
        public virtual Massage Id1 { get; set; }
        public virtual Star Id2 { get; set; }
        public virtual CustomerInquiry IdNavigation { get; set; }
        public virtual ICollection<CategoryUser> CategoryUsers { get; set; }
        public virtual ICollection<Opinion> Opinions { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
