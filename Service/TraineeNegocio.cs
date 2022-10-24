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
    }
}
