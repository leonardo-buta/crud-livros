namespace Livros.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static Type[] RegisterMappings()
        {
            return new Type[]
            {
                typeof(DomainToDTOMappingProfile),
                typeof(DTOToDomainMappingProfile)
            };
        }
    }
}
