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
        private Tipo atrImagen;
        private Tipo[] atrImagenes;
        #endregion

        #region Metodos

        #region Accesores
        public int darLongitud() { return atrLongitud; }
        public Tipo[] darItems() { return atrItems; }
        public clsNodoDobleEnlazado<Tipo> darPrimero() { return atrUltimo; }
        public clsNodoDobleEnlazado<Tipo> darUltimo() { return atrPrimero; }

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
        public bool apilar(Tipo prmItem)
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
            for (int i = 0; i < atrItems.Length - 1; i++)
            {
                atrImagen = atrImagenes[atrImagenes.Length - 1 - i];
                atrItems[atrImagenes.Length - i] = atrImagen;
            }
            atrItems[0] = prmItem;
            atrLongitud++;
            return true;

        }
        public bool desapilar(ref Tipo prmItem)
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
