using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TectoluxConfigurator.Models;

namespace TectoluxConfigurator.Validators 
{
    public class ConfiguratorValidator : AbstractValidator<ConfiguratorViewModel>
    {
        public ConfiguratorValidator()
        {
            RuleFor(x => x.Length).NotEmpty().WithMessage("Een lengte is verplicht");
            RuleFor(x => x.Length).LessThanOrEqualTo(4000).WithMessage("Lengte moet tussen 1700 mm en 4000 mm zijn");
            RuleFor(x => x.Length).GreaterThanOrEqualTo(1700).WithMessage("Lengte moet tussen 1700 mm en 4000 mm zijn");
            RuleFor(x => x.Width).NotEmpty().WithMessage("Een breedte is verplicht");
            RuleFor(x => x.Width).LessThanOrEqualTo(1200).WithMessage("Breedte moet tussen 800 mm en 1200 mm zijn");
            RuleFor(x => x.Width).GreaterThanOrEqualTo(800).WithMessage("Breedte moet tussen 800 mm en 1200 mm zijn");
            RuleFor(x => x.SelectedGlassOptionId).NotEmpty().WithMessage("Selecteer een glasoptie");
            RuleFor(x => x.SelectedBlindsOptionId).NotEmpty().WithMessage("Selecteer een zonneweringsoptie");
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Een aantal is verplicht");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Het veld 'naam' is verplicht");
            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("Het veld 'e-mailadres' is verplicht");
            RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("E-mailadres is niet goed ingevuld");
        }
    }
}
