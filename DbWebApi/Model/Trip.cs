using System;
using System.Collections.Generic;

namespace DbWebApi.Model
{
    public partial class Trip
    {
        public int Id { get; set; }
        public string Manager { get; set; } = null!;
        public string LoadCrm { get; set; } = null!;
        public string Docs { get; set; } = null!;
        public string ReadySort { get; set; } = null!;
        public DateTime DateTrip { get; set; }
        public int? EmployesId { get; set; }

        public virtual Employe? Employes { get; set; }
    }
}
