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
    public  class AddEmployeeHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly CancellationToken _cancellationToken;
        public AddEmployeeHandlerTests()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public async Task Handle_Should_Call_Add_From_EmployeeService()
        {
            var mockEmployeeService = _fixture.Freeze<Mock<IEmployeeService>>();
            var handler = _fixture.Create<AddEmployeeHandler>();
            var request = _fixture.Create<AddEmployeeCommand>();
            await handler.Handle(request, _cancellationToken);
            mockEmployeeService.Verify(n => n.AddEmployee(
                                 request.EmployeeNum,
                                request.FirstName,
                                request.LastName,
                                request.BirthDate,
                                request.EmployedDate), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Return_AddEmployeeResponse()
        {

            var handler = _fixture.Create<AddEmployeeHandler>();
            var command = _fixture.Create<AddEmployeeCommand>();

            var response = await handler.Handle(command, _cancellationToken);
            response.Should().BeOfType<GetEmployeeResponse>();
        }
    }
}
