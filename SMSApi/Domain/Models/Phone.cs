﻿using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using static SMSApi.Domain.Exceptions.Exceptions;

namespace SMSApi.Domain.Models
{
    public class Phone
    {
        public string Number { get; private set; }

        public Phone(string phoneNumber)
        {
            Number = phoneNumber;
        }

        public static void Validate(Phone phone)
        {
            if (string.IsNullOrEmpty(phone.Number) || !Regex.IsMatch(phone.Number, @"^\+\d{1,3}\d{1,14}$"))
            {
                throw new InvalidPhoneNumberException("Invalid phone number format");
            }
        }
    }
}
