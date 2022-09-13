using MoveIT.Application.DTOs;

namespace MoveIT.Services.Interfaces;

public interface IProposalService
{
    Task<IEnumerable<ProposalDto>> GetAllProposalsAsync();
    Task<ProposalDto> GetProposalByIdAsync(int id);
    Task<IEnumerable<ProposalDto>> GetProposalsByUserIdAsync(string userId);
    Task CreateProposal(ProposalDto proposalDto, string userId);
    Task ModifyProposal(ProposalDto proposalDto, string userId);
    Task DeleteProposal(int id);
}