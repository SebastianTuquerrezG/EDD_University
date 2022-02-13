using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsPilaDobleEnlazada<Tipo> : iPila<Tipo> where Tipo : IComparable
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
        public clsNodoEnlazado<Tipo> darPrimero() { return atrPrimero; }
        public clsNodoEnlazado<Tipo> darUltimo() { return atrUltimo; }
        public int darCapacidad() { return atrCapacidad; }
        public int darFactorCrecimiento() { return atrFactorCrecimiento; }
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
        public clsPilaDobleEnlazada()
        {
            atrFactorCrecimiento = 1000;
            atrDinamica = true;
            atrItems = new Tipo[0];
            atrCapacidad = 0;
            atrLongitud = 0;
        }
        public clsPilaDobleEnlazada(int prmCapacidad)
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
        public clsPilaDobleEnlazada(int prmCapacidad, bool prmFlexible)
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
        public clsPilaDobleEnlazada(int prmCapacidad, int prmFactorCrecimiento)
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
        public bool apilar(Tipo prmItem)
        {
            try
            {
                if (atrLongitud < int.MaxValue / 16)
                {
                    if (atrLongitud >= atrCapacidad)
                    {
                        resizing(atrDinamica, atrFactorCrecimiento);
                    }
                    Desplazar();
                    atrItems[0] = prmItem;
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
        public bool desapilar(ref Tipo prmItem)
        {
            if (atrLongitud == 0)
            {
                return false;
            }
            else
            {
                prmItem = atrItems[0];
                eliminar_ult();
                atrLongitud--;
            }
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
        public bool Desplazar()
        {
            if (atrLongitud < atrCapacidad)
            {
                for (int i = atrLongitud; i > 0; i--)
                    atrItems[i] = atrItems[i - 1];
            }
            return true;
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