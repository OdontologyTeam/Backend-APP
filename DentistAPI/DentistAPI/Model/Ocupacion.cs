using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Ocupacion
    {
        public Ocupacion()
        {
            Paciente = new HashSet<Paciente>();
        }

        public int Id { get; set; }
        public string Ocupacion1 { get; set; }

        public ICollection<Paciente> Paciente { get; set; }
    }
}
