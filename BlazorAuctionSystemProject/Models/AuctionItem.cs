namespace BlazorAuctionSystemProject.Models
{
    public class AuctionItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public decimal CurrentBid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public required string ImageUrl { get; set; }
    }
}
