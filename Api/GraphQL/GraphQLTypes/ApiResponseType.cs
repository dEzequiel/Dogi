using Crosscuting.Api.DTOs.Response;

namespace Api.GraphQL.GraphQLTypes
{
    public class ApiResponseType<T> : ObjectType<ApiResponse<T>>
        where T : class, IOutputType
    {
        protected override void Configure(IObjectTypeDescriptor<ApiResponse<T>> descriptor)
        {
            descriptor.Field(f => f.Succeeded)
                .Type<BooleanType>();

            descriptor.Field(f => f.Message)
                .Type<StringType>();

            descriptor.Field(f => f.Errors)
                .Type<ListType<StringType>>();

            descriptor.Field(f => f.Data)
                .Type<T>();
        }
    }
}
