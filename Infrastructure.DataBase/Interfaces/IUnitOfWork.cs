namespace Infrastructure.DataBase.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}