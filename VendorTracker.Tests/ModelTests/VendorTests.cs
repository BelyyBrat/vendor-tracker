using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VendorTracker.Models;
using System;

namespace VendorTracker.Tests
{
  [TestClass]
  public class VendorTest: IDisposable
  {

    public void Dispose()
    {
      Vendor.DeleteAllVendors();
    }

    [TestMethod]
    public void FindVendor_FindVendorByProvidedId_Vendor()
    {
      Vendor Bob = new Vendor("Bob", "Bob from 5th avenue");
      Vendor John = new Vendor("John", "John from 6th avenue");
      Vendor Tom = new Vendor("Tom", "Tom from 5th avenue");
      List <Vendor> AllVendors = Vendor.GetVendors();
      Assert.AreEqual(AllVendors.Count, 3);
      Assert.AreEqual(AllVendors[1], John);
      Assert.AreEqual(AllVendors[0].VendorId, 1);

    }

    [TestMethod]
    public void FindOrder_FindOrderByProvidedId_Order()
    {
      Vendor Bob = new Vendor("Bob", "Bob from 5th avenue");
      Order OrderOne = new Order ("OrderOne", "First order", 5, new DateTime (2019, 2, 2));
      Order OrderTwo = new Order ("OrderOne", "First order", 5, new DateTime (2019, 2, 3));
      Order OrderThree = new Order ("OrderOne", "First order", 5, new DateTime (2019, 2, 4));

      Bob.AddOrder(OrderOne);
      Bob.AddOrder(OrderTwo);
      Bob.AddOrder(OrderThree);

      Assert.AreEqual(Bob.AllVendorOrders.Count, 3);
      Assert.AreEqual(Bob.AllVendorOrders[0], OrderOne);
      Assert.AreEqual(Bob.AllOrdersNumbers[0], 1);
      Assert.AreEqual(Bob.AllOrdersNumbers[1], 2);
    }    
  }
}