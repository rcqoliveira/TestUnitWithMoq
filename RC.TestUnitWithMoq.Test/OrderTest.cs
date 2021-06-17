using Moq;
using NUnit.Framework;
using RC.TestUnitWithMoq.Domains;
using RC.TestUnitWithMoq.Interface.Repository;
using RC.TestUnitWithMoq.Response;
using RC.TestUnitWithMoq.Service;
using System;

namespace RC.TestUnitWithMoq.Test
{
    public class OrderTest
    {

        private OrderService orderService;
        private readonly Mock<IOrderRepository> orderRepositoryMock = new Mock<IOrderRepository>();

        [SetUp]
        public void Setup()
        {
            this.orderService = new OrderService(orderRepositoryMock.Object);
        }

        [Test]
        public void GetById_ShouldReturnTrue_WhenOrderExist()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var createDate = DateTime.Now;
            var orderResponse = new OrderResponse { Id = orderId, CreatedDate = createDate };
            var order = new Order { Id = orderId, CreatedDate = createDate };

            this.orderRepositoryMock.Setup(x => x.GetById(orderId)).Returns(order);

            // Act
            var item = this.orderService.GetById(orderId);

            // Assets
            Assert.AreEqual(orderId, item.Id);
            Assert.AreEqual(createDate, item.CreatedDate);

        }

        [Test]
        public void GetById_ShouldReturnNothing_WhenOrderDoesNotExist()
        {
            // Arrange
            this.orderRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(() => null);

            // Act
            var item = this.orderService.GetById(Guid.NewGuid());

            // Assets
            Assert.Null(item);
        }

        [Test]
        public void Save_ShouldReturnOrder_WhenOrderNotNull()
        {
            //Arrange
            var createDate = DateTime.Now;
            var order = new Order { CreatedDate = createDate };
            var orderResponse = new OrderResponse { CreatedDate = createDate };

            this.orderRepositoryMock.Setup(x => x.Salvar(It.IsAny<Order>())).Returns(orderResponse);

            //Act
            var item = this.orderService.Save(order);

            //Assets
            Assert.NotNull(order);
            Assert.AreNotEqual(item.Id, Guid.Empty);
        }

        [Test]
        public void Save_ShouldReturnException_WhenOrderNoFieldCreatedDate()
        {
            //Arrange
            var order = new Order();
            this.orderRepositoryMock.Setup(x => x.Salvar(order)).Returns(() => null);

            try
            {
                //Act
                var item = this.orderService.Save(new Order());
            }
            catch (Exception ex)
            {
                //Assets
                Assert.IsTrue(ex.Message.Contains("CreatedDate field is required"));
            }
        }

        [Test]
        public void Save_ShouldReturnNothing_WhenOrderDoesNotExist()
        {
            //Arrange
            var order = new Order();
            this.orderRepositoryMock.Setup(x => x.Salvar(order)).Returns(() => null);

            //Act
            var item = this.orderService.Save(new Order { CreatedDate = DateTime.Now });

            //Assets
            Assert.Null(item);

        }
    }
}