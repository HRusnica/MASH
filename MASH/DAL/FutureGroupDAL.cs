using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MASH.Models;
using System.Data.SqlClient;

namespace MASH.DAL
{
    public class FutureGroupDAL : IFutureGroupDAL
    {
        private const string SQL_GetFutureGroups = "SELECT * FROM MashThemeList WHERE Theme = @themeSelection AND (isFemale = @isGirl OR isFemale IS NULL);";

        public List<FutureGroup> GetAllGroups(string themeSelection, int isGirl)
        {
            List<FutureGroup> output = new List<FutureGroup>();
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Mash;User ID=te_student;Password=sqlserver1"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetFutureGroups, conn);
                    cmd.Parameters.AddWithValue("@themeSelection", themeSelection);
                    cmd.Parameters.AddWithValue("@isGirl", isGirl);
                    //SqlRowSet rows = conn.BeginTransaction(cmd, );
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                      
                        FutureGroup thisGroup = new FutureGroup();
                        thisGroup.Type = Convert.ToString(reader["Type"]);
                        thisGroup.Item1 = Convert.ToString(reader["Field1"]);
                        thisGroup.Item2 = Convert.ToString(reader["Field2"]);
                        thisGroup.Item3 = Convert.ToString(reader["Field3"]);
                        thisGroup.Item4 = Convert.ToString(reader["Field4"]);

                        output.Add(thisGroup);
                    }
                    FutureGroup MashGroup = new FutureGroup();
                    MashGroup.Type = "House";
                    MashGroup.Item1 = "mansion";
                    MashGroup.Item2 = "apartment";
                    MashGroup.Item3 = "shack";
                    MashGroup.Item4 = "house";

                    output.Add(MashGroup);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }
    }
}