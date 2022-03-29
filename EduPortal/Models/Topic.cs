using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Topic
    {
        public int TopicId { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string SubTitle { get; set; }
        public string ArabicSubTitle { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
