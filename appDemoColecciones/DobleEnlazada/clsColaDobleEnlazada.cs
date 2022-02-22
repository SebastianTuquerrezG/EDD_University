using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsColaDobleEnlazada<Tipo> : iCola<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private int atrLongitud;
        private Tipo[] atrItems;
        private clsNodoEnlazado<Tipo> atrPrimero;
        private clsNodoEnlazado<Tipo> atrUltimo;
        #endregion

        #region Metodos

        #region Accesores
        public Tipo[] darItems() { return atrItems; }
        public int darLongitud() { return atrLongitud; }
        public object darPrimero() { return atrPrimero; }
        public object darUltimo() { return atrUltimo; }
        #endregion

        #region Mutadores
        public bool ponerItems(Tipo[] prmItems)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CRUDs
        public bool encolar(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public bool desencolar(ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public bool revisar(ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public bool reversar()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}



