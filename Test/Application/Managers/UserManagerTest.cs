using Application.DTOs.User;
using Application.DTOs.UserManager;
using Application.Features.Person.Commands;
using Application.Features.Person.Queries;
using Application.Features.RoleUser.Commands;
using Application.Features.RoleUser.Queries;
using Application.Features.User.Commands;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Managers;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs.Authentication;
using Crosscuting.Api.DTOs.Response;
using Domain.Entities.Authorization;
using Domain.Entities.Shelter;
using MediatR;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.Managers;

public class UserManagerTest
{
    [Theory]
    [AutoMoqData]
    internal async Task
        ShouldRegisterUserAndCreatePersonaAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            [Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IUserRepository> userRepositoryMock,
            User returnUser,
            ApiResponse<User> userResponse,
            ApiResponse<Person> personResponse,
            UserDataRegister registerData,
            UserManager sut)
    {
        // Arrange
        unitOfWorkMock.Setup(u => u.UserRepository)
            .Returns(userRepositoryMock.Object);

        userRepositoryMock.Setup(r => r.GetAsync(
                It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User)null);

        mediatorMock.Setup(x => x.Send(It.IsAny<RegisterUserRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(userResponse);

        mediatorMock.Setup(x => x.Send(It.IsAny<InsertPersonRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(personResponse);

        // Act
        var result = await sut.Register(registerData, default);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<RegisteredUserWithPersonCredentials>(result);

        unitOfWorkMock.Verify(u => u.UserRepository, Times.Once);

        userRepositoryMock.Verify(r => r.GetAsync(
            It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once);

        mediatorMock.Verify(x => x.Send(It.IsAny<RegisterUserRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);

        mediatorMock.Verify(x => x.Send(It.IsAny<InsertPersonRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Theory]
    [AutoMoqData]
    internal async Task
        ShouldAuthenticateCorrectUserCredentialsAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            UserWithToken userWithTokenResponse,
            ApiResponse<Person> personApiResponse,
            UserDataLogin loginData,
            UserManager sut)
    {
        // Arrange
        mediatorMock.Setup(x => x.Send(It.IsAny<AuthenticateUserRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(userWithTokenResponse);

        mediatorMock.Setup(x => x.Send(It.IsAny<GetPersonByUserIdRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(personApiResponse);

        // Act
        var result = await sut.Authenticate(loginData, default);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<UserWithCredentials>(result);

        mediatorMock.Verify(x => x.Send(It.IsAny<AuthenticateUserRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);

        mediatorMock.Verify(x => x.Send(It.IsAny<GetPersonByUserIdRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Theory]
    [AutoMoqData]
    internal async Task
        ShouldAssigneRoleAsync(
            [Frozen] Mock<IMediator> mediatorMock,
            ApiResponse<IEnumerable<RoleUser>> rolesUser,
            ApiResponse<HashSet<string>> permissions,
            UserWithRoles userWithRoles,
            UserManager sut)
    {
        // Arrange
        mediatorMock.Setup(x => x.Send(It.IsAny<AssigneUserToRoleRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(rolesUser);

        mediatorMock.Setup(x => x.Send(It.IsAny<GetUserPermissionsRequest>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(permissions);

        // Act
        var result = await sut.AssigneRole(userWithRoles, default);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<UserWithPermissions>(result);

        mediatorMock.Verify(x => x.Send(It.IsAny<AssigneUserToRoleRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);

        mediatorMock.Verify(x => x.Send(It.IsAny<GetUserPermissionsRequest>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}