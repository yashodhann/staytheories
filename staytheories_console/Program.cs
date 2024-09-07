using Microsoft.EntityFrameworkCore;
using staytheories.Model;
using staytheories.Repository;

public class staytheories_console
{
    static StaytheoriesContext context;

    static staytheories_console()
    {
        context = new StaytheoriesContext();
    }
    
    //Tenant Related Operations;
    static bool AddTenant(Tenant tenant)
    {
        context.Tenants.Add(tenant);
        var result = context.SaveChanges();
        return (result > 0 ? true : false);
    }
    
    static void addTenantFromConsole()
    {
        Console.Write("Enter the tenant name: ");
        string tenantName = Console.ReadLine();
        if(AddTenant(new Tenant() { TenantName = tenantName }))Console.WriteLine("Tenant added");
        else Console.WriteLine("Tenant not added");
    }
    
    static void getAllTenants()
    {
        foreach (Tenant tenant in context.Tenants)
        {
            Console.WriteLine("{0}: {1}", tenant.TenantID, tenant.TenantName);
        }
    }

    static void updateTenant(int tenantId, string newTenantName)
    {
        var getExistingTenantName = context.Tenants.Find(tenantId);
        if (getExistingTenantName != null)
        {   
            getExistingTenantName.TenantName = newTenantName;
            context.SaveChanges();
            Console.WriteLine("Tenant Name Updated");
        }
        else
        {
            Console.WriteLine("Tenant Not Found");
        }
    }
    
    static void updateTenantFromConsole()
    {
            Console.Write("Enter the tenant ID");
            int tenantid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the tenant name: ");
            string tenantName = Console.ReadLine();
            updateTenant(tenantid, tenantName);
    }
    
    static bool deleteTenant(Tenant tenant)
    {
        context.Tenants.Remove(tenant);
        var res = context.SaveChanges();
        return (res > 0 ? true : false);
    }

    static void removeTenantFromDatabase()
    {
        Console.Write("Enter the tenant ID: ");
        int tenantId = Convert.ToInt32(Console.ReadLine());
        if(deleteTenant(context.Tenants.Find(tenantId)))Console.WriteLine("Tenant deleted");
        else Console.WriteLine("Tenant not deleted");
    }

    
    
    //Product Related Operations;
    static bool AddProduct(Product product)
    {
        context.Products.Add(product);
        var result = context.SaveChanges();
        return (result > 0 ? true : false);
    }
    
    static void addProductFromConsole()
    {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter product Serial: ");
            string productSerial = Console.ReadLine();
            if(AddProduct(new Product() { ProductName = productName, ProductSerial = productSerial })){Console.WriteLine("Product Added");}
            else{Console.WriteLine("Product Not Found");}
    }
    
    static void getAllProducts()
    {
        foreach (Product product in context.Products)
        {
            Console.WriteLine("{0}: {1}: {2}", product.ProductID, product.ProductName, product.ProductSerial);
        }
    }
    
    static void updateProduct(int productId, string productName, string productSerial)
    {
        var getExistingProductDetails = context.Products.Find(productId);
        if (getExistingProductDetails != null)
        {   
            getExistingProductDetails.ProductName = productName;
            getExistingProductDetails.ProductSerial = string.IsNullOrWhiteSpace(productSerial) == true ? getExistingProductDetails.ProductSerial : productSerial;
            context.SaveChanges();
            Console.WriteLine("Product Name Updated");
        }
        else
        {
            Console.WriteLine("Product Not Found");
        }
    }
    
    static void updateProductFromConsole()
    {
            Console.Write("Enter product ID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter product Serial: ");
            string productSerial = Console.ReadLine();
            
            updateProduct(productId, productName, productSerial);
    }
    
    static bool deleteProdcut(Product product)
    {
        context.Products.Remove(product);
        var res = context.SaveChanges();
        return (res > 0 ? true : false);
    }
    
    static void removeProductFromDatabase()
    {
        Console.Write("Enter the Product ID: ");
        int productsId = Convert.ToInt32(Console.ReadLine());
        if(deleteProdcut(context.Products.Find(productsId))){Console.WriteLine("Product Deleted");}
        else Console.WriteLine("Product Not Found");
    }
    
    //Product Sell Related Operations;
    static bool AddSell(ProductSale productSale)
    {
        context.ProductSales.Add(productSale);
        var result = context.SaveChanges();
        return (result > 0 ? true : false);
    }
    static void addSaleFromConsole()
    {
        
        Console.Write("Enter Product ID");
        int productId = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter Tenant ID");
        int tenantId = Convert.ToInt32(Console.ReadLine());
        
        Product p = context.Products.Find(productId);
        Tenant t = context.Tenants.Find(tenantId);

        if(AddSell(new ProductSale() { Product = p , Tenant = t})){Console.WriteLine("Sale Added");}
        else Console.WriteLine("Sale not added");

    }
    
    static void getAllProductsSale()
    {
        var products = context.ProductSales.Include(p => p.Product).Include(q=>q.Tenant).ToList();
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
                    addTenantFromConsole();
                    break;
                case 2:
                    addProductFromConsole();
                    break;
                case 3:
                    updateTenantFromConsole();
                    break;
                case 4:
                    updateProductFromConsole();
                    break;
                case 5:
                    removeTenantFromDatabase();
                    break;
                case 6:
                    removeProductFromDatabase();
                    break;
                case 7:
                    addSaleFromConsole();
                    break;
                case 8:
                    getAllTenants();
                    break;
                case 9:
                    getAllProducts();
                    break;
                case 10:
                    getAllProductsSale();
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