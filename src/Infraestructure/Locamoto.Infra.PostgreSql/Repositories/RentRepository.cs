using Locamoto.Domain.Entities;
using Locamoto.Domain.Repositories;
using Locamoto.Infra.EF.Contexts;
using Locamoto.Infra.EF.Core;
using Microsoft.EntityFrameworkCore;

namespace Locamoto.Infra.PostgreSql.Repositories
{
    internal class RentRepository : RepositoryBase<Rent>, IRentRepository
    {
        public RentRepository(LocamotoEFContext context) : base(context)
        {
        }

        public async Task<bool> ExistsRentForMotorcycle(Guid motorcycleID)
        {
            return await _dbSet.AnyAsync(x => x.Motorcycle.Id == motorcycleID && x.Status == StatusRent.Active);
        }

        public async Task<Rent?> GetByMotorcyclePlate(string plate)
        {
            return await _dbSet
                .Include(x => x.Plan)
                .Include(x => x.Motorcycle)
                .Include(x => x.Deliveryman)
                .FirstOrDefaultAsync(x => x.Motorcycle.Plate == plate);
        }

        public override async Task<Rent?> GetById(Guid id)
        {
            return await _dbSet
                .Include(x => x.Plan)
                .Include(x => x.Motorcycle)
                .Include(x => x.Deliveryman)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        
    }

    internal class OrderNotificationRepository : IOrdeDeliverymanNotificationRepository
    {
        public Task Create(OrderNotification notification)
        {
            throw new NotImplementedException();
        }

        public Task Create(OrderDeliverymanNotification notification)
        {
            throw new NotImplementedException();
        }

        public Task<OrderNotification?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasNotificationForDeliveryman(Guid orderID, Guid deliverymanID)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }

        Task<OrderDeliverymanNotification?> IOrdeDeliverymanNotificationRepository.GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}