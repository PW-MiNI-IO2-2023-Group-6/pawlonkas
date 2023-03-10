using Workshop;

namespace WorkshopTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturns0()
        {
            int result = StringCalculator.Calculate("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("0", 0)]
        [InlineData("121", 121)]
        [InlineData("42", 42)]
        public void StringWithNumberReturnsItsValue(string str, int exptected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(exptected, result);
        }

        [Theory]
        [InlineData("12,12", 24)]
        [InlineData("32,16", 48)]
        [InlineData("10,22", 32)]
        public void TwoNumbersWithCommaReturnsTheirSum(string str, int exptected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(exptected, result);
        }

        [Theory]
        [InlineData("12\n12", 24)]
        [InlineData("32\n16", 48)]
        [InlineData("10\n22", 32)]
        public void TwoNumbersWithNewLineReturnsTheirSum(string str, int exptected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(exptected, result);
        }

        [Theory]
        [InlineData("12\n12,10", 34)]
        [InlineData("32,3\n16", 51)]
        [InlineData("10\n22,21", 53)]
        public void ManyNumbersWithNewLineReturnsTheirSum(string str, int exptected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(exptected, result);
        }

        [Theory]
        [InlineData("12\n1000,10", 1022)]
        [InlineData("32,3000\n16", 48)]
        [InlineData("999\n1,2", 1002)]
        [InlineData("2000", 0)]
        public void NumbersOver1000AreOmitted(string str, int exptected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(exptected, result);
        }

        [Theory]
        [InlineData("-100")]
        [InlineData("-1")]
        public void NegativeValuesThrowsException(string str)
        {
            Assert.Throws<NotImplementedException>(() => StringCalculator.Calculate(str));
        }

        [Theory]
        [InlineData("//X\n100X100", 200)]
        [InlineData("//X\n1X5", 6)]
        public void StringStartsWithSpecialChar(string str, int exptected)
        {
            int result = StringCalculator.Calculate(str);
            Assert.Equal(exptected, result);
        }
    }
}