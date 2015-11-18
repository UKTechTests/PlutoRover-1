using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlutoRoverUnitTest
{
    [TestClass]
    public class MovementTest
    {

        #region Basic Movement

        [TestMethod]
        public void TestMoveForward2()
        {
            PlutoRoverAPI.Core rover = new PlutoRoverAPI.Core();

            String result = rover.Move("FF");

            Assert.AreEqual("OK", result);

            Assert.AreEqual("0, 2, N", rover.GetPosition());
        }

        [TestMethod]
        public void TestMoveForward2TurnRightForward2()
        {
            PlutoRoverAPI.Core rover = new PlutoRoverAPI.Core();

            String result = rover.Move("FFRFF");

            Assert.AreEqual("OK", result);

            Assert.AreEqual("2, 2, E", rover.GetPosition());
        }

        [TestMethod]
        public void TestMoveForward3Backward2()
        {
            PlutoRoverAPI.Core rover = new PlutoRoverAPI.Core();

            String result = rover.Move("FFFBB");

            Assert.AreEqual("OK", result);

            Assert.AreEqual("0, 1, N", rover.GetPosition());
        }

        #endregion

        #region Wrapping

        [TestMethod]
        public void TestMoveBackward3()
        {
            PlutoRoverAPI.Core rover = new PlutoRoverAPI.Core();

            String result = rover.Move("BBB");

            Assert.AreEqual("OK", result);

            Assert.AreEqual("0, 97, N", rover.GetPosition());
        }

        [TestMethod]
        public void TestMoveForward2TurnLeftForward1()
        {
            PlutoRoverAPI.Core rover = new PlutoRoverAPI.Core();

            String result = rover.Move("FFLF");

            Assert.AreEqual("OK", result);

            Assert.AreEqual("99, 2, W", rover.GetPosition());
        }

        #endregion

        #region Obstacles

        [TestMethod]
        public void TestMoveAndReportObstacle()
        {
            PlutoRoverAPI.Core rover = new PlutoRoverAPI.Core();

            String result = rover.Move("FRFF");

            Assert.AreEqual("Obstacle at 2, 1", result);

            Assert.AreEqual("1, 1, E", rover.GetPosition());
        }

        #endregion
    }
}
