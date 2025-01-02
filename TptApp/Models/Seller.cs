namespace TptApp.Models;

internal partial class Seller : Contact
{
    public int Inventory { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
