using MapsterMapper;
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Products.Commands
{
    internal class UpdateProductHandler : AsyncRequestHandler<UpdateProductRequest>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public UpdateProductHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        protected async override Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var entity = await appContext.Products.FindAsync(request.dto.Id);
            if (entity == null)
            {
                return;
            }
            var product = mapper.Map<Domain.Models.Product>(request.dto);
            appContext.Entry(entity).CurrentValues.SetValues(product);
            await appContext.SaveChangesAsync();
        }
    }
}
