using CanonicalModel.Model.Configuration;
using CanonicalModel.Model.Entity;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace API.Repository
{
    public class GenericRepository: IGenericRepository
    {
        private readonly CultureInfo culture = new CultureInfo("is-IS");
        private readonly CultureInfo cultureFecha = new CultureInfo("en-US");
        private readonly JwtConfiguration _jwtConfig;

        public GenericRepository(IOptionsMonitor<JwtConfiguration> optionsMonitor)
        {
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        public async Task<int> ActualizarPersona(Personas entidad)
        {
            using (SqlConnection con = new SqlConnection("Server=SERVER;Database=Pedalea;user=sa;Password=Bell*900715*;trustServerCertificate=true;"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SpUpdatePersona", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.Add("@PersonaID", SqlDbType.Int).Value = entidad.PersonaID ?? 0;
                    cmd.Parameters.Add("@PrimerNombre", SqlDbType.VarChar, 50).Value = entidad.PrimerNombre;
                    cmd.Parameters.Add("@SegundoNombre", SqlDbType.VarChar, 50).Value = entidad.SegundoNombre;
                    cmd.Parameters.Add("@PrimerApellido", SqlDbType.VarChar, 50).Value = entidad.PrimerApellido;
                    cmd.Parameters.Add("@SegundoApellido", SqlDbType.VarChar, 50).Value = entidad.SegundoApellido;
                    cmd.Parameters.Add("@Identificacion", SqlDbType.VarChar, 15).Value = entidad.Identificacion;
                    cmd.Parameters.Add("@EsCliente", SqlDbType.Bit).Value = entidad.EsCliente;
                    cmd.Parameters.Add("@EsProveedor", SqlDbType.Bit).Value = entidad.EsProveedor;
                    cmd.Parameters.Add("@FechaNaciemiento", SqlDbType.DateTime).Value = entidad.FechaNaciemiento;
                    cmd.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = entidad.Correo;
                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = entidad.Direccion;
                    cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = entidad.Direccion;

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return (rowsAffected);
                }
                catch (Exception e)
                {
                    var debugger = e.Message;
                    return e.GetHashCode();
                }
            }
        }

        public async Task<int> BorrarPersona(int PersonaID)
        {
            using (SqlConnection con = new SqlConnection(_jwtConfig.ConnectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SpDeletePersona", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.Add("@PersonaID", SqlDbType.Int).Value = PersonaID;

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return (rowsAffected);
                }
                catch (Exception e)
                {
                    var debugger = e.Message;
                    return e.GetHashCode();
                }
            }
        }

        public async Task<int> CrearPersona(Personas entidad)
        {
            int Identificacion=await GetPersonasByIdentificacion(entidad.Identificacion);
            if (Identificacion >0)
            {
                return 0;
            }
            using (SqlConnection con = new SqlConnection("Server=SERVER;Database=Pedalea;user=sa;Password=Bell*900715*;trustServerCertificate=true;"))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SpInserPersona", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.Add("@PersonaID", SqlDbType.Int).Value = entidad.PersonaID ?? 0;
                    cmd.Parameters.Add("@PrimerNombre", SqlDbType.VarChar, 50).Value = entidad.PrimerNombre;
                    cmd.Parameters.Add("@SegundoNombre", SqlDbType.VarChar, 50).Value = entidad.SegundoNombre;
                    cmd.Parameters.Add("@PrimerApellido", SqlDbType.VarChar, 50).Value = entidad.PrimerApellido;
                    cmd.Parameters.Add("@SegundoApellido", SqlDbType.VarChar, 50).Value = entidad.SegundoApellido;
                    cmd.Parameters.Add("@Identificacion", SqlDbType.VarChar, 15).Value = entidad.Identificacion;
                    cmd.Parameters.Add("@EsCliente", SqlDbType.Bit).Value = entidad.EsCliente;
                    cmd.Parameters.Add("@EsProveedor", SqlDbType.Bit).Value = entidad.EsProveedor;
                    cmd.Parameters.Add("@FechaNaciemiento", SqlDbType.DateTime).Value = Convert.ToDateTime(entidad.FechaNaciemiento);
                    cmd.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = entidad.Correo;
                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = entidad.Direccion;
                    cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = entidad.Direccion;

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return (rowsAffected);
                }
                catch (Exception e)
                {
                    var debugger = e.Message;
                    return e.GetHashCode();
                }
            }
        }

        public async Task<List<Personas>> GetPersonas()
        {
            List<Personas> personas = new List<Personas>();
            using (SqlConnection con = new SqlConnection("Server=SERVER;Database=Pedalea;user=sa;Password=Bell*900715*;trustServerCertificate=true;"))
            {
                SqlCommand cmd = new SqlCommand("SpGetPersonas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (await rdr.ReadAsync())
                {
                    var employee = new Personas()
                    {
                        PersonaID = Convert.ToInt32(rdr["PersonaID"]),
                        PrimerNombre = rdr["PrimerNombre"].ToString(),
                        Identificacion = rdr["identificacion"].ToString(),
                        SegundoNombre = rdr["SegundoNombre"].ToString(),
                        PrimerApellido = rdr["PrimerApellido"].ToString(),
                        SegundoApellido = rdr["SegundoApellido"].ToString(),
                        EsCliente = Convert.ToBoolean(rdr["EsCliente"].ToString()),
                        EsProveedor = Convert.ToBoolean(((!string.IsNullOrWhiteSpace(rdr["EsProveedor"]?.ToString()) ? rdr["EsProveedor"]?.ToString() : false))),
                    };
                    personas.Add(employee);
                }
                con.Close();
                return (personas);
            }
        }

        public async Task<Personas> GetPersonasById(int PersonaID)
        {
            Personas personas = new Personas();
            using (SqlConnection con = new SqlConnection("Server=SERVER;Database=Pedalea;user=sa;Password=Bell*900715*;trustServerCertificate=true;"))
            {
                SqlCommand cmd = new SqlCommand("SpGetPersonasById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PersonaID", SqlDbType.Int).Value = PersonaID;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                try
                {
                    await rdr.ReadAsync();
                    var employee = new Personas()
                    {
                        PersonaID = Convert.ToInt32(rdr["PersonaID"]),
                        PrimerNombre = rdr["PrimerNombre"].ToString(),
                        Identificacion = rdr["identificacion"].ToString(),
                        SegundoNombre = rdr["SegundoNombre"].ToString(),
                        PrimerApellido = rdr["PrimerApellido"].ToString(),
                        SegundoApellido = rdr["SegundoApellido"].ToString(),
                        EsCliente = Convert.ToBoolean(rdr["EsCliente"].ToString()),
                        EsProveedor = Convert.ToBoolean(((!string.IsNullOrWhiteSpace(rdr["EsProveedor"]?.ToString()) ? rdr["EsProveedor"]?.ToString() : false))),
                    };
                    personas = employee;

                    con.Close();
                    return (personas);
                }
                catch (Exception e)
                {
                    con.Close();
                    return (personas);
                }
            }
        }

        public async Task<int> GetPersonasByIdentificacion(string Identificacion)
        {
            int personas=0;
            using (SqlConnection con = new SqlConnection("Server=SERVER;Database=Pedalea;user=sa;Password=Bell*900715*;trustServerCertificate=true;"))
            {
                SqlCommand cmd = new SqlCommand("SpGetPersonasByIdentificacion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = Identificacion;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                try
                {
                    await rdr.ReadAsync();
                    var data = new Personas()
                    {
                        PersonaID = Convert.ToInt32(rdr["PersonaID"]),
                        PrimerNombre = rdr["PrimerNombre"].ToString(),
                        Identificacion = rdr["identificacion"].ToString(),
                        SegundoNombre = rdr["SegundoNombre"].ToString(),
                        PrimerApellido = rdr["PrimerApellido"].ToString(),
                        SegundoApellido = rdr["SegundoApellido"].ToString(),
                        EsCliente = Convert.ToBoolean(rdr["EsCliente"].ToString()),
                        EsProveedor = Convert.ToBoolean(((!string.IsNullOrWhiteSpace(rdr["EsProveedor"]?.ToString()) ? rdr["EsProveedor"]?.ToString() : false))),
                    };
                    personas = data.PersonaID.Value;

                    con.Close();
                    return (personas);
                }
                catch (Exception e)
                {
                    con.Close();
                    return (personas);
                }
            }
        }
    }
}
