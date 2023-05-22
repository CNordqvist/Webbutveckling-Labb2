
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Webbutveckling_Labb2.DataAccess.Models
{
    public class Customer
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string FirstName { get; set; }
        [BsonElement]
        public string LastName { get; set; }
        [BsonElement]
        public string Email { get; set; }
        [BsonElement("E-Mail")]
        public string Address { get; set; }
        [BsonElement]
        public string PhoneNumber { get; set; }
            
    }
}
