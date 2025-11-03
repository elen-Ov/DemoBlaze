namespace DemoBlaze.Models;

public class Product
{
    public string ProductTitle { get; set; }
    public string ProductPrice { get; set; }

    public Product(string productTitle, string productPrice)
    {
        ProductTitle = productTitle;
        ProductPrice = productPrice;
    }
}