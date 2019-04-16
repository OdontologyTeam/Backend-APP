using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Antecendentesodontologicos
    {
        public string HistoriaPacienteCedula { get; set; }
        public int AntecedenteOdontologicoId { get; set; }
        public string Observaciones { get; set; }

        public Antecedenteodontologico AntecedenteOdontologico { get; set; }
        public Historia HistoriaPacienteCedulaNavigation { get; set; }
    }
}
