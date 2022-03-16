using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodo<Tipo> where Tipo : IComparable
    {
        protected Tipo atrItem;

        #region Accesores
        public Tipo darItem()
        {
            return atrItem;
        }
        #endregion

        #region Mutadores
        public void ponerItem(Tipo prmContenido)
        {
            atrItem = prmContenido;
        }
        #endregion
    }
}