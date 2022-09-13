namespace MoveIT.Application.Exceptions;

public sealed class ProposalNotFoundException :NotFoundException
{
    
    public ProposalNotFoundException(int id) 
        : base($"Proposal with id {id} is not found")
    {
    }
}