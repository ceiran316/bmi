using System;
using BMICalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BMICalculatorUnitTests
{
    [TestClass]
    public class BMIUnitTests
    {
        [TestMethod]
        public void TestWeightStone_GetAndSet()
        {
            //Arrange
            BMI b1 = new BMI();

            //Act
            b1.WeightStones = 6;

            //Assert
            Assert.AreEqual(6, b1.WeightStones);
        }


        [TestMethod]
        public void TestWeightPounds_GetAndSet()
        {
            //Arrange
            BMI b1 = new BMI();

            //Act
            b1.WeightPounds = 6;

            //Assert
            Assert.AreEqual(6, b1.WeightPounds);
        }

        [TestMethod]
        public void TestHeightFeet_GetAndSet()
        {
            //Arrange
            BMI b1 = new BMI();

            //Act
            b1.HeightFeet = 6;

            //Assert
            Assert.AreEqual(6, b1.HeightFeet);
        }

        [TestMethod]
        public void TestHeightInches_GetAndSet()
        {
            //Arrange
            BMI b1 = new BMI();

            //Act
            b1.HeightInches = 6;

            //Assert
            Assert.AreEqual(6, b1.HeightInches);
        }

        [DataRow(6, 3, 5, 7)]
        [DataTestMethod]
        public void TestBMIValue_ReturnBMI(int stone, int pound, int feet, int inch)
        {
            //Arrange
            BMI b1 = new BMI(stone, pound, feet, inch);

            double totalWeightInPounds = (stone * 14) + pound;
            double totalHeightInInches = (feet * 12) + inch;

            // do conversions to metric
            double totalWeightInKgs = totalWeightInPounds * 0.453592;
            double totalHeightInMetres = totalHeightInInches * 0.0254;

            //Act
            double actualResult = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));

            //Assert
            Assert.AreEqual(actualResult, b1.BMIValue);
        }

        [DataRow(6, 3, 5, 7)]
        [DataTestMethod]
        public void TestBMICategory_Underweight(int stone, int pound, int feet, int inch)
        {
            //Arrange
            BMI b1 = new BMI(stone, pound, feet, inch);

            double totalWeightInPounds = (stone * 14) + pound;
            double totalHeightInInches = (feet * 12) + inch;

            // do conversions to metric
            double totalWeightInKgs = totalWeightInPounds * 0.453592;
            double totalHeightInMetres = totalHeightInInches * 0.0254;

            //Act
            double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));
            BMICategory expectedResult = BMICategory.Underweight;

            //Assert
            Assert.AreEqual(expectedResult, b1.BMICategory);
        }

        [DataRow(10, 3, 5, 7)]
        [DataTestMethod]
        public void TestBMICategory_Normalweight(int stone, int pound, int feet, int inch)
        {
            //Arrange
            BMI b1 = new BMI(stone, pound, feet, inch);

            double totalWeightInPounds = (stone * 14) + pound;
            double totalHeightInInches = (feet * 12) + inch;

            // do conversions to metric
            double totalWeightInKgs = totalWeightInPounds * 0.453592;
            double totalHeightInMetres = totalHeightInInches * 0.0254;

            //Act
            double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));
            BMICategory expectedResult = BMICategory.Normal;

            //Assert
            Assert.AreEqual(expectedResult, b1.BMICategory);
        }

        [DataRow(12, 3, 5, 7)]
        [DataTestMethod]
        public void TestBMICategory_Overweight(int stone, int pound, int feet, int inch)
        {
            //Arrange
            BMI b1 = new BMI(stone, pound, feet, inch);

            double totalWeightInPounds = (stone * 14) + pound;
            double totalHeightInInches = (feet * 12) + inch;

            // do conversions to metric
            double totalWeightInKgs = totalWeightInPounds * 0.453592;
            double totalHeightInMetres = totalHeightInInches * 0.0254;

            //Act
            double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));
            BMICategory expectedResult = BMICategory.Overweight;

            //Assert
            Assert.AreEqual(expectedResult, b1.BMICategory);
        }

        [DataRow(23, 3, 5, 7)]
        [DataTestMethod]
        public void TestBMICategory_Obese(int stone, int pound, int feet, int inch)
        {
            //Arrange
            BMI b1 = new BMI(stone, pound, feet, inch);

            double totalWeightInPounds = (stone * 14) + pound;
            double totalHeightInInches = (feet * 12) + inch;

            // do conversions to metric
            double totalWeightInKgs = totalWeightInPounds * 0.453592;
            double totalHeightInMetres = totalHeightInInches * 0.0254;

            //Act
            double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));
            BMICategory expectedResult = BMICategory.Obese;

            //Assert
            Assert.AreEqual(expectedResult, b1.BMICategory);
        }

        [DataRow(6, 3, 5, 7)]
        [DataTestMethod]
        public void TestHealthyWeight_Underweight(int stone, int pound, int feet, int inch)
        {
            //Arrange
            //BMI b2 = new BMI();
            BMI b1 = new BMI(stone, pound, feet, inch);

            double totalWeightInPounds = (stone * 14) + pound;
            double totalHeightInInches = (feet * 12) + inch;

            // do conversions to metric
            double totalWeightInKgs = totalWeightInPounds * 0.453592;
            double totalHeightInMetres = totalHeightInInches * 0.0254;

            double kgToLose = 0;
            double maxhealthyWeight = 0;

            //Act
            double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));
            maxhealthyWeight = 24.9 * (Math.Pow(totalHeightInMetres, 2));
            kgToLose = totalWeightInKgs - maxhealthyWeight;

            String expectedResult = "\nYour Current weight is 39.462504kg" +
                "\nIdeal maximum weight for someone 1.7018metres is 72.113468676kg" +
                "\nMaximum weight in kilogramms to put on is 32.650964676";

            //Assert
            Assert.AreEqual(expectedResult, b1.HealthyWeight);
        }

        [DataRow(10, 3, 5, 7)]
        [DataTestMethod]
        public void TestHealthyWeight_Normalweight(int stone, int pound, int feet, int inch)
        {
            //Arrange
            BMI b1 = new BMI(stone, pound, feet, inch);

            double totalWeightInPounds = (stone * 14) + pound;
            double totalHeightInInches = (feet * 12) + inch;

            // do conversions to metric
            double totalWeightInKgs = totalWeightInPounds * 0.453592;
            double totalHeightInMetres = totalHeightInInches * 0.0254;

            double kgToLose = 0;
            double maxhealthyWeight = 0;

            //Act
            double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));
            maxhealthyWeight = 24.9 * (Math.Pow(totalHeightInMetres, 2));
            kgToLose = totalWeightInKgs - maxhealthyWeight;

            String expectedResult = "\nYou are a healthy weight";

            //Assert
            Assert.AreEqual(expectedResult, b1.HealthyWeight);
        }

        [DataRow(12, 3, 5, 7)]
        [DataTestMethod]
        public void TestHealthyWeight_Overweight(int stone, int pound, int feet, int inch)
        {
            //Arrange
            BMI b1 = new BMI(stone, pound, feet, inch);

            double totalWeightInPounds = (stone * 14) + pound;
            double totalHeightInInches = (feet * 12) + inch;

            // do conversions to metric
            double totalWeightInKgs = totalWeightInPounds * 0.453592;
            double totalHeightInMetres = totalHeightInInches * 0.0254;

            double kgToLose = 0;
            double maxhealthyWeight = 0;

            //Act
            double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));
            maxhealthyWeight = 24.9 * (Math.Pow(totalHeightInMetres, 2));
            kgToLose = totalWeightInKgs - maxhealthyWeight;

            String expectedResult = "\nYour Current weight is 77.564232kg" +
                "\nIdeal maximum weight for someone 1.7018metres is 72.113468676kg" +
                "\nMinimum weight in kilogramms to lose is 5.45076332400001";

            //Assert
            Assert.AreEqual(expectedResult, b1.HealthyWeight);
        }

        [DataRow(23, 3, 5, 7)]
        [DataTestMethod]
        public void TestHealthyWeight_Obese(int stone, int pound, int feet, int inch)
        {
            //Arrange
            BMI b1 = new BMI(stone, pound, feet, inch);

            double totalWeightInPounds = (stone * 14) + pound;
            double totalHeightInInches = (feet * 12) + inch;

            // do conversions to metric
            double totalWeightInKgs = totalWeightInPounds * 0.453592;
            double totalHeightInMetres = totalHeightInInches * 0.0254;

            double kgToLose = 0;
            double maxhealthyWeight = 0;

            //Act
            double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));
            maxhealthyWeight = 24.9 * (Math.Pow(totalHeightInMetres, 2));
            kgToLose = totalWeightInKgs - maxhealthyWeight;

            String expectedResult = "\nYour Current weight is 147.4174kg" +
                "\nIdeal maximum weight for someone 1.7018metres is 72.113468676kg" +
                "\nMinimum weight in kilogramms to lose is 75.303931324";

            //Assert
            Assert.AreEqual(expectedResult, b1.HealthyWeight);
        }
    }
}
