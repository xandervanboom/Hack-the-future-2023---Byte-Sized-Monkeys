using Byte.Sized.Monkeys.Common;
using Byte_Sized_Monkeys_Pad_A.Core.Services;
using System.Net.Http.Json;
using System.Text.Json;

// See https://aka.ms/new-console-template for more information

var apiClient = new HackTheFutureClient();
await apiClient.Login("Byte-Sized Monkeys", "eDbmn9unx9");

var result = await apiClient.GetAsync("api/path/a/easy/sample");
var response = await result.Content.ReadAsStringAsync();

var decodedMayanText = Mapper.MapMayanHieroglyphicsToString(response);

var postResponse = await apiClient.PostAsJsonAsync("api/path/a/easy/sample", decodedMayanText);

