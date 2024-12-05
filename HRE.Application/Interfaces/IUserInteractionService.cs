using HRE.Application.DTOs.UserInteraction;
using HRE.Domain.Entities;

namespace HRE.Application.Interfaces;

public interface IUserInteractionService
{
    Task<UserInteraction?> StartInteraction(StartUserInteractionDTO createInteraction);

    Task<UserInteraction?> FinishInteraction(FinishInteractionDTO finishInteraction);
}
