using AutoMapper;
using Infrastructure.Exceptions;
using Infrastructure.Services.Interfaces;
using List.Host.Data.Entities;
using List.Host.Models.Dtos;
using List.Host.Models.Requests;
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
        public async Task GetListsAsync_Returns_IEnumerableListDto_Successfully()
        {
            var dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            var loggerMock = new Mock<ILogger<ListService>>();
            var listRepositoryMock = new Mock<IListRepository>();

            var dbContextTransactionMock = new Mock<IDbContextTransaction>();
            dbContextWrapperMock.Setup(s => s.BeginTransactionAsync(CancellationToken.None))
                .ReturnsAsync(dbContextTransactionMock.Object);

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

            var listRepositoryResultMock = new List<ListEntity> { listEntitySucces };
            var listServiceResultMock = new List<ListDto> { listDtoSucces };

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<ListDto>(It.IsAny<ListEntity>())).Returns(listDtoSucces);

            listRepositoryMock.Setup(h => h.GetListsAsync(boardIdRequest)).ReturnsAsync(listRepositoryResultMock);

            var listService = new ListService(
                listRepositoryMock.Object,
                mapperMock.Object,
                dbContextWrapperMock.Object,
                loggerMock.Object
            );

            var result = await listService.GetListsAsync(boardIdRequest);
            Assert.NotNull(result);

            Assert.Equal(listServiceResultMock, result);
            listRepositoryMock.Verify(x => x.GetListsAsync(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public async Task GetListsAsync_Failed_ReturnsNull()
        {
            var dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            var loggerMock = new Mock<ILogger<ListService>>();
            var listRepositoryMock = new Mock<IListRepository>();

            var dbContextTransactionMock = new Mock<IDbContextTransaction>();
            dbContextWrapperMock.Setup(s => s.BeginTransactionAsync(CancellationToken.None))
                .ReturnsAsync(dbContextTransactionMock.Object);

            var boardIdRequest = 1;

            var mapperMock = new Mock<IMapper>();

            mapperMock.Setup(s => s.Map<List<ListDto>>(
                It.IsAny<List<ListEntity>>())).Returns(new List<ListDto>());

            listRepositoryMock.Setup(h => h.GetListsAsync(boardIdRequest)).ReturnsAsync((List<ListEntity>)null!);

            var listService = new ListService(
                listRepositoryMock.Object,
                mapperMock.Object,
                dbContextWrapperMock.Object,
                loggerMock.Object
            );

            var result = await listService.GetListsAsync(boardIdRequest);

            Assert.Null(result);
        }

        
        [Fact]
        public async Task AddListAsync_Succesfully()
        {
            var dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            var loggerMock = new Mock<ILogger<ListService>>();
            var listRepositoryMock = new Mock<IListRepository>();

            var dbContextTransactionMock = new Mock<IDbContextTransaction>();
            dbContextWrapperMock.Setup(s => s.BeginTransactionAsync(CancellationToken.None))
                .ReturnsAsync(dbContextTransactionMock.Object);

            var listEntitySuccess = new ListEntity()
            {
                Id = 1,
                Title = "Test",
                BoardId = 1,
            };

            var listEntityMapped = new ListEntity()
            {
                Title = "Test",
                BoardId = 1,
            };

            var listRequestSuccess = new AddListRequest()
            {
                Title = "Test",
                BoardId = 1
            };

            var listId = 1;

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<ListEntity>(
                It.Is<AddListRequest>(i => i.Equals(listRequestSuccess)))).Returns(listEntityMapped);


            var listService = new ListService(
                listRepositoryMock.Object,
                mapperMock.Object,
                dbContextWrapperMock.Object,
                loggerMock.Object
            );

            var result = await listService.AddListAsync(listRequestSuccess);

            listRepositoryMock.Verify(r => r.AddListAsync(It.IsAny<ListEntity>()), Times.Once);


            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddListAsync_Failed()
        {
            var dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            var loggerMock = new Mock<ILogger<ListService>>();
            var listRepositoryMock = new Mock<IListRepository>();

            var dbContextTransactionMock = new Mock<IDbContextTransaction>();
            dbContextWrapperMock.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ThrowsAsync(new BusinessException());

            var listEntitySucces = new ListEntity();

            var listRequestSucces = new AddListRequest();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(s => s.Map<AddListRequest>(
                It.Is<ListEntity>(i => i.Equals(listEntitySucces)))).Returns(listRequestSucces);

            listRepositoryMock.Setup(h => h.AddListAsync(It.IsAny<ListEntity>())).ReturnsAsync(null);

            var listService = new ListService(
                listRepositoryMock.Object,
                mapperMock.Object,
                dbContextWrapperMock.Object,
                loggerMock.Object
            );

            await Assert.ThrowsAsync<BusinessException>(async () => await listService.AddListAsync(listRequestSucces));
        }

        [Fact]
        public async Task DeleteListAsync_ValidList_DeletesList()
        {
            var dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            var loggerMock = new Mock<ILogger<ListService>>();
            var listRepositoryMock = new Mock<IListRepository>();
            var mapperMock = new Mock<IMapper>();

            var dbContextTransactionMock = new Mock<IDbContextTransaction>();
            dbContextWrapperMock.Setup(s => s.BeginTransactionAsync(CancellationToken.None))
                .ReturnsAsync(dbContextTransactionMock.Object);

            // Arrange

            var existingListId = 1;
            var existingList = new ListEntity { Id = 1, Title = "Existing", BoardId = 1 };

            listRepositoryMock.Setup(repo => repo.GetListAsync(existingListId))
                .ReturnsAsync(existingList);

            listRepositoryMock.Setup(h => h.DeleteListAsync(It.IsAny<ListEntity>())).Returns(Task.CompletedTask);

            var listService = new ListService(
                listRepositoryMock.Object,
                mapperMock.Object,
                dbContextWrapperMock.Object,
                loggerMock.Object
            );

            // Act
            await listService.DeleteListAsync(existingListId);

            // Assert
            listRepositoryMock.Verify(repo => repo.DeleteListAsync(existingList), Times.Once);
        }

        [Fact]
        public async Task DeleteListAsync_NonexistentList_ThrowsBusinessException()
        {
            var dbContextWrapperMock = new Mock<IDbContextWrapper<ApplicationDbContext>>();
            var loggerMock = new Mock<ILogger<ListService>>();
            var listRepositoryMock = new Mock<IListRepository>();
            var mapperMock = new Mock<IMapper>();

            var dbContextTransactionMock = new Mock<IDbContextTransaction>();
            dbContextWrapperMock.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ThrowsAsync(new BusinessException());

            var nonExistentListId = 999;

            listRepositoryMock.Setup(repo => repo.GetListAsync(nonExistentListId))
                .ReturnsAsync((ListEntity)null); // Simulate non-existent question

            var listService = new ListService(
                listRepositoryMock.Object,
                mapperMock.Object,
                dbContextWrapperMock.Object,
                loggerMock.Object
            );

            // Act & Assert
            await Assert.ThrowsAsync<BusinessException>(async () => await listService.DeleteListAsync(nonExistentListId));
        }
    }
}
