using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Material
    {
        public Material()
        {
            StudentsFinishMaterial = new HashSet<StudentsFinishMaterial>();
        }

        public int MaterialId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public DateTime? UploadedAt { get; set; }
        public int? SessionId { get; set; }

        public virtual Session Session { get; set; }
        public virtual ICollection<StudentsFinishMaterial> StudentsFinishMaterial { get; set; }
    }
}
