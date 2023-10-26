namespace SolarMP.DTOs.Bracket
{
    public class BracketUpdateDTO
    {
        public string BracketId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Manufacturer { get; set; }
        public bool? Status { get; set; }
    }
}
