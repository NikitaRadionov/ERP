using Models;
using Services;
using Xunit;

namespace Tests
{

    public class AnimalTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            var animal = new Animal(1, 10);

            Assert.Equal(1, animal.Number);
            Assert.Equal(10, animal.Food);
        }

        [Fact]
        public void SetFood_ShouldUpdateFoodProperty()
        {
            var animal = new Animal(2, 5);

            animal.Food = 20;

            Assert.Equal(20, animal.Food);
        }

        [Fact]
        public void SetNumber_ShouldUpdateNumberProperty()
        {
            var animal = new Animal(3, 7);

            animal.Number = 99;

            Assert.Equal(99, animal.Number);
        }
    }

}
