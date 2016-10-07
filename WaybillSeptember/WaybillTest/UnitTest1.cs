using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using WaybillNamespace;

namespace WaybillTest
{
    [TestClass]
    public class WaybillTesting
    {
        [TestMethod]
        public void LineCounterTest()
        {
            StreamReader testFile = new StreamReader(@"C:\test.txt");
            var expectedCount = 4;
            var lineCounter = new Waybill();

            var count = lineCounter.LineCounter(testFile);

            Assert.AreEqual(expectedCount, count);
        }

        [TestMethod]
        public void LineReaderTest()
        {
            StreamReader testFile = new StreamReader(@"C:\test.txt");
            string[] expectedResult = {   "0| articul1|  568|    7|  3000",
                                          "1| articul2|  826|   15| 12000",
                                          "2| articul3|  896|    2|  1000" };
            var lineReader = new Waybill();

            var result = lineReader.LineReader(testFile);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void LineParserTest()
        {
            var testLine = "0| articul1|  568|    7|  3000";
            string[] expectedResult = { "0", " articul1", "  568", "    7", "  3000" };
            var lineParser = new Waybill();

            var result = lineParser.LineParser(testLine);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WeightCheckAllowed()
        {
            StreamReader testFile = new StreamReader(@"C:\test.txt");
            var allowedWeight = 9999999999;
            var weightCheck = new Waybill();
            var expectedResult = "Допустимая масса";

            var result = weightCheck.WeightCheck(testFile, allowedWeight);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WeightCheckNotAllowed()
        {
            StreamReader testFile = new StreamReader(@"C:\test.txt");
            var allowedWeight = 10;
            var weightCheck = new Waybill();
            var expectedResult = "Масса превышает допустимую";

            var result = weightCheck.WeightCheck(testFile, allowedWeight);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AmountCalculationCheck()
        {
            StreamReader testFile = new StreamReader(@"C:\test.txt");
            var expectedSum = 16000;
            var amountCalculation = new Waybill();

            var sum = amountCalculation.TotalAmountCalculation(testFile);

            Assert.AreEqual(expectedSum, sum);
        }

        [TestMethod]
        public void SendEmailTest()
        {
            StreamReader testFile = new StreamReader(@"C:\test.txt");
            var expectedResult = true;
            var email = "lizardia@yandex.ru";
            var sendEmail = new Waybill();

            var result = sendEmail.SendEmail(testFile, email);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
