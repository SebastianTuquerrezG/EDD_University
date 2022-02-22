using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoEnlazado<Tipo> where Tipo : IComparable
    {
        private Tipo atrItem;
        private clsNodoEnlazado<Tipo> atrSiguiente;
    }
}