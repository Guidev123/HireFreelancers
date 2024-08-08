﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderProject.Business.ValueObject
{
    public class Phone
    {
        public Phone(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) throw new DomainException("Phone number cannot be empty.");
            if (!IsValidPhoneNumber(number)) throw new DomainException("Invalid phone number format.");
        }

        private bool IsValidPhoneNumber(string number)
        {
            var regex = new Regex(@"^\+\d{2} \(\d{2}\)\d{5}-\d{4}$");
            return regex.IsMatch(number);
        }
    }
}