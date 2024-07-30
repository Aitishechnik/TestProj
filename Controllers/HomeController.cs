using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using TestProj.Models;
using TestProj.Services;

namespace TestProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //readonly static CoinsData _coinsData = new();
        private ICoinsData _coinsData;

        public HomeController(ILogger<HomeController> logger, ICoinsData coinsData)
        {
            _logger = logger;
            _coinsData = coinsData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowCoins()
        {
            return View(_coinsData.Coins);
        }

        [HttpGet]
        public IActionResult EditCoin(int id)
        {
            var coin = _coinsData.Coins.FirstOrDefault(x => x.Id == id);
            if (coin != null)
                return View(coin);
            throw new Exception("Coin error");
        }

        [HttpPost]
        public IActionResult Save(Coin coin)
        {
			var _coin = _coinsData.Coins.FirstOrDefault(item => item.Id == coin.Id);
			if (_coin != null)
				_coin.ReplaceCoinData(coin);
			return RedirectToAction("ShowCoins");
		}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
