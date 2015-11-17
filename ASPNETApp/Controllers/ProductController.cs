using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETApp.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductRepository repository;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        const int PageSize = 4;
        // GET: Product
        public ViewResult List(int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
.OrderBy(p => p.ProductID)
.Skip((page - 1) * PageSize)
.Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            };
            return View(model);
        }
    }
}