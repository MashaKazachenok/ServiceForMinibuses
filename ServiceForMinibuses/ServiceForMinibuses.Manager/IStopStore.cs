

using Models;

namespace ServiceForMinibuses.Manager
{
    public interface IStopStore
    {
        Stop GetStopById(int id);
    }
}
