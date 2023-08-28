using Xunit;
using TestFeatures.Models;
using System;

namespace FunctionsTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2, 2, 5, 1.5, 2)]
        [InlineData(0, 4, 3, 5, 2.3)]
        public void LinearTest(int a, int b, int c, double x, double y)
        {
            UniFunc testFunc = new UniFunc() { A = a, B = b, C = c, X = x, Y = y, FuncType = FuncType.Linear };

            Assert.Equal(a*x+b+c , testFunc.Calculate());
        }
        [Theory]
        [InlineData(2, 2, 5, 1.5, 2)]
        [InlineData(0, 4, 3, 5, 2.3)]
        public void QuadraticTest(int a, int b, int c, double x, double y)
        {
            UniFunc testFunc = new UniFunc() { A = a, B = b, C = c, X = x, Y = y, FuncType = FuncType.Quadratic };

            Assert.Equal(a * Math.Pow(x, 2) + b * y + c, testFunc.Calculate());
        }
        [Theory]
        [InlineData(2, 2, 5, 1.5, 2)]
        [InlineData(0, 4, 3, 5, 2.3)]
        public void ThirdDegreeTest(int a, int b, int c, double x, double y)
        {
            UniFunc testFunc = new UniFunc() { A = a, B = b, C = c, X = x, Y = y, FuncType = FuncType.ThirdDegree };

            Assert.Equal(a * Math.Pow(x, 3) + b * Math.Pow(y, 2) + c, testFunc.Calculate());
        }
        [Theory]
        [InlineData(2, 2, 5, 1.5, 2)]
        [InlineData(0, 4, 3, 5, 2.3)]
        public void FourthDegreeTest(int a, int b, int c, double x, double y)
        {
            UniFunc testFunc = new UniFunc() { A = a, B = b, C = c, X = x, Y = y, FuncType = FuncType.FourthDegree };

            Assert.Equal(a * Math.Pow(x, 4) + b * Math.Pow(y, 3) + c, testFunc.Calculate());
        }
        [Theory]
        [InlineData(2, 2, 5, 1.5, 2)]
        [InlineData(0, 4, 3, 5, 2.3)]
        public void FifthDegreeTest(int a, int b, int c, double x, double y)
        {
            UniFunc testFunc = new UniFunc() { A = a, B = b, C = c, X = x, Y = y, FuncType = FuncType.FifthDegree };

            Assert.Equal(a * Math.Pow(x, 5) + b * Math.Pow(y, 4) + c, testFunc.Calculate());
        }
    }
}