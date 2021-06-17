using RC.TestUnitWithMoq.Domains;
using RC.TestUnitWithMoq.Interface.Repository;
using RC.TestUnitWithMoq.Interface.Service;
using RC.TestUnitWithMoq.Response;
using System;

namespace RC.TestUnitWithMoq.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public OrderResponse Save(Order order)
        {
            if (order.CreatedDate.Ticks == 0)
            {
                throw new ArgumentNullException("CreatedDate field is required");
            }

            var orderResponse = this.orderRepository.Salvar(order);

            if (orderResponse == null)
            {
                return null;
            }

            orderResponse.Id = Guid.NewGuid();
                
            return orderResponse;
        }

        public OrderResponse GetById(Guid id)
        {
            var order = this.orderRepository.GetById(id);

            if (order == null)
            {
                return null;
            }

            return new OrderResponse { Id = order.Id, CreatedDate = order.CreatedDate };
        }
    }
}