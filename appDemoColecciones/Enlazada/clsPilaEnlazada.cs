using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsPilaEnlazada<Tipo> : clsTADEnlazado<Tipo>, iPila<Tipo> where Tipo : IComparable
    {
        #region Constructores
        public clsPilaEnlazada():base() { }
        #endregion

        #region CRUDs
        public bool apilar(Tipo prmItem)
        {
            return insertar(prmItem, 0);
        }
        public bool desapilar(ref Tipo prmItem)
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
