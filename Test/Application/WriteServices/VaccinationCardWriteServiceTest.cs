using Application.Interfaces.Repositories;
using Application.Service.Implementation.Write;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.WriteServices
{
    public class VaccinationCardWriteServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldAddNewVaccinationCardAsync([Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IVaccinationCardRepository> repositoryMock,
            [Frozen] AdminData admin,
            Domain.Entities.VaccinationCard vaccinationCardAdd,
            VaccinationCardWrite sut)
        {
            // Arrange
            unitOfWorkMock.Setup(x => x.VaccinationCardRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.VaccinationCard>(),
                                                 It.IsAny<AdminData>(),
                                                 It.IsAny<CancellationToken>()))
                                                    .Returns(Task.CompletedTask);

            // Act
            var result = await sut.AddAsync(vaccinationCardAdd, admin);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.Entities.VaccinationCard>(result);
            repositoryMock.Verify(r => r.AddAsync(
                It.IsAny<Domain.Entities.VaccinationCard>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldUpdateExistingVaccinationCardAsync([Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IVaccinationCardRepository> repositoryMock,
            [Frozen] AdminData admin,
            Domain.Entities.VaccinationCard vaccinationCardAdd,
            VaccinationCardWrite sut)
        {
            // Arrange
            var vaccinationCardObservations = "Test";

            unitOfWorkMock.Setup(x => x.VaccinationCardRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Guid>(),
                                                 It.IsAny<string>(),
                                                 It.IsAny<AdminData>(),
                                                 It.IsAny<CancellationToken>()))
                                                    .ReturnsAsync(vaccinationCardAdd);

            // Act
            var result = await sut.UpdateAsync(vaccinationCardAdd.Id, vaccinationCardObservations, admin);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.Entities.VaccinationCard>(result);
            repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Guid>(),
                                                     It.IsAny<string>(),
                                                     It.IsAny<AdminData>(),
                                                     It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
