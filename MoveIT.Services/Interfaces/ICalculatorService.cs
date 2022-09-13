using MoveIT.Application.DTOs;

namespace MoveIT.Services.Interfaces;

public interface ICalculatorService
{
    int CalculatePrice(CalculatorDto calculatorDto);
}