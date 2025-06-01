using System.Collections.Generic;
using Domain;

namespace Repository
{
    public interface IRepository<ID, E> where E : Entity<ID>
    {
        E FindById(ID id);
        IEnumerable<E> FindAll();
        void Save(E entity);
        void Delete(ID id);
        void Update(E entity);
    }
}