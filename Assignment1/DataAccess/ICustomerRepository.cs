using BusinessObjects;

namespace DataAccess
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomerByUsername(string username);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
