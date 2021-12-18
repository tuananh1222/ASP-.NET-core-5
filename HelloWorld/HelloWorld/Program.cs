using System.Net.Http;

var client = new HttpClient();

var request = new HttpRequestMessage(
    method: HttpMethod.Post,
    requestUri: "http://localhost:3000/objects"
);

string payload = @"{""id"":5,""item"":""The Fiancés"",""artist"":""Pierre Auguste Renoir"",""collection"":""Wallraf–Richartz Museum, Cologne, Germany"",""date"":""1868""}";

var requestData = new StringContent(
    content: payload,
    encoding: System.Text.Encoding.UTF8,
    mediaType: "application/json"
);

request.Content = requestData;

HttpResponseMessage response = await client.SendAsync(request);

if (response.IsSuccessStatusCode)
{
    string responseContent = await response.Content.ReadAsStringAsync();

    Console.WriteLine(responseContent);
}