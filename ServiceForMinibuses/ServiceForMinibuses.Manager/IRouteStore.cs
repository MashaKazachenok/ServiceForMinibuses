using Models;

namespace ServiceForMinibuses.Manager
{
    public interface IRouteStore
    {
        Route GetRouteById(int id);
    }
}
