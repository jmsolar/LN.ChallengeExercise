namespace LN.Application.NewFolder.Interfaces
{
    public interface IMapContactRequest<T1, T2> where T1 : class
    {
        void AssignRequest(T1 request);
        void MapRequest();
        T2 MapResponse();
    }
}
