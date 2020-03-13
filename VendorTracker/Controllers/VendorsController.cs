using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List <Vendor> allVendors = Vendor.GetVendors();
      return View(allVendors);
    }

    [HttpGet("/vendors/newvendor")]
    public ActionResult NewVendor()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string title, string description)
    {
      Vendor newVendor = new Vendor(title, description);
      return RedirectToAction("Index");
    }     
  }
}