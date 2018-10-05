using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TradingResearchAPI.Database.DataAccess
{
    public class BaseDAO
    {

        public SqlDataReader ExecuteProcedure(string procedure, SqlParameter[] parameters, bool returnData = false)
        {
            // TODO: Add connection string to app properties
            using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=TradingPlatform;Integrated Security=SSPI"))
            {
                conn.Open();

                // 1.  create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand(procedure, conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                foreach(SqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                return cmd.ExecuteReader();
            }
        }

    }
}
