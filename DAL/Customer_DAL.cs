using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class Customer_DAL: DBConnection
    {
        public List<Customer_DTO> ReadCustomer()
        {
            return Customers.ToList();
        }
        public void DeleteCustomer(Customer_DTO cus)
        {
            var deletedCustomer = this.Customers.Where(c => c.Id == cus.Id).FirstOrDefault();
            this.Customers.Remove(deletedCustomer);
            this.SaveChanges();
        }
        public void NewCustomer(Customer_DTO cus)
        {
            this.Customers.Add(cus);
            this.SaveChanges();
        }
        public void EditCustomer(Customer_DTO cus)
        {
            var editCustomer = this.Customers.Where(c => c.Id == cus.Id).FirstOrDefault();
            if (editCustomer != null)
            {
                editCustomer.Id= cus.Id;
                editCustomer.Name = cus.Name;
                //this.Entry(editCustomer).CurrentValues.SetValues(cus);
                this.SaveChanges();
            }
            //this.Entry(cus).State = EntityState.Modified;
            //this.SaveChanges();
        }
    }
}
