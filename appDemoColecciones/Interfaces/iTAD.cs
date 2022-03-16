using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iTAD<Tipo> where Tipo : IComparable
    {
        int darLongitud();
        Tipo[] darItems();
        bool ponerItems(Tipo[] prmVector);
        bool reversar();
        bool contieneA(Tipo prmItem);
        bool encontrarA(Tipo prmItem);
    }
}
