using AWSApiPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSApiPersonas.Repositories
{
    public class RepositoryPersonas
    {
        List<Persona> personasList;
        public RepositoryPersonas()
        {
            //AQUI EL CODIGO DE CREACION DE LA LISTA DE PERSONAS
            this.personasList = new List<Persona>
            {
                new Persona { IdPersona=1, Nombre = "Ana", Email = "ana@gmail.com", Edad = 30},
                new Persona { IdPersona=2,Nombre = "Lucia", Email = "lucia@gmail.com", Edad = 20},
                new Persona { IdPersona=3,Nombre = "Adrian", Email = "adrian@gmail.com", Edad = 22},
                new Persona { IdPersona=4,Nombre = "Carlos", Email = "carlos@gmail.com", Edad = 35}
            };
        }

        public List<Persona> GetPersonas()
        {
            return this.personasList;
        }

        public Persona FindPersona(int id)
        {
            return this.personasList.FirstOrDefault(x => x.IdPersona == id);
        }
    }
}
