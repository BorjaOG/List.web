using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Service
{
    public  class DataAccess
    {
        private SqlConnection conection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public DataAccess()
        {
            conection = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true;");
            command = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;
        }

        public void setearProcedimiento(string sp)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = sp;

        }

        public void ejecutarlectura()
        {
            command.Connection = conection;
            try
            {
                conection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void ejecutarAccion()
        {
            command.Connection = conection;

            try
            {
                conection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void setearparametro(string nombre, object valor)
        {
            command.Parameters.AddWithValue(nombre, valor);
        }
        
        public void cerrarconexion()
        {
            if(reader != null)
                reader.Close();
            conection.Close();
        }
    }
}
