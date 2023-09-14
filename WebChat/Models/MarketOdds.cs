using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace WebChat.Models
{
    public class MarketOdds
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string indicator { get; set; }
        public string leagues { get; set; }
        public string eventname { get; set; }
        public string handicap { get; set; }
        public string odds { get; set; }
        public string decimalOdds { get; set; }
        public string date { get; set; }
    }
}
