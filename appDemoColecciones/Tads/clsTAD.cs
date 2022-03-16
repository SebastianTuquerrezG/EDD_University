using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Tads
{
    public class clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos
        protected int atrLongitud = 0;
        protected Tipo atrItemActual;
        protected int atrIndiceActual;
        protected int atrBorde = int.MaxValue / 64;
        #endregion

        #region Accesores
        public int darLongitud()
        {
            return atrLongitud;
        }
        public virtual Tipo[] darItems() { throw new NotImplementedException(); }
        public int darIndiceActual()
        {
            return atrIndiceActual;
        }
        public Tipo darItemActual()
        {
            return atrItemActual;
        }
        #endregion

        #region Consultores
        public bool esValido(int prmIndice)
        {
            return (prmIndice >= 0 && prmIndice <= atrLongitud - 1);
        }
        public bool estaVacia()
        {
            if (atrLongitud == 0)
                return true;
            return false;

        }
        public bool hayAnterior()
        {
            return (estaVacia() == false && atrIndiceActual > 0);
        }
        public bool haySiguiente()
        {
            return (estaVacia() == false && (atrIndiceActual < atrLongitud - 1));
        }
        #endregion

        #region Mutadores
        public virtual bool ponerItems(Tipo[] prmVector) { throw new NotImplementedException(); }
        #endregion

        #region CRUDs
        public virtual bool contieneA(Tipo prmItem) { throw new NotImplementedException(); }
        public virtual int encontrarA(Tipo prmItem) { throw new NotImplementedException(); }
        protected virtual bool insertar(Tipo prmItem, int prmIndice) { throw new NotImplementedException(); }
        protected virtual bool extraer(ref Tipo prmItem, int prmIndice) { throw new NotImplementedException(); }
        protected virtual bool recuperar(ref Tipo prmItem, int prmIndice) { throw new NotImplementedException(); }
        public virtual bool reversar() { throw new NotImplementedException(); }
        #endregion

        #region posicionadores
        public virtual bool irPrimero()
        {
            return false;
        }
        public virtual bool irUltimo()
        {
            return false;
        }
        public bool irAnterior()
        {
            if (hayAnterior())
            {
                return retrocederItem();
            }
            return false;
        }
        public bool irSiuiente()
        {
            if (haySiguiente())
            {
                return avanzarItem();
            }
            return false;
        }
        public virtual bool irIndice(int prmIndice)
        {
            if (prmIndice == 0) return irPrimero();
            if (prmIndice == atrLongitud - 1) return irUltimo();
            if (esValido(prmIndice))
            {
                irPrimero();
                while (atrIndiceActual < prmIndice)
                    irSiuiente();
                return true;
            }
            return false;
        }
        protected virtual bool avanzarItem()
        {
            return true;
        }
        protected virtual bool retrocederItem()
        {
            return false;
        }
        #endregion
    }
}