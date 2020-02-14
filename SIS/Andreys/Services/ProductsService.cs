namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.Models;
    using Andreys.Models.Enum;
    using Andreys.ViewModels.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public int Add(ProductsAddInputModel productAddInputModel)
        {
            var genderAsEnum = Enum.Parse<ProductGender>(productAddInputModel.Gender);
            var categoryAsEnum = Enum.Parse<ProductCategory>(productAddInputModel.Category);

            var product = new Product
            {
                Name = productAddInputModel.Name,
                Description = productAddInputModel.Description,
                ImageUrl = productAddInputModel.ImageUrl,
                Price = productAddInputModel.Price,
                Category = categoryAsEnum,
                Gender = genderAsEnum
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();

            return product.Id;
        }

        public IEnumerable<Product> GetAll()
            => this.db.Products.Select(x => new Product
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Price = x.Price
            })
            .ToArray();


        public Product GetById(int id)
            => this.db.Products.FirstOrDefault(x => x.Id == id);

        public void DeleteById(int id)
        {
            var product = this.GetById(id);

            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }
    }
}
