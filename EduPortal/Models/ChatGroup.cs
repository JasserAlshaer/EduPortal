using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class ChatGroup
    {
        public ChatGroup()
        {
            Chats = new HashSet<Chats>();
            UserChatGroup = new HashSet<UserChatGroup>();
        }

        public int ChatGroupId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastActive { get; set; }
        public string LastMassage { get; set; }
        public int? SessionId { get; set; }

        public virtual Session Session { get; set; }
        public virtual ICollection<Chats> Chats { get; set; }
        public virtual ICollection<UserChatGroup> UserChatGroup { get; set; }
    }
}
