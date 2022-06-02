using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Login = new HashSet<Login>();
            Message = new HashSet<Message>();
            Question = new HashSet<Question>();
            Session = new HashSet<Session>();
            ToDoList = new HashSet<ToDoList>();
            UserChatGroup = new HashSet<UserChatGroup>();
        }

        public int TeacherId { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Pio { get; set; }
        public string IsActive { get; set; }
        public int? SpectializationId { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }

        public virtual Spectialization Spectialization { get; set; }
        public virtual ICollection<Login> Login { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<Session> Session { get; set; }
        public virtual ICollection<ToDoList> ToDoList { get; set; }
        public virtual ICollection<UserChatGroup> UserChatGroup { get; set; }
    }
}
