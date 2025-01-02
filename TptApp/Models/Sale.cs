namespace TptApp.Models;

internal partial class Sale
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int? SellerId { get; set; }

    public int? BuyerId { get; set; }

    public virtual Buyer Buyer { get; set; }

    public virtual Seller Seller { get; set; }
}
