using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBWebAPI.Models
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("account_id")]
        public int AccountID { get; set; }

        [BsonElement("limit")]
        public int limit { get; set; }

        [BsonElement("products")]
        public List<string> products { get; set; }
    }
}
