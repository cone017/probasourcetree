using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MenuItemRepository
    {
        public string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RestaurantDB;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public List<MenuItem2> GetAllMenuItems()
        {
            var list = new List<MenuItem2>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;

                sqlCommand.CommandText = "SELECT * FROM MenuItems";

                SqlDataReader adapter = sqlCommand.ExecuteReader();

                while(adapter.Read())
                {
                    MenuItem2 menu = new MenuItem2();

                    menu.Id = adapter.GetInt32(0);
                    menu.Title = adapter.GetString(1);
                    menu.Description = adapter.GetString(2);
                    menu.Price = adapter.GetDecimal(3);

                    list.Add(menu);
                }
            }
            return list;
        }

        public int InsertMenuItem(MenuItem2 menuItem)
        {
            using(SqlConnection sql = new SqlConnection(connectionString))
            {
                sql.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;

                cmd.CommandText = string.Format("INSERT INTO MenuItems VALUES('{0}', '{1}', '{2}')",
                    menuItem.Title, menuItem.Description, menuItem.Price);

                return cmd.ExecuteNonQuery();
            }
        }
    }
}
