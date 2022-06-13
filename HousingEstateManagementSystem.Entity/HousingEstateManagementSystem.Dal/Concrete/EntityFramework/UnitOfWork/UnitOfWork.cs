using HousingEstateManagementSystem.Dal.Abstract;
using HousingEstateManagementSystem.Dal.Concrete.EntityFramework.Repository;
using HousingEstateManagementSystem.Entity.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Dal.Concrete.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitofWork
    {
        #region Variables
        DbContext context;
        IDbContextTransaction transaction;
        bool dispose;
        #endregion

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public bool BeginTransaction()
        {
            try
            {
                transaction = context.Database.BeginTransaction();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            //Çöp toplama (Garbage collection çalıştırır)
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!dispose)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            dispose = true;
        }

        public IGenericRepository<T> GetRepository<T>() where T : EntityBase
        {
            return new GenericRepository<T>(context);
        }

        public bool RollBackTransaction()
        {
            try
            {
                transaction.Rollback();
                transaction = null;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SaveChanges()
        {
            var _transaction = transaction != null ? transaction : context.Database.BeginTransaction();
            using (_transaction)
            {
                try
                {
                    if (context == null)
                    {
                        throw new ArgumentException("Context is null");
                    }

                    int result = context.SaveChanges();

                    _transaction.Commit();

                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw new Exception("Error on save changes", ex);
                }
            }
        }
    }
}
