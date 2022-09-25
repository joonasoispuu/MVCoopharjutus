namespace MVCoopkrodus.Models
{
    public class GDP
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public int? EstimatebyDollar { get; set; }
        public int? Population { get; set; }
        public string Year { get; set; }
    }
}
