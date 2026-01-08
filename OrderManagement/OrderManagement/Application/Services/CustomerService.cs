using OrderManagement.Application.DTO;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Services
{
    public class CustomerService
    {
        ICustomerRepository iCustomerRepository;

        public CustomerService(ICustomerRepository repository)
        {
            iCustomerRepository = repository;
        }

        public async Task<int> CreateCustomerAsync(int id, string name)
        {
            var customer = Customer.Create(id, name);
            iCustomerRepository.Add(customer);
            iCustomerRepository.Save();
            return customer.Id;
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customers = iCustomerRepository.GetAll();
            return customers.Select(c => new CustomerDto());
        }
    }
}
