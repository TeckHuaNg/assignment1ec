using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment1comp2007.Controllers;

namespace assignment1comp2007.Tests.Controllers
{
    /// <summary>
    /// Summary description for CompanyControllerTest
    /// </summary>
    [TestClass]
    public class CompanyControllerTest
    {
       [TestMethod]
       public void IndexViewTest()
        {
            //arrange
            CompaniesController controller = new CompaniesController();

            //act
            var actual = controller.Index();

            //assert

        }
    }
}
