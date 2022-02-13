using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoEnlazado<Tipo> : iLista<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private Tipo[] atrItems;
        private Tipo[] atrImagenes;
        private Tipo atrImagen;
        private int atrLongitud;
        private int atrCapacidad;
        private int atrFactorCrecimiento;
        private bool atrDinamica;
        #endregion

        #region Metodos

        #region Accesores
        public Tipo[] darItems() { return atrItems; }
        public int darLongitud() { return atrLongitud; }
        public int darCapacidad() { return atrCapacidad; }
        public int darFactorCrecimiento() { return atrFactorCrecimiento; }


        #endregion

        #region Mutadores
        public bool ponerItems(Tipo[] prmItems)
        {
            atrItems = prmItems;
            atrCapacidad = atrItems.Length;
            atrLongitud = atrCapacidad;
            if (prmItems.Length == int.MaxValue / 16)
            {
                atrDinamica = false;
                atrFactorCrecimiento = 0;
            }
            if (prmItems.Length > int.MaxValue / 16)
            {
                atrItems = new Tipo[0];
                atrCapacidad = 0;
                atrLongitud = 0;
                atrDinamica = true;
                atrFactorCrecimiento = 1000;
                return false;
            }
            return true;
        }
        public bool ajustarFlexibilidad(bool prmTipo)
        {
            if (atrCapacidad == 0 || atrCapacidad == int.MaxValue / 16)
            {
                return false;
            }
            atrDinamica = false;
            atrFactorCrecimiento = 0;
            return true;
        }
        public bool ajustarFactorCrecimiento(int prmFactorCrecimiento)
        {
            if (atrItems.Length >= 0 && atrItems.Length < int.MaxValue / 16)
            {
                atrFactorCrecimiento = prmFactorCrecimiento;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Constructores
        public clsListaVector()
        {
            atrFactorCrecimiento = 1000;
            atrDinamica = true;
            atrItems = new Tipo[0];
            atrCapacidad = 0;
            atrLongitud = 0;
        }
        public clsListaVector(int prmCapacidad)
        {
            atrFactorCrecimiento = 1000;
            atrDinamica = true;
            atrLongitud = 0;
            if (prmCapacidad <= 0 || prmCapacidad > int.MaxValue / 16)
            {
                atrItems = new Tipo[0];
                atrCapacidad = 0;
            }
            else
            {
                atrItems = new Tipo[prmCapacidad];
                atrCapacidad = prmCapacidad;
                if (prmCapacidad == int.MaxValue / 16)
                {
                    atrFactorCrecimiento = 0;
                    atrDinamica = false;
                }
            }
        }
        public clsListaVector(int prmCapacidad, bool prmFlexible)
        {
            atrFactorCrecimiento = 1000;
            atrDinamica = prmFlexible;
            atrLongitud = 0;
            if (prmCapacidad <= 0 || prmCapacidad <= 0 && prmFlexible == false || prmCapacidad > int.MaxValue / 16)
            {
                atrDinamica = true;
                atrItems = new Tipo[0];
                atrCapacidad = 0;
            }
            else
            {
                atrItems = new Tipo[prmCapacidad];
                atrCapacidad = prmCapacidad;
                atrDinamica = prmFlexible;
                if (prmFlexible == false || prmCapacidad == int.MaxValue / 16)
                {
                    atrFactorCrecimiento = 0;
                    atrDinamica = false;
                }
            }
        }
        public clsListaVector(int prmCapacidad, int prmFactorCrecimiento)
        {
            atrFactorCrecimiento = prmFactorCrecimiento;
            atrDinamica = true;
            atrLongitud = 0;
            if (prmCapacidad < 0 || prmFactorCrecimiento < 0 || prmCapacidad <= 0 && prmFactorCrecimiento == 0 || prmCapacidad > int.MaxValue / 16 || prmFactorCrecimiento > int.MaxValue / 16)
            {
                atrFactorCrecimiento = 1000;
                atrItems = new Tipo[0];
                atrCapacidad = 0;
            }
            else
            {
                atrItems = new Tipo[prmCapacidad];
                atrCapacidad = prmCapacidad;
                if (prmFactorCrecimiento == 0)
                {
                    atrFactorCrecimiento = 0;
                    atrDinamica = false;
                }
                if (prmCapacidad == int.MaxValue / 16 && prmFactorCrecimiento > 0)
                {
                    atrItems = new Tipo[0];
                    atrCapacidad = 0;
                    atrFactorCrecimiento = 1000;
                    atrDinamica = true;
                }
            }
        }
        #endregion

        #region Colsultores
        public bool esDinamica()
        {
            if (atrCapacidad == int.MaxValue / 16)
            {
                atrDinamica = false;
            }
            return atrDinamica;
        }
        #endregion

        #region CRUDs
        public bool agregar(Tipo prmItem)
        {
            try
            {
                if (atrCapacidad == atrLongitud)
                {
                    atrCapacidad = atrCapacidad + atrFactorCrecimiento;
                    atrImagenes = atrItems;
                    atrItems = new Tipo[atrCapacidad];
                    for (int i = 0; i < atrLongitud; i++)
                    {
                        atrImagen = atrImagenes[i];
                        atrItems[i] = atrImagen;
                    }
                    atrItems[atrLongitud] = prmItem;
                    atrLongitud++;
                    return true;
                }
                else
                {
                    atrItems[atrLongitud] = prmItem;
                    atrLongitud++;
                    return true;
                }
            }
            catch { return false; }
        }
        public bool insertarEn(int prmIndice, Tipo prmItem)
        {
            if (prmIndice >= 0 && atrCapacidad == atrLongitud && atrDinamica && prmIndice < atrLongitud + 1)
            {
                atrCapacidad = atrCapacidad + atrFactorCrecimiento;
                atrImagenes = atrItems;
                atrItems = new Tipo[atrCapacidad];
                for (int i = 0; i < atrLongitud; i++)
                {
                    atrImagen = atrImagenes[i];
                    atrItems[i] = atrImagen;
                }
            }
            if (prmIndice >= 0 && prmIndice < atrLongitud + 1 || prmIndice >= 0 && prmIndice < atrLongitud + 1 && atrCapacidad == 0 && atrDinamica)
            {
                if (atrCapacidad > atrLongitud || atrDinamica)
                {
                    for (int i = 0; i < atrLongitud - prmIndice; i++)
                    {
                        atrImagen = atrItems[atrLongitud - 1 - i];
                        atrItems[atrLongitud - i] = atrImagen;
                    }
                    atrItems[prmIndice] = prmItem;
                    atrLongitud++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
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

        #endregion

        #endregion
    }
}
