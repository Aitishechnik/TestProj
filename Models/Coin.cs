using System.ComponentModel.DataAnnotations;

namespace TestProj.Models;

public class Coin {
    public int Id   { get; set; }
    [Range(1900,2023)]
    public int Year { get; set; }
    public string Country { get; set; }
    public string Metal   { get; set; }
    public string Face    { get; set; }
    public string Comment { get; set; } =".";
    public string Denomination   { get; set; }

	public void ReplaceCoinData(Coin coin)
	{
		if (coin != null)
		{
			Comment = coin.Comment;
			Country = coin.Country;
			Denomination = coin.Denomination;
			Face = coin.Face;
			Metal = coin.Metal;
			Year = coin.Year;
		}
	}
}   