namespace Api.GraphQLMutations;

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
}

/// <summary>
/// 
/// </summary>
public class MutationType : ObjectType<Mutation>
{
    protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
    {
        descriptor.Field(f => f.AddReceptionDocument(default));
    }
}    