using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TectoluxConfigurator.Models
{
    public class Configurator
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public string ItemPrice { get; set; }
        public string TotalPrice { get; set; }
        public int Amount { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
    }
}
