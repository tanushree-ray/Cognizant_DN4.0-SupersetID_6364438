using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calc;

        [SetUp]
        public void SetUp()
        {
            calc = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            calc = null;
        }

        [Test]
        [TestCase(10, 5, 15)]
        [TestCase(-2, -3, -5)]
        [TestCase(0, 0, 0)]
        public void TestAddition(double a, double b, double expected)
        {
            var result = calc.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, 5, 5)]
        [TestCase(-2, -3, 1)]
        [TestCase(0, 0, 0)]
        public void TestSubtraction(double a, double b, double expected)
        {
            var result = calc.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, 5, 50)]
        [TestCase(-2, -3, 6)]
        [TestCase(0, 100, 0)]
        public void TestMultiplication(double a, double b, double expected)
        {
            var result = calc.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, 2, 5)]
        [TestCase(9, 3, 3)]
        [TestCase(-6, -2, 3)]
        public void TestDivision(double a, double b, double expected)
        {
            var result = calc.Division(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => calc.Division(5, 0));
            Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
        }

        [Test]
        public void AllClear_ShouldResetResultToZero()
        {
            calc.Addition(10, 5);
            calc.AllClear();
            Assert.That(calc.GetResult, Is.EqualTo(0));
        }
    }
}