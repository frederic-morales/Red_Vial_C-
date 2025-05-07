namespace RED_VIAL_C
{
    public class InformacionNodo
    {
        public int CantidadVehiculos { get; set; }
        public string TipoViaNorte { get; set; }
        public string TipoViaSur { get; set; }
        public string TipoViaEste { get; set; }
        public string TipoViaOeste { get; set; }
        public bool Semaforo { get; set; }
        public string EstadoSemaforo { get; set; }  // "Rojo", "Verde", etc.
        public int TiempoPromedioTransito { get; set; }
        public string Nombre { get; set; }

        public InformacionNodo()
        {
            EstadoSemaforo = "Rojo";
        }
    }
}
