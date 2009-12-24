using System.Collections.Generic;
using ShowOff.Core.Model;

namespace ShowOff.Core.Repository
{
    public interface IItemRepository
    {
        IList<Item> GetAll();
        Item GetById(int id);
        void Add(Item entity);
        void Add(IList<Item> entities);
        void Update(Item entity);
        void Delete(Item entity);
        void Delete(IList<Item> entities);
        void Save();
    }

    public class ItemRepository : NHibernateRepositoryBase<Item>, IItemRepository
    {
        
    }
}