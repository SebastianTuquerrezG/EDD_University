using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Interfaces //Empaquetamos en un lugar que sabemos vamos a encontrar
{
    public interface iPila<Tipo>where Tipo :IComparable //metodo de ordenamiento, patron de capas(estrategia arquitectonica, empaquetamiento)
    {
        bool apilar(Tipo prmItem); //Pila por pila
        bool desapilar(ref Tipo prmItem); 
        bool revisar(ref Tipo prmItem); //revisar todo lo que pasa, o entra
    }
}
