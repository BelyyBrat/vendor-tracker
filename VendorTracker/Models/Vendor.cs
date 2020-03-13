using System;
using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Vendor
  {
    public string Name {get; set;}
    public string Description {get; set;}
    public int VendorId {get;}    
    private static List <Vendor> _allVendors = new List <Vendor> () {};

    public Vendor (string name, string description)
    {
      Name = name;
      Description = description;
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

  }


}