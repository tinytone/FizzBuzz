
namespace Company.Fizzbuzz.Web.Host.DependencyResolution
{
    using StructureMap;
	
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}