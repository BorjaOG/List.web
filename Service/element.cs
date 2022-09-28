using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Service
{
    public class element
    {
        public List<elemento> listar()
        {
            List<elemento>lista = new List<elemento>();
            DataAccess datos = new DataAccess();
            try
			{

                datos.setearConsulta(" Select Id, Descripcion From ELEMENTOS");
                datos.ejecutarlectura();

                while (datos.Reader.Read())
                {
                    elemento aux = new elemento();
                    aux.Id = (int)datos.Reader["Id"];
                    aux.Descripcion = (string)datos.Reader["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
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
