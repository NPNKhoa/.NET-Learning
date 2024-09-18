using BusinessObjects;

namespace DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        public void AddCustomer(Customer customer) => CustomerDAO.AddCustomer(customer);

        public void DeleteCustomer(Customer customer) => CustomerDAO.DeleteCustomer(customer);

        public Customer GetCustomerByUsername(string username) => CustomerDAO.GetCustomerByUsername(username);

        public List<Customer> GetCustomers() => CustomerDAO.GetCustomers();

        public void UpdateCustomer(Customer customer) => CustomerDAO.UpdateCustomer(customer);
    }
}
