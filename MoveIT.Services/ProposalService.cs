using Mapster;
using MoveIT.Application.DTOs;
using MoveIT.Application.Exceptions;
using MoveIT.Data.Entities;
using MoveIT.Data.Persistence.Repositories.Interfaces;
using MoveIT.Services.Interfaces;

namespace MoveIT.Services;

public class ProposalService : IProposalService
{
    private readonly IProposalRepository _repository;
    public ProposalService(IProposalRepository repository) => _repository = repository;

    public async Task<IEnumerable<ProposalDto>> GetAllProposalsAsync()
    {
        var proposals = await _repository.GetAllAsync();

        return proposals.Adapt<IEnumerable<ProposalDto>>();
    }

    public async Task<ProposalDto> GetProposalByIdAsync(int id)
    {
        var proposal = await _repository.GetByIdAsync(id);

        if (proposal is null)
            throw new ProposalNotFoundException(id);

        //map to dto
        return proposal.Adapt<ProposalDto>();
    }

    public async Task<IEnumerable<ProposalDto>> GetProposalsByUserIdAsync(string userId)
    {
        var proposals = await _repository.GetByUserIdAsync(userId);

        return proposals.Adapt<IEnumerable<ProposalDto>>();
    }

    public async Task CreateProposal(ProposalDto proposalDto, string userId)
    {
        if (proposalDto == null)
            throw new ArgumentNullException(nameof(proposalDto));

        var proposal = proposalDto.Adapt<Proposal>();
        proposal.UserId = userId;
        await _repository.Save(proposal);
    }

    public async Task ModifyProposal(ProposalDto proposalDto, string userId)
    {
        if (proposalDto == null)
            throw new ArgumentNullException(nameof(proposalDto));

        var proposal = proposalDto.Adapt<Proposal>();
        proposal.UserId = userId;

        await _repository.Update(proposal);
    }

    public async Task DeleteProposal(int id) => 
        await _repository.Delete(id);
}