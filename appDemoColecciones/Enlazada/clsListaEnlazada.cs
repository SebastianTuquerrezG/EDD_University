using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsListaEnlazada<Tipo> : iLista<Tipo> where Tipo : IComparable
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
        public Tipo[] darItems()
        {
            return atrItems;
        }
        public clsNodoEnlazado<Tipo> darUltimo() { return atrUltimo; }
        public clsNodoEnlazado<Tipo> darPrimero() { return atrPrimero; }
        #endregion

        #region Mutadores
        public bool ponerItems(Tipo[] prmVector)
        {
            if ((prmVector.Length > int.MaxValue / 16) || (prmVector.Length == 0)) { return false; }
            atrItems = prmVector;
            atrLongitud = prmVector.Length;
            return true;
        }
        #endregion

        #region CRUDs
        public bool agregar(Tipo prmItem)
        {
            try
            {
                if (atrLongitud == 0)
                {
                    atrItems = new Tipo[1];
                    atrLongitud++;
                    atrItems[0] = prmItem;
                    return true;
                }
                else if (atrItems.Length == int.MaxValue / 16)
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
            catch (Exception) { return false; }
        }
        public bool insertarEn(int prmIndice, Tipo prmItem)
        {
            if (prmIndice < 0 || prmIndice > int.MaxValue / 16 || prmIndice > atrLongitud)
            {
                return false;
            }
            if (atrItems == null)
            {
                atrItems = new Tipo[1];
                atrItems[prmIndice] = prmItem;
                atrLongitud++;
                return true;
            }
            atrImagenes = atrItems;
            atrItems = new Tipo[atrImagenes.Length + 1];
            for (int i = 0; i < atrLongitud; i++)
            {
                atrImagen = atrImagenes[i];
                atrItems[i] = atrImagen;
            }
            for (int i = 0; i < atrLongitud - prmIndice; i++)
            {
                atrImagen = atrImagenes[atrLongitud - 1 - i];
                atrItems[atrLongitud - i] = atrImagen;
            }
            atrItems[prmIndice] = prmItem;
            atrLongitud++;
            return true;
        }
        public bool extraerEn(int prmIndice, ref Tipo prmItem)
        {
            if (atrLongitud == 0 || prmIndice < 0 || prmIndice > atrLongitud - 1)
            {
                prmItem = default(Tipo);
                return false;
            }
            else
            {
                prmItem = atrItems[prmIndice];
                for (int i = 0; i < (atrLongitud - prmIndice - 1); i++)
                {
                    atrImagen = atrItems[prmIndice + 1 + i];
                    atrItems[prmIndice + i] = atrImagen;
                }
                atrLongitud--;
                return true;
            }
        }
        public bool modificarEn(int prmIndice, Tipo prmItem)
        {
            if (prmIndice < 0 || prmIndice > int.MaxValue / 16 || atrLongitud == 0 || prmIndice > atrLongitud - 1)
            {
                return false;
            }
            else
            {
                atrItems[prmIndice] = prmItem;
                return true;
            }
        }
        public bool recuperarEn(int prmIndice, ref Tipo prmItem)
        {
            if (prmIndice < 0 || atrLongitud == 0 || prmIndice > atrLongitud - 1)
            {
                prmItem = default(Tipo);
                return false;
            }
            else
            {
                prmItem = atrItems[prmIndice];
                return true;
            }
        }
        public bool contieneA(Tipo prmItem)
        {
            if (atrLongitud == 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    if (prmItem.Equals(atrItems[i]))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public int encontrarA(Tipo prmItem)
        {
            if (atrLongitud == 0)
            {
                return -1;
            }
            else
            {
                for (int i = 0; i < atrLongitud; i++)
                {
                    if (prmItem.Equals(atrItems[i]))
                    {
                        return i;
                    }
                }
                return -1;
            }
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
