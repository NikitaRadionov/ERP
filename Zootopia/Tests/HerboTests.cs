
using Models;

namespace Tests
{
    public class HerboTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            var herbo = new Herbo(1, 10, 7);

            Assert.Equal(1, herbo.Number);
            Assert.Equal(10, herbo.Food);
            Assert.Equal(7, herbo.Kindness);
        }

        [Fact]
        public void Constructor_ShouldSetDefaultKindnessToFive()
        {
            var herbo = new Herbo(2, 15);

            Assert.Equal(5, herbo.Kindness);
        }

        [Fact]
        public void SetKindness_ShouldUpdateKindnessProperty()
        {
            var herbo = new Herbo(3, 8, 4);

            herbo.Kindness = 10;

            Assert.Equal(10, herbo.Kindness);
        }
    }
}
