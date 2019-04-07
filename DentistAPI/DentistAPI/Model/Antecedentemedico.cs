using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Antecedentemedico
    {
        public Antecedentemedico()
        {
            Antecentesmedicos = new HashSet<Antecentesmedicos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Antecentesmedicos> Antecentesmedicos { get; set; }
    }
}
