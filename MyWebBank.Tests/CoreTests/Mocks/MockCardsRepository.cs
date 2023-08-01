using Moq;
using MyWebBank.Application.Interfaces;
using MyWebBank.Domain.Entities;

namespace MyWebBank.Tests.CoreTests.Mocks
{
    public static class MockCardsRepository
    {
        public static Mock<ICardsRepository> GetMockCardsRepository()
        {
            var cards = new List<Card>
            {
                new Card
                {
                    Id = Guid.Parse("8a5d62bb-0811-402c-9000-97583a1b4ef6"),
                    Name = "Credit card Acc 1",
                    Balance = 1000,
                    Number = "1111222233334444",
                    ExpirationMonth = "01",
                    ExpirationYear = "25",
                    CVV = "123",
                    AccountId = Guid.Parse("1f67ea66-7ad3-4273-94d4-729cabafdffa"),
                },
                new Card
                {
                    Id = Guid.Parse("a53f1a4b-873f-466f-b08c-2009fc95b4f9"),
                    Name = "Credit card Acc 2",
                    Balance = 100000,
                    Number = "1111222233335555",
                    ExpirationMonth = "05",
                    ExpirationYear = "30",
                    CVV = "321",
                    AccountId = Guid.Parse("7159ce0a-cc4e-46c1-becf-29201240baff"),
                }
            };

            var mockRepository = new Mock<ICardsRepository>();

            mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(cards);
            mockRepository.Setup(r => r.GetUserCardsAsync()).ReturnsAsync(cards);
            mockRepository.Setup(r => r.CreateAsync(It.IsAny<Card>()))
                .Returns((Card card) =>
                {
                    cards.Add(card);
                    return Task.FromResult(card);
                });

            return mockRepository;
        }
    }
}
