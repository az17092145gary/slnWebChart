namespace WebChat.Models
{
    public class MarketOddsSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get;set; } = null!;
        public string MarketOddCollectionName { get; set; } = null!;
    }
}
