using api.Handlers;
using api.Handlers.Commands;
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
    public class RemoveEmployeeHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly CancellationToken _cancellationToken;
        public RemoveEmployeeHandlerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task Handle_Should_Call_Remove_From_EmployeeService()
        {
            var mockEmployeeService = _fixture.Freeze<Mock<IEmployeeService>>();
            var handler = _fixture.Create<RemoveEmployeeHandler>();
            var request = _fixture.Create<RemoveEmployeeCommand>();
            await handler.Handle(request, _cancellationToken);
            mockEmployeeService.Verify(n => n.RemoveEmployee(
                                request.EmployeeId), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Return_GetEmployeesResponse()
        { 
            var handler = _fixture.Create<RemoveEmployeeHandler>();
            var command = _fixture.Create<RemoveEmployeeCommand>();

            var response = await handler.Handle(command, _cancellationToken);
            response.Should().BeOfType<GetEmployeesResponse>();
        }
    }
}
