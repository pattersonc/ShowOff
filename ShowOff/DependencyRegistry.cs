using System.Web.Security;
using ShowOff.Core.Repository;
using ShowOff.Models;
using StructureMap.Configuration.DSL;

namespace ShowOff
{
    public class DependencyRegistry : Registry
    {
        public DependencyRegistry()
        {
            For<IItemTypeRepository>().Use<ItemTypeRepository>();
            For<IItemRepository>().Use<ItemRepository>();
            For<IItemImageRepository>().Use<ItemImageRepository>();
            For<IFormsAuthenticationService>().Use<FormsAuthenticationService>();
            For<IMembershipService>().Use<AccountMembershipService>();
            For<MembershipProvider>().Use(Membership.Provider);
        }
    }
}