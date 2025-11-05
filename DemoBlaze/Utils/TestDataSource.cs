namespace DemoBlaze.Utils;

public class TestDataSource
{
    public static IEnumerable<TestCaseData> GetTestCasesForCartPage()
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(baseDir, "Resources", "testDataForCartPage.csv");
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            string productImageUrl = parts[0];
            string productTitle = parts[1];
            string productPrice = parts[2];
            yield return new TestCaseData(productImageUrl, productTitle, productPrice)
                .SetName($"The product's imageUrl is {productImageUrl}, its title is {productTitle} and its price is {productPrice}");
        }
    }
    
    public static IEnumerable<TestCaseData> GetTestCasesForProductPage()
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(baseDir, "Resources", "testDataForProductPage.csv");
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            string productName = parts[0];
            string productPrice = parts[1];
            string productDescription = parts[2];
            yield return new TestCaseData(productName, productPrice, productDescription)
                .SetName($"The product's name is {productName}, its price is {productPrice} and its description: {productDescription}");
        }
    }
}