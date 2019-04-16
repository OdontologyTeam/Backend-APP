using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Paciente
    {
        public string Cedula { get; set; }
        public int LugarCedula { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int LugarNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int Ocupacion { get; set; }

        public Lugar LugarCedulaNavigation { get; set; }
        public Lugar LugarNacimientoNavigation { get; set; }
        public Ocupacion OcupacionNavigation { get; set; }
        public Historia Historia { get; set; }
    }
}
