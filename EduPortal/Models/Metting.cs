using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Metting
    {
        public int MettingId { get; set; }
        public string Link { get; set; }
        public int? SessionId { get; set; }

        public virtual Session Session { get; set; }
    }
}
