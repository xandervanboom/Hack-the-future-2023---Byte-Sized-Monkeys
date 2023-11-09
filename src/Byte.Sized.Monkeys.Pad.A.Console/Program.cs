using Byte.Sized.Monkeys.Common;
using Byte_Sized_Monkeys_Pad_A.Core.Services;
using System.Net.Http.Json;
using System.Text.Json;

// See https://aka.ms/new-console-template for more information


//

var apiClient = new HackTheFutureClient();
await apiClient.Login("Byte-Sized Monkeys", "eDbmn9unx9");



//Chalange A1
await apiClient.GetAsync("api/path/a/easy/start");
var resultA1 = await apiClient.GetStringAsync("api/path/a/easy/puzzle");

var decodedMayanText = Mapper.MapMayanHieroglyphicsToString(resultA1);

await apiClient.PostAsJsonAsync("api/path/a/easy/puzzle", decodedMayanText);


//ChalangeA2
await apiClient.GetAsync("api/path/a/medium/start");
var resultA2 = await apiClient.GetFromJsonAsync<VineNavigationChallengeDto>("api/path/a/medium/puzzle");

var endPosition = Mapper.GetVineEndDestination(resultA2);

await apiClient.PostAsJsonAsync("api/path/a/medium/puzzle", endPosition);

//ChalangeA3 
await apiClient.GetAsync("api/path/a/hard/start");
var resultA3 = await apiClient.GetFromJsonAsync<Animal[]>("api/path/a/hard/sample");

var nameChain = Mapper.CreateAnimalNameChain(resultA3.ToList());

await apiClient.PostAsJsonAsync("api/path/a/hard/sample", nameChain);

