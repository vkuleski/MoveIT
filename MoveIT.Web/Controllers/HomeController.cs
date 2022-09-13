using Microsoft.AspNetCore.Mvc;
using MoveIT.Web.Models;
using System.Diagnostics;
using System.Security.Claims;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using MoveIT.Application.DTOs;
using MoveIT.Services.Interfaces;

namespace MoveIT.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProposalService _proposalService;
        private readonly ICalculatorService _calculatorService;

        private string CurrentUserId { get; }
        public HomeController(IProposalService proposalService,
            ICalculatorService calculatorService, IHttpContextAccessor httpContextAccessor)
        {
            _proposalService = proposalService;
            _calculatorService = calculatorService;
            CurrentUserId = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public async Task<IActionResult> Index()
        {
            var proposals = await _proposalService.GetProposalsByUserIdAsync(CurrentUserId);

            return View(proposals.Adapt<List<ProposalViewModel>>());
        }

        public int TotalPrice(CalculatorDto calculator) =>
            _calculatorService.CalculatePrice(calculator);

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProposalViewModel proposalViewModel)
        {
            if (!ModelState.IsValid)
                return View(proposalViewModel);


            await _proposalService.CreateProposal(proposalViewModel.Adapt<ProposalDto>(), CurrentUserId);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _proposalService.DeleteProposal(id);

            TempData["Success"] = "The proposal has been deleted";

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}