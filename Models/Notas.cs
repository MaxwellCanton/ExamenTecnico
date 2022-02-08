using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamenTecnico.Models
{
    public class NotaModelo
    {
        //para ingresar manual el id del registro [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string Tema { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }
    }
}
