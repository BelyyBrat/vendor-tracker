using System;
using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Order
  {
    public string Title {get; set;}
    public string Description {get; set;}
    public int Price {get; set;}
    public DateTime OrderDate = new DateTime();
    public int AllOrderId {get; } 
    private static List <Order> _allOrders = new List <Order> {};

    public Order (string title, string description, int price, DateTime orderDate)
    {
      Title = title;
      Description = description;
      AllOrderId = _allOrders.Count;
      Price = price;
      OrderDate = orderDate;
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