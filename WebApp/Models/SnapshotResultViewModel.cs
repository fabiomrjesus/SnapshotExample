namespace WebApp.Models
{
    public class SnapshotResultViewModel
    {
        public string Id { get; set; }
        public List<ProcessedBlock> Blocks { get; set; } = new();
    }
}
