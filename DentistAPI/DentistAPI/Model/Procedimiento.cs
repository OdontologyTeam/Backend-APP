using System;
using System.Collections.Generic;

namespace DentistAPI.Model
{
    public partial class Procedimiento
    {
        public int Id { get; set; }
        public string HistoriaPacienteCedula { get; set; }
        public string RealizadoPorUsuarioCedula { get; set; }
        public string DienteNumeroDiente { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public string DiagnosticoInicial { get; set; }
        public string RxInicial { get; set; }
        public string PruebasSensibilidad { get; set; }
        public string DiagnosticoFinal { get; set; }
        public string Pronostico { get; set; }
        public string TecnicaAnestesica { get; set; }
        public string Carpul { get; set; }
        public string TipoAnestesia { get; set; }
        public string TipoAislamiento { get; set; }
        public string AperturaCameral { get; set; }
        public string LongitudTrabajo { get; set; }
        public string SistemaLimas { get; set; }
        public string Descripcion { get; set; }
        public string Irrigacion { get; set; }
        public string SecadoConducto { get; set; }
        public string TecnicaObturacion { get; set; }
        public string ConoPrincipal { get; set; }
        public string Accesorios { get; set; }
        public string CementoEndodontico { get; set; }
        public string ObturacionBase { get; set; }
        public string ObturacionTemporal { get; set; }
        public string ComplicacionesRecomendaciones { get; set; }

        public Diente DienteNumeroDienteNavigation { get; set; }
        public Historia HistoriaPacienteCedulaNavigation { get; set; }
        public Usuario RealizadoPorUsuarioCedulaNavigation { get; set; }
        public Consentimiento Consentimiento { get; set; }
    }
}
