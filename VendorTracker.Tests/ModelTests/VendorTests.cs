using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using VendorTracker.Models;
using System;

namespace VendorTracker.Tests
{

  public class VendorTest: IDisposable
  {

    public void Dispose()
    {
      Vendor.DeleteAllVendors();
    }

    [TestMethod]
    public void FindVendor_FindVendorByProvidedId_Vendor()
    {

    }
  }
}