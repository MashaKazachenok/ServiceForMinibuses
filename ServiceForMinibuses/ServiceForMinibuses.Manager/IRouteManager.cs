
using Models;

namespace ServiceForMinibuses.Manager
{
    public interface IRouteManager
    {
        Route GetRouteById(int id);
    }
}
