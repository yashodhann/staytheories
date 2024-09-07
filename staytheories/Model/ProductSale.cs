namespace staytheories.Model;

public class ProductSale
{
    public int ProductSaleID { get; set; }
    public Product Product { get; set; }
    
    public Tenant Tenant { get; set; }
}