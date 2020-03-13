using System;
using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Vendor
  {
    public string Name {get; set;}
    public string Description {get; set;}
    public int VendorId {get;} 
    public int VendorOrderId {get; } 
   
    private static List <Vendor> _allVendors = new List <Vendor> {};
    public List <Order> AllVendorOrders {get; set;}

    public Vendor (string name, string description)
    {
      Name = name;
      Description = description;
      VendorId = _allVendors.Count;
      AllVendorOrders = new List <Order> {};
      VendorOrderId = AllVendorOrders.Count;
      _allVendors.Add(this);
    }

    public static List <Vendor> GetVendors()
    {
      return _allVendors;
    }

    public static void DeleteAllVendors()
    {
      _allVendors.Clear();
    }

    public static void DeleteVendor(int number)
    {
      _allVendors.RemoveAt(number-1);
    }    

    public static Vendor FindVendor(int number)
    {
      return _allVendors[number-1];
    }

    public void AddOrder (Order order)
    {
      AllVendorOrders.Add(order);
    }
  }


}