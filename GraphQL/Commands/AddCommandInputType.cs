namespace CommanderGQL.GraphQL.Commands
{
    public class AddCommandInputType : InputObjectType<AddCommandInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddCommandInput> descriptor)
        {
            descriptor.Description("Presents the input to add for a command.");

            descriptor
                .Field(c=>c.CommanLine)
                .Description("Represents the command line.");
            
            descriptor
                .Field(c=>c.PlatformId)
                .Description("Presents the unique ID of the platform which the command belongs.");

            base.Configure(descriptor);
        }
    }
}