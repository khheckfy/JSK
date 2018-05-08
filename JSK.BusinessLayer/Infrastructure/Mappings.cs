using AutoMapper;
using System.Linq;
using System.Reflection;

namespace JSK.BusinessLayer.Infrastructure
{
    public class Mappings
    {
        public static void RegisterMappings()
        {
            var all =
            Assembly
               .GetEntryAssembly()
               .GetReferencedAssemblies()
               .Select(Assembly.Load)
               .SelectMany(x => x.DefinedTypes)
               .Where(type => typeof(Profile).GetTypeInfo().IsAssignableFrom(type.AsType()));

            foreach (var ti in all)
            {
                var t = ti.AsType();
                if (t.Equals(typeof(Profile)))
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.AddProfiles(t); // Initialise each Profile classe
                    });
                }
            }
        }

    }
}
