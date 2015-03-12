using System;
using RobsDerbyCars.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobsDerbyCars.DAL;
using RobsDerbyCars.Controllers;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Car car1 = new Car();
        Car car2 = new Car();
        Car car3 = new Car();

        Comment com1 = new Comment();
        Comment com2 = new Comment();
        Comment com3 = new Comment();

        
        
   
        [TestMethod]
        public void Test_CarCount()
        {
            // arrange

            List<Car> carList = new List<Car>();
           
            carList.Add(car1);
            carList.Add(car2);
            carList.Add(car3);
            var fuow = new FakeUnitOfWork(carList);
            int target;

            // act
            target = fuow.CarCount;

            //Assert
            Assert.AreEqual(target, carList.Count());
        }


        [TestMethod]
        public void Test_CommentCount()
        {
            // arrange
            
            List<Comment> comList = new List<Comment>();

            comList.Add(com1); 
            comList.Add(com2);
            comList.Add(com3);
            var fuow = new FakeUnitOfWork(null,comList);
            int target;

            // act
            target = fuow.CommentCount;

            //Assert
            Assert.AreEqual(target, comList.Count());
        }

    }
}
