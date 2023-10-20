using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.Platforms
{
    [Obsolete]
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Presents any software or service that has a command line interface.");

            descriptor
                .Field(p => p.LicenseKey).Ignore();

            descriptor
                .Field(p => p.commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of availble commands for this platform");
        }
        private class Resolvers
        {
            public IQueryable<Command> GetCommands([Parent]Platform platform, [ScopedService] AppDbContext context)
            {
                return context.Commands.Where(p => p.PlatformId == platform.Id);
            }
        }
    }
}