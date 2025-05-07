namespace RED_VIAL_C
{
    public class NodoInterseccion
    {
        public InformacionNodo Info { get; set; }
        public NodoInterseccion Norte { get; set; }
        public NodoInterseccion Sur { get; set; }
        public NodoInterseccion Este { get; set; }
        public NodoInterseccion Oeste { get; set; }

        public NodoInterseccion(InformacionNodo info)
        {
            Info = info;
        }
    }
}
