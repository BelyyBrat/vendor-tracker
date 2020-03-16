using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;
using System;
using System.Collections.Generic;

namespace VendorTracker.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult ShowOrder(int vendorId, int orderId)
    { 
      Order order = Order.FindOrder(orderId);
      Vendor vendor = Vendor.FindVendor(vendorId);
      Dictionary <string, object> model = new Dictionary <string, object>();
      model.Add("vendor", vendor);
      model.Add("order", order);
      return View(model);
    }

    [HttpGet("/vendors/{vendorId}/orders/neworder")]
    public ActionResult NewOrder(int vendorId)
    {
      Vendor vendor = Vendor.FindVendor(vendorId);
      return View(vendor);
    }


 
  }
}
