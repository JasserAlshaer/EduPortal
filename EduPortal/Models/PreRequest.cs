﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class PreRequest
    {
        public int PreRequestId { get; set; }
        public int? CourseId { get; set; }
        public int? PrevouisCourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Course PrevouisCourse { get; set; }
    }
}
