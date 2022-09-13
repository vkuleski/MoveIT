using MoveIT.Application.Constants;
using MoveIT.Application.DTOs;
using MoveIT.Services.Interfaces;

namespace MoveIT.Services;

public class CalculatorService : ICalculatorService
{

    private const int PianoExtraHandlingPrice = 5000;
    public int CalculatePrice(CalculatorDto calculatorDto)
    {
        var pricePerDistance = PricePerDistance(calculatorDto.Distance);
        var numberOfCars = GetNumberOfCars(calculatorDto.LivingArea, calculatorDto.AtticArea);

        var totalPrice = pricePerDistance * numberOfCars;

        return calculatorDto.HasPiano 
            ? totalPrice + PianoExtraHandlingPrice
            :totalPrice;
    }

    private static int PricePerDistance(int distance)
    {
        if (distance <= 0)
            throw new ArgumentException("The distance value must grater than 0!");

        int price;
        switch (distance)
        {
            case < 50:
                price = PricesTo50Km.DefaultPrice + (distance * PricesTo50Km.PricePerKm);
                break;

            case >= 50 and < 100:
                price = PricesTo100Km.DefaultPrice + (distance * PricesTo100Km.PricePerKm);
                break;

            case >= 100:
                price = PricesAbove100Km.DefaultPrice + (distance * PricesAbove100Km.PricePerKm);
                break;
        }

        return price;
    }

    private static int GetNumberOfCars(int livingArea, int atticArea)
    {
        var totalAtticArea = atticArea > 0 
            ? atticArea * 2
            : atticArea;

        var totalArea = livingArea + totalAtticArea;

        var numberOfCars = totalArea > 50
            ? (totalArea / 50) + 1
            : 1;

        return numberOfCars;
    }
}