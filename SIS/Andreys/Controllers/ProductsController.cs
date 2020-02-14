namespace Andreys.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels.Products;

    using SIS.HTTP;
    using SIS.MvcFramework;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(ProductsAddInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect("/Products/Add");
            }

            if (input.Description.Length > 10)
            {
                return this.Redirect("/Products/Add");
            }

            if (input.Price < 0)
            {
                return this.Redirect("/Products/Add");
            }

            if (!input.ImageUrl.StartsWith("https"))
            {
                return this.Redirect("/Products/Add");
            }

            var productId = this.productsService.Add(input);

            return this.Redirect("/");
        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.productsService.GetById(id);

            if (viewModel == null)
            {
                return this.Error("Product not found.");
            }

            return this.View(viewModel);
        }

        public HttpResponse Delete(int id)
        {
            this.productsService.DeleteById(id);

            return this.Redirect("/");
        }
    }
}
