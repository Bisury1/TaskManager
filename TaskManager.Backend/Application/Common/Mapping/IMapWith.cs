using AutoMapper;

namespace TaskManager.Application.Common.Mapping
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile);
    }
}
