using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
     public class Pokemon
    {
        public int Id { get; set; }
        [DisplayName("Number")]
        public int Numero { get; set; }
        [DisplayName("Name")]
        public string Nombre { get; set; }
        [DisplayName("Description")]
        
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        [DisplayName("Type")]
        public elemento Tipo { get; set; }
        [DisplayName("Weakness")]
        public elemento Debilidad { get; set; }
       
        public bool Activo { get; set; }

    }
}
