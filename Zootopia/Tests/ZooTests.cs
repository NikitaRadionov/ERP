using Models;
using Services;
using NSubstitute;

namespace Tests
{
    public class ZooTests
    {
        private readonly Zoo _zoo;
        private readonly VetClinic _vetClinic;

        public ZooTests()
        {
            _vetClinic = new VetClinic();
            _zoo = new Zoo(_vetClinic);
        }

        [Fact]
        public void AddAnimal_HealthyAnimal_ShouldBeAdded()
        {
            var vetClinicMock = Substitute.For<VetClinic>();
            vetClinicMock.When(x => x.CheckHealth(Arg.Any<Animal>())).DoNotCallBase();
            vetClinicMock.CheckHealth(Arg.Any<Animal>()).Returns(true);

            var zoo = new Zoo(vetClinicMock);
            var rabbit = new Rabbit(1, 1);

            zoo.AddAnimal(rabbit);

            Assert.Contains(rabbit, zoo.Animals);
        }

        [Fact]
        public void AddAnimal_UnhealthyAnimal_ShouldNotBeAdded()
        {
            var vetClinicMock = Substitute.For<VetClinic>();
            vetClinicMock.When(x => x.CheckHealth(Arg.Any<Animal>())).DoNotCallBase();
            vetClinicMock.CheckHealth(Arg.Any<Animal>()).Returns(false);

            var zoo = new Zoo(vetClinicMock);
            var rabbit = new Rabbit(1, 1);

            zoo.AddAnimal(rabbit);

            Assert.DoesNotContain(rabbit, zoo.Animals);
        }

        [Fact]
        public void AddThing_ShouldBeAddedToInventory()
        {
            var table = new Table(101);
            _zoo.AddThing(table);
            Assert.Contains(table, _zoo.Inventory);
        }

        [Fact]
        public void ReportFoodConsumption_ShouldCalculateTotalFood()
        {
            var vetClinicMock = Substitute.For<VetClinic>();
            vetClinicMock.When(x => x.CheckHealth(Arg.Any<Animal>())).DoNotCallBase();
            vetClinicMock.CheckHealth(Arg.Any<Animal>()).Returns(true);

            var zoo = new Zoo(vetClinicMock);
            zoo.AddAnimal(new Monkey(1, 10, 6));
            zoo.AddAnimal(new Rabbit(2, 5, 8));

            var totalFood = zoo.GetFoodConsumption();

            Assert.Equal(15, totalFood);
        }

        [Fact]
        public void ListContactZooAnimals_ShouldReturnOnlyKindAnimals()
        {
            var vetClinicMock = Substitute.For<VetClinic>();
            vetClinicMock.CheckHealth(Arg.Any<Animal>()).Returns(true);

            var zoo = new Zoo(vetClinicMock);

            var kindRabbit = new Rabbit(3, 5, 6);
            var aggressiveRabbit = new Rabbit(4, 10, 1);

            zoo.AddAnimal(kindRabbit);
            zoo.AddAnimal(aggressiveRabbit);

            List<Herbo> contactAnimals = zoo.GetContactZooAnimals();

            Assert.Contains(kindRabbit, contactAnimals);
            Assert.DoesNotContain(aggressiveRabbit, contactAnimals);
        }
    }
}