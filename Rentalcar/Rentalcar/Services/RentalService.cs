using Rentalcar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentalcar.Services;

class RentalService
{
    public double PricePerHour { get; private set; }
    public double PricePerDay { get; private set; }

    private BrazilTaxService _BrazilTaxService = new BrazilTaxService();

    public RentalService(double pricePerHour, double pricePerDay)
    {
        PricePerHour = pricePerHour;
        PricePerDay = pricePerDay;
    }
    public void ProcessInvoice(CarRental carRental)
    {
        TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

        double basicPayment = 0.0;

        if(duration.TotalHours <= 12) 
        {
            basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
        }
        else
        {
            basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
        }

        double tax = _BrazilTaxService.Tax(basicPayment);

        carRental.Invoice = new Invoice(basicPayment, tax); 
    }
}

