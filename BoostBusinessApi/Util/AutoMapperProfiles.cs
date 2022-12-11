using AutoMapper;
using BoostBusinessApi.Data.Entity;
using BoostBusinessApi.Model.User;

namespace BoostBusinessApi.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserCreateModel, UserEntity>();
         
            //CreateMap<ActorCreacionDTO, Actor>();
            //CreateMap<Actor, ActorDTO>();
            //CreateMap<ComentarioCreacionDTO, Comentario>();

            //CreateMap<PeliculaCreacionDTO, Pelicula>()
            //    .ForMember(ent => ent.Generos, dto =>
            //    dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));

            //CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();
        }
    }
}
