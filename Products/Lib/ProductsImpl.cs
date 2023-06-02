namespace Products.Lib;

public class ProductsImpl
{
    // Product.Id -> Product
    private Dictionary<string, Product> _products = new Dictionary<string, Product>();

    private bool HasProduct(string productId)
    {
        return this._products.ContainsKey(productId);
    }

    public bool AddProduct(Product product)
    {
        if (this.HasProduct(product.Id))
        {
            return false;
        }

        this._products.Add(product.Id, product);
        return true;
    }

    public bool DeleteProduct(Product product)
    {
        if (!this.HasProduct(product.Id))
        {
            return false;
        }

        this._products.Remove(product.Id);
        return true;
    }

    public string GetName(string productId)
    {
        var product = this._products.GetValueOrDefault(productId, null);

        if (product is null)
        {
            return string.Empty;
        }

        return product.Name;
    }

    public List<string> FindByName(string name)
    {
        return this._products.Values.Where(product => product.Name == name)
            .Select(product => product.Id)
            .ToList();
    }
}