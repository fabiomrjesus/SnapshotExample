namespace WebApp.Models
{
    public class ProcessedBlock
    {
        public int Number { get; set; }
        public int TransactionsFound { get; set; }
        public List<string> RelatedAddresses { get; set; } = new List<string>();
    }
}
