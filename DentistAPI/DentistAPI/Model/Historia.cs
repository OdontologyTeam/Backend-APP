using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Historia
    {
        public Historia()
        {
            Antecendentesodontologicos = new HashSet<Antecendentesodontologicos>();
            Antecentesmedicos = new HashSet<Antecentesmedicos>();
            Odontograma = new HashSet<Odontograma>();
            Procedimiento = new HashSet<Procedimiento>();
        }

        public string PacienteCedula { get; set; }
        public string MotivoConsulta { get; set; }

        public Paciente PacienteCedulaNavigation { get; set; }
        public ICollection<Antecendentesodontologicos> Antecendentesodontologicos { get; set; }
        public ICollection<Antecentesmedicos> Antecentesmedicos { get; set; }
        public ICollection<Odontograma> Odontograma { get; set; }
        public ICollection<Procedimiento> Procedimiento { get; set; }
    }
}
