using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsColaDobleEnlazada<Tipo> : clsTADDobleEnlazado<Tipo>, iCola<Tipo> where Tipo : IComparable
    {
        #region Constructores
        public clsColaDobleEnlazada() : base() { }
        #endregion

        #region CRUDs
        public bool encolar(Tipo prmItem)
        {
            return insertar(prmItem, atrLongitud);
        }
        public bool desencolar(ref Tipo prmItem)
        {
            return extraer(ref prmItem, 0);
        }
        public bool revisar(ref Tipo prmItem)
        {
            return recuperar(ref prmItem, 0);
        }
        #endregion
    }
}
