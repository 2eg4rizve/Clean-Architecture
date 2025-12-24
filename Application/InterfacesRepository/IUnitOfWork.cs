using System;
using System.Collections.Generic;
using System.Text;

namespace Application.InterfacesRepository
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }

        Task<int> CommitAsync();
    }
}
