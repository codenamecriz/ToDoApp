using Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Services.UnitTest
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData(1,2)]
        public void Add_ComputeTwoValue(int a,int b)
        {
            var expected = 3;
            int actual = Calculator.Add(a, b);

            Assert.Equal(expected , actual);
        }
    }
}
