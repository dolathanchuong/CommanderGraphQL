using CommanderGQL.Data;
using CommanderGQL.GraphQL.Commands;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.Models;
using HotChocolate.Language;
using HotChocolate.Subscriptions;

namespace CommanderGQL.GraphQL
{
    [Obsolete]
    [GraphQLDescription("Represents the mutations available.")]
    public class Mutation
    {
        #region PlatForm Action...
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
        [GraphQLDescription("Delete a platform.")]
        public async Task<AddPlatformPayload> DeletePlatformAsync(int platformID, [ScopedService] AppDbContext context)
        {
            var _findPlatForm = context.Platforms.Where(x=>x.Id == platformID).FirstOrDefault();
            if(_findPlatForm != null)
            {
                context.Platforms.Remove(_findPlatForm);
                var _result = await context.SaveChangesAsync();
                var _check = _result > 0 ? true : false;
                return new AddPlatformPayload(_findPlatForm);
            }
            return new AddPlatformPayload(default!);
        }

        [UseDbContext(typeof(AppDbContext))]
        [GraphQLDescription("Update a platform.")]
        public async Task<AddPlatformPayload> UpdatePlatformAsync(int platformID, AddPlatformInput input, [ScopedService] AppDbContext context)
        {
            var _check= false;
            var _findPlatForm = context.Platforms.Where(x=>x.Id == platformID).FirstOrDefault();
            if(_findPlatForm != null)
            {
                _findPlatForm.Name = input.Name.Trim();
                context.Platforms.Update(_findPlatForm);
                var _result = await context.SaveChangesAsync();
                _check = _result > 0 ? true : false;
            }
            return _check ? new AddPlatformPayload(_findPlatForm!) : new AddPlatformPayload(default!);
        }
        #endregion
        #region Command Action...
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
        #endregion
    }
}