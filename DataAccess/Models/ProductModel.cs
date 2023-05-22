using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Webbutveckling_Labb2.DataAccess.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public string Description { get; set; }
        [BsonElement]
        public int Price { get; set; }
        [BsonElement]
        public string Category { get; set; }
        [BsonElement]
        public string Status { get; set; }
    }
}
