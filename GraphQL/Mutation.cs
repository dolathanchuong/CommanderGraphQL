using CommanderGQL.Data;
using CommanderGQL.GraphQL.Commands;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.Models;
using HotChocolate.Subscriptions;

namespace CommanderGQL.GraphQL
{
    [Obsolete]
    [GraphQLDescription("Represents the mutations available.")]
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Adds a platform.")]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, 
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var platform = new Platform
            {
                Name = input.Name
            };
            Console.WriteLine(cancellationToken.IsCancellationRequested);
            context.Platforms.Add(platform);
            await context.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded),platform, cancellationToken);
            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Adds a command.")]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [ScopedService] AppDbContext context)
        {
            var command = new Command{
                HowTo = input.HowTo,
                CommandLine = input.CommanLine,
                PlatformId = input.PlatformId
            };

            context.Commands.Add(command);
            await context.SaveChangesAsync();
            return new AddCommandPayload(command);
        }
    }
}