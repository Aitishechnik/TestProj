using TestProj.Models;

namespace TestProj.Services
{
    public interface ICoinsData
    {
        public IEnumerable<Coin> Coins { get; }
        public void AddCoin(Coin obj);
    }
}
