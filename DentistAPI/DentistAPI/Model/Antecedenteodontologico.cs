using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Antecedenteodontologico
    {
        public Antecedenteodontologico()
        {
            Antecendentesodontologicos = new HashSet<Antecendentesodontologicos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Antecendentesodontologicos> Antecendentesodontologicos { get; set; }
    }
}
