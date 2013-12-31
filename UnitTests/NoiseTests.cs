using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapGenerator;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class NoiseTests
    {
        [Test]
        public void ItShouldReturnBetweenZeroAndOne()
        {
            var rand = new Random();

            for (var i = 0; i < 100; i++)
            {
                var result = SimplexNoise.Generate2D(NextFloat(rand), NextFloat(rand));
                Assert.GreaterOrEqual(result, 0.0f);
                Assert.LessOrEqual(result, 1.0f);
            }
        }

        private static float NextFloat(Random random)
        {
            double mantissa = (random.NextDouble()*2.0) - 1.0;
            double exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float) (mantissa*exponent);
        }
    }
}
