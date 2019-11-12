using Dominio.Base;

namespace Dominio.Entities
{
    public class Persona : Entity<int>
    {
        public Persona()
        {

        }
        public Persona(string cedula, string nombres)
        {
            this.Cedula = cedula;
            this.Nombres = nombres;
        }
        public string Cedula { get; private set; }
        public string Nombres { get; private set; }
    }
}
