using System.ComponentModel.Design;

static async Task<string> CallUrl(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetStringAsync(url);
    return response;
}


    string url = "https://es.tradingview.com/symbols/BTCUSD/";
    var response = CallUrl(url).Result;
    Console.WriteLine(response);
