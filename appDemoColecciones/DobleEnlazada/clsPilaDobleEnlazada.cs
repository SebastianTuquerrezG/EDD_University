using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsPilaDobleEnlazada<Tipo> : iPila<Tipo> where Tipo : IComparable
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
        public clsNodoDobleEnlazado<Tipo> darPrimero() { return atrPrimero; }
        public clsNodoDobleEnlazado<Tipo> darUltimo() { return atrUltimo; }
        #endregion

        #region Mutadores
        public bool ponerItems(Tipo[] prmItems)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CRUDs
        public bool apilar(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        public bool desapilar(ref Tipo prmItem)
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