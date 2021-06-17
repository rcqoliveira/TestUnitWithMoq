using RC.TestUnitWithMoq.Domains;
using RC.TestUnitWithMoq.Response;
using System;

namespace RC.TestUnitWithMoq.Interface.Service
{
    public interface IOrderService
    {
        OrderResponse Save(Order order);

        OrderResponse GetById(Guid id);
    }
}