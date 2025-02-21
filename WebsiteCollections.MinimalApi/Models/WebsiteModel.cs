using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebsiteCollections.MinimalApi.Models
{
    public class WebsiteModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Collection { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
    }
}
