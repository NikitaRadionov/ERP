using Models;

namespace Tests
{
    public class ThingTests
    {
        [Fact]
        public void Constructor_ShouldInitializeNumber()
        {
            var thing = new Thing(42);

            Assert.Equal(42, thing.Number);
        }

        [Fact]
        public void SetNumber_ShouldUpdateNumberProperty()
        {
            var thing = new Thing(10);

            thing.Number = 99;

            Assert.Equal(99, thing.Number);
        }
    }
}
