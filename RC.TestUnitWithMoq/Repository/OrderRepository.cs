using RC.TestUnitWithMoq.Domains;
using RC.TestUnitWithMoq.Interface.Repository;
using RC.TestUnitWithMoq.Response;
using System;

namespace RC.TestUnitWithMoq.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Order GetById(Guid id)
        {
            return new Order();
        }

        public OrderResponse Salvar(Order order)
        {
            return new OrderResponse();
        }
    }
}
