using CoreWebAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.IRepository
{
    public  interface IUnitOfWork:IDisposable
    {
        
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hospital> Hospitals { get; }
        Task Save();
    }
}
