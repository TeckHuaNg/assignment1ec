using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using assignment1comp2007.Controllers;
using Moq;
using assignment1comp2007.Models;
using System.Linq;
using System.Web.Mvc;

namespace assignment1comp2007.Tests.Controllers
{
    /// <summary>
    /// Summary description for CompanyControllerTest
    /// </summary>
    [TestClass]
    public class CompanyControllerTest
    {
        CompaniesController controller;
        Mock<IMockCompaniesRepository> mock;
        List<Company> companies;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IMockCompaniesRepository>();

            companies = new List<Company>
            {
                new Company { CompanyName = "Company 1", BrandId = 1},
                new Company { CompanyName = "Comapny 2", BrandId = 2},
                new Company { CompanyName = "Company 3", BrandId = 3}
            };

            mock.Setup(m => m.Companies).Returns(companies.AsQueryable());
            controller = new CompaniesController(mock.Object);
        }

       [TestMethod]
       public void IndexViewTest()
        {
            //act
            var actual = controller.Index();

            //assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void IndexLoadsTest()
        {
            //act
            var actual = (List<Company>)((ViewResult)controller.Index()).Model;

            //assert
            CollectionAssert.AreEqual(companies, actual);
        }
    }
}
