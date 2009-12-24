using System.Collections.Generic;
using System.Linq;
using NHibernate;

using ShowOff.Core.Data;

namespace ShowOff.Core.Repository
{
    public abstract class NHibernateRepositoryBase<T> : IRepository<T> where T : class
    {
        protected ISession _session;

        public NHibernateRepositoryBase()
        {
            _session = SessionFactoryFactory.GetSessionFactory().OpenSession();
        }

        public virtual IList<T> GetAll()
        {
            var criteria = _session.CreateCriteria(typeof(T));

            return criteria.List<T>();
        }

        public virtual T GetById(int id)
        {
            return _session.Get<T>(id);
        }

        public virtual void Add(T entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public virtual void Add(IList<T> entities)
        {
            foreach (var t in entities)
            {
                Add(t);
            }
        }

        public virtual void Update(T entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public virtual void Delete(T entity)
        {
           _session.Delete(entity);
        }

        public virtual void Delete(IList<T> entities)
        {
            foreach (var t in entities)
            {
                Delete(t);    
            }
        }

        public virtual void Save()
        {
            _session.Flush();
        }

    }
}