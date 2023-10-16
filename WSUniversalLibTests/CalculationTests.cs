using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using WSUniversalLib;

namespace WSUniversalLibTests
{
    [TestClass]
    public class CalculationTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            double expected = 114146;
            //act
            float actual = Calculation.GetQuantityForProduct(3, 1, 15, 20, 45);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        private void ReadInputData(string fileName, out int productType, out int materialType, out int count, out float width, out float length)
        {
            string path = @"..\\..\\..\\..\\TestingData\\" + fileName;
            string[] data = File.ReadAllLines(path);

            productType = int.Parse(data[0]);
            materialType = int.Parse(data[1]);
            count = int.Parse(data[2]);
            width = float.Parse(data[3]);
            length = float.Parse(data[4]);
        }

        private int ReadOutputData(string fileName)
        {
            string path = @"..\\..\\..\\..\\TestingData\\" + fileName;
            string data = File.ReadAllText(path);
            return int.Parse(data);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            int productType, materialType, count;
            float width, length;

            for (int i = 1; i < 20; i++)
            {
                string input = "";
                string output = "";
                if (i < 10)
                {
                    input = $"InputData_Easy_0{i}.txt";
                }
                else
                {
                    input = $"InputData_Easy_{i}.txt";
                }
                if (i < 10)
                {
                    output = $"OutputData_Easy_0{i}.txt";
                }
                else
                {
                    output = $"OutputData_Easy_{i}.txt";
                }


                ReadInputData(input, out productType, out materialType, out count, out width, out length);

                int expected = ReadOutputData(output);
                //Act
                int actual = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);

                //Assert
                Assert.AreEqual(expected, actual);
            }


        }
    }
}
