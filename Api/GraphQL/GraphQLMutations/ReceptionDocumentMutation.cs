using Crosscuting.Base.Exceptions;
using Domain.Entities;

namespace Api.GraphQL.GraphQLMutations;

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

    public bool UpdateReceptionDocument(Guid actualId, Guid newId)
    {
        ReceptionDocument? doc = _documents.FirstOrDefault(d => d.Id == actualId);

        if (doc is null)
            throw new GraphQLException(new Error("DOC NOT FOUND.", StatusCodes.Status404NotFound.ToString()));

        return true;
    }
}