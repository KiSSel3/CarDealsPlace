﻿using CarDealsPlace.Domain.Models;
using CarDealsPlace.Domain.ViewModels;
using CarDealsPlace.Filters;
using CarDealsPlace.Storage.Implementations;
using CarDealsPlace.Storage.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarDealsPlace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}