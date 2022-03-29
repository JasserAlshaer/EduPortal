using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class StudentsFinishMaterial
    {
        public int StudentsFinishMaterialId { get; set; }
        public int? MaterialId { get; set; }
        public int? StudentId { get; set; }

        public virtual Material Material { get; set; }
        public virtual Student StudentsFinishMaterialNavigation { get; set; }
    }
}
