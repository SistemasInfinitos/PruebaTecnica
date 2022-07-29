using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanonicalModel.Model.Entity
{
    public class Persona
    {
        public Persona()
        {
            FechaNacimiento=DateTime.Now;
        }
        public string? identificacion { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }

    }
}
