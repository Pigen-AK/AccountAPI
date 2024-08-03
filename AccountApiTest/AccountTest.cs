using AccountApi.Models;

namespace AccountApi.Test
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            //Arrange
            var account = new Account("lønkonto");

            //Act
            account.Insert(500);

            //Assert
            Assert.That(account.Balance, Is.EqualTo(10500));
        }
    }
}