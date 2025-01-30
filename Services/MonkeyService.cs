namespace BlazorMonkey.Services
{
    public class MonkeyService
    {
        private List<Monkey>? _monkeys = [];
        private readonly HttpClient _httpClient = new();

        public async Task<List<Monkey>?> GetMonkeys()
        {
            if (_monkeys.Count == 0)
            {
                var response = await _httpClient.GetAsync("https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/monkeydata.json");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _monkeys = JsonConvert.DeserializeObject<List<Monkey>>(content);
                }
                
            }

            return _monkeys;
        }
    }
}
