using RC.TestUnitWithMoq.Domains;
using RC.TestUnitWithMoq.Response;
using System;

namespace RC.TestUnitWithMoq.Interface.Repository
{
    public interface IOrderRepository
    {
        Order GetById(Guid id);
        OrderResponse Salvar(Order order);

    }
}