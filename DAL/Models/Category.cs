﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryUsers = new HashSet<CategoryUser>();
            Publications = new HashSet<Publication>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string BigPicture { get; set; }
        public string SmallPicture { get; set; }

        public virtual ICollection<CategoryUser> CategoryUsers { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
