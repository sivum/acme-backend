using api.Handlers;
using api.Handlers.Queries;
using api.Handlers.Responses;
using api.Services;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace api.tests
{
    public class GetEmployeesHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly CancellationToken _cancellationToken;
        public GetEmployeesHandlerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task Handle_Should_Call_GetEmployees_From_EmployeeService()
        {
            var mockEmployeeService = _fixture.Freeze<Mock<IEmployeeService>>();
            var handler = _fixture.Create<GetEmployeesHandler>();
            var request = _fixture.Create<GetEmployeesQuery>();
            await handler.Handle(request, _cancellationToken);
            mockEmployeeService.Verify(n => n.GetEmployees(), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Return_GetEmployeesResponse()
        {
           
            var handler = _fixture.Create<GetEmployeesHandler>();
            var request = _fixture.Create<GetEmployeesQuery>();
            var response = await handler.Handle(request, _cancellationToken);
            response.Should().BeOfType<GetEmployeesResponse>();
        }

    }
}
