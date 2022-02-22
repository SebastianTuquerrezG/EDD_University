using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsListaDobleEnlazada<Tipo> : iLista<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private clsNodoDobleEnlazado<Tipo> atrPrimero;
        private clsNodoDobleEnlazado<Tipo> atrUltimo;
        private int atrLongitud;
        private Tipo[] atrItems;
        #endregion

        #region Metodos

        #region Accesores
        public Tipo[] darItems() { return atrItems; }
        public int darLongitud() { return atrLongitud; }
        public clsNodoDobleEnlazado<Tipo> darUltimo() { return atrUltimo; }
        public clsNodoDobleEnlazado<Tipo> darPrimero() { return atrPrimero; }
        #endregion

        #region Mutadores
        public bool ponerItems(Tipo[] prmItems)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CRUDs
        public bool agregar(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public bool contieneA(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public int encontrarA(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public bool extraerEn(int prmIndice, ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public bool insertarEn(int prmIndice, Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public bool modificarEn(int prmIndice, Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public bool recuperarEn(int prmIndice, ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public bool reversar()
        {
            throw new NotImplementedException();
        }
        int iLista<Tipo>.encontrarA(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
