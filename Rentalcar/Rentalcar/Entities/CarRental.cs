using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentalcar.Entities;

class CarRental
{
    public DateTime Start { get; set; }
    public DateTime Finish { get; set; }
    public Vehicle Vehicle { get; set; }
    public Invoice Invoice { get; set; }

    public CarRental(DateTime start, DateTime finish, Vehicle vehicle, Invoice invoice)
    {
        Start = start;
        Finish = finish;
        Vehicle = vehicle;
        Invoice = null;
    }
    public CarRental(DateTime start, DateTime finish, object value)
    {
        Start = start;
        Finish = finish;
    }
}
