using GideonMarket.UseCases.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.ProductTypes.Commands
{
    internal class UpdateProductTypeHandler : AsyncRequestHandler<UpdateProductTypeRequest>
    {
        private readonly IAppContext appContext;

        public UpdateProductTypeHandler(IAppContext appContext)
        {
            this.appContext = appContext;
        }
        protected async override Task Handle(UpdateProductTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = await appContext.ProductTypes.FindAsync(request.dto.Id);
            if (entity == null)
            {
                return;
            }
            appContext.Entry(entity).CurrentValues.SetValues(new Entities.Models.ProductType(request.dto.Id, request.dto.Name));
            await appContext.SaveChangesAsync();
        }
    }
}
