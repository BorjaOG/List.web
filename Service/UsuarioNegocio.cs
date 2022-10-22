using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Service
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
			DataAccess datos = new DataAccess();
			try
			{
				datos.setearConsulta("Select id, tipousuario from Usuarios where usuario = @user And pass = @pass");
				datos.setearparametro("@user", usuario.User);
				datos.setearparametro("@pass", usuario.Pass);

				datos.ejecutarlectura();
				while (datos.Reader.Read())
				{
					usuario.Id = (int)datos.Reader["Id"];
					usuario.TipoUsuario = (int)(datos.Reader["TipoUsuario"]) == 2 ? TipoUsuario.Admin : TipoUsuario.Normal;
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
