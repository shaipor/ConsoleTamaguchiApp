using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleTamaguchiApp.DataTransferObjects;
using System.Threading.Tasks;

namespace Tamagotchi.UI
{
    class PlayingScreen : Screen
    {
        public PlayingScreen() : base("play with your pet")
        {
        }

        public override void Show()
        {
            base.Show();
            try
            {
                // מציגים את רשימת המשחקים
                Task<List<ActionsDTO>> list = UIMain.api.GetAllGamesAsync();
                ObjectsList games = new ObjectsList("games", list.Result.ToList<object>());
                games.Show();
                Console.WriteLine();

                Console.WriteLine("which game would you like to play:");
                int gameId = int.Parse(Console.ReadLine());
                const int DEAD_STATUS_ID = 4;
                Task<List<PetsDTO>> playerPets = UIMain.api.GetPlayerAnimalsAsync();
                PetsDTO p = playerPets.Result.Where(p => p.LifeCycleId != DEAD_STATUS_ID).FirstOrDefault();

                ActionsDTO actionsDTO = list.Result.Where(a => a.actionId == gameId).FirstOrDefault();
                if (p == null)
                    Console.WriteLine("There is no active pet");
                else
                {
                    Task<bool> task = UIMain.api.PlayAsync(actionsDTO);
                    if (task.Result)
                        Console.WriteLine($"The pet played {actionsDTO.actionName}");
                    else
                        Console.WriteLine("Something wrong happened!");
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Something wrong happened!");
                Console.WriteLine($"Error message: {e.Message}");
            }

            Console.WriteLine("Please press any key to get back to menu!");
            Console.ReadKey(true);
        }


    }
}