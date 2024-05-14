namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IClothingRepository Clothing { get; }
        IUserRepository User { get; }
        IUserOrderRepository UserOrder { get; }
        IOrderItemRepository OrderItem { get; }
        void Save();
    }
}