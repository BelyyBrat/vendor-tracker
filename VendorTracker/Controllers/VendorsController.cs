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
    public ActionResult DeleteAllVendors()
    {
      Vendor.DeleteAllVendors();
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{number}")]
    public ActionResult ShowVendor(int number)
    {
      Dictionary <string, object> model = new Dictionary <string, object>();
      Vendor foundVendor = Vendor.FindVendor(number);
      List <Order> foundVendorOrders = foundVendor.AllVendorOrders;
      model.Add("vendor", foundVendor);
      model.Add("orders", foundVendorOrders);
      return View(model);
    }

    [HttpPost("/vendors/{number}/delete")]
    public ActionResult DeleteVendor(string number)
    {
      Vendor.DeleteVendor(int.Parse(number));
      return RedirectToAction("Index");
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string orderTitle, string orderDescription, int orderPrice, DateTime orderDate)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.FindVendor(vendorId);
      Order newOrder = new Order(orderTitle, orderDescription, orderPrice, orderDate);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.AllVendorOrders;
      model.Add("vendor", foundVendor);
      model.Add("orders", vendorOrders);
      return View("ShowVendor", model);
    }

    [HttpPost("/vendors/{number}/deleteall")]
    public ActionResult DeleteAllOrders(int number)
    {
      Vendor foundVendor = Vendor.FindVendor(number);
      List<Order> vendorOrders = foundVendor.AllVendorOrders;
      vendorOrders.Clear();
      return RedirectToAction("ShowVendor");
    }
  }
}