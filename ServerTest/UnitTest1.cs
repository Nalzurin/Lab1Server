using Server;
using System.Drawing;

namespace ServerTest
{
    
    [TestClass]
    public class UnitTest1
    {
        byte[] rgbExpected, rgbActual;
        byte[] message;
        short val1Ex, val2Ex, val3Ex, val4Ex, val5Ex;
        short val1Ac, val2Ac, val3Ac, val4Ac, val5Ac;
        string textAc, textEx;

        [TestMethod]
        public void ClearDisplayTestCorrect()
        {
            message = new byte[] { 1, 255, 255, 255};
            rgbExpected = new byte[] { 255, 255, 255};
            Server.ServerProgram.ClearDisplay(message, out rgbActual);
            CollectionAssert.AreEqual(rgbExpected, rgbActual);
        }
        [TestMethod]
        public void ClearDisplayTestIncorrect()
        {
            message = new byte[] { 1, 255, 205, 255 };
            rgbExpected = new byte[] { 255, 255, 255 };
            Server.ServerProgram.ClearDisplay(message, out rgbActual);
            CollectionAssert.AreNotEqual(rgbExpected, rgbActual);
        }
        [TestMethod]
        public void ThreeVarTestCorrect()
        {
            message = new byte[] { 2, 5, 0, 10, 0, 255, 255, 255 };
            rgbExpected = new byte[] { 255, 255, 255};
            val1Ex = 5;
            val2Ex = 10;
            Server.ServerProgram.ThreeVarsDecode(message, out val1Ac, out val2Ac, out rgbActual );
            CollectionAssert.AreEqual(rgbExpected, rgbActual);
            Assert.AreEqual(val1Ex, val1Ac);
            Assert.AreEqual(val2Ex, val2Ac);
        }
        [TestMethod]
        public void ThreeVarTestIncorrect()
        {
            message = new byte[] { 2, 92, 0, 102, 0, 215, 255, 255 };
            rgbExpected = new byte[] { 255, 255, 255 };
            val1Ex = 5;
            val2Ex = 10;
            Server.ServerProgram.ThreeVarsDecode(message, out val1Ac, out val2Ac, out rgbActual);
            CollectionAssert.AreNotEqual(rgbExpected, rgbActual);
            Assert.AreNotEqual(val1Ex, val1Ac);
            Assert.AreNotEqual(val2Ex, val2Ac);
        }

        [TestMethod]
        public void FiveVarTestCorrect()
        {
            message = new byte[] { 3, 5, 0, 10, 0, 25, 0, 13, 0, 255, 0, 0 };
            rgbExpected = new byte[] { 255, 0, 0 };
            val1Ex = 5;
            val2Ex = 10;
            val3Ex = 25;
            val4Ex = 13;
            Server.ServerProgram.FiveVarsDecode(message, out val1Ac, out val2Ac, out val3Ac, out val4Ac, out rgbActual);
            CollectionAssert.AreEqual(rgbExpected, rgbActual);
            Assert.AreEqual(val1Ex, val1Ac);
            Assert.AreEqual(val2Ex, val2Ac);
            Assert.AreEqual(val3Ex, val3Ac);
            Assert.AreEqual(val4Ex, val4Ac);
        }
        [TestMethod]
        public void FiveVarTestIncorrect()
        {
            message = new byte[] { 3, 50, 0, 100, 0, 250, 0, 130, 0, 255, 2, 0 };
            rgbExpected = new byte[] { 255, 0, 0 };
            val1Ex = 5;
            val2Ex = 10;
            val3Ex = 25;
            val4Ex = 13;
            Server.ServerProgram.FiveVarsDecode(message, out val1Ac, out val2Ac, out val3Ac, out val4Ac, out rgbActual);
            CollectionAssert.AreNotEqual(rgbExpected, rgbActual);
            Assert.AreNotEqual(val1Ex, val1Ac);
            Assert.AreNotEqual(val2Ex, val2Ac);
            Assert.AreNotEqual(val3Ex, val3Ac);
            Assert.AreNotEqual(val4Ex, val4Ac);
        }
        [TestMethod]
        public void CircleTestCorrect()
        {
            message = new byte[] { 5, 5, 0, 10, 0, 25, 0, 0, 0, 0 };
            rgbExpected = new byte[] { 0, 0, 0 };
            val1Ex = 5;
            val2Ex = 10;
            val3Ex = 25;
            Server.ServerProgram.CircleDecoder(message, out val1Ac, out val2Ac, out val3Ac, out rgbActual);
            CollectionAssert.AreEqual(rgbExpected, rgbActual);
            Assert.AreEqual(val1Ex, val1Ac);
            Assert.AreEqual(val2Ex, val2Ac);
            Assert.AreEqual(val3Ex, val3Ac);
        }
        [TestMethod]
        public void CircleTestIncorrect()
        {
            message = new byte[] { 3, 50, 0, 100, 0, 250, 0, 255, 2, 0 };
            rgbExpected = new byte[] { 255, 0, 0 };
            val1Ex = 5;
            val2Ex = 10;
            val3Ex = 25;
            Server.ServerProgram.CircleDecoder(message, out val1Ac, out val2Ac, out val3Ac, out rgbActual);
            CollectionAssert.AreNotEqual(rgbExpected, rgbActual);
            Assert.AreNotEqual(val1Ex, val1Ac);
            Assert.AreNotEqual(val2Ex, val2Ac);
            Assert.AreNotEqual(val3Ex, val3Ac);
        }


        [TestMethod]
        public void RoundedRectangleCorrect()
        {
            message = new byte[] { 2, 5, 0, 10, 0, 25, 0, 133, 0, 15, 0, 0, 0, 0 };
            rgbExpected = new byte[] { 0, 0, 0 };
            val1Ex = 5;
            val2Ex = 10;
            val3Ex = 25;
            val4Ex = 133;
            val5Ex = 15;
            Server.ServerProgram.RoundedRectangleDecoder(message, out val1Ac, out val2Ac, out val3Ac, out val4Ac, out val5Ac, out rgbActual);
            CollectionAssert.AreEqual(rgbExpected, rgbActual);
            Assert.AreEqual(val1Ex, val1Ac);
            Assert.AreEqual(val2Ex, val2Ac);
            Assert.AreEqual(val3Ex, val3Ac);
            Assert.AreEqual(val4Ex, val4Ac);
            Assert.AreEqual(val5Ex, val5Ac);
        }
        [TestMethod]
        public void RoundedRectangleIncorrect()
        {
            message = new byte[] { 2, 50, 0, 100, 0, 250, 0, 135, 0, 150, 0, 0, 0, 1 };
            rgbExpected = new byte[] { 0, 0, 0 };
            val1Ex = 5;
            val2Ex = 10;
            val3Ex = 25;
            val4Ex = 133;
            val5Ex = 15;
            Server.ServerProgram.RoundedRectangleDecoder(message, out val1Ac, out val2Ac, out val3Ac, out val4Ac, out val5Ac, out rgbActual);
            CollectionAssert.AreNotEqual(rgbExpected, rgbActual);
            Assert.AreNotEqual(val1Ex, val1Ac);
            Assert.AreNotEqual(val2Ex, val2Ac);
            Assert.AreNotEqual(val3Ex, val3Ac);
            Assert.AreNotEqual(val4Ex, val4Ac);
            Assert.AreNotEqual(val5Ex, val5Ac);
        }

        [TestMethod]
        public void TextCorrect()
        {
            message = new byte[] { 2, 5, 0, 10, 0, 0, 0, 0, 25, 0, 5, 0, 72, 101, 108, 108, 111 };
            rgbExpected = new byte[] { 0, 0, 0 };
            val1Ex = 5;
            val2Ex = 10;
            val3Ex = 25;
            val4Ex = 5;
            textEx = "Hello";
            Server.ServerProgram.TextDecoder(message, out val1Ac, out val2Ac, out val3Ac, out val4Ac, out rgbActual, out textAc);
            CollectionAssert.AreEqual(rgbExpected, rgbActual);
            Assert.AreEqual(val1Ex, val1Ac);
            Assert.AreEqual(val2Ex, val2Ac);
            Assert.AreEqual(val3Ex, val3Ac);
            Assert.AreEqual(val4Ex, val4Ac);
            Assert.AreEqual(textEx, textAc);
        }
        [TestMethod]
        public void TextIncorrect()
        {
            message = new byte[] { 2, 50, 0, 100, 0, 0, 0, 0, 250, 0, 50, 0, 72, 101, 198, 108, 111 };
            rgbExpected = new byte[] { 0, 0, 0 };
            val1Ex = 5;
            val2Ex = 10;
            val3Ex = 25;
            val4Ex = 5;
            textAc = "Hello";
            Server.ServerProgram.RoundedRectangleDecoder(message, out val1Ac, out val2Ac, out val3Ac, out val4Ac, out val5Ac, out rgbActual);
            CollectionAssert.AreNotEqual(rgbExpected, rgbActual);
            Assert.AreNotEqual(val1Ex, val1Ac);
            Assert.AreNotEqual(val2Ex, val2Ac);
            Assert.AreNotEqual(val3Ex, val3Ac);
            Assert.AreNotEqual(val4Ex, val4Ac);
            Assert.AreNotEqual(textEx, textAc);
        }

    }
}