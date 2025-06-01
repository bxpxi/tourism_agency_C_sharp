using System.Collections.Generic;
using Domain;
using Repository;

namespace Service
{
    public class AbstractService<ID, E, R> : IService<ID, E> where E : Entity<ID> where R : IRepository<ID, E>
    {
        protected R Repository { get; }

        public AbstractService(R repository)
        {
            Repository = repository;
        }

        public void Save(E entity)
        {
            Repository.Save(entity);
        }

        public void Delete(ID id)
        {
            Repository.Delete(id);
        }

        public void Update(E entity)
        {
            Repository.Update(entity);
        }

        public E FindById(ID id)
        {
            return Repository.FindById(id);
        }

        public IEnumerable<E> FindAll()
        {
            return Repository.FindAll();
        }
    }
}