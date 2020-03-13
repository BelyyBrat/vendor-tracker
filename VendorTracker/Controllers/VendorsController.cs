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
    public ActionResult Create(string name, string description)
    {
      Vendor newVendor = new Vendor(name, description);
      return RedirectToAction("Index");
    }

    [HttpPost("/vendors/deleteall")]
    public ActionResult DeleteAll()
    {
      Vendor.DeleteAllVendors();
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{number}")]
    public ActionResult ShowVendor(int number)
    {
      Vendor foundVendor = Vendor.FindVendor(number);
      return View(foundVendor);
    }

    [HttpPost("/vendors/{number}/delete")]
    public ActionResult DeleteVendor(string number)
    {
      Vendor.DeleteVendor(int.Parse(number));
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/neworder")]
    public ActionResult NewOrder()
    {
      return View();
    }         
  }
}