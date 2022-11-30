using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Service
{
    public class TraineeNegocio
    {
        public void actualizar(Trainee user)
        { 
            DataAccess datos = new DataAccess();
            try
            {
               
                datos.setearConsulta("update Users set imagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido, fechaNacimiento = @fecha   where Id = @Id");
                datos.setearparametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : (object) DBNull.Value);
                datos.setearparametro("@nombre", user.Nombre);
                datos.setearparametro("@apellido", user.Apellido);
                datos.setearparametro("@fecha", user.FechaNacimiento);
                datos.setearparametro("@Id", user.Id);
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

        public int insertarNuevo(Trainee nuevo)
        {
            DataAccess datos = new DataAccess();

            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearparametro("@Nombre", nuevo.Nombre);
                datos.setearparametro("@Email", nuevo.Email);
                datos.setearparametro("@Pass", nuevo.Pass);
                return datos.ejecutarAccionScalar();



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

        public bool Login(Trainee trainee)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.setearConsulta("Select Id, email, pass, admin, imagenPerfil, nombre, apellido, fechaNacimiento from Users Where email = @email And pass = @pass");
                datos.setearparametro("@email", trainee.Email);
                datos.setearparametro("@pass", trainee.Pass);
                datos.ejecutarlectura();
                if (datos.Reader.Read())
                {
                    trainee.Id = (int)datos.Reader["Id"];
                    trainee.Admin = (bool)datos.Reader["Admin"];
                    if (!(datos.Reader["imagenPerfil"] is DBNull))
                    trainee.ImagenPerfil = (string)datos.Reader["imagenPerfil"];
                    if (!(datos.Reader["nombre"] is DBNull))
                        trainee.Nombre = (string)datos.Reader["nombre"];
                    if (!(datos.Reader["apellido"] is DBNull))
                        trainee.Apellido = (string)datos.Reader["apellido"];
                    if (!(datos.Reader["fechaNacimiento"] is DBNull))
                        trainee.FechaNacimiento = DateTime.Parse(datos.Reader["fechanacimiento"].ToString());
                    return true;
                }
                return false;
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
    }
}
