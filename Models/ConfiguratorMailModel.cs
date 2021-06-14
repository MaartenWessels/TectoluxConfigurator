using PostmarkDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TectoluxConfigurator.Data.Entities;

namespace TectoluxConfigurator.Models
{
    public class ConfiguratorMailModel : Configurator
    {
        public GlassOption GlassOption { get; set; }
        public BlindsOption BlindsOption { get; set; }
    }
}
