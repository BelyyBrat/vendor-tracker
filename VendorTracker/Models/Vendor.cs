using System;
using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Vendor
  {
    public string Name {get; set;}
    public string Description {get; set;}
    private static List <Vendor> _allVendors = new List <Vendor> {};

    public int VendorId {get;} 
   
    public List <Order> AllVendorOrders {get; set;}
    public List <int> AllOrdersNumbers {get; set;}

    public int VendorOrderId;

    public Vendor (string name, string description)
    {
      Name = name;
      Description = description;
      AllVendorOrders = new List <Order> {};
      AllOrdersNumbers = new List <int> {};
      _allVendors.Add(this);
      VendorId = _allVendors.Count;
      VendorOrderId = 0;
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
      VendorOrderId ++;
      AllOrdersNumbers.Add(VendorOrderId);
    }
  }


}