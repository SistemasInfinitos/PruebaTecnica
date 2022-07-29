
namespace CanonicalModel.Model.Entity
{
    public class Personas
    {
        public Personas()
        {
            PersonaID = 0;
            EsCliente = false;
            EsProveedor = false;
        }
        public int? PersonaID { get; set; }
        public string? Identificacion { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public bool? EsCliente { get; set; }
        public bool? EsProveedor { get; set; }

    }
}
