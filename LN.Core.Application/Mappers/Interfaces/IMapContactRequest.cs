namespace LN.Application.Mappers.Interfaces
{
    public interface IMapContactRequest<T1, T2>
    {
        void AssignRequest(T1 request);
        void MapRequest();
        T2 MapResponse();
    }
}
