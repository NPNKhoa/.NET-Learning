using BusinessObjects;

namespace DataAccess
{
    public class CustomerDAO
    {
        public static List<Customer> GetCustomers()
        {
            var list = new List<Customer>();
            try
            {
                using (var context = new CustomerContext())
                {
                    list = context.Customers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static Customer GetCustomerByUsername(string username)
        {
            var customer = new Customer();
            try
            {
                using (var context = new CustomerContext())
                {
                    customer = context.Customers.SingleOrDefault(x => x.Username.Equals(username));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return customer;
        }

        public static void AddCustomer(Customer customer)
        {
            try
            {
                using (var context = new CustomerContext())
                {
                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            try
            {
                using (var context = new CustomerContext())
                {
                    context.Entry<Customer>(customer).State
                        = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCustomer(Customer customer)
        {
            try
            {
                using (var context = new CustomerContext())
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
