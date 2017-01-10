using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class Program
{
	static readonly string[] PIZZA_LIST = @"- Mediteraneo
  - motsarela - 122g
  - domaten sos - 104g
  - presni domati - 30g
  - zeleni chushki - 69g
  - krave sirene - 195g
  - maslini - 56g
- Alfredo
  - smetana - 191g
  - motsarela - 194g
  - pileshko file - 12g
  - beybi spanak - 127g
- Vita
  - domaten sos - 59g
  - motsarela - 97g
  - beybi spanak - 147g
  - krave sirene - 28g
  - presni domati - 55g
- Margarita
  - domaten sos - 6g
  - motsarela - 152g
- Chikenita
  - domaten sos - 30g
  - motsarela - 17g
  - pileshko file - 199g
  - peperoni - 166g
  - domati - 144g
  - emental - 79g
- Dominos Spetsialna
  - domaten sos - 161g
  - motsarela - 137g
  - shunka - 181g
  - bekon - 37g
  - zeleni chushki - 158g
  - luk - 183g
  - gabi - 90g
- ChikChiRik
  - domaten sos - 133g
  - motsarela - 20g
  - krehko pile - 64g
  - topeno sirene - 166g
  - tsarevitsa - 0g
- Karbonara
  - smetana - 40g
  - motsarela - 158g
  - bekon - 141g
  - gabi - 160g
- Amerikan Hot
  - domaten sos - 82g
  - motsarela - 88g
  - peperoni - 149g
  - halapenyo - 197g
  - luk - 196g
- Gardan Klasik
  - domaten sos - 165g
  - motsarela - 165g
  - maslini - 194g
  - zeleni chushki - 123g
  - luk - 91g
  - presni domati - 86g
  - gabi - 8g
- Peperoni Klasik
  - domaten sos - 105g
  - motsarela - 98g
  - peperoni - 186g
- Barbekyu Pile
  - barbekyu sos - 195g
  - motsarela - 169g
  - bekon - 20g
  - krehko pile - 26g
- Barbekyu Klasik
  - barbekyu sos - 147g
  - motsarela - 175g
  - bekon - 150g
  - pikantno teleshko - 104g
- Nyu york
  - domaten sos - 177g
  - motsarela - 152g
  - bekon - 151g
  - chedar - 126g
  - presni gabi - 18g
- Shunka Klasik
  - domaten sos - 110g
  - motsarela - 74g
  - shunka - 26g
  - zeleni chushki - 166g
  - presni gabi - 150g
- Zverska
  - domaten sos - 147g
  - motsarela - 125g
  - shunka - 9g
  - bekon - 78g
  - pikantno teleshko - 55g
- Italianska
  - domaten sos - 32g
  - motsarela - 61g
  - pesto - 79g
  - parmezan - 132g
  - presni domati - 60g
  - bosilek - 30g
- Havay
  - domaten sos - 81g
  - motsarela - 180g
  - shunka - 90g
  - ananas - 47g
- Balgarska
  - motsarela - 45g
  - domaten sos - 175g
  - luk - 163g
  - maslini - 146g
  - zeleni chushki - 110g
  - krave sirene - 0g
  - selska nadenitsa - 195g
  - presni domati - 53g
  - rigan - 159g
- Formadzhi
  - domaten sos - 72g
  - motsarela - 98g
  - chedar - 194g
  - krave sirene - 82g
  - parmezan - 117g
- Ton
  - domaten sos - 54g
  - motsarela - 119g
  - riba ton - 190g
  - presni domati - 78g
  - luk - 36g
- Chorizana
  - domaten sos - 56g
  - motsarela - 102g
  - chorizo - 161g
  - pileshko file - 63g
  - krave sirene - 197g
  - presni domati - 17g
- Meat Mania
  - domaten sos - 1g
  - motsarela - 111g
  - shunka - 83g
  - bekon - 129g
  - teleshko - 70g
  - pileshko file - 86g
  - chorizo - 182g
- Unika
  - domaten sos - 185g
  - motsarela - 177g
  - parmezan - 114g
  - peperoni - 44g
  - gabi - 49g
  - presni domati - 86g
  - rukola - 42g
- Bene
  - domaten sos - 139g
  - kashkaval - 93g
  - shunka - 129g
  - tsarevitsa - 149g
  - maslini - 4g
- Bondzhorno
  - domaten sos - 99g
  - kashkaval - 23g
  - svinsko file - 199g
  - gabi - 86g
  - kiseli krastavichki - 91g
- Vegetarianska
  - domaten sos - 9g
  - kashkaval - 184g
  - gabi - 67g
  - chushki - 42g
  - luk - 42g
  - tsarevitsa - 124g
- Venetsiya
  - domaten sos - 148g
  - kashkaval - 47g
  - gabi - 43g
  - pusheni gardi - 32g
  - yaytse - 50g
  - luk - 122g
- Garda
  - domaten sos - 84g
  - kashkaval - 35g
  - pileshko role - 107g
  - pusheno sirene - 197g
  - chushki - 113g
  - maslini - 151g
- Kaltsone
  - domaten sos - 21g
  - kashkaval - 142g
  - shunka - 195g
  - gabi - 127g
- Kaprichoza
  - domaten sos - 40g
  - kashkaval - 22g
  - yaytse - 57g
  - presni domati - 14g
  - magadanoz - 160g
  - shunka - 10g
  - maslini - 88g
  - pusheni gardi - 22g
  - gabi - 35g
- Kompaniola
  - domaten sos - 16g
  - kashkaval - 87g
  - bekon - 111g
  - gabi - 198g
  - rigan - 95g
- Meksikana
  - domaten sos - 119g
  - kashkaval - 147g
  - gabi - 88g
  - lukanka - 155g
  - tsarevitsa - 153g
  - luk - 83g
  - lyuta chushka - 60g
- Morski darove
  - domaten sos - 89g
  - kashkaval - 66g
  - midi - 6g
  - kalmari - 175g
  - limon - 142g
  - zehtin - 113g
  - rigan - 121g
- Kastelo
  - domaten sok - 195g
  - shunka - 89g
  - bekon - 88g
  - pusheno sirene - 19g
  - kashkaval - 114g
  - pileshko role - 30g
  - maslini - 63g
  - kiseli krastavichki - 179g
- Prima Vera
  - domaten sos - 126g
  - kashkaval - 155g
  - shunka - 26g
  - gabi - 44g
  - domati - 22g
  - zehtin - 64g
  - bosilek - 4g
- Proshuto
  - domaten sos - 58g
  - kashkaval - 136g
  - shunka - 30g
  - proshuto - 100g
  - maslini - 136g
- Rimini
  - domaten sos - 55g
  - kashkaval - 81g
  - shunka - 4g
  - bekon - 23g
  - lukanka - 188g
  - chushki - 91g
  - gabi - 147g
  - tsarevitsa - 57g
  - yaytse - 60g
- San Marko
  - domaten sos - 129g
  - kashkaval - 28g
  - gabi - 106g
  - lukanka - 38g
  - pusheno sirene - 91g
  - zehtin - 62g
- Tono
  - domaten sos - 155g
  - kashkaval - 60g
  - riba ton - 131g
  - ratsi - 124g
  - luk - 100g
  - chesan - 142g
  - limon - 106g".Split('\n');

	static void Main()
	{
		var menu = new Dictionary<string, Dictionary<string, int>>();
		Dictionary<string, int> products = null;

		foreach(var line in PIZZA_LIST)
		{
			if(line[0] == '-')
			{
				products = new Dictionary<string, int>();
				products.Add("testo", 256);
				menu.Add(line.Split('-')[1].Trim().ToLower(), products);
			}
			else
			{
				var spl = line.Split('-');
				var product = spl[1].Trim().ToLower();
				var weight = int.Parse(spl[2].Split('g')[0].Trim());
				products.Add(product, weight);
			}
		}

		var inputBuilder = new StringBuilder();

		string input;
		while(true)
		{
			input = Console.ReadLine();
			if(input == null)
			{
				break;
			}
			inputBuilder.Append(' ' + input);
		}
		input = inputBuilder.ToString();

		int dotIndex = input.IndexOf('.');

		var words = input
			.Substring(0, dotIndex)
			.Replace(",", " , ")
			.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries)
			.Skip(1)
			.Select(x => x.ToLower())
			.Where(x => x != "pizza")
			.ToList();
		words.Add("i");

		var result = new SortedDictionary<string, int>();

		int quantity = 1;
		string item = null;
		products = null;
		foreach(var w in words)
		{
			if(w == "," || w == "i"
				|| (w == "bez" && item != null)
				|| (char.IsDigit(w[0]) && item != null))
			{
				if(products == null)
				{
					products = menu[item];
					foreach(var p in products)
					{
						if(result.ContainsKey(p.Key))
						{
							result[p.Key] += p.Value * quantity;
						}
						else
						{
							result[p.Key] = p.Value * quantity;
						}
					}
				}
				else
				{
					result[item] -= products[item] * quantity;
				}

				item = null;
			}
			else if(char.IsDigit(w[0]) || w == "bez") {}
			else if(item == null)
			{
				item = w;
			}
			else
			{
				item += " " + w;
			}

			if(char.IsDigit(w[0]))
			{
				quantity = int.Parse(w);
			}
			else if(w == "," || w == "i")
			{
				products = null;
				quantity = 1;
			}
		}

		foreach(var x in result)
		{
			if(x.Value > 0)
			{
				Console.WriteLine("{0}: {1}g", x.Key, x.Value);
			}
		}
	}
}
