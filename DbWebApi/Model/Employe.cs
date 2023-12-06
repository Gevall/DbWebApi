using System;
using System.Collections.Generic;

namespace DbWebApi.Model
{
    public partial class Employe
    {
        public Employe()
        {
            Trips = new HashSet<Trip>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;

        public virtual ICollection<Trip> Trips { get; set; }
    }
}
