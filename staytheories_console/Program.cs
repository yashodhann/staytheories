using Microsoft.EntityFrameworkCore;
using staytheories.Model;
using staytheories.Repository;

public class staytheories_console
{
    static StaytheoriesContext _context;

    static staytheories_console()
    {
        _context = new StaytheoriesContext();
    }
    
    //Tenant Related Operations;
    static bool AddTenant(Tenant tenant)
    {
        _context.Tenants.Add(tenant);
        var result = _context.SaveChanges();
        return (result > 0 ? true : false);
    }
    
    static void AddTenantFromConsole()
    {
        Console.Write("Enter the tenant name: ");
        string tenantName = Console.ReadLine();
        if(AddTenant(new Tenant() { TenantName = tenantName }))Console.WriteLine("Tenant added");
        else Console.WriteLine("Tenant not added");
    }
    
    static void GetAllTenants()
    {
        foreach (Tenant tenant in _context.Tenants)
        {
            Console.WriteLine("{0}: {1}", tenant.TenantID, tenant.TenantName);
        }
    }

    static void UpdateTenant(int tenantId, string newTenantName)
    {
        var getExistingTenantName = _context.Tenants.Find(tenantId);
        if (getExistingTenantName != null)
        {   
            getExistingTenantName.TenantName = newTenantName;
            _context.SaveChanges();
            Console.WriteLine("Tenant Name Updated");
        }
        else
        {
            Console.WriteLine("Tenant Not Found");
        }
    }
    
    static void UpdateTenantFromConsole()
    {
            Console.Write("Enter the tenant ID");
            int tenantid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the tenant name: ");
            string tenantName = Console.ReadLine();
            UpdateTenant(tenantid, tenantName);
    }
    
    static bool DeleteTenant(Tenant tenant)
    {
        _context.Tenants.Remove(tenant);
        var res = _context.SaveChanges();
        return (res > 0 ? true : false);
    }

    static void RemoveTenantFromDatabase()
    {
        Console.Write("Enter the tenant ID: ");
        int tenantId = Convert.ToInt32(Console.ReadLine());
        if(DeleteTenant(_context.Tenants.Find(tenantId)))Console.WriteLine("Tenant deleted");
        else Console.WriteLine("Tenant not deleted");
    }

    
    
    //Product Related Operations;
    static bool AddProduct(Product product)
    {
        _context.Products.Add(product);
        var result = _context.SaveChanges();
        return (result > 0 ? true : false);
    }
    
    static void AddProductFromConsole()
    {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter product Serial: ");
            string productSerial = Console.ReadLine();
            if(AddProduct(new Product() { ProductName = productName, ProductSerial = productSerial })){Console.WriteLine("Product Added");}
            else{Console.WriteLine("Product Not Found");}
    }
    
    static void GetAllProducts()
    {
        foreach (Product product in _context.Products)
        {
            Console.WriteLine("{0}: {1}: {2}", product.ProductID, product.ProductName, product.ProductSerial);
        }
    }
    
    static void UpdateProduct(int productId, string productName, string productSerial)
    {
        var getExistingProductDetails = _context.Products.Find(productId);
        if (getExistingProductDetails != null)
        {   
            getExistingProductDetails.ProductName = productName;
            getExistingProductDetails.ProductSerial = string.IsNullOrWhiteSpace(productSerial) == true ? getExistingProductDetails.ProductSerial : productSerial;
            _context.SaveChanges();
            Console.WriteLine("Product Name Updated");
        }
        else
        {
            Console.WriteLine("Product Not Found");
        }
    }
    
    static void UpdateProductFromConsole()
    {
            Console.Write("Enter product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter product Serial: ");
            string productSerial = Console.ReadLine();
            
            UpdateProduct(productId, productName, productSerial);
    }
    
    static bool DeleteProdcut(Product product)
    {
        _context.Products.Remove(product);
        var res = _context.SaveChanges();
        return (res > 0 ? true : false);
    }
    
    static void RemoveProductFromDatabase()
    {
        Console.Write("Enter the Product ID: ");
        int productsId = Convert.ToInt32(Console.ReadLine());
        if(DeleteProdcut(_context.Products.Find(productsId))){Console.WriteLine("Product Deleted");}
        else Console.WriteLine("Product Not Found");
    }
    
    //Product Sell Related Operations;
    static bool AddSell(ProductSale productSale)
    {
        _context.ProductSales.Add(productSale);
        var result = _context.SaveChanges();
        return (result > 0 ? true : false);
    }
    static void AddSaleFromConsole()
    {
        
        Console.Write("Enter Product ID");
        int productId = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter Tenant ID");
        int tenantId = Convert.ToInt32(Console.ReadLine());
        
        Product p = _context.Products.Find(productId);
        Tenant t = _context.Tenants.Find(tenantId);

        if(AddSell(new ProductSale() { Product = p , Tenant = t})){Console.WriteLine("Sale Added");}
        else Console.WriteLine("Sale not added");

    }
    
    static void GetAllProductsSale()
    {
        var products = _context.ProductSales.Include(p => p.Product).Include(q=>q.Tenant).ToList();
        foreach (var product in products)
        {
            Console.WriteLine("{0}: {1}: {2}: {3}", product.ProductSaleID, product.Product.ProductName,product.Product.ProductSerial, product.Tenant.TenantName );
        }
    }

    static void Main(string[] args)
    {
        int ch;
        bool exit = false;
        while (!exit)
        {
            Console.Write("Please choose one of the following options: \n");
            Console.WriteLine("1. Add Tenant");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Update Tenant");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Remove Tenant");
            Console.WriteLine("6. Remove Product");
            Console.WriteLine("7. Add Sale");
            Console.WriteLine("8. View Tenants");
            Console.WriteLine("9. View Products");
            Console.WriteLine("10. View Sales");
            Console.WriteLine("11. Exit");

            
            switch (ch = Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    AddTenantFromConsole();
                    break;
                case 2:
                    AddProductFromConsole();
                    break;
                case 3:
                    UpdateTenantFromConsole();
                    break;
                case 4:
                    UpdateProductFromConsole();
                    break;
                case 5:
                    RemoveTenantFromDatabase();
                    break;
                case 6:
                    RemoveProductFromDatabase();
                    break;
                case 7:
                    AddSaleFromConsole();
                    break;
                case 8:
                    GetAllTenants();
                    break;
                case 9:
                    GetAllProducts();
                    break;
                case 10:
                    GetAllProductsSale();
                    break;
                case 11:
                    Console.WriteLine("----Thank you----");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Uhh ohh! You choose wrong option. Please try again.");
                    break;
            }
        }
    }
}