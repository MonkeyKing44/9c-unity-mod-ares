//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Do not modify the contents of this file directly.
//     Changes might be overwritten the next time the code is generated.
//     Source URL: http://localhost:5152/swagger/v1/swagger.json
// </auto-generated>
//------------------------------------------------------------------------------
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;
using System.Collections;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using Libplanet.Crypto;

public class GuildServiceClient
{
    private string Url;
    private readonly HttpClient _client;

    public GuildServiceClient(string url)
    {
        Url = url;
        _client = new System.Net.Http.HttpClient();
        _client.Timeout = TimeSpan.FromSeconds(10);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public class AvatarModel
    {
        [JsonPropertyName("avatarAddress")]
        public Address AvatarAddress { get; set; }
        [JsonPropertyName("agentAddress")]
        public Address AgentAddress { get; set; }
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }
        [JsonPropertyName("guildId")]
        public string GuildId { get; set; }
    }

    public class AvatarSchema
    {
        [JsonPropertyName("avatarAddress")]
        public Address AvatarAddress { get; set; }
        [JsonPropertyName("agentAddress")]
        public Address AgentAddress { get; set; }
        [JsonPropertyName("guildName")]
        public string GuildName { get; set; }
    }

    public class GuildModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }
        [JsonPropertyName("avatarModels")]
        public List<AvatarModel> AvatarModels { get; set; }
    }

    public class IValue
    {
        [JsonPropertyName("kind")]
        public ValueKind Kind { get; set; }
        [JsonPropertyName("encodingLength")]
        public int EncodingLength { get; set; }
    }

    [JsonConverter(typeof(ValueKindTypeConverter))]
    public enum ValueKind
    {
        _0,
        _1,
        _2,
        _3,
        _4,
        _5,
        _6,
    }

    public class ValueKindTypeConverter : JsonConverter<ValueKind>
    {
        public override ValueKind Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return reader.TokenType switch
            {
                JsonTokenType.Number => (ValueKind)reader.GetInt32(),
                JsonTokenType.String => Enum.Parse<ValueKind>("_"+reader.GetString()),
                _ => throw new JsonException(
                    $"Expected token type to be {string.Join(" or ", new[] { JsonTokenType.Number, JsonTokenType.String })} but got {reader.TokenType}")
            };
        }
        public override void Write(
            Utf8JsonWriter writer,
            ValueKind value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString().Substring(1));
        }
    }

    public async Task GetAvatarAsync(Action<AvatarModel[]> onSuccess, Action<string> onError)
    {
        string url = Url + "/api/avatar";
        using (var request = new System.Net.Http.HttpRequestMessage(new System.Net.Http.HttpMethod("GET"), url))
        {
            try
            {
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                AvatarModel[] result = System.Text.Json.JsonSerializer.Deserialize<AvatarModel[]>(responseBody);
                onSuccess?.Invoke(result);
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex.Message);
            }
        }
    }

    public async Task PutAvatarAsync(AvatarSchema requestBody, Action<string> onSuccess, Action<string> onError)
    {
        string url = Url + "/api/avatar";
        using (var request = new System.Net.Http.HttpRequestMessage(new System.Net.Http.HttpMethod("PUT"), url))
        {
            request.Content = new System.Net.Http.StringContent(System.Text.Json.JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json");
            try
            {
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                onSuccess?.Invoke(responseBody);
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex.Message);
            }
        }
    }

    public async Task GetGuildAsync(Action<GuildModel[]> onSuccess, Action<string> onError)
    {
        string url = Url + "/api/guild";
        using (var request = new System.Net.Http.HttpRequestMessage(new System.Net.Http.HttpMethod("GET"), url))
        {
            try
            {
                var response = await _client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                GuildModel[] result = System.Text.Json.JsonSerializer.Deserialize<GuildModel[]>(responseBody);
                onSuccess?.Invoke(result);
            }
            catch (Exception ex)
            {
                onError?.Invoke(ex.Message);
            }
        }
    }

}