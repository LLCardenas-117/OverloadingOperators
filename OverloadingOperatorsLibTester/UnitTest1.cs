using OverloadingOperatorsLib;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using Xunit.Sdk;

namespace OverloadingOperatorsLibTester
{
    public class FractionTests
    {
        //There are 4 primary rules to automated testing
        // 1. Every test should think it's the only test
        // 2. Every test should start from a place of newness
        // 3. Every test should test one thing
        // 4. Test EVERYTHING

        [Fact]
        public void GCD_5and3_Returns1()
        {
            // There are 3 stages to every test
            // Arrange
            int num1 = 5;
            int num2 = 3;
            int expected = 1;
            // Act
            int actual = Fraction.GCD(num1, num2);
            // Assert
            Assert.Equal(expected, actual);
        }

        //[Fact]
        //public void GCD_15and3_Returns3()
        //{
        //    // There are 3 stages to every test
        //    // Arrange
        //    int num1 = 15;
        //    int num2 = 3;
        //    int expected = 3;
        //    // Act
        //    int actual = Fraction.GCD(num1, num2);
        //    // Assert
        //    Assert.Equal(expected, actual);
        //}

        //[Fact]
        //public void GCD_3and15_Returns3()
        //{
        //    // There are 3 stages to every test
        //    // Arrange
        //    int num1 = 3;
        //    int num2 = 15;
        //    int expected = 3;
        //    // Act
        //    int actual = Fraction.GCD(num1, num2);
        //    // Assert
        //    Assert.Equal(expected, actual);
        //}

        [Theory]
        [InlineData(15, 3, 3)]
        [InlineData(3, 15, 3)]
        [InlineData(30, 40, 10)]
        [InlineData(35, 35, 35)]
        [InlineData(5, 3, 1)]
        public void GCD_ReturnsCorrectValue(int m, int n, int expected)
        {
            // There are 3 stages to every test
            // Arrange
            // Act
            int actual = Fraction.GCD(m, n);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 1, 2, 0, 10, 15, 1, 1, 6)]
        [InlineData(0, 1, 2, 0, 10, 15, 1, 1, 3)]
        //[InlineData(0, 20, 5, 0, 20, 5, 8)]
        //[TestCaseOrderer(new Fraction(0, 15, 3), new Fraction(0, 15, 3), new Fraction(10, 0, 3))]
        //[InlineData(, , )]
        public void Fraction_ReturnCorrectAdditionValue(int w1, int n1, int d1, int w2, int n2, int d2, int w3, int n3, int d3)
        {
            Fraction f1 = new Fraction(w1, n1, d1);
            Fraction f2 = new Fraction(w2, n2, d2);
            Fraction actual = f1 + f2;
            Fraction expected = new Fraction(w3, n3, d3);
            //int actual = Fraction.GCD(f3.Numerator, f3.Denominator);

            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(0, 1, 2,  0, 1, 4,  0, 1, 4)]
        [InlineData(0, 1, 2,  0, 1, 4,  0, 1, 2)]
        public void Fraction_ReturnCorrectSubtractionValue(int w1, int n1, int d1, int w2, int n2, int d2, int w3, int n3, int d3)
        {
            Fraction f1 = new Fraction(w1, n1, d1);
            Fraction f2 = new Fraction(w2, n2, d2);
            Fraction actual = f1 - f2;
            Fraction expected = new Fraction(w3, n3, d3);
            //int actual = Fraction.GCD(f3.Numerator, f3.Denominator);

            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData(0, 1, 2,  0, 1, 4,  0, 1, 8)]
        [InlineData(0, 2, 6,  0, 5, 20,  0, 1, 12)]
        public void Fraction_ReturnCorrectMultiplicationValue(int w1, int n1, int d1, int w2, int n2, int d2, int w3, int n3, int d3)
        {
            Fraction f1 = new Fraction(w1, n1, d1);
            Fraction f2 = new Fraction(w2, n2, d2);
            Fraction actual = f1 * f2;
            Fraction expected = new Fraction(w3, n3, d3);
            //int actual = Fraction.GCD(f3.Numerator, f3.Denominator);

            Assert.Equal(expected, actual);

        }

        [Theory]
        //[InlineData(0, 1, 2, 0, 1, 4, 0, 1, 8)]
        [InlineData(0, 5, 2,  0, 6, 8,  3, 1, 3)]
        public void Fraction_ReturnCorrectDivisionValue(int w1, int n1, int d1, int w2, int n2, int d2, int w3, int n3, int d3)
        {
            Fraction f1 = new Fraction(w1, n1, d1);
            Fraction f2 = new Fraction(w2, n2, d2);
            Fraction actual = f1 / f2;
            Fraction expected = new Fraction(w3, n3, d3);
            //int actual = Fraction.GCD(f3.Numerator, f3.Denominator);

            Assert.Equal(expected, actual);

        }
    }
}
