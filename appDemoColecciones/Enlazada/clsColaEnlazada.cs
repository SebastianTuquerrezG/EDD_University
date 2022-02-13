using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsColaEnlazada<Tipo> : iCola<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private Tipo[] atrItems;
        private Tipo[] atrImagenes;
        private Tipo atrImagen;
        private int atrLongitud;
        private int atrCapacidad;
        private int atrFactorCrecimiento;
        private bool atrDinamica;
        private clsNodoEnlazado<Tipo> atrPrimero;
        private clsNodoEnlazado<Tipo> atrUltimo;
        #endregion

        #region Metodos

        #region Accesores
        public Tipo[] darItems() { return atrItems; }
        public int darLongitud() { return atrLongitud; }
        public int darCapacidad() { return atrCapacidad; }
        public int darFactorCrecimiento() { return atrFactorCrecimiento; }
        public clsNodoEnlazado<Tipo> darPrimero() { return atrPrimero; }
        public clsNodoEnlazado<Tipo> darUltimo() { return atrUltimo; }
        #endregion

        #region Mutadores
        public bool ponerItems(Tipo[] prmItems)
        {
            try
            {
                if (prmItems.Length == int.MaxValue / 16 + 1)
                {
                    return false;
                }
                if (atrLongitud != int.MaxValue / 16)
                {
                    atrItems = prmItems;
                    atrCapacidad = atrItems.Length;
                    atrLongitud = atrCapacidad;
                    if (atrCapacidad == int.MaxValue / 16)
                    {
                        atrDinamica = false;
                    }
                    return true;
                }
                return false;

            }
            catch
            {
                return false;
            }
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
        public clsColaEnlazada()
        {
            atrFactorCrecimiento = 1000;
            atrDinamica = true;
            atrItems = new Tipo[0];
            atrCapacidad = 0;
            atrLongitud = 0;
        }
        public clsColaEnlazada(int prmCapacidad)
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
        public clsColaEnlazada(int prmCapacidad, bool prmFlexible)
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
        public clsColaEnlazada(int prmCapacidad, int prmFactorCrecimiento)
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
                atrFactorCrecimiento = 0;
                atrDinamica = false;
            }
            return atrDinamica;
        }
        #endregion

        #region CRUDs
        public bool encolar(Tipo prmItem)
        {
            try
            {
                if (atrLongitud < int.MaxValue / 16)
                {
                    if (atrLongitud >= atrCapacidad)
                    {
                        resizing(atrDinamica, atrFactorCrecimiento);
                    }
                    atrItems[atrLongitud] = prmItem;
                    atrLongitud++;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool desencolar(ref Tipo prmItem)
        {
            int contador = 0;
            if (atrLongitud >= 1)
            {
                prmItem = atrItems[0 + contador];
                contador++;
                for (int i = 1; i < atrLongitud; i++)
                    atrItems[i - 1] = atrItems[i];
                atrLongitud--;

                return true;
            }


            return false;
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

        public void resizing(bool prmDinamica, int prmFactorCrecimiento)
        {
            if (prmDinamica)
            {
                atrCapacidad += prmFactorCrecimiento;
                Tipo[] Redimensionar = new Tipo[atrCapacidad];
                atrItems.CopyTo(Redimensionar, 0);
                ponerItems(Redimensionar);
                atrLongitud += -prmFactorCrecimiento;
            }
        }
        #endregion
    }
}



