using AutoMapper;
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.ProductType.Commands
{
    internal class UpdateProductTypeHandler : AsyncRequestHandler<UpdateProductTypeRequest>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public UpdateProductTypeHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        protected async override Task Handle(UpdateProductTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = await appContext.ProductTypes.FindAsync(request.dto.Id);
            if (entity == null)
            {
                return;
            }
            appContext.Entry(entity).CurrentValues.SetValues(new Domain.Models.ProductType(request.dto.Id, request.dto.Name));
            await appContext.SaveChangesAsync();
        }
    }
}
