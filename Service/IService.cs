using System.Collections.Generic;
using Domain;

namespace Service
{
    public interface IService<ID, E> where E : Entity<ID>
    {
        void Save(E entity);
        void Delete(ID id);
        void Update(E entity);
        E FindById(ID id);
        IEnumerable<E> FindAll();
    }
}