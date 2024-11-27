namespace Tests {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EFTuto.Models;
    using EFTuto.Services;
    using Moq;
    using Xunit;

    public class OrderStatusServiceTest {
        private readonly Mock<IOrderStatusRepository> _orderStatusRepository;
        private readonly OrderStatusService _orderStatusService;

        public OrderStatusServiceTest() {
            _orderStatusRepository = new Mock<IOrderStatusRepository>();
            _orderStatusService = new OrderStatusService(_orderStatusRepository.Object);
        }

        [Fact]
        public void GetOrderStatuses_ReturnsOrderStatuses() {
            // Arrange
            var orderStatuses = new List<OrderStatus> {
                new OrderStatus { Id = 1, Name = "Pending" },
                new OrderStatus { Id = 2, Name = "Processing" },
                new OrderStatus { Id = 3, Name = "Completed" }
            };
            _orderStatusRepository.Setup(repo => repo.GetOrderStatuses).Returns(orderStatuses);

            // Act
            var result = _orderStatusService.GetOrderStatuses.ToList();

            // Assert
            Assert.Equal(result.Count, orderStatuses.Count);
            Assert.Equal(orderStatuses, result);
        }

        [Fact]
        public void GetOrderStatusById_ReturnsOrderStatus() {
            // Arrange
            var orderStatus = new OrderStatus { Id = 1, Name = "Pending" };
            _orderStatusRepository.Setup(repo => repo.GetOrderStatusById(1)).Returns(orderStatus);

            // Act
            var result = _orderStatusService.GetOrderStatusById(1);

            // Assert
            Assert.Equal(orderStatus, result);
        }
    }
}