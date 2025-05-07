namespace RED_VIAL_C
{
    public class RedVial
    {
        public NodoInterseccion NodoCentral { get; set; }

        public RedVial()
        {
            NodoCentral = null;
        }

        public void CrearNodoCentral(InformacionNodo info)
        {
            NodoCentral = new NodoInterseccion(info);
        }

        public NodoInterseccion AgregarNodo(NodoInterseccion origen, string direccion, InformacionNodo info)
        {
            NodoInterseccion nuevo = new NodoInterseccion(info);

            switch (direccion.ToLower())
            {
                case "norte":
                    origen.Norte = nuevo;
                    nuevo.Sur = origen;
                    break;
                case "sur":
                    origen.Sur = nuevo;
                    nuevo.Norte = origen;
                    break;
                case "este":
                    origen.Este = nuevo;
                    nuevo.Oeste = origen;
                    break;
                case "oeste":
                    origen.Oeste = nuevo;
                    nuevo.Este = origen;
                    break;
            }

            return nuevo;
        }
    }
}
