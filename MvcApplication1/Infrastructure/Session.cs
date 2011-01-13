using System;
using System.Linq;
using Norm.Linq;

namespace MvcApplication1.Infrastructure
{
    internal class MongoSession<TEntity> : IDisposable
    {
        private readonly MongoQueryProvider provider;

        public MongoSession()
        {
            this.provider = new MongoQueryProvider("Twisted");
        }

        public IQueryable<TEntity> Queryable
        {
            get { return new MongoQuery<TEntity>(this.provider); }
        }

        public MongoQueryProvider Provider
        {
            get { return this.provider; }
        }

        public void Add<T>(T item) where T : class, new()
        {
            this.provider.DB.GetCollection<T>().Insert(item);
        }

        public void Dispose()
        {
            this.provider.Server.Dispose(); 
        }
        public void Delete<T>(T item) where T : class, new()
        {
            this.provider.DB.GetCollection<T>().Delete(item);
        }

        public void Drop<T>()
        {
            this.provider.DB.DropCollection(typeof(T).Name);
        }

        public void Save<T>(T item) where T : class,new()
        {
            this.provider.DB.GetCollection<T>().Save(item);            
        }
        

    }    
}