using System;
using Lab2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab2Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ToStringTestNormal()
        {
            Rational r = new Rational(23, 45);
            Assert.AreEqual("23:45", r.ToString());
        }

        [TestMethod]
        public void ToStringTestDenominatorLessThanNumerator()
        {
            Rational r = new Rational(42, 11);
            Assert.AreEqual("3.9:11", r.ToString());
        }

        [TestMethod]
        public void ToStringNegativeValuesTest1()
        {
            Rational r = new Rational(42, -11);
            Assert.AreEqual("-3.9:11", r.ToString());
        }

        [TestMethod]
        public void ToStringNegativeValuesTest2()
        {
            Rational r = new Rational(-42, 11);
            Assert.AreEqual("-3.9:11", r.ToString());
        }

        [TestMethod]
        public void ToStringTestInt()
        {
            Rational r = new Rational(42, 21);
            Assert.AreEqual("2", r.ToString());
        }

        [TestMethod]
        public void TryParseWrongParamsEmptyStringSuccessTest()
        {
            Rational r = new Rational();
            bool success = Rational.TryParse("", out r);
            Assert.AreEqual(false, success);
        }

        [TestMethod]
        public void TryParseWrongParamsUnexpectedSymbolsSuccessTest()
        {
            Rational r = new Rational();
            bool success = Rational.TryParse("2.l2:42", out r);
            Assert.AreEqual(false, success);
        }

        [TestMethod]
        public void TryParseNumWithZeroDenominatorSuccessTest()
        {
            try
            {
                Rational r;
                Rational.TryParse("-2.12:0", out r);
                Assert.Fail();
            } catch (Exception) { }

        }

        [TestMethod]
        public void TryParseSuccessTestNormal()
        {
            Rational r = new Rational();
            bool success = Rational.TryParse("2.12:42", out r);
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void TryParseNegativeNumberSuccessTest()
        {
            Rational r = new Rational();
            bool success = Rational.TryParse("-2.12:42", out r);
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void TryParseWithoutWholePartSuccessTest()
        {
            Rational r = new Rational();
            bool success = Rational.TryParse("42:11", out r);
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void TryParseWithoutWholePartNegativeNumberSuccessTest()
        {
            Rational r = new Rational();
            bool success = Rational.TryParse("-42:11", out r);
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void TryParseIntSuccessTest()
        {
            Rational r = new Rational();
            bool success = Rational.TryParse("42", out r);
            Assert.AreEqual(true, success);
        }

        [TestMethod]
        public void TryParseNormalCorrectnessTest()
        {
            Rational r = new Rational();
            Rational.TryParse("1.12:11", out r);
            Assert.AreEqual("2.1:11", r.ToString());
        }

        [TestMethod]
        public void TryParseNegativeCorrectnessTest()
        {
            Rational r = new Rational();
            Rational.TryParse("-2.1:31", out r);
            Assert.AreEqual("-2.1:31", r.ToString());
        }

        [TestMethod]
        public void TryParseIntCorrectnessTest()
        {
            Rational r = new Rational();
            Rational.TryParse("42", out r);
            Assert.AreEqual("42", r.ToString());
        }

        [TestMethod]
        public void TryParseWithoutWholePartCorrectnessTest()
        {
            Rational r = new Rational();
            Rational.TryParse("1:31", out r);
            Assert.AreEqual("1:31", r.ToString());
        }
    }
}
