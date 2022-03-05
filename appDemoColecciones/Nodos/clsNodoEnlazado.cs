using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoEnlazado<Tipo> where Tipo : IComparable
    {
        private Tipo atrItem;
        private clsNodoEnlazado<Tipo> atrSiguiente = null;

        public bool ponerSiguiente(clsNodoEnlazado<Tipo> prmNuevoNodo)
        {
            atrSiguiente = prmNuevoNodo;
            return true;
        }

        public clsNodoEnlazado()
        {
        }
        public clsNodoEnlazado(Tipo prmItem, clsNodoEnlazado<Tipo> prmSiguiente)
        {
            atrItem = prmItem;
            atrSiguiente = prmSiguiente;
        }
        public clsNodoEnlazado(Tipo prmItem)
        {
            atrItem = prmItem;
        }
        public clsNodoEnlazado(Tipo prmItem, clsNodoEnlazado<Tipo> prmAnterior, clsNodoEnlazado<Tipo> prmSiguiente)
        {
            atrItem = prmItem;
            atrSiguiente = prmSiguiente;
            prmSiguiente.ponerSiguiente(this);
        }

        #region
        public Tipo darItem()
        {
            return atrItem;
        }
        public clsNodoEnlazado<Tipo> darclsNodoEnlazado()
        {
            return atrSiguiente;
        }
        public void ModificarItem(Tipo atrItem)
        {
            this.atrItem = atrItem;
        }
        public void ModificarNodoEnlazado(clsNodoEnlazado<Tipo> nodoEnlazado)
        {
            this.atrSiguiente = nodoEnlazado;
        }
        #endregion
    }
}