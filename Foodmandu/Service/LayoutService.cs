using Foodmandu.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Foodmandu.Service
{
    public class LayoutService : ILayoutService
    {
        private readonly FoodmanduDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public LayoutService(FoodmanduDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }


        public IList<Layouts> GetLayoutDetails()
        {
            List<Layouts> list = new List<Layouts>();
            var conn = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usp_GetLayout_Details", connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Layouts obj = new Layouts();
                        obj.layoutId = Convert.ToInt16(reader.GetValue(0));
                        obj.layout = Convert.ToString(reader.GetValue(1));
                        obj.displayOrder = Convert.ToInt32(reader.GetValue(2));
                        obj.title = Convert.ToString(reader.GetValue(3));
                        obj.tagline = Convert.ToString(reader.GetValue(4));
                        list.Add(obj);
                    }
                }
                command.Dispose();
            }
            return list;
        }
        public IList<LayoutItems> GetLayoutItemDetails(int layoutId)
        {
            List<LayoutItems> list = new List<LayoutItems>();
            var conn = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usp_GetLayout_Item_Details", connection);
                command.Parameters.Add("@layoutId", SqlDbType.Int).Value = layoutId;
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LayoutItems obj = new LayoutItems();
                        obj.LayoutItemId = Convert.ToInt16(reader.GetValue(0));
                        obj.type = Convert.ToString(reader.GetValue(1));
                        obj.title = Convert.ToString(reader.GetValue(2));
                        obj.layoutId = Convert.ToInt32(reader.GetValue(3));
                        obj.displayOrder = Convert.ToInt32(reader.GetValue(4));
                        obj.featured = Convert.ToBoolean(reader.GetValue(5));
                        obj.image = Convert.ToString(reader.GetValue(6));
                        obj.subtitle1 = Convert.ToString(reader.GetValue(7));
                        obj.subtitle2 = Convert.ToString(reader.GetValue(8));
                        obj.subtitle3 = Convert.ToString(reader.GetValue(9));
                        obj.logo = Convert.ToString(reader.GetValue(10));
                        obj.extraInfo1 = Convert.ToString(reader.GetValue(11));
                        obj.extraInfo2 = Convert.ToString(reader.GetValue(12));
                        obj.ParentLayoutItemId = Convert.ToInt32(reader.GetValue(13)); 
                        list.Add(obj);
                    }
                }
                command.Dispose();
            }
            return list;
        }
        public IList<LayoutItems> GetLayout_Item_Index_Details()
        {
            List<LayoutItems> list = new List<LayoutItems>();
            var conn = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("usp_GetLayout_Item_Index_Details", connection);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LayoutItems obj = new LayoutItems();
                        obj.LayoutItemId = Convert.ToInt16(reader.GetValue(0));
                        obj.type = Convert.ToString(reader.GetValue(1));
                        obj.title = Convert.ToString(reader.GetValue(2));
                        obj.layoutId = Convert.ToInt32(reader.GetValue(3));
                        obj.displayOrder = Convert.ToInt32(reader.GetValue(4));
                        obj.featured = Convert.ToBoolean(reader.GetValue(5));
                        obj.image = Convert.ToString(reader.GetValue(6));
                        obj.subtitle1 = Convert.ToString(reader.GetValue(7));
                        obj.subtitle2 = Convert.ToString(reader.GetValue(8));
                        obj.subtitle3 = Convert.ToString(reader.GetValue(9));
                        obj.logo = Convert.ToString(reader.GetValue(10));
                        obj.extraInfo1 = Convert.ToString(reader.GetValue(11));
                        obj.extraInfo2 = Convert.ToString(reader.GetValue(12));
                        obj.ParentLayoutItemId = Convert.ToInt32(reader.GetValue(13)); 
                        list.Add(obj);
                    }
                }
                command.Dispose();
            }
            return list;
        }
    } 
}
