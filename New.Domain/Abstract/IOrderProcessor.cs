using New.Domain.Entities;

namespace New.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, RequestDetails requestDetails);
    }
}
