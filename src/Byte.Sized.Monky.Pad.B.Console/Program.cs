
// See https://aka.ms/new-console-template for more information
using Byte.Sized.Monkeys.Common;
using Byte.Sized.Monkeys.Pad.B.Core.Services;
using System.Net.Http.Json;
using System.Text.Json;

var apiClient = new HackTheFutureClient();
await apiClient.Login("Byte-Sized Monkeys", "eDbmn9unx9");
//B1
//await apiClient.GetAsync("/api/path/b/easy/start");

//var result = await apiClient.GetFromJsonAsync<MayanCalendarChallengeDto>("/api/path/b/easy/sample");

//var countDay = Mapper.CountDay(result);

//await apiClient.PostAsJsonAsync("/api/path/b/easy/puzzle", countDay);

await apiClient.GetAsync("/api/path/b/medium/start");

var result = await apiClient.GetFromJsonAsync<string[]>("/api/path/b/medium/puzzle");

var respons = Mapper.ConvertSymbols(result);
var test = await apiClient.PostAsJsonAsync("/api/path/b/medium/puzzle", respons);
Console.WriteLine($"{respons},{test}");
