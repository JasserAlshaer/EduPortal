using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Message
    {
        public Message()
        {
            Chats = new HashSet<Chats>();
        }

        public int MessageId { get; set; }
        public int StudentId { get; set; }
        public int? TeacherId { get; set; }
        public string Text { get; set; }
        public string AttachedImage { get; set; }
        public string AttachedVideo { get; set; }
        public string AttachedFile { get; set; }
        public DateTime? MassageDate { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Chats> Chats { get; set; }
    }
}
