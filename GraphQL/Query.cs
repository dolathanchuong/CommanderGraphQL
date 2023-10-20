using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL
{
    [Obsolete]
    [GraphQLDescription("Represents the queries available.")]
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        // [UseProjection]
        [GraphQLDescription("Gets the queryable platform.")]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        // [UseProjection]
        [GraphQLDescription("Gets the queryable command.")]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}