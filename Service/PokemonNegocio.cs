using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using Service;
using System.Security.Cryptography;
using System.Net;
using System.Xml.Linq;
using System.Configuration;

namespace Service
{
    public class PokemonNegocio
    {

        public List<Pokemon> listar(string id = "")
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = ConfigurationManager.AppSettings["cadenaConexion"];
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id, P.Activo From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad ";
                if (id != "")
                    comando.CommandText += " and P.Id = " + id;

                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    //if(!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                    //    aux.UrlImagen = (string)lector["UrlImagen"];
                    if (!(lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagen"];

                    aux.Tipo = new elemento();
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Debilidad = new elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    aux.Activo = bool.Parse(lector["Activo"].ToString());

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Pokemon> listarConSP()
        {
            List<Pokemon> lista = new List<Pokemon>();
            DataAccess datos = new DataAccess();
            try
            {
                //string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad And P.Activo = 1";
                //datos.setearConsulta(consulta);
                datos.setearProcedimiento("storedListar");

                datos.ejecutarlectura();
                while (datos.Reader.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Reader["Id"];
                    aux.Numero = datos.Reader.GetInt32(0);
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Descripcion = (string)datos.Reader["Descripcion"];
                    if (!(datos.Reader["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Reader["UrlImagen"];

                    aux.Tipo = new elemento();
                    aux.Tipo.Id = (int)datos.Reader["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Reader["Tipo"];
                    aux.Debilidad = new elemento();
                    aux.Debilidad.Id = (int)datos.Reader["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Reader["Debilidad"];

                    aux.Activo = bool.Parse(datos.Reader["Activo"].ToString());

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregar(Pokemon nuevo)
        {
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen)values(" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1, @idTipo, @idDebilidad, @urlImagen)");
                datos.setearparametro("@idTipo", nuevo.Tipo.Id);
                datos.setearparametro("@idDebilidad", nuevo.Debilidad.Id);
                datos.setearparametro("@urlImagen", nuevo.UrlImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarconexion();
            }
        }

        public void agregarConSP(Pokemon nuevo)
        {
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearProcedimiento("storedAltaPokemon");
                datos.setearparametro("@numero", nuevo.Numero);
                datos.setearparametro("@nombre", nuevo.Nombre);
                datos.setearparametro("@desc", nuevo.Descripcion);
                datos.setearparametro("@img", nuevo.UrlImagen);
                datos.setearparametro("@idTipo", nuevo.Tipo.Id);
                datos.setearparametro("@idDebilidad", nuevo.Debilidad.Id);
                //datos.setearParametro("@idEvolucion", null);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarconexion();
            }
        }

        public void modificar(Pokemon poke)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("update POKEMONS set Numero = @numero, Nombre = @nombre, Descripcion = @desc, UrlImagen = @img, IdTipo = @idTipo, IdDebilidad = @idDebilidad Where Id = @id");
                datos.setearparametro("@numero", poke.Numero);
                datos.setearparametro("@nombre", poke.Nombre);
                datos.setearparametro("@desc", poke.Descripcion);
                datos.setearparametro("@img", poke.UrlImagen);
                datos.setearparametro("@idTipo", poke.Tipo.Id);
                datos.setearparametro("@idDebilidad", poke.Debilidad.Id);
                datos.setearparametro("@id", poke.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarconexion();
            }
        }

        public void modificarConSP(Pokemon poke)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearProcedimiento("storedModificarPokemon");
                datos.setearparametro("@numero", poke.Numero);
                datos.setearparametro("@nombre", poke.Nombre);
                datos.setearparametro("@desc", poke.Descripcion);
                datos.setearparametro("@img", poke.UrlImagen);
                datos.setearparametro("@idTipo", poke.Tipo.Id);
                datos.setearparametro("@idDebilidad", poke.Debilidad.Id);
                datos.setearparametro("@id", poke.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarconexion();
            }
        }

        public List<Pokemon> filtrar(string campo, string criterio, string filtro, string estado)
        {
            List<Pokemon> lista = new List<Pokemon>();
            DataAccess datos = new DataAccess();
            try
            {
                string consulta = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, P.IdTipo, P.IdDebilidad, P.Id, P.Activo From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad And ";
                if (campo == "Número")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "E.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "E.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "E.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                if (estado == "Activo")
                    consulta += " and P.Activo = 1";
                else if (estado == "Inactivo")
                    consulta += " and P.Activo = 0";

                datos.setearConsulta(consulta);
                datos.ejecutarlectura();
                while (datos.Reader.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Reader["Id"];
                    aux.Numero = datos.Reader.GetInt32(0);
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Descripcion = (string)datos.Reader["Descripcion"];
                    if (!(datos.Reader["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Reader["UrlImagen"];

                    aux.Tipo = new elemento();
                    aux.Tipo.Id = (int)datos.Reader["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Reader["Tipo"];
                    aux.Debilidad = new elemento();
                    aux.Debilidad.Id = (int)datos.Reader["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Reader["Debilidad"];

                    aux.Activo = bool.Parse(datos.Reader["Activo"].ToString());

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminar(int id)
        {
            try
            {
                DataAccess datos = new DataAccess();
                datos.setearConsulta("delete from pokemons where id = @id");
                datos.setearparametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarLogico(int id, bool activo = false)
        {
            try
            {
                DataAccess datos = new DataAccess();
                datos.setearConsulta("update POKEMONS set Activo = @activo Where id = @id");
                datos.setearparametro("@id", id);
                datos.setearparametro("@activo", activo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
