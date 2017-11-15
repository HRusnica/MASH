using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MASH.Models;

namespace MASH.DAL
{
    public class ThemeDAL
    {

        public List<Theme> GetAllThemes()
        {
            List<Theme> themesList = new List<Theme>();

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Mash;User ID=te_student;Password=sqlserver1")) 
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT Theme FROM MashThemeList", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Theme thisTheme = new Theme();
                        thisTheme.MashTheme = Convert.ToString(reader["Theme"]);
                        themesList.Add(thisTheme);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return themesList;
        }
    }
}


