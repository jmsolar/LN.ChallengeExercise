using LN.Application.NewFolder.Interfaces;

namespace LN.Application.NewFolder.Implementations
{
    public class MapContactRequest<T> : IMapContactRequest<T> where T : class
    {
        public T _requestToMap;
        public T _responseToMap;

        public void AssignRequest(T request) {
            _requestToMap = request;
        }

        public void MapRequest() { }

        public T MapResponse() {
            return _responseToMap;
        }
    }
}
