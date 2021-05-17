
using GideonMarket.Infrastructure.Interfaces.DataAccess;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.Handlers.Products.Commands
{
    internal class DeleteProductHandler : AsyncRequestHandler<DeleteProductRequest>
    {
        private readonly IAppContext appContext;
        private readonly IMapper mapper;

        public DeleteProductHandler(IAppContext appContext, IMapper mapper)
        {
            this.appContext = appContext;
            this.mapper = mapper;
        }
        protected async override Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await appContext.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            appContext.Products.Remove(product);
            await appContext.SaveChangesAsync();
        }
    }
}
