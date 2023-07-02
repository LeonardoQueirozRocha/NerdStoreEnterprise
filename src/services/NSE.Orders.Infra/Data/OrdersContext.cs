using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Core.DomainObjects;
using NSE.Core.Mediator;
using NSE.Core.Messages;
using NSE.Orders.Domain.Vouchers;

namespace NSE.Orders.Infra.Data
{
    public class OrdersContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public OrdersContext(DbContextOptions<OrdersContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            var success = await base.SaveChangesAsync() > 0;

            if (success) await _mediatorHandler.PublishEventsAsync(this);

            return success;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishEventsAsync<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities.SelectMany(x => x.Entity.Notifications).ToList();

            domainEntities.ToList().ForEach(entity => entity.Entity.ClearEvents());

            var tasks = domainEvents.Select(async (domainEvent) =>
            {
                await mediator.PublishEventAsync(domainEvent);
            });

            await Task.WhenAll(tasks);
        }
    }
}
