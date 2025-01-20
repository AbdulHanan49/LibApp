using static System.Reflection.Metadata.BlobBuilder;

namespace LibApp.Models
{
    public class CartItem
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string CoverImagePath { get; set; }
        public decimal Price { get; set; }
    }

}
