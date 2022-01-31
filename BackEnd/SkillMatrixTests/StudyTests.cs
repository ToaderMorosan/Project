using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SkillMatrix1.Controllers;
/*using NUnit.Framework;*/
using SkillMatrix1.Data;
using SkillMatrix1.Dto;
using SkillMatrix1.Interfaces;
using SkillMatrix1.Models;
using SkillMatrix1.Repository;
using System.Collections.Generic;
using Xunit;

namespace SkillMatrixTests
{
    public class StudyTests
    {
        public class TestSimpleProductController
        {
            private readonly 

            [Fact]
            public void GetAllInterests()
            {
                var mockInterest = new Mock<IInterestRepository>();
                var mockMapper = new Mock<IMapper>();
                var mockEmployee = new Mock<IEmployeeRepository>();
                var controller = new InterestController(mockInterest.Object, mockMapper.Object, mockEmployee.Object);
                // act
                var result = controller.GetInterests();
                var okResult = result as ObjectResult;

                // assert
                Assert.IsNotNull(okResult);
                Assert.AreEqual(200, okResult.StatusCode);
            }

  /*          [TestMethod]
            public async Task GetAllProductsAsync_ShouldReturnAllProducts()
            {
                var testProducts = GetTestProducts();
                var controller = new SimpleProductController(testProducts);

                var result = await controller.GetAllProductsAsync() as List<Product>;
                Assert.AreEqual(testProducts.Count, result.Count);
            }

            [TestMethod]
            public void GetProduct_ShouldReturnCorrectProduct()
            {
                var testProducts = GetTestProducts();
                var controller = new SimpleProductController(testProducts);

                var result = controller.GetProduct(4) as OkNegotiatedContentResult<Product>;
                Assert.IsNotNull(result);
                Assert.AreEqual(testProducts[3].Name, result.Content.Name);
            }

            [TestMethod]
            public async Task GetProductAsync_ShouldReturnCorrectProduct()
            {
                var testProducts = GetTestProducts();
                var controller = new SimpleProductController(testProducts);

                var result = await controller.GetProductAsync(4) as OkNegotiatedContentResult<Product>;
                Assert.IsNotNull(result);
                Assert.AreEqual(testProducts[3].Name, result.Content.Name);
            }

            [TestMethod]
            public void GetProduct_ShouldNotFindProduct()
            {
                var controller = new SimpleProductController(GetTestProducts());

                var result = controller.GetProduct(999);
                Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            }
*/
/*            private List<Interest> GetInterests()
            {
                var testinterests = new List<Interest>();
                testinterests.Add(new Interest { Id = 1, Name = "Demo1"});
                testinterests.Add(new Interest { Id = 2, Name = "Demo2" });
                testinterests.Add(new Interest { Id = 3, Name = "Demo3" });
                testinterests.Add(new Interest { Id = 4, Name = "Demo4"});

                return testProducts;
            }*/
        }

    }
}