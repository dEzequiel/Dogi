namespace Api.GraphQL.GraphQLMutations;

public class Mutation
{
    private ReceptionDocumentMutation _receptionDocument;

    public Mutation()
    {
        _receptionDocument = new ReceptionDocumentMutation();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool AddReceptionDocument(Guid id)
    {
        var result = _receptionDocument.CreateReceptionDocument(id);
        return result;
    }

    public bool UpdateReceptionDocument(Guid actualId, Guid newId)
    {
        var result = _receptionDocument.UpdateReceptionDocument(actualId, newId);
        return result;
    }
}

/// <summary>
/// 
/// </summary>
public class MutationType : ObjectType<Mutation>
{
    protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
    {
        descriptor.Field(f => f.AddReceptionDocument(default));
        descriptor.Field(f => f.UpdateReceptionDocument(default, default));
    }
}
