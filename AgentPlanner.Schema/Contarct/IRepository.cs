namespace AgentPlanner.Repositories.Contarct
{
    public interface IRepository<TModel, TPk>
    {
        TPk Add(TModel model);
        TPk Update(TModel model);
        int Remove(TPk id);
        TModel Get(TPk id);
    }
}
