namespace DemoBlaze.Models;

public class ProductInCart
{
    private string ImageUrl { get; set; }
    private string Title { get; set; }
    private string Price { get; set; }

    public ProductInCart(string image, string title, string price)
    {
        ImageUrl = image;
        Title = title;
        Price = price;
    }
    
    public override bool Equals(object obj)
    {
        if (obj is not ProductInCart other) return false;
        return ImageUrl == other.ImageUrl 
               && Title == other.Title 
               && Price == other.Price;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ImageUrl, Title, Price);
    }
    public override string ToString() => $"{ImageUrl} | {Title} | {Price}";
}