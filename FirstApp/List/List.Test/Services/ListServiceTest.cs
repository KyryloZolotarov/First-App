using AutoMapper;
using Infrastructure.Services.Interfaces;
using List.Host.Data.Entities;
using List.Host.Models.Dtos;
using List.Host.Repositories.Interfaces;
using List.Host.Services;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCatalog.Host.Data;

namespace List.Test.Services
{
    public class ListServiceTest
    {
        [Fact]
        public async Task GetListsAsync_Returns_IEnumerableListDto_Seccesfully()
        {
            var dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            var loggerMock = new Mock<ILogger<ListService>>();
            var listRepositoryMock = new Mock<IListRepository>();

            var dbContextTransactionMock = new Mock<IDbContextTransaction>();
            dbContextWrapperMock.Setup(s => s.BeginTransactionAsync(CancellationToken.None))
                .ReturnsAsync(dbContextTransactionMock.Object);

            var listRepositoryResultMock = new List<ListEntity>();
            var listServiceResultMock = new List<ListDto>();

            var listEntitySucces = new ListEntity()
            {
                Id = 1,
                Title = "Test",
                BoardId = 1,
            };

            var listDtoSucces = new ListDto()
            {
                Id = 1,
                Title = "Test",
                BoardId = 1
            };

            var boardIdRequest = 1;

            listRepositoryResultMock.Add(listEntitySucces);
            listRepositoryResultMock.Add(listEntitySucces);

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<ListDto>(
                It.Is<ListEntity>(i => listRepositoryResultMock.Equals(listEntitySucces)))).Returns(listDtoSucces);


            listRepositoryMock.Setup(h => h.GetListsAsync(boardIdRequest)).ReturnsAsync(listRepositoryResultMock);

            var listService = new ListService(
                listRepositoryMock.Object,
                loggerMock.Object,
                dbContextWrapperMock.Object,
                mapperMock.Object);

            var result = await listService.GetListsAsync(boardIdRequest);
            Assert.NotNull(result);
            if (result == null)
            {
                return;
            }

            Assert.Equal(listServiceResultMock, result);
            listRepositoryMock.Verify(x => x.GetListsAsync(It.IsAny<int>()), Times.Once());
        }

        /*
        [Fact]
        public async Task GetListsAsync_Throws_ArgumentNullException_Failed()
        {
            var dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            var loggerMock = new Mock<ILogger<DogsService>>();
            var dogsRepositoryMock = new Mock<IDogsRepository>();

            var dbContextTransactionMock = new Mock<IDbContextTransaction>();
            dbContextWrapperMock.Setup(s => s.BeginTransactionAsync(CancellationToken.None))
                .ReturnsAsync(dbContextTransactionMock.Object);

            var dogsRepositoryResultMock = new List<DogEntity>();
            var dogsServiceResultMock = new List<DogDto>();

            var cancellationTokenMock = new CancellationToken();

            var paramMock = new GetDogsQueryParametrs()
            {
                Attribute = "tailLength",
            };

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<List<DogDto>>(
                It.Is<List<DogEntity>>(i => i.Equals(dogsRepositoryMock)))).Returns(dogsServiceResultMock);


            dogsRepositoryMock.Setup(h => h.GetDogsAsync(It.IsAny<GetDogsQueryParametrs>())).ReturnsAsync((Func<List<DogEntity>>)null!);

            var dogsService = new DogsService(
                dogsRepositoryMock.Object,
                loggerMock.Object,
                dbContextWrapperMock.Object,
                mapperMock.Object);


            await Assert.ThrowsAsync<ArgumentNullException>(async () => {
                var result = await dogsService.GetDogsAsync(paramMock, cancellationTokenMock);
            });
        }
        [Fact]
        public async Task AddListAsync_Succesfully()
        {
            var dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            var loggerMock = new Mock<ILogger<DogsService>>();
            var dogsRepositoryMock = new Mock<IDogsRepository>();

            var dbContextTransactionMock = new Mock<IDbContextTransaction>();
            dbContextWrapperMock.Setup(s => s.BeginTransactionAsync(CancellationToken.None))
                .ReturnsAsync(dbContextTransactionMock.Object);

            var dogEntitySucces = new DogEntity()
            {
                Name = "Test",
                Color = "Test_Color",
                TailLength = 10,
                Weight = 3
            };

            var dogDtoSucces = new DogDto()
            {
                Name = "Test",
                Color = "Test_Color",
                TailLength = 10,
                Weight = 3
            };

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<DogEntity>(
                It.Is<DogDto>(i => i.Equals(dogDtoSucces)))).Returns(dogEntitySucces);

            dogsRepositoryMock.Setup(h => h.AddDogAsync(It.IsAny<DogEntity>())).Returns(Task.CompletedTask);

            var dogsService = new DogsService(
                dogsRepositoryMock.Object,
                loggerMock.Object,
                dbContextWrapperMock.Object,
                mapperMock.Object);

            await dogsService.AddDogAsync(dogDtoSucces, CancellationToken.None);
            mapperMock.Verify(m => m.Map<DogEntity>(dogDtoSucces), Times.Once);
            dogsRepositoryMock.Verify(r => r.AddDogAsync(dogEntitySucces), Times.Once);
        }
        [Fact]
        public async Task AddListAsync_Failed()
        {
            var dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            var loggerMock = new Mock<ILogger<DogsService>>();
            var dogsRepositoryMock = new Mock<IDogsRepository>();

            var dbContextTransactionMock = new Mock<IDbContextTransaction>();
            dbContextWrapperMock.Setup(s => s.BeginTransactionAsync(CancellationToken.None))
                .ReturnsAsync(dbContextTransactionMock.Object);

            var dogEntitySucces = new DogEntity();

            var dogDtoSucces = new DogDto();

            var cancellationTokenMock = new CancellationToken();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<DogDto>(
                It.Is<DogEntity>(i => i.Equals(dogEntitySucces)))).Returns(dogDtoSucces);

            dogsRepositoryMock.Setup(h => h.AddDogAsync(It.IsAny<DogEntity>())).Returns(Task.CompletedTask);

            var dogsService = new DogsService(
                dogsRepositoryMock.Object,
                loggerMock.Object,
                dbContextWrapperMock.Object,
                mapperMock.Object);

            await dogsService.AddDogAsync(dogDtoSucces, cancellationTokenMock);
        }
        */
    }
}
