using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Consentimiento
    {
        public int ProcedimientoId { get; set; }
        public byte[] HuellaPaciente { get; set; }

        public Procedimiento Procedimiento { get; set; }
    }
}
