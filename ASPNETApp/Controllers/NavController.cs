﻿using SportsStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        readonly IProductRepository repository;
        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }
        
        public PartialViewResult Menu(string category)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
.Select(x => x.Category)
.Distinct()
.OrderBy(x => x);
            return PartialView(categories);
        }
    }
}