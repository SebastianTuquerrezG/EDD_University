using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Tads
{
    public class clsTADVectorial<Tipo> : clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos
        protected Tipo[] atrItems;
        protected int atrCapacidad;
        protected int atrFactorCrecimiento = 1000;
        protected bool atrDinamica = true;
        #endregion

        #region Constructores
        protected clsTADVectorial()
        {
            atrFactorCrecimiento = 1000;
            atrDinamica = true;
            atrItems = new Tipo[0];
            atrCapacidad = 0;
            atrLongitud = 0;
        }
        protected clsTADVectorial(int prmCapacidad)
        {
            atrFactorCrecimiento = 1000;
            atrDinamica = true;
            atrLongitud = 0;
            if (prmCapacidad <= 0 || prmCapacidad > int.MaxValue / 64)
            {
                atrItems = new Tipo[0];
                atrCapacidad = 0;
            }
            else
            {
                atrItems = new Tipo[prmCapacidad];
                atrCapacidad = prmCapacidad;
                if (prmCapacidad == int.MaxValue / 64)
                {
                    atrFactorCrecimiento = 0;
                    atrDinamica = false;
                }
            }
        }
        protected clsTADVectorial(int prmCapacidad, bool prmFlexible)
        {
            atrFactorCrecimiento = 1000;
            atrDinamica = prmFlexible;
            atrLongitud = 0;
            if (prmCapacidad <= 0 || prmCapacidad <= 0 && prmFlexible == false || prmCapacidad > int.MaxValue / 64)
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
                if (prmFlexible == false || prmCapacidad == int.MaxValue / 64)
                {
                    atrFactorCrecimiento = 0;
                    atrDinamica = false;
                }
            }
        }
        protected clsTADVectorial(int prmCapacidad, int prmFactorCrecimiento)
        {
            atrFactorCrecimiento = prmFactorCrecimiento;
            atrDinamica = true;
            atrLongitud = 0;
            if (prmCapacidad < 0 || prmFactorCrecimiento < 0 || prmCapacidad <= 0 && prmFactorCrecimiento == 0 || prmCapacidad > int.MaxValue / 64 || prmFactorCrecimiento > int.MaxValue / 64)
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
                if (prmCapacidad == int.MaxValue / 64 && prmFactorCrecimiento > 0)
                {
                    atrItems = new Tipo[0];
                    atrCapacidad = 0;
                    atrFactorCrecimiento = 1000;
                    atrDinamica = true;
                }
            }
        }
        #endregion

        #region Accesores
        public override Tipo[] darItems() { return atrItems; }
        public int darCapacidad() { return atrCapacidad; }
        public int darFactorCrecimiento() { return atrFactorCrecimiento; }
        #endregion

        #region Mutadores
        public override bool ponerItems(Tipo[] prmVector)
        {
            try
            {
                if (prmVector.Length >= 0 && prmVector.Length <= atrBorde)
                {
                    atrItems = prmVector;
                    atrLongitud = prmVector.Length;
                    atrCapacidad = prmVector.Length;
                    atrFactorCrecimiento = atrItems.Length == atrBorde ? 0 : 1000;
                    atrDinamica = atrFactorCrecimiento == 0 ? false : true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ajustarFlexibilidad(bool prmValor)
        {
            if (atrCapacidad == 0 || atrCapacidad == atrBorde)
            {
                return false;
            }
            else
            {
                atrDinamica = prmValor;
                if (!atrDinamica)
                    atrFactorCrecimiento = 0;
            }
            return true;
        }
        public bool ajustarFactorCrecimiento(int prmValor)
        {
            if (prmValor >= atrBorde)
            {
                return false;
            }
            atrFactorCrecimiento = prmValor;
            return true;
        }
        public bool ponerCapacidad(int prmValor)
        {
            if (atrCapacidad <= 0 || atrCapacidad > atrBorde)
            {
                return false;
            }
            atrCapacidad = prmValor;
            return true;
        }
        #endregion

        #region Colsultores
        public bool esDinamica()
        {
            if (atrCapacidad == int.MaxValue / 64)
            {
                atrFactorCrecimiento = 0;
                atrDinamica = false;
            }
            return atrDinamica;
        }
        protected bool validarCapacidad(int prmCapacidad)
        {
            return prmCapacidad > 0 && prmCapacidad <= atrBorde;
        }
        #endregion

        #region CRUDs
        public override bool contieneA(Tipo prmItem)
        {
            foreach (Tipo varItem in atrItems)
            {
                if (varItem.CompareTo(prmItem) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public override int encontrarA(Tipo prmItem)
        {
            for (int varIndice = 0; varIndice < atrLongitud; varIndice++)
            {
                if (atrItems[varIndice].CompareTo(prmItem) == 0)
                {
                    return varIndice;
                }
            }
            return -1;
        }
        protected override bool insertar(Tipo prmItem, int prmIndice)
        {
            if (prmIndice < 0 || prmIndice > atrLongitud)
            {
                return false;
            }
            if (atrLongitud == atrCapacidad)
            {
                if (atrDinamica)
                {
                    atrCapacidad += atrFactorCrecimiento;
                    Array.Resize(ref atrItems, atrCapacidad);
                }
                else
                {
                    return false;
                }
            }
            if (atrLongitud - prmIndice< 0)
            {
                return false;
            }
            Array.Copy(atrItems, prmIndice, atrItems, prmIndice + 1, atrLongitud - prmIndice);
            atrItems[prmIndice] = prmItem;
            atrLongitud++;
            return true;
        } 
        protected override bool extraer(ref Tipo prmItem, int prmIndice)
        {
            if (prmIndice < 0 || atrLongitud == 0 || prmIndice >= atrLongitud)
            {
                return false;
            }
            prmItem = atrItems[prmIndice];
            Array.Copy(atrItems, prmIndice + 1, atrItems, prmIndice, atrLongitud - prmIndice - 1);
            atrLongitud--;
            return true;
        }
        protected override bool recuperar(ref Tipo prmItem, int prmIndice)
        {
            if (prmIndice < 0 || atrLongitud == 0 || prmIndice >= atrLongitud)
            {
                return false;
            }
            prmItem = atrItems[prmIndice];
            return true;
        }
        public override bool reversar() 
        {
            if (atrLongitud == 0)
            {
                return false;
            }
            int varMitad = (int)atrLongitud / 2;
            for (int varIndice = 0; varIndice < varMitad; varIndice++)
            {
                Tipo varItemActual = atrItems[varIndice];
                atrItems[varIndice] = atrItems[atrLongitud - 1 - varIndice];
                atrItems[atrLongitud - 1 - varIndice] = varItemActual;
            }
            return true;
        }
        #endregion
    }
}