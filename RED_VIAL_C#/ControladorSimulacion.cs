namespace RED_VIAL_C
{
    using System;
    using System.Collections.Generic;

    public class ControladorSimulacion
    {
        private RedVial red;

        public ControladorSimulacion(RedVial red)
        {
            this.red = red;
        }

        // Cambia el estado del semáforo de cada nodo
        public void ActualizarSemaforos(NodoInterseccion nodo)
        {
            if (nodo == null || !nodo.Info.Semaforo) return;

            switch (nodo.Info.EstadoSemaforo)
            {
                case "Rojo":
                    nodo.Info.EstadoSemaforo = "Verde";
                    break;
                case "Verde":
                    nodo.Info.EstadoSemaforo = "Amarillo";
                    break;
                case "Amarillo":
                    nodo.Info.EstadoSemaforo = "Rojo";
                    break;
            }

            ActualizarSemaforos(nodo.Norte);
            ActualizarSemaforos(nodo.Sur);
            ActualizarSemaforos(nodo.Este);
            ActualizarSemaforos(nodo.Oeste);
        }

        // Mueve vehículos a nodos adyacentes si el semáforo está en verde
        public void MoverVehiculos(NodoInterseccion nodo)
        {
            if (nodo == null) return;

            if (nodo.Info.Semaforo && nodo.Info.EstadoSemaforo == "Verde" && nodo.Info.CantidadVehiculos > 0)
            {
                // Ejemplo: mover hacia el Este si existe
                if (nodo.Este != null)
                {
                    nodo.Info.CantidadVehiculos--;
                    nodo.Este.Info.CantidadVehiculos++;
                }
            }

            MoverVehiculos(nodo.Norte);
            MoverVehiculos(nodo.Sur);
            MoverVehiculos(nodo.Este);
            MoverVehiculos(nodo.Oeste);
        }

        // Detecta nodos con congestión (más vehículos que el umbral)
        public void DetectarCongestion(NodoInterseccion nodo, int umbral)
        {
            if (nodo == null) return;

            if (nodo.Info.CantidadVehiculos >= umbral)
            {
                Console.WriteLine($"⚠ Intersección congestionada en: {nodo.Info.Nombre} ({nodo.Info.CantidadVehiculos} vehículos)");
            }

            DetectarCongestion(nodo.Norte, umbral);
            DetectarCongestion(nodo.Sur, umbral);
            DetectarCongestion(nodo.Este, umbral);
            DetectarCongestion(nodo.Oeste, umbral);
        }

        // Calcula tiempo estimado de un punto a otro usando DFS
        public int CalcularTiempo(NodoInterseccion origen, NodoInterseccion destino)
        {
            HashSet<NodoInterseccion> visitados = new HashSet<NodoInterseccion>();
            return CalcularTiempoRecursivo(origen, destino, visitados);
        }

        private int CalcularTiempoRecursivo(NodoInterseccion actual, NodoInterseccion destino, HashSet<NodoInterseccion> visitados)
        {
            if (actual == null || destino == null || visitados.Contains(actual))
                return int.MaxValue;

            if (actual == destino)
                return actual.Info.TiempoPromedioTransito;

            visitados.Add(actual);

            int tiempoNorte = CalcularTiempoRecursivo(actual.Norte, destino, new HashSet<NodoInterseccion>(visitados));
            int tiempoSur = CalcularTiempoRecursivo(actual.Sur, destino, new HashSet<NodoInterseccion>(visitados));
            int tiempoEste = CalcularTiempoRecursivo(actual.Este, destino, new HashSet<NodoInterseccion>(visitados));
            int tiempoOeste = CalcularTiempoRecursivo(actual.Oeste, destino, new HashSet<NodoInterseccion>(visitados));

            int menorTiempo = Math.Min(Math.Min(tiempoNorte, tiempoSur), Math.Min(tiempoEste, tiempoOeste));

            return (menorTiempo == int.MaxValue) ? int.MaxValue : menorTiempo + actual.Info.TiempoPromedioTransito;
        }
    }
}
