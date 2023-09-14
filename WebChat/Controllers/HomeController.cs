using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;
using System.Text.Json;
using System.Xml.Linq;
using WebChat.Models;

namespace WebChat.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly MarketOddsService _mongo;

		public HomeController(ILogger<HomeController> logger, MarketOddsService mongo)
		{
			_logger = logger;
			_mongo = mongo;
		}

		public async Task<IActionResult> Index()
		{
			string eventname = "Armenia vs Croatia";
			string A_indicator = "Home";
			string handicap_A = "0.5";
			string handicap_B = "-0.5";
			string B_indicator = "Away";
			var listA = await _mongo.GetAsync(eventname, A_indicator, handicap_A);	
			var listB = await _mongo.GetAsync(eventname, B_indicator, handicap_B);
			ViewBag.dataA = listA.ConvertAll(x => new Odds
			{
				name = x.name,
				indicator = x.indicator,
				handicap = x.handicap,
				odds = x.odds,
				decimalOdds = x.decimalOdds,
				date = x.date
			}).ToArray();
			ViewBag.dataAName = A_indicator;
			ViewBag.dataB = listB.ConvertAll(x => new Odds
			{
				name = x.name,
				indicator = x.indicator,
				handicap = x.handicap,
				odds = x.odds,
				decimalOdds = x.decimalOdds,
				date = x.date
			}).ToArray();
			ViewBag.dataBName = B_indicator;
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}