using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class Configuracoes
    {
        public int RegistrosPorPagina { get; set; }
        //Quando tiver configurações novas, basta colocar aqui com o mesmo nome que está no appsettings que ele 
        //entende e já referencia automaticamente.
    }
}
