using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;


namespace Servicios.Colecciones.Enlazadas
{
    public class clsColaEnlazada<Tipo> : iCola<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private int atrLongitud;
        private clsNodoEnlazado<Tipo> atrPrimero;
        private clsNodoEnlazado<Tipo> atrUltimo;
        private Tipo[] atrItems;
        private Tipo[] atrImagenes;
        private Tipo atrImagen;
        #endregion

        #region Metodos

        #region Accesores
        public int darLongitud() { return atrLongitud; }
        public Tipo[] darItems() {
            return atrItems;
        }
        public clsNodoEnlazado<Tipo> darUltimo() { return atrUltimo; }
        public clsNodoEnlazado<Tipo> darPrimero() { return atrPrimero; }
        #endregion

        #region Mutadores
        public bool ponerItems(Tipo[] prmVector)
        {
            if ((prmVector.Length > int.MaxValue / 16)) { return false; }
            atrItems = prmVector;
            atrLongitud = prmVector.Length;
            if (atrItems.Length == 0) { return false; }
            return true;
        }
        #endregion

        #region CRUDs
        public bool encolar(Tipo prmItem)
        {
            if (atrLongitud == 0)
            {
                atrItems = new Tipo[1];
                atrLongitud++;
                atrItems[0] = prmItem;
                return true;
            }
            if (atrItems.Length == int.MaxValue / 16)
            {
                return false;
            }
            atrImagenes = atrItems;
            atrItems = new Tipo[atrImagenes.Length + 1];
            for (int i = atrImagenes.Length; i > 0; i--)
            {
                atrImagen = atrImagenes[i - 1];
                atrItems[i - 1] = atrImagen;
            }
            atrItems[atrItems.Length - 1] = prmItem;
            atrLongitud++;
            return true;
        }
        public bool desencolar(ref Tipo prmItem)
        {
            if (atrItems == null)
            {
                return false;
            }
            prmItem = atrItems[0];
            atrImagenes = atrItems;
            atrItems = new Tipo[atrImagenes.Length - 1];
            for (int i = atrItems.Length; i > 0; i--)
            {
                atrImagen = atrImagenes[atrItems.Length + 1 - i];
                atrItems[atrItems.Length - i] = atrImagen;
            }
            atrLongitud--;
            return true;
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
        #endregion
        #endregion

    }
}
