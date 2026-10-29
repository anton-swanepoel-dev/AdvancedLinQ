using System;
using SOLID.DIP;

namespace SOLID
{
    public class PaymentProcessor;

    public class MainViewModel
    {
        public Customer customer { get; set; }

        public MainViewModel(Customer customerPassed)
        {
            customer = customerPassed;
        }

    };

    public interface ICustomer
    {

    }

    public class Customer : ICustomer
    {

        public CustomerRepository repository { get; set; }

        public Customer(CustomerRepository repo)
        {
            repository = repo;
        }

    }

    public interface ICustomerRepository
    {

    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbGateway _connection;

        public CustomerRepository(DbGateway gateway)
        {
            _connection = gateway;
        }

    }

    public interface IDbGateway
    {
        public string database { get; set; }

    }

    public class DbGateway : IDbGateway
    {
        public string database { get; set; }

        //public DbGateway(string databaseConenction)
        //{
        //    database = databaseConenction;
        //}
    }

    class Progrm
    {
        static void Main(string[] args)
        {

            SimpleIOC ioc = new SimpleIOC();

            ioc.Register<MainViewModel, MainViewModel>();
            ioc.Register<Customer, Customer>();
            ioc.Register<CustomerRepository, CustomerRepository>();
            ioc.Register<DbGateway, DbGateway>();

            var dbGateway = ioc.Resolve<DbGateway>();
            var customerRepository = ioc.Resolve<CustomerRepository>(dbGateway);
            var customer = ioc.Resolve<Customer>();
            var mainViewModel = ioc.Resolve<MainViewModel>();

            Console.WriteLine();



        }


    }


}