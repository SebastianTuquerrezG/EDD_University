﻿using System;
using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsListaDobleEnlazada<Tipo> : clsTADDobleEnlazado<Tipo>, iLista<Tipo> where Tipo : IComparable
    {
        #region Constructores
        public clsListaDobleEnlazada():base() { }
        #endregion

        #region CRUDs
        public bool agregar(Tipo prmItem)
        {
            return insertar(prmItem, atrLongitud);
        }
        public bool insertarEn(int prmIndice, Tipo prmItem)
        {
            return insertar(prmItem, prmIndice);
        }
        public bool extraerEn(int prmIndice, ref Tipo prmItem)
        {
            return extraer(ref prmItem, prmIndice);
        }
        public bool modificarEn(int prmIndice, Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> varNodo = null;
            if (buscarNodo(prmIndice, ref varNodo))
            {
                varNodo.ponerItem(prmItem);
                return true;
            }
            return false;
        }
        public bool recuperarEn(int prmIndice, ref Tipo prmItem)
        {
            return recuperar(ref prmItem, prmIndice);
        }
        #endregion
    }
}
