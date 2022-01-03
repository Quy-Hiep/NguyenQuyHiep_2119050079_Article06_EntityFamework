using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DBConnection : DbContext
    {
        public DBConnection() : base("name = SaleDB")
        {

        }
        public System.Data.Entity.DbSet<Customer_DTO> Customers { get; set; }
    }
}
