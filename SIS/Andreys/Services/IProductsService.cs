namespace Andreys.Services
{
    using Andreys.Models;
    using Andreys.ViewModels.Products;
    using System.Collections.Generic;

    public interface IProductsService
    {
        int Add(ProductsAddInputModel productAddInputModel);

        Product GetById(int id);

        IEnumerable<Product> GetAll();

        void DeleteById(int id);
    }
}
