using System;
using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Order
  {
    public string Title {get; set;}
    public string Description {get; set;}
    public int Price {get; set;}
    public DateTime Date = new DateTime();
    public int OrderId {get; } 
    private static List <Order> _vendorOrders = new List <Order> () {};

    public Order (string title, string description)
    {
      Title = title;
      Description = description;
      OrderId = _vendorOrders.Count;
    }

    public static List<Order> GetOrders()
    {
      return _vendorOrders;
    }

    public static void DeleteAllOrders()
    {
      _vendorOrders.Clear();
    }

    public static void DeleteOrder(int number)
    {
        _vendorOrders.RemoveAt(number-1);
    }

    public static Order FindOrder(int number)
    {
      return _vendorOrders[number-1];
    }

  }
}