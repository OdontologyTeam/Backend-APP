using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Diente
    {
        public Diente()
        {
            Odontograma = new HashSet<Odontograma>();
            Procedimiento = new HashSet<Procedimiento>();
        }

        public string NumeroDiente { get; set; }

        public ICollection<Odontograma> Odontograma { get; set; }
        public ICollection<Procedimiento> Procedimiento { get; set; }
    }
}
