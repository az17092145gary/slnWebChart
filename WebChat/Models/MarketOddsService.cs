using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebChat.Models
{
    public class MarketOddsService
    {
        private readonly IMongoCollection<MarketOdds> _marketOdds;
        public MarketOddsService(IOptions<MarketOddsSettings> marketOddsSettings)
        {
            var mongoClient = new MongoClient(
                marketOddsSettings.Value.ConnectionString
                );
            var mongoDatabase = mongoClient.GetDatabase(
                marketOddsSettings.Value.DatabaseName
                );
            _marketOdds = mongoDatabase.GetCollection<MarketOdds>(
                marketOddsSettings.Value.MarketOddCollectionName
                );
        }
        public async Task<List<MarketOdds>> GetAsync() =>
        await _marketOdds.Find(_ => true).ToListAsync();

        public async Task<MarketOdds?> GetAsync(string EventName) =>
            await _marketOdds.Find(x => x.eventname == EventName).FirstOrDefaultAsync();
        public async Task<List<MarketOdds>?> GetAsync(string EventName, string indicator, string hadicap) =>
            await _marketOdds.Find(x => x.eventname == EventName && x.indicator == indicator && x.handicap == hadicap).ToListAsync();

        public async Task CreateAsync(MarketOdds newBook) =>
            await _marketOdds.InsertOneAsync(newBook);
    }
}
