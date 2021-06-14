using FluentValidation.Results;
using PostmarkDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TectoluxConfigurator.Data.Entities;

namespace TectoluxConfigurator.Models
{
    public class ConfiguratorViewModel : Configurator
    {
        public List<GlassOption> GlassOptions { get; set; }
        public List<BlindsOption> BlindsOptions { get; set; }
        public GlassOption SelectedGlassOption { get; set; }
        public int SelectedGlassOptionId { get; set; }
        public BlindsOption SelectedBlindsOption { get; set; }
        public int SelectedBlindsOptionId { get; set; }
        public ValidationResult ValidationResult { get; set; }

    }


}
