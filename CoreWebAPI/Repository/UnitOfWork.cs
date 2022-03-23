using CoreWebAPI.Data;
using CoreWebAPI.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hospital> _hospitals;
        public IGenericRepository<Country> Countries => _countries ??=new GenericRepository<Country>(_databaseContext);

        public IGenericRepository<Hospital> Hospitals => _hospitals  ??= new GenericRepository<Hospital>(_databaseContext);

        public UnitOfWork(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async  Task Save()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
