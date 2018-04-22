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

        [TestMethod]
        public void DetailsInvalidTest()
        {
            //act
            var actual = (ViewResult)controller.Details(5);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DetailsNullId()
        {
            //act
            var actual = (ViewResult)controller.Details(null);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdTest()
        {
            //act
            var actual = (Company)((ViewResult)controller.Details(2)).Model;

            //assert
            Assert.AreEqual(companies[1], actual);
        }

        [TestMethod]
        public void EditValidId()
        {
            //act
            var actual = ((ViewResult)controller.Edit(1)).Model;

            //assert
            Assert.AreEqual(companies[0], actual);
        }

        [TestMethod]
        public void EditInvalidId()
        {
            //act
            var actual = (ViewResult)controller.Edit(100);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void EditNullId()
        {
            int? id = null;

            //act
            var actual = (ViewResult)controller.Edit(id);

            //assert
            Assert.AreEqual("Error", actual.ViewName);
        }

        //POST
        [TestMethod]
        public void EditPostValid()
        {
            //act
            var actual = (RedirectToRouteResult)controller.Edit(companies[0]);

            //assert
            Assert.AreEqual("Index", actual.RouteValues["action"]);
        }

        [TestMethod]
        public void EditPostInvalid()
        {
            //arrange
            controller.ModelState.AddModelError("key", "update error");

            //act
            var actual = (ViewResult)controller.Edit(companies[0]);

            //assert
            Assert.AreEqual("Edit", actual.ViewName);
        }




    }
}
