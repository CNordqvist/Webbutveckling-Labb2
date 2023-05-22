using MongoDB.Driver;
using Webbutveckling_Labb2.DataAccess.Models;
using MongoDB.Driver.Core.Operations;

namespace Webbutveckling_Labb2.DataAccess.Repositories
{
    public class CustomerRepository
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<CustomerModel> _customerCollection;

        public CustomerRepository()
        {
            var host = "";
            var databasename = "";
            var connectionString = "";
            var client = new MongoClient();
            var database = client.GetDatabase(databasename);
            _customerCollection = database.GetCollection<CustomerModel>("Customer",
                new MongoCollectionSettings() { AssignIdOnInsert = true });
        }

        public async Task AddCustomer(CustomerModel customer)
        {
            await _customerCollection.InsertOneAsync(customer);
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomers(CustomerModel customer)
        {
            var allCustomers = await _customerCollection.FindAsync(_ => true);
            return await allCustomers.ToListAsync();
        }

        public async Task<CustomerModel> FindByEmailAsync(string email)
        {
            var filter = Builders<CustomerModel>.Filter.Eq("Email", email);
            var customer = await _customerCollection.Find(filter).FirstOrDefaultAsync();
            return customer;
        }

        public async Task DeleteAsync(object id)
        {
            var filter = Builders<CustomerModel>.Filter.Eq("_id", id);
            await _customerCollection.FindOneAndDeleteAsync(filter);
        }

        public async Task UpdateAsync(object id, CustomerModel customer)
        {
            var filter = Builders<CustomerModel>.Filter.Eq("_id", id);
            var update = Builders<CustomerModel>.Update
                    .Set("FirstName", customer.FirstName)
                    .Set("LastName", customer.LastName)
                    .Set("Address", customer.Address)
                    .Set("PhoneNumber", customer.PhoneNumber)
                    .Set("Email", customer.Email);

            var result = await _customerCollection.FindOneAndUpdateAsync(filter, update);
        }
    }
}
