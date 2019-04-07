using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Odontograma
    {
        public string HistoriaPacienteCedula { get; set; }
        public string DienteNumeroDiente { get; set; }
        public string Observacion { get; set; }

        public Diente DienteNumeroDienteNavigation { get; set; }
        public Historia HistoriaPacienteCedulaNavigation { get; set; }
    }
}
