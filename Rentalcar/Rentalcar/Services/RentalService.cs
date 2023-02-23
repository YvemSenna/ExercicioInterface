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

    private ITaxService _TaxService;

    public RentalService(double pricePerHour, double pricePerDay, ITaxService itaxservice)
    {
        PricePerHour = pricePerHour;
        PricePerDay = pricePerDay;
        _TaxService = itaxservice;
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

        double tax = _TaxService.Tax(basicPayment);

        carRental.Invoice = new Invoice(basicPayment, tax); 
    }
}

