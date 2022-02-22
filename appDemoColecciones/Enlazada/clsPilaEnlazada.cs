using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsPilaEnlazada<Tipo> : iPila<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private int atrLongitud;
        private clsNodoEnlazado<Tipo> atrPrimero;
        private clsNodoEnlazado<Tipo> atrUltimo;
        private Tipo[] atrItems;
        private Tipo atrImagen;
        private Tipo[] atrImagenes;
        #endregion

        #region Metodos

        #region Accesores
        public Tipo[] darItems() { return atrItems; }
        public int darLongitud() { return atrLongitud; }
        public clsNodoEnlazado<Tipo> darPrimero() { return atrPrimero; }
        public clsNodoEnlazado<Tipo> darUltimo() { return atrUltimo; }
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
            if (atrLongitud != 0)
            {
                for (int i = 0; i <= atrLongitud; i++)
                {
                    prmItem = atrItems[i];

                    return true;
                }
            }

            return false;
        }
        public bool reversar()
        {
            if (atrLongitud == 0)
            {
                return false;
            }
            else
            {
                atrImagenes = atrItems;
                atrItems = new Tipo[atrImagenes.Length];
                for (int i = atrLongitud, j = 0; i > 0; j++, i--)
                {
                    atrImagen = atrImagenes[i - 1];
                    atrItems[j] = atrImagen;
                }
                return true;
            }
        }
        public bool eliminar_ult()
        {
            for (int i = 1; i < atrLongitud; i++)
                atrItems[i - 1] = atrItems[i];
            return true;
        }
        #endregion

        #endregion
    }
}