// --------------------------------------------------------------------------------------------------------------------
// <copyright file=DAOClass.cs" Company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Kuldeep Kasaudhan"/>
// ----------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserProblem
{
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// DAO class.
    /// </summary>
    public class DAOClass
    {
        /// <summary>
        /// Connection string with My sql Server.
        /// </summary>
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Stata_Table;Integrated Security=True";

        /// <summary>
        /// Connect the sql server and insert the Data in State table.
        /// </summary>
        /// <param name="filePath">filePath.</param>
        public void Register(string filePath)
        {
            string json = File.ReadAllText(filePath);
            JArray stateArrary = JArray.Parse(json);

            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                for (int i = 0; i < stateArrary.Count; i++)
                {
                    SqlCommand sqlCommand = new SqlCommand("insertStateData", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@State_Name", stateArrary[i]["State"]);
                    sqlCommand.Parameters.AddWithValue("@State_Population", stateArrary[i]["Population"]);
                    sqlCommand.Parameters.AddWithValue("@State_AreaInSqKm", stateArrary[i]["AreaInSqKm"]);
                    sqlCommand.Parameters.AddWithValue("@State_DensityPerSqKm", stateArrary[i]["DensityPerSqKm"]);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }
    }
}
