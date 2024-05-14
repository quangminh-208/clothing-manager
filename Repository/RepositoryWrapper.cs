using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IClothingRepository _clothing;
        private IUserRepository _user;
        private IUserOrderRepository _userOrder;
        private IOrderItemRepository _orderItem;

        public IClothingRepository Clothing
        {
            get
            {
                if (_clothing == null)
                {
                    _clothing = new ClothingRepository(_repoContext);
                }

                return _clothing;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }

        public IUserOrderRepository UserOrder
        {
            get
            {
                if (_userOrder == null)
                {
                    _userOrder = new UserOrderRepository(_repoContext);
                }

                return _userOrder;
            }
        }

        public IOrderItemRepository OrderItem
        {
            get
            {
                if (_orderItem == null)
                {
                    _orderItem = new OrderItemRepository(_repoContext);
                }

                return _orderItem;
            }
        }


        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}