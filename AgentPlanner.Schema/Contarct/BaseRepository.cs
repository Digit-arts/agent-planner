using System;
using AgentPlanner.DataAccess;


namespace AgentPlanner.Repositories.Contarct
{
    public abstract class BaseRepository<TModel, TPk> : IRepository<TModel, TPk>, IDisposable
    {
        protected readonly AgentPlannerEntities Db;

        protected BaseRepository()
        {
            Db = new AgentPlannerEntities();
        }

        public void Dispose()
        {
            ((IDisposable)Db).Dispose();
        }

        public abstract TPk Add(TModel model);
        public abstract TPk Update(TModel model);
        public abstract int Remove(TPk id);
        public abstract TModel Get(TPk id);

        protected int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}
