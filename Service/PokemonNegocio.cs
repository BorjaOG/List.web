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

namespace Service
{
     public class PokemonNegocio
    {
        public List<Pokemon> listar(string  Id = "")
        {
            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select numero, nombre, p.descripcion, Urlimagen, e.descripcion tipo, d. Descripcion Debilidad, P. IdTipo, P.IdDebilidad, P.Id, P.Activo from pokemons p, elementos e, elementos d where e.id = P.idtipo AND d.id = p.IdDebilidad ";
                if (Id != "")
                    comando.CommandText += " and P.Id = " + Id;
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)lector["Id"];
                    aux.Numero = (int)lector["Numero"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    if(!(lector["UrlImagen"] is DBNull))
                    aux.UrlImagen = (string)lector["UrlImagen"];

                    aux.Tipo = new elemento();
                    aux.Tipo.Id = (int)lector["Idtipo"];
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
        public List<Pokemon> listarconSP()
        {
            List<Pokemon> lista = new List<Pokemon>();
            DataAccess datos = new DataAccess();
            try
            {
                //string consulta = "select numero, nombre, p.descripcion, Urlimagen, e.descripcion tipo, d. Descripcion Debilidad, P. IdTipo, P.IdDebilidad, P.Id  from pokemons p, elementos e, elementos d where e.id = P.idtipo AND d.id = p.IdDebilidad AND p.Activo = 1";
                //datos.setearConsulta(consulta);

                datos.setearProcedimiento("storedListar");

                datos.ejecutarlectura();
                while (datos.Reader.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Reader["Id"];
                    aux.Numero = (int)datos.Reader["Numero"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Descripcion = (string)datos.Reader["Descripcion"];

                    if (!(datos.Reader["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Reader["UrlImagen"];

                    aux.Tipo = new elemento();
                    aux.Tipo.Id = (int)datos.Reader["Idtipo"];
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
                datos.setearConsulta("Insert into POKEMONS(Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen) values(" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1, @idTipo, @idDebilidad, @UrlImagen)");
                datos.setearparametro("@idtipo", nuevo.Tipo.Id);
                datos.setearparametro("@idDebilidad", nuevo.Debilidad.Id);
                datos.setearparametro("@UrlImagen", nuevo.UrlImagen);
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
                datos.setearparametro("@number", nuevo.Numero);
                datos.setearparametro("@name", nuevo.Nombre); 
                datos.setearparametro("@desc", nuevo.Descripcion);
                datos.setearparametro("@img", nuevo.UrlImagen);
                datos.setearparametro("@idtipo", nuevo.Tipo.Id);
                datos.setearparametro("@idDebilidad", nuevo.Debilidad.Id);
                //datos.setearparametro("@idEvolucion", null);
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
                datos.setearConsulta("update pokemons set Numero = @numero, Nombre = @nombre, Descripcion = @descripcion, Urlimagen = @UrlImagen, IdTipo = @IdTipo, IdDebilidad = @IdDebilidad where id = @Id");
                datos.setearparametro("@numero", poke.Numero);
                datos.setearparametro("@nombre", poke.Nombre);
                datos.setearparametro("@descripcion", poke.Descripcion);
                datos.setearparametro("@UrlImagen", poke.UrlImagen);
                datos.setearparametro("@Idtipo", poke.Tipo.Id);
                datos.setearparametro("@IdDebilidad", poke.Debilidad.Id);
                datos.setearparametro("@Id", poke.Id);
                
                datos.ejecutarAccion();
            }

           
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarconexion();}
        }

        public void modificarConSp(Pokemon poke)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearProcedimiento("storedModify");
                datos.setearparametro("@numero", poke.Numero);
                datos.setearparametro("@nombre", poke.Nombre);
                datos.setearparametro("@desc", poke.Descripcion);
                datos.setearparametro("@img", poke.UrlImagen);
                datos.setearparametro("@Idtipo", poke.Tipo.Id);
                datos.setearparametro("@IdDebilidad", poke.Debilidad.Id);
                datos.setearparametro("@ID", poke.Id);

                datos.ejecutarAccion();
            }


            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarconexion(); }
        }

        public void eliminar (int id)
        {
            try
            {
                DataAccess datos = new DataAccess ();
                datos.setearConsulta("delete pokemons where id = @Id");
                datos.setearparametro("@Id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarlogico(int Id, bool activo = false)
        {
            try
            {
                DataAccess datos = new DataAccess ();
                datos.setearConsulta("update pokemons set activo = @activo where id = @Id");
                datos.setearparametro("@ID", Id);
                datos.setearparametro("@activo", activo);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            DataAccess datos = new DataAccess ();
            try
            {
                string consulta = "select numero, nombre, p.descripcion, Urlimagen, e.descripcion tipo, d. Descripcion Debilidad, P. IdTipo, P.IdDebilidad, P.Id  from pokemons p, elementos e, elementos d where e.id = P.idtipo AND d.id = p.IdDebilidad AND p.Activo = 1 AND  ";
                if (campo == "Numero")
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
                            consulta += "P.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "P.Descripcion like '%" + filtro + "%'";
                            break;

                    }


                }

                datos.setearConsulta(consulta);
                datos.ejecutarlectura();
                while (datos.Reader.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.Id = (int)datos.Reader["Id"];
                    aux.Numero = (int)datos.Reader["Numero"];
                    aux.Nombre = (string)datos.Reader["Nombre"];
                    aux.Descripcion = (string)datos.Reader["Descripcion"];

                    if (!(datos.Reader["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Reader["UrlImagen"];

                    aux.Tipo = new elemento();
                    aux.Tipo.Id = (int)datos.Reader["Idtipo"];
                    aux.Tipo.Descripcion = (string)datos.Reader["Tipo"];
                    aux.Debilidad = new elemento();
                    aux.Debilidad.Id = (int)datos.Reader["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Reader["Debilidad"];

                    lista.Add(aux);

                }
                return lista;
                }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
    }

