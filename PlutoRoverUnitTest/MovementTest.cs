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

            rover.Move("FF");

            Assert.AreEqual("0, 2, N", rover.GetPosition());
        }

        [TestMethod]
        public void TestMoveForward2TurnRightForward2()
        {
            PlutoRoverAPI.Core rover = new PlutoRoverAPI.Core();

            rover.Move("FFRFF");

            Assert.AreEqual("2, 2, E", rover.GetPosition());
        }

        [TestMethod]
        public void TestMoveForward3Backward2()
        {
            PlutoRoverAPI.Core rover = new PlutoRoverAPI.Core();

            rover.Move("FFFBB");

            Assert.AreEqual("0, 1, N", rover.GetPosition());
        }

        #endregion

        #region Wrapping

        [TestMethod]
        public void TestMoveBackward3()
        {
            PlutoRoverAPI.Core rover = new PlutoRoverAPI.Core();

            rover.Move("BBB");

            Assert.AreEqual("0, 97, N", rover.GetPosition());
        }

        [TestMethod]
        public void TestMoveForward2TurnLeftForward1()
        {
            PlutoRoverAPI.Core rover = new PlutoRoverAPI.Core();

            rover.Move("FFLF");

            Assert.AreEqual("99, 2, W", rover.GetPosition());
        }

        #endregion

    }
}
