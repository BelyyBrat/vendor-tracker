using System;
using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Order
  {
    public string Title {get; set;}
    public string Description {get; set;}
    public int Price {get; set;}

    public int OrderId {get; }
    public DateTime OrderDate = new DateTime();
    private static List <Order> _allOrders = new List <Order> {};

    public Order (string title, string description, int price, DateTime orderDate)
    {
      Title = title;
      Description = description;
      Price = price;
      OrderDate = orderDate;
      _allOrders.Add(this);
      OrderId = _allOrders.Count;
    }

    public static List<Order> GetOrders()
    {
      return _allOrders;
    }

    public static void DeleteAllOrders()
    {
      _allOrders.Clear();
    }

    public static void DeleteOrder(int number)
    {
        _allOrders.RemoveAt(number-1);
    }

    public static Order FindOrder(int number)
    {
      return _allOrders[number-1];
    }

  }
}