﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rentalcar.Services;

interface ITaxService
{
    double Tax(double amount);
}
