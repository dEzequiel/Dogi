using Api.GraphQLQueries;
using Domain.Entities;

namespace Api.GraphQLMutations;

public class ReceptionDocumentMutation
{
    private readonly List<ReceptionDocument> _documents = new List<ReceptionDocument>();
    
    public bool CreateReceptionDocument(Guid id)
    {
        ReceptionDocument doc = new ReceptionDocument()
        {
            Id = Guid.NewGuid()
        };
        
        _documents.Add(doc);

        return true;
    }
}