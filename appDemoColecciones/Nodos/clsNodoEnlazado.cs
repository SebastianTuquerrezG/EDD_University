using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoEnlazado<Tipo> : clsNodo<Tipo> where Tipo : IComparable
    {
        private clsNodoEnlazado<Tipo> atrSiguiente;

        #region Constructores
        public clsNodoEnlazado() { }
        public clsNodoEnlazado(Tipo prmItem)
        {
            atrItem = prmItem;
        }
        public clsNodoEnlazado(Tipo prmItem, clsNodoEnlazado<Tipo> prmSiguiente)
        {
            atrItem = prmItem;
            atrSiguiente = prmSiguiente;
        }
        public clsNodoEnlazado(clsNodoEnlazado<Tipo> prmAnterior, Tipo prmItem, clsNodoEnlazado<Tipo> prmSiguiente)
        {
            atrItem = prmItem;
            atrSiguiente = prmSiguiente;
            prmAnterior.ponerSiguiente(this);
        }
        #endregion 

        #region Accesores
        public clsNodoEnlazado<Tipo> darSiguiente()
        {
            return atrSiguiente;
        }
        #endregion

        #region Conectores
        public void conectarSiguiente(clsNodoEnlazado<Tipo> prmNodo)
        {
            atrSiguiente = prmNodo;
        }
        #endregion

        #region Mutadores
        public bool ponerSiguiente(clsNodoEnlazado<Tipo> prmSiguiente)
        {
            atrSiguiente = prmSiguiente;
            return true;
        }
        #endregion
    }
}