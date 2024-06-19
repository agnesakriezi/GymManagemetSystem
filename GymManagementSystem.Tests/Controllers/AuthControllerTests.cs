using System.Threading.Tasks;
using GymManagementSystem.Controllers;
using GymManagementSystem.DTOs;
using GymManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class AuthControllerTests
{
    private readonly Mock<IUserService> _mockService;
    private readonly AuthController _controller;

    public AuthControllerTests()
    {
        _mockService = new Mock<IUserService>();
        _controller = new AuthController(_mockService.Object);
    }

    [Fact]
    public async Task Login_ReturnsUnauthorized_WhenCredentialsAreInvalid()
    {
        // Arrange
        var loginDto = new LoginDTO();
        _mockService.Setup(service => service.Login(loginDto))
                    .ReturnsAsync((UserLoginResponseDTO)null);

        // Act
        var result = await _controller.Login(loginDto);

        // Assert
        Assert.IsType<UnauthorizedResult>(result);
    }
}
