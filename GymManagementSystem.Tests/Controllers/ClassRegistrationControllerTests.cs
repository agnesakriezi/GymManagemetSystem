using GymManagementSystem.Controllers;
using GymManagementSystem.DTOs;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class ClassRegistrationControllerTests
{
    private readonly Mock<IClassRegistrationService> _mockService;
    private readonly ClassRegistrationController _controller;

    public ClassRegistrationControllerTests()
    {
        _mockService = new Mock<IClassRegistrationService>();
        _controller = new ClassRegistrationController(_mockService.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithListOfClassRegistrations()
    {
        // Arrange
        var classRegistrations = new List<ClassRegistrationDTO>
        {
            new ClassRegistrationDTO { Id = 1, MemberId = 1, ScheduleId = 1, RegistrationDate = DateTime.Now }
        };
        _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(classRegistrations);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<ClassRegistrationDTO>>(okResult.Value);
        Assert.Single(returnValue);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenClassRegistrationDoesNotExist()
    {
        // Arrange
        var classRegistrationId = 1;
        _mockService.Setup(service => service.GetByIdAsync(classRegistrationId))
                    .ReturnsAsync((ClassRegistrationDTO)null);

        // Act
        var result = await _controller.GetById(classRegistrationId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task Add_ReturnsCreatedAtAction_WhenClassRegistrationIsAdded()
    {
        // Arrange
        var classRegistrationDto = new ClassRegistrationDTO { Id = 1, MemberId = 1, ScheduleId = 1, RegistrationDate = DateTime.Now };
        _mockService.Setup(service => service.AddAsync(classRegistrationDto)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Add(classRegistrationDto);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(_controller.GetById), createdAtActionResult.ActionName);
        Assert.Equal(classRegistrationDto.Id, createdAtActionResult.RouteValues["id"]);
    }

    [Fact]
    public async Task Update_ReturnsBadRequest_WhenIdsDoNotMatch()
    {
        // Arrange
        var classRegistrationId = 1;
        var classRegistrationDto = new ClassRegistrationDTO { Id = 2, MemberId = 1, ScheduleId = 1, RegistrationDate = DateTime.Now };

        // Act
        var result = await _controller.Update(classRegistrationId, classRegistrationDto);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task Delete_ReturnsNoContent_WhenClassRegistrationIsDeleted()
    {
        // Arrange
        var classRegistrationId = 1;
        _mockService.Setup(service => service.DeleteAsync(classRegistrationId)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Delete(classRegistrationId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
