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
    public class UpdateEmployeeHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly CancellationToken _cancellationToken;
        public UpdateEmployeeHandlerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task Handle_Should_Call_Update_From_EmployeeService()
        {
            var mockEmployeeService = _fixture.Freeze<Mock<IEmployeeService>>();
            var handler = _fixture.Create<UpdateEmployeeHandler>();
            var request = _fixture.Create<UpdateEmployeeCommand>();
            await handler.Handle(request, _cancellationToken);
            mockEmployeeService.Verify(n => n.UpdateEmployee(
                                request.EmployeeId,
                                request.EmployeeNum,
                                request.FirstName,
                                request.LastName,
                                request.BirthDate,
                                request.EmployedDate,
                                request.TerminationDate), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Return_GetEmployeeResponse()
        {

            var handler = _fixture.Create<UpdateEmployeeHandler>();
            var command = _fixture.Create<UpdateEmployeeCommand>();

            var response = await handler.Handle(command, _cancellationToken);
            response.Should().BeOfType<GetEmployeeResponse>();
        }
    }
}
