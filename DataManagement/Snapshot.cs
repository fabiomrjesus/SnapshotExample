using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataManagement
{
    public class Snapshot<TBlock>
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public List<TBlock> Blocks { get; set; } = new();
    }
}
