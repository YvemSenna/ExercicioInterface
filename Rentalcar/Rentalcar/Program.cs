﻿using Rentalcar.Entities;
using Rentalcar.Services;
using System;
using System.Globalization;

namespace Rentalcar; 

class Program
{
    public static void Main(string[] args) 
    {
        Console.WriteLine("Enter retal Data: ");
        Console.Write("Car Model: ");
        string model = Console.ReadLine();
        Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
        DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        Console.Write("Return (dd/MM/yyyy hh:mm): ");
        DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        Console.Write("Enter price per hour: ");
        double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Enter price per day: ");
        double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        CarRental carRental = new CarRental(start, finish, new Vehicle(model));

        RentalService rentalservice =  new RentalService(hour, day, new BrazilTaxService());

        rentalservice.ProcessInvoice(carRental);

        Console.WriteLine("INVOICE: ");
        Console.WriteLine(carRental.Invoice);
    }
}
