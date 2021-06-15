using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostmarkDotNet;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TectoluxAPI.Data;
using TectoluxConfigurator.Models;
using TectoluxConfigurator.Validators;

namespace TectoluxConfigurator.Controllers
{
    public class ConfiguratorController : Controller
    {
        private readonly TectoluxDbContext _context;
        private readonly IConfiguration _config;

        public ConfiguratorController(TectoluxDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<ActionResult> Index()
        {
            var viewModel = await GetViewModel();
            return View(viewModel);
        }

        public IActionResult Thanks()
        {
            return View("Thanks"); 
        }

        [HttpPost]
        public async Task<ActionResult<ConfiguratorViewModel>> Configurate(ConfiguratorViewModel formResult)
        {
            var glassOption = await _context.GlassOptions.SingleOrDefaultAsync(x => x.Id == formResult.SelectedGlassOptionId);
            var blindsOption = await _context.BlindsOptions.SingleOrDefaultAsync(x => x.Id == formResult.SelectedBlindsOptionId);
            var glassOptions = await _context.GlassOptions.ToListAsync();
            var blindsOptions = await _context.BlindsOptions.ToListAsync();
            formResult.GlassOptions = glassOptions;
            formResult.BlindsOptions = blindsOptions;
            formResult = GetRoofLight(formResult).Result;
            formResult.ValidationResult = new ValidationResult();

            var validator = new ConfiguratorValidator();
            ValidationResult validatorResult = validator.Validate(formResult);

            if (!validatorResult.IsValid)
            {
                formResult.ValidationResult = validatorResult;
                return View("Index", formResult);
            }

            //var mailModel = new ConfiguratorMailModel
            //{
            //    BlindsOption = blindsOption,
            //    GlassOption = glassOption,
            //    ItemPrice = formResult.ItemPrice,
            //    TotalPrice = formResult.TotalPrice,
            //    Length = formResult.Length,
            //    Width = formResult.Width,
            //    Amount = formResult.Amount,
            //    FullName = formResult.FullName,
            //    EmailAddress = formResult.EmailAddress,
            //    PhoneNumber = formResult.PhoneNumber
            //};
            //var toSalesMessage = new TemplatedPostmarkMessage
            //{
            //    From = _config.GetValue<string>("Postmark:FromEmailAddress"),
            //    To = _config.GetValue<string>("Postmark:SalesEmailAddress"),
            //    TemplateId = _config.GetValue<int>("Postmark:SalesTemplateKey"),
            //    TemplateModel = mailModel,
            //};
            //var toCustomermessage = new TemplatedPostmarkMessage
            //{
            //    From = _config.GetValue<string>("Postmark:FromEmailAddress"),
            //    To = mailModel.EmailAddress,
            //    TemplateId = _config.GetValue<int>("Postmark:CustomerTemplateKey"),
            //    TemplateModel = mailModel,
            //};
            //var client = new PostmarkClient(_config.GetValue<string>("Postmark:PostmarkApiKey"));
            //await client.SendMessageAsync(toSalesMessage);
            //await client.SendMessageAsync(toCustomermessage);

            return RedirectToAction("Thanks");
        }

        public async Task<ConfiguratorViewModel> GetViewModel()
        {
            var glassOptions = await _context.GlassOptions.ToListAsync();
            var blindsOptions = await _context.BlindsOptions.ToListAsync();
            var viewModel = new ConfiguratorViewModel
            {
                GlassOptions = glassOptions,
                BlindsOptions = blindsOptions,
                SelectedGlassOptionId = glassOptions[0].Id,
                SelectedBlindsOptionId = blindsOptions[0].Id,
                Length = 2900,
                Width = 1200,
                Amount = 1,
                ValidationResult = new ValidationResult()
            };
            var newPriceViewModel = GetRoofLight(viewModel);
            return newPriceViewModel.Result;
        }

        public async Task<ConfiguratorViewModel> GetRoofLight(ConfiguratorViewModel formResult)
        {
            var glassOption = await _context.GlassOptions.SingleOrDefaultAsync(x => x.Id == formResult.SelectedGlassOptionId);
            var blindsOption = await _context.BlindsOptions.SingleOrDefaultAsync(x => x.Id == formResult.SelectedBlindsOptionId);
            var price = 1200 + (formResult.Length * 0.2m) + (formResult.Width * 0.2m) + blindsOption.Price + glassOption.Price;
            price = price + (0.21m * price);
            var totalPrice = price * formResult.Amount;

            formResult.ImageUrl = $"{glassOption.SortOrder}-{blindsOption.SortOrder}.png";
            formResult.SelectedGlassOption = glassOption;
            formResult.SelectedBlindsOption = blindsOption;
            formResult.ItemPrice = price.ToString("C2", new CultureInfo("nl-NL"));
            formResult.TotalPrice = totalPrice.ToString("C2", new CultureInfo("nl-NL"));
            return formResult;
        }
    }
}
