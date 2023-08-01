using AutoMapper;
using Moq;
using MyWebBank.Application.CQRS.Card.Queries.GetUserCards;
using MyWebBank.Application.DTO.Card;
using MyWebBank.Application.Interfaces;
using MyWebBank.Application.MappingProfiles;
using MyWebBank.Tests.CoreTests.Mocks;
using Shouldly;

namespace MyWebBank.Tests.CoreTests.CQRS.Card
{
    public class GetUserCardsQueryHandlerTest
    {
        private readonly Mock<ICardsRepository> _mockCardsRepository;
        private readonly IMapper _mapper;

        public GetUserCardsQueryHandlerTest()
        {
            _mockCardsRepository = MockCardsRepository.GetMockCardsRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AppMappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetUserCardsTest()
        {
            var handler = new GetUserCardsQueryHandler(_mapper, _mockCardsRepository.Object);

            var result = await handler.Handle(new GetUserCardsQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CardDto>>();
            result.Count().ShouldBe(2);
        }
    }
}
