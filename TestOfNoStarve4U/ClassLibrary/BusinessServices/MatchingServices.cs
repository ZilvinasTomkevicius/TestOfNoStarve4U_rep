using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
   public class MatchingServices : IMatchingServices
    {
        private string connectionString;

        public MatchingServices()
        {
            this.connectionString = ClassLibrary.Properties.Settings.Default.ConnectionString;
        }

        private SqlDataReader reader;

        public List<RecipeEntity> GetMatchedRecipes()
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();

                List<RecipeEntity> recipeList = new List<RecipeEntity>();

                SqlCommand cmd = new SqlCommand("Recipe_matching", con);
                cmd.CommandType = CommandType.StoredProcedure;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RecipeEntity recipe = new RecipeEntity();

                    recipe.ID = reader.GetInt32(0);
                    recipe.Name = reader.GetString(1);
                    recipe.Description = reader.GetString(2);
                    recipe.CookingTime = reader.GetInt32(3);

                    recipeList.Add(recipe);
                }

                reader.Close();

                return recipeList;
            }
        }

        public void SendCheckedProducts(List<ProductEntity> checkedProducts)
        {
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                try
                {
                    con.Open();

                    SqlTransaction tr = con.BeginTransaction();

                    SqlCommand cmd = new SqlCommand("declare @tp as Temp_Product insert into @tp(ID, Name) values (@ID, @Name)", con, tr);
                    cmd.CommandType = CommandType.Text;

                    foreach(var product in checkedProducts)
                    {
                         cmd.Parameters.AddWithValue("@ID", product.ID);
                         cmd.Parameters.AddWithValue("@Name", product.Name);

                         cmd.ExecuteNonQuery();
                         cmd.Parameters.Clear();
                    }
                                        
                    tr.Commit();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
        }
    }
}
