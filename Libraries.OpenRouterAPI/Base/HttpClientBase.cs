using Libraries.OpenRouterAPI.Exceptions;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Authentication;
using System.Text;

namespace Libraries.OpenRouterAPI.Base;

public abstract class HttpClientBase
{
    protected readonly static HttpClient _client = new HttpClient();
    protected string? _url { get; set; }

    protected HttpClientBase() { }

    protected HttpClientBase(string url)
    {
        this._url = url;
    }

    internal async Task<HttpResponseMessage> HttpRequestBase(string? url = null, HttpMethod? method = null, object? postData = null, bool streaming = false)
    {
        if (string.IsNullOrEmpty(url))
            url = this._url;

        if (method is null)
            method = HttpMethod.Get;

        HttpResponseMessage? response;
        string? resultAsString;
        HttpRequestMessage req = new HttpRequestMessage(method, url);

        if (postData is not null)
        {
            if (postData is HttpContent httpContent)
            {
                req.Content = httpContent;
            }
            else
            {
                string jsonContent = JsonConvert.SerializeObject(postData, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                var stringContent = new StringContent(jsonContent, UnicodeEncoding.UTF8, "application/json");
                req.Content = stringContent;
            }
        }

        response = await _client.SendAsync(req, streaming ? HttpCompletionOption.ResponseHeadersRead : HttpCompletionOption.ResponseContentRead);

        if (response.IsSuccessStatusCode)
        {
            return response;
        }
        else
        {
            try
            {
                resultAsString = await response.Content.ReadAsStringAsync();
            }
            catch (Exception readError)
            {
                resultAsString = "Additionally, the following error was thrown when attemping to read the response content: " + readError.ToString();
            }

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new AuthenticationException("OpenRouter rejected your authorization, most likely due to an invalid API Key.");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException("OpenRouter had an internal server error, which can happen occasionally.  Please retry your request.");
            }
            else
            {
                throw new HttpRequestException(response.StatusCode.ToString() + ": " + resultAsString);
            }
        }
    }

    private async Task<T> HttpRequest<T>(string? url = null, HttpMethod? method = null, object? postData = null) where T : ApiResultBase
    {
        var response = await HttpRequestBase(url, method, postData);

        if (response is null)
        {
            throw new HttpNullResponseException(url, method?.Method ?? string.Empty);
        }
        string resultAsString = await response.Content.ReadAsStringAsync();

        var res = JsonConvert.DeserializeObject<T>(resultAsString);

        if (res is null)
        {
            throw new FailedToParseJsonException(url, resultAsString);
        }

        return res;
    }

    internal async Task<T> HttpGet<T>(string? url = null) where T : ApiResultBase
    {
        try
        {
            return await HttpRequest<T>(url, HttpMethod.Get);
        }
        catch (Exception ex)
        {
            throw new FailedToGetHttpResponseException(url, ex.Message);
        }
    }

    internal async Task<T> HttpPostRequest<T>(string? url = null, object? postData = null) where T : ApiResultBase
    {
        try
        {
            return await HttpRequest<T>(url, HttpMethod.Post, postData);
        }
        catch (Exception ex)
        {
            throw new FailedToPostHttpResponseException(url, ex.Message);
        }
    }
}
