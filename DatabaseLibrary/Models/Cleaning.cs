namespace DatabaseLibrary.Models
{
    public class Cleaning
    {
        public int Id { get; set; }
        public int Room_id { get; set; }
        public string Status { get; set; } = null!;
        public string Notes { get; set; } = null!;

        public virtual Romdata Room { get; set; } = null!;
    }
}