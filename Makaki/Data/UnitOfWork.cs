using System;
using System.Collections.Generic;
using Makaki.Data.Repository;
using Makaki.Model;

namespace Makaki.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly DatabaseContext _context = new DatabaseContext();
        private GenericRepository<MemberCategory> _memberCategoryRepository;
        private GenericRepository<MemberFunction> _memberFunctionRepository;
        private GenericRepository<Country> _countryRepository;
        private GenericRepository<Member> _memberRepository;

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public virtual GenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return Repository<TEntity>(typeof(TEntity));
        }

        public virtual GenericRepository<TEntity> Repository<TEntity>(Type type) where TEntity : class
        {
            if (type != typeof(TEntity) && !type.IsSubclassOf(typeof(TEntity)))
                throw new Exception($"'{typeof(TEntity)}' is not base class of '{type}'");

            if (!_repositories.ContainsKey(type))
                _repositories.Add(type, new GenericRepository<TEntity>(_context));

            return (GenericRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        public GenericRepository<MemberCategory> MemberCategoryRepository => _memberCategoryRepository ??
                                                                             (_memberCategoryRepository = new GenericRepository<MemberCategory>(_context));

        public GenericRepository<MemberFunction> MemberFunctionRepository => _memberFunctionRepository ??
                                                                             (_memberFunctionRepository = new GenericRepository<MemberFunction>(_context));

        public GenericRepository<Country> CountryRepository => _countryRepository ?? (_countryRepository = new GenericRepository<Country>(_context));

        public GenericRepository<Member> MemberRepository => _memberRepository ?? (_memberRepository = new GenericRepository<Member>(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        #region IDispose
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
