using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataManagement
{
    public class SnapshotDataAccessObject<TBlock>
    {
        private readonly IMongoCollection<Snapshot<TBlock>> _snapshotCollection;
        
        public SnapshotDataAccessObject(IOptions<DatabaseOptions> databaseOptions)
        {
            var conn = new MongoClient(databaseOptions.Value.ConnectionString);
            var db = conn.GetDatabase(databaseOptions.Value.DatabaseName);
            _snapshotCollection = db.GetCollection<Snapshot<TBlock>>("Snapshots");
        }

        /// <summary>
        /// Saves a snapshot
        /// </summary>
        public async Task<string> CreateSnapshot(Snapshot<TBlock> snapshot)
        {
            await _snapshotCollection.InsertOneAsync(snapshot);
            return snapshot?.Id;
        }

        /// <summary>
        /// Fetches a snapshot from the database
        /// </summary>
        public async Task<Snapshot<TBlock>> GetSnapshot(string id)
        {
            return (await _snapshotCollection.FindAsync(x => x.Id == id)).FirstOrDefault();
        }

        /// <summary>
        /// Updates a snapshot from the database
        /// </summary>
        public async Task UpdateSnapshot(Snapshot<TBlock> snapshot)
        {
            var res = await _snapshotCollection.ReplaceOneAsync((x)=>x.Id == snapshot.Id, snapshot);
        }
    }
}
