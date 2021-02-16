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

                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}api/GetAnimals");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<PetsDTO> fList = JsonSerializer.Deserialize<List<PetsDTO>>(content, options);
                    //List<PetsDTO> fList = JsonSerializer.Deserialize<List<PetsDTO>>(content, options);
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

        public async Task<List<ActionsDTO>> GetAllGamesAsync()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}api/GetAllGames");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<ActionsDTO> fList = JsonSerializer.Deserialize<List<ActionsDTO>>(content, options);
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
        public async Task<PetsDTO> FeedAnimalAsync(ActionsDTO ac)
        {
            try
            {
                string json = JsonSerializer.Serialize(ac);
                StringContent content1 = new StringContent(json, Encoding.UTF8, "application/json");
                int actionIdNum = ac.actionId;
                HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}api/FeedAnimal?actionId={ac.actionId}", content1);
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    PetsDTO p = JsonSerializer.Deserialize<PetsDTO>(content, options);
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
        public async Task<bool> PlayAsync(ActionsDTO actionsDTO)
        {
            //Set URI to the specific function API
            string url = $"{this.baseUri}api/Play";
            try
            {
                //Call the server API
                string json = JsonSerializer.Serialize(actionsDTO);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                //Check status
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<PlayerDTO> LoginAsync(string userName, string pass)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}api/Login?userName={userName}&pass={pass}");
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
        public async Task<List<ActionsDTO>> GetFeedingActionsAsync()
        {
            try 
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}api/GetFeedingActions");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<ActionsDTO> fList = JsonSerializer.Deserialize<List<ActionsDTO>>(content, options);
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

        public async Task<bool> HasActiveAnimal()
        {
            HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}api/HasActiveAnimal", null);
            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                string content = await response.Content.ReadAsStringAsync();
                bool p = JsonSerializer.Deserialize<bool>(content, options);
                return p;
            }
            else
            {
                return false;
            }
        }
    }
    }


      
