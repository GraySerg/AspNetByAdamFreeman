using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductRepository repository;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        const int PageSize = 3;
        
        public ViewResult List(string Category, int page = 1)
        {
            var query = repository.Products;
            if (!string.IsNullOrWhiteSpace(Category))
                query = query.Where(x => x.Category == Category);
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = query
.OrderBy(p => p.ProductID)
.Skip((page - 1) * PageSize)
.Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = query.Count()
                     
                }, CurrentCategory = Category
            };
            return View(model);
        }
    }
}