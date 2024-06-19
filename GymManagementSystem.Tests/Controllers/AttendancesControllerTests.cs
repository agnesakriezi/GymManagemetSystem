using GymManagementSystem.Controllers;
using GymManagementSystem.DTOs;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class AttendancesControllerTests
{
    private readonly Mock<IAttendanceService> _mockService;
    private readonly AttendancesController _controller;

    public AttendancesControllerTests()
    {
        _mockService = new Mock<IAttendanceService>();
        _controller = new AttendancesController(_mockService.Object);
    }

    [Fact]
    public async Task GetAttendanceById_ReturnsOkResult_WhenAttendanceExists()
    {
        // Arrange
        var attendanceId = 1;
        _mockService.Setup(service => service.GetAttendanceByIdAsync(attendanceId))
                    .ReturnsAsync(new AttendanceDTO());

        // Act
        var result = await _controller.GetAttendanceById(attendanceId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<AttendanceDTO>(okResult.Value);
    }
}
