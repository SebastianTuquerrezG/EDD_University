using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo> : clsNodo<Tipo> where Tipo : IComparable
    {
        private clsNodoDobleEnlazado<Tipo> atrAnterior;
        private clsNodoDobleEnlazado<Tipo> atrSiguiente;

        #region Constructores
        public clsNodoDobleEnlazado() { }
        public clsNodoDobleEnlazado(clsNodoDobleEnlazado<Tipo> prmAnterior, Tipo prmItem, clsNodoDobleEnlazado<Tipo> prmSiguiente)
        {
            enlazar(prmAnterior, prmSiguiente);
            atrItem = prmItem;
        }
        public clsNodoDobleEnlazado(Tipo prmItem)
        {
            atrItem = prmItem;
            atrAnterior = null;
            atrSiguiente = null;
        }
        #endregion

        #region Accesores
        public clsNodoDobleEnlazado<Tipo> darAnterior()
        {
            return atrAnterior;
        }
        public clsNodoDobleEnlazado<Tipo> darSiguiente()
        {
            return atrSiguiente;
        }
        public void conectarSiguiente(clsNodoDobleEnlazado<Tipo> prmNodo)
        {
            atrSiguiente = prmNodo;
        }
        #endregion

        #region Mutadores
        public bool ponerAnterior(clsNodoDobleEnlazado<Tipo> prmNuevoNodo)
        {
            atrAnterior = prmNuevoNodo;
            return true;
        }
        public bool ponerSiguiente(clsNodoDobleEnlazado<Tipo> prmNuevoNodo)
        {
            atrSiguiente = prmNuevoNodo;
            return true;
        }
        public void invertirEnlaces()
        {
            clsNodoDobleEnlazado<Tipo> varTemporal = atrAnterior;
            atrAnterior = atrSiguiente;
            atrSiguiente = varTemporal;
        }
        #endregion

        #region Enlazadores
        public void enlazarSiguiente(clsNodoDobleEnlazado<Tipo> prmSiguiente)
        {
            atrSiguiente = prmSiguiente;
            prmSiguiente.ponerAnterior(this);
        }
        public void enlazarAnterior(clsNodoDobleEnlazado<Tipo> prmAnterior)
        {
            atrAnterior = prmAnterior;
            prmAnterior.ponerSiguiente(this);
        }
        public void enlazar(clsNodoDobleEnlazado<Tipo> prmAnterior, clsNodoDobleEnlazado<Tipo> prmSiguiente)
        {
            enlazarAnterior(prmAnterior);
            enlazarSiguiente(prmSiguiente);
        }
        #endregion Enlazadores
    }
}