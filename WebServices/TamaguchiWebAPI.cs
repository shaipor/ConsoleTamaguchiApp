using ConsoleTamaguchiApp.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleTamaguchiApp.WebServices
{
    public class TamagotchiWebAPI
    {
        private HttpClient client;
        private string baseUri;

        public TamagotchiWebAPI(string baseUri)
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            //Create client with the handler!
            this.client = new HttpClient(handler, true);
            this.baseUri = baseUri;
        }

        public async Task<List<PetsDTO>> GetPlayerAnimalsAsync()
        {
            try
            {

                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetAnimals");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<PetsDTO> fList = JsonSerializer.Deserialize<List<PetsDTO>>(content, options);
                    return fList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Task<PlayerDTO> showPlayingActions(string userName, string pass)
        {
            


        }

            public async Task<PetsDTO> PlayWithAnimalAsync(ActionsDTO ac)
            {

                try
                {
                    HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/PlayWithAnimal?action={ac.actionId}", null);
                    //if (response.IsSuccessStatusCode)
                    //{
                        JsonSerializerOptions options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };

                        //string content = await response.Content.ReadAsStringAsync();
                        //PetsDTO p = JsonSerializer.Deserialize<PetsDTO>(content, options);
                        //return p;
                    //}
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }

        public async Task<PlayerDTO> LoginAsync(string userName, string pass)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/Login?userName={userName}&pass={pass}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    PlayerDTO p = JsonSerializer.Deserialize<PlayerDTO>(content, options);
                    return p;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

      

    }
}
