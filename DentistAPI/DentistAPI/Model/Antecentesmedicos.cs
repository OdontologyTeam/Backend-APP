using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Antecentesmedicos
    {
        public string HistoriaPacienteCedula { get; set; }
        public int AntecedenteMedicoId { get; set; }
        public string Observaciones { get; set; }

        public Antecedentemedico AntecedenteMedico { get; set; }
        public Historia HistoriaPacienteCedulaNavigation { get; set; }
    }
}
