using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Chats
    {
        public int ChatsId { get; set; }
        public int? ChatGroupId { get; set; }
        public int? MessageId { get; set; }

        public virtual ChatGroup ChatGroup { get; set; }
    }
}
