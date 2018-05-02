using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using cityList.Models;
using System;

namespace Wordlists.Controllers
{
    public class ItemsController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            
            List<cityItem> allItems = cityItem.GetAll();
            return View(allItems);
        }
        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
        [HttpPost("/items")]
        public ActionResult Create()
        {
          
          List<cityItem> allItems = cityItem.GetAll();
          return View("Index", allItems);
        }
    
    }
}
