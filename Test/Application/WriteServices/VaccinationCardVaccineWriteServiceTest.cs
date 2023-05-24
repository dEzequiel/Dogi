using Application.Interfaces.Repositories;
using Application.Service.Implementation.Write;
using Application.Service.Interfaces;
using AutoFixture.Xunit2;
using Crosscuting.Api.DTOs;
using Moq;
using Test.Utils.Attributes;

namespace Test.Application.WriteServices
{
    public class VaccinationCardVaccineWriteServiceTest
    {
        [Theory]
        [AutoMoqData]
        internal async Task ShouldAddNewVaccinationCardVaccineAsync([Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IVaccinationCardVaccineRepository> repositoryMock,
            [Frozen] AdminData admin,
            Domain.Entities.VaccinationCardVaccine vaccinationCardVaccineAdd,
            VaccinationCardVaccineWrite sut)
        {
            // Arrange
            unitOfWorkMock.Setup(x => x.VaccinationCardVaccineRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.VaccinationCardVaccine>(),
            It.IsAny<AdminData>(),
            It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await sut.AddAsync(vaccinationCardVaccineAdd, admin);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.Entities.VaccinationCardVaccine>(result);
            repositoryMock.Verify(r => r.AddAsync(
                It.IsAny<Domain.Entities.VaccinationCardVaccine>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Theory]
        [AutoMoqData]
        internal async Task ShouldDoneVaccinationCardVaccineAsync([Frozen] Mock<IUnitOfWork> unitOfWorkMock,
            [Frozen] Mock<IVaccinationCardVaccineRepository> repositoryMock,
            [Frozen] AdminData admin,
            Domain.Entities.VaccinationCardVaccine vaccinationCardVaccineAdd,
            VaccinationCardVaccineWrite sut)
        {
            // Arrange
            var vaccineId = Guid.NewGuid();
            var vaccineCardId = Guid.NewGuid();

            unitOfWorkMock.Setup(x => x.VaccinationCardVaccineRepository)
                .Returns(repositoryMock.Object);

            repositoryMock.Setup(x => x.VaccineAsync(It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<AdminData>(),
            It.IsAny<CancellationToken>()))
                .ReturnsAsync(vaccinationCardVaccineAdd);

            // Act
            var result = await sut.VaccineAsync(vaccineId, vaccineCardId, admin);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.Entities.VaccinationCardVaccine>(result);
            repositoryMock.Verify(r => r.VaccineAsync(It.IsAny<Guid>(),
                It.IsAny<Guid>(),
                It.IsAny<AdminData>(),
                It.IsAny<CancellationToken>()), Times.Once);
            unitOfWorkMock.Verify(u => u.CompleteAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
