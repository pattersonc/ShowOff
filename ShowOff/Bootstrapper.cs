using StructureMap;

namespace ShowOff
{
    public static class Bootstrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x => x.AddRegistry(new DependencyRegistry()));
        }
    }
}