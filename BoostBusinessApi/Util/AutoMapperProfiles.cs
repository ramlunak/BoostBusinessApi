using AutoMapper;
using BoostBusinessApi.Aplication.Commands;
using BoostBusinessApi.Data.Entity;

namespace BoostBusinessApi.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserCreateRequest, UserEntity>();
            CreateMap<UserUpdateRequest, UserEntity>();

            //CreateMap<PeliculaCreacionDTO, Pelicula>()
            //    .ForMember(ent => ent.Generos, dto =>
            //    dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));

            //CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();
        }
    }
}
