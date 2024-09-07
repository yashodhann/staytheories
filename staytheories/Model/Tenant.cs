namespace staytheories.Model;

public class Tenant
{
    public int TenantID { get; set; }
    public string TenantName { get; set; }
    
    public List<ProductSale> ProductSales  { get; set; }
}