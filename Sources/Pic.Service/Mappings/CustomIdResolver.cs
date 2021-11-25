using AutoMapper;

namespace Pic.Service.Mappings
{
    public class CustomIdResolver : IValueResolver<object, object, int>
    {
        public int Resolve(object source, object destination, int member, ResolutionContext context)
        {
            if (context.Items.TryGetValue(Mapper.IdProperty, out var id))
            {
                return (int)id;
            }

            return default;
        }
    }
}
