using Products.Lib;

namespace TestProducts;

[TestClass]
public class TestProductsImpl
{
    readonly ProductsImpl _productsImpl = new();
    readonly Product _testProduct = new("1", "Product");

    [TestMethod]
    public void TestAddProduct()
    {
        Assert.IsTrue(_productsImpl.AddProduct(_testProduct));
        Assert.IsFalse(_productsImpl.AddProduct(_testProduct));
    }

    [TestMethod]
    public void TestDeleteProduct()
    {
        Assert.IsFalse(_productsImpl.DeleteProduct(_testProduct));

        _productsImpl.AddProduct(_testProduct);

        Assert.IsTrue(_productsImpl.DeleteProduct(_testProduct));
    }

    [TestMethod]
    public void TestGetName()
    {
        _productsImpl.AddProduct(_testProduct);

        var name = _productsImpl.GetName(_testProduct.Id);

        Assert.IsTrue(_testProduct.Name.Equals(name));
        Assert.IsTrue(_productsImpl.GetName("fakeId").Equals(string.Empty));
    }

    [TestMethod]
    public void TestFindByName()
    {
        var secondTestProduct = new Product("2", _testProduct.Name);

        _productsImpl.AddProduct(_testProduct);
        _productsImpl.AddProduct(secondTestProduct);

        var productsFoundByName = _productsImpl.FindByName(secondTestProduct.Name);

        var testIds = new string[] { _testProduct.Id, secondTestProduct.Id };

        Assert.IsTrue(
            productsFoundByName.Count == testIds.Length
            && productsFoundByName.All(productId => testIds.Contains(productId))
        );
    }
}