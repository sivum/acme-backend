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

namespace api.tests.handlers
{
    public class GetEmployeeHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly CancellationToken _cancellationToken;
        public GetEmployeeHandlerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task Handle_Should_Call_GetEmployee_From_EmployeeService()
        {
            var mockEmployeeService = _fixture.Freeze<Mock<IEmployeeService>>();
            var handler = _fixture.Create<GetEmployeeHandler>();
            var request = _fixture.Create<GetEmployeeQuery>();
            await handler.Handle(request, _cancellationToken);
            mockEmployeeService.Verify(n => n.GetEmployee(request.EmployeeId), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Return_GetEmployeeResponse()
        {

            var handler = _fixture.Create<GetEmployeeHandler>();
            var request = _fixture.Create<GetEmployeeQuery>();
           
            var response = await handler.Handle(request, _cancellationToken);
            response.Should().BeOfType<GetEmployeeResponse>();
        }

    }
}
