using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

static async Task<string> CallUrl(string url)
{
    using HttpClient client = new HttpClient();
    var response = await client.GetStringAsync(url);
    return response;
}

static string ParseHtml(string html)
{
    HtmlDocument htmlDocument = new HtmlDocument();
    htmlDocument.LoadHtml(html);
    string inicio = "¿Cuál es el precio de Bitcoin hoy?El precio actual de Bitcoin (BTC) es";
    string fim = "USD.";

    var divTexts = htmlDocument.DocumentNode
        .Descendants("div")
        .Select(div => div.InnerText) // Pega o texto interno de cada div
        .FirstOrDefault(text => text.Contains(inicio) && text.Contains(fim)); // Pega apenas o primeiro que contenha os delimitadores


    // Extrai o texto entre as frases delimitadoras
    string resultado = null;

    if (divTexts != null)
    {
        int startIndex = divTexts.IndexOf(inicio) + inicio.Length;
        int endIndex = divTexts.IndexOf(fim, startIndex);
        resultado = divTexts.Substring(startIndex, endIndex - startIndex).Trim();
    }
    return resultado;
}


    string url = "https://es.tradingview.com/symbols/BTCUSD/";
    var response = await CallUrl(url);
    var parsedResults = ParseHtml(response);
    Console.WriteLine("Parsed Results:");

    Console.WriteLine(parsedResults + "K DOL");
