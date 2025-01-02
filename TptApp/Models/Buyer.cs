namespace TptApp.Models;

internal partial class Buyer : Contact
{
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
