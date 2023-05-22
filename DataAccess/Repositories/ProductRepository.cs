using MongoDB.Driver;
using Webbutveckling_Labb2.DataAccess.Models;

namespace Webbutveckling_Labb2.DataAccess.Repositories
{
    public class ProductRepository
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<ProductModel> _productCollection;

        public ProductRepository()
        {
            var host = "";
            var databasename = "";
            var connectionString = "";
            var client = new MongoClient();
            var database = client.GetDatabase(databasename);
            _productCollection = database.GetCollection<ProductModel>("Product",
                new MongoCollectionSettings() { AssignIdOnInsert = true });
        }

        public async Task AddProduct(ProductModel product)
        {
            await _productCollection.InsertOneAsync(product);
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts(ProductModel product)
        {
            var allProducts = await _productCollection.FindAsync(_ => true);
            return await allProducts.ToListAsync();
        }

        public async Task<ProductModel> FindByNameAsync(string name)
        {
            var filter = Builders<ProductModel>.Filter.Eq("Name", name);
            var product = await _productCollection.Find(filter).FirstOrDefaultAsync();
            return product;
        }
        public async Task<ProductModel> FindByNumberAsync(string productNumber)
        {
            var filter = Builders<ProductModel>.Filter.Eq("ProductNumber", productNumber);
            var product = await _productCollection.Find(filter).FirstOrDefaultAsync();
            return product;
        }
        public async Task DeleteAsync(object id)
        {
            var filter = Builders<ProductModel>.Filter.Eq("_id", id);
            await _productCollection.FindOneAndDeleteAsync(filter);
        }

        public async Task UpdateProductAsync(object id, ProductModel product)
        {
            var filter = Builders<ProductModel>.Filter.Eq("_id", id);
            var update = Builders<ProductModel>.Update
                .Set(p => p.ProductNumber, product.ProductNumber)
                .Set(p => p.Name, product.Name)
                .Set(p => p.Description, product.Description)
                .Set(p => p.Price, product.Price)
                .Set(p => p.Category, product.Category)
                .Set(p => p.Status, product.Status);

            await _productCollection.UpdateOneAsync(filter, update);
        }
    }
}
