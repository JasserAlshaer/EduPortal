using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class UserChatGroup
    {
        public int UserChatGroupId { get; set; }
        public int? StudentId { get; set; }
        public int? TacherId { get; set; }
        public int ChatGroupId { get; set; }

        public virtual ChatGroup ChatGroup { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Tacher { get; set; }
    }
}
