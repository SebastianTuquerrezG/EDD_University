using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo> where Tipo : IComparable
    {
        private clsNodoDobleEnlazado<Tipo> atrAnterior;
        private Tipo atrItem;
        private clsNodoDobleEnlazado<Tipo> atrSiguiente;
    }
}