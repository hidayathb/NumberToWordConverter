using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToWordConverter;

namespace NumberToWordConverterTest
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void TestMethod_InvalidNumber()
        {
            Assert.AreEqual("Invalid input", NumberConverter.ToWord(-1));
            Assert.AreEqual("Invalid input", NumberConverter.ToWord(1000000000));
        }

        [TestMethod]
        public void TestMethod_LessThan20()
        {
            Assert.AreEqual("one", NumberConverter.ToWord(1));

            Assert.AreEqual("twelve", NumberConverter.ToWord(12));
            Assert.AreEqual("eighteen", NumberConverter.ToWord(18));
        }

        [TestMethod]
        public void TestMethod_LessThan100()
        {
            Assert.AreEqual("twenty one", NumberConverter.ToWord(21));

            Assert.AreEqual("ninety nine", NumberConverter.ToWord(99));
        }

        [TestMethod]
        public void TestMethod_MoreThan1000()
        {
            Assert.AreEqual("eleven thousand", NumberConverter.ToWord(11000));
            Assert.AreEqual("thirteen thousand four hundred and fifty six", NumberConverter.ToWord(13456));
        }

        [TestMethod]
        public void TestMethod_MoreThanThousands()
        {
            Assert.AreEqual("fifty six million nine hundred and forty five thousand seven hundred and eighty one", 
                                NumberConverter.ToWord(56945781));
            Assert.AreEqual("five million nine hundred and forty five thousand seven hundred and eighty one",
                               NumberConverter.ToWord(5945781));
        }

        [TestMethod]
        public void TestMethod_RoundNumbers()
        {
            Assert.AreEqual("ten million", NumberConverter.ToWord(10000000));
            Assert.AreEqual("one million", NumberConverter.ToWord(1000000));
            Assert.AreEqual("one hundred thousand", NumberConverter.ToWord(100000));
            Assert.AreEqual("ten thousand", NumberConverter.ToWord(10000));
            Assert.AreEqual("one thousand", NumberConverter.ToWord(1000));
            Assert.AreEqual("one hundred", NumberConverter.ToWord(100));
            Assert.AreEqual("ten", NumberConverter.ToWord(10));
        }
    }
}
