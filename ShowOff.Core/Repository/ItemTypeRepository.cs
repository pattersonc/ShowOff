using System.Collections.Generic;
using ShowOff.Core.Model;

namespace ShowOff.Core.Repository
{
    public interface IItemTypeRepository
    {
        IList<ItemType> GetAll();
        ItemType GetById(int id);
        void Add(ItemType entity);
        void Add(IList<ItemType> entities);
        void Update(ItemType entity);
        void Delete(ItemType entity);
        void Delete(IList<ItemType> entities);
        void Save();
    }

    public class ItemTypeRepository : NHibernateRepositoryBase<ItemType>, IItemTypeRepository
    {
        
    }
}