using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo> where Tipo : IComparable
    {
        private clsNodoDobleEnlazado<Tipo> atrAnterior = null;
        private Tipo atrItem;
        private clsNodoDobleEnlazado<Tipo> atrSiguiente = null;

        public bool ponerAnterior(clsNodoDobleEnlazado<Tipo> prmNuevoNodo)
        {
            atrAnterior = prmNuevoNodo;
            return true;
        }
        public bool ponerSiguiente(clsNodoDobleEnlazado<Tipo> prmNuevoNodo)
        {
            atrSiguiente = prmNuevoNodo;
            return true;
        }

        public void enlazarSiguiente(clsNodoDobleEnlazado<Tipo> prmSiguiente)
        {
            atrSiguiente = prmSiguiente;
            prmSiguiente.ponerAnterior(this);
        }
        public void enlazarAnterior(clsNodoDobleEnlazado<Tipo> prmAnterior)
        {
            atrSiguiente = prmAnterior;
            prmAnterior.ponerSiguiente(this);
        }
        public void enlazar(clsNodoDobleEnlazado<Tipo> prmAnterior, clsNodoDobleEnlazado<Tipo> prmSiguiente)
        {
            enlazarAnterior(prmAnterior);
            enlazarSiguiente(prmSiguiente);
        }

        public clsNodoDobleEnlazado()
        {
        }
        public clsNodoDobleEnlazado(Tipo prmItem, clsNodoDobleEnlazado<Tipo> prmAnterior,clsNodoDobleEnlazado<Tipo> prmSiguiente)
        {
            enlazar(prmAnterior, prmSiguiente);
            atrItem = prmItem;
        }
        public clsNodoDobleEnlazado(Tipo prmItem)
        {
            atrItem = prmItem;
            atrAnterior = null;
            atrSiguiente = null;
        }
        
        public Tipo darItem()
        {
            return atrItem;
        }
        public clsNodoDobleEnlazado<Tipo> darAnterior()
        {
            return atrAnterior;
        }
        public clsNodoDobleEnlazado<Tipo> darSiguiente()
        {
            return atrSiguiente;
        }
        public void ModificarItem(Tipo atrItem)
        {
            this.atrItem = atrItem;
        }
        public void ModificarSiguiente(clsNodoDobleEnlazado<Tipo> nodoEnlazado)
        {
            this.atrSiguiente = nodoEnlazado;
        }
        public void ModificarAnteriror(clsNodoDobleEnlazado<Tipo> nodoEnlazado)
        {
            this.atrAnterior = nodoEnlazado;
        }
    }
}