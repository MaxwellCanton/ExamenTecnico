using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using ExamenTecnico.Models;

namespace ExamenTecnico.Data
{
    public class DbInitializer
    {
        public static void Initialize(NotasContext context)
        {
            context.Database.EnsureCreated();

            // Valida que la tabla tenga algun registro.
            if (context.Notas.Any())
            {
                //Si la base de datos tiene registro no ejecute nada.
                return;
            }


            var Notas = new NotaModelo[]
            {
                new NotaModelo{Titulo = "Mobby", Contenido  = "Este es un cuento muy largo donde un joven paisano vivia en un lugar muy legano..", Tema = "Historia", Fecha=DateTime.Parse("05/02/2022")}
            };
            foreach (NotaModelo i in Notas)
            {
                context.Notas.Add(i);
            }
            context.SaveChanges();

        }

        
    }
}
