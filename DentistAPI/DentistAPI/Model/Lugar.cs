using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Lugar
    {
        public Lugar()
        {
            PacienteLugarCedulaNavigation = new HashSet<Paciente>();
            PacienteLugarNacimientoNavigation = new HashSet<Paciente>();
        }

        public int Id { get; set; }
        public string Lugar1 { get; set; }

        public ICollection<Paciente> PacienteLugarCedulaNavigation { get; set; }
        public ICollection<Paciente> PacienteLugarNacimientoNavigation { get; set; }
    }
}
