using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebsiteCollections.MinimalApi.Models
{
    public class WebsiteModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Collection { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
    }
}
