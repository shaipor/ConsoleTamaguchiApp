using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTamaguchiApp.DataTransferObjects;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
 

namespace Tamagotchi.UI
{
    class FeedingScreen : Screen
    {
        public FeedingScreen() : base("Feed your pet!")
        {

        }

        public override void Show()
        {
            base.Show();
            try
            {
                Console.WriteLine("which food would you like to give your pet?");
                Task<List<ActionsDTO>> list= UIMain.api.GetFeedingActionsAsync();
                //List<ActionsDTO> list = UIMain.api.GetFeedingActionsAsync();
                list.Wait();
                List<ActionsDTO> feedingActions = list.Result;
                ObjectsList list1 = new ObjectsList(" ", feedingActions.ToList<object>());
                //ObjectsList list1 = new ObjectsList("Animals", list);
                //list.Print();

                list1.Show();
                int idfeed = int.Parse(Console.ReadLine());
                const int DEAD_STATUS_ID = 4;
                Task<List<PetsDTO>> pts = UIMain.api.GetPlayerAnimalsAsync();
                pts.Wait();
                PetsDTO pe = (pts.Result.Where(p => p.LifeCycleId != DEAD_STATUS_ID).FirstOrDefault());
                ActionsDTO ac = feedingActions.Where(a => a.actionId == idfeed).FirstOrDefault();
                if (pe == null)
                    Console.WriteLine("there is no active pet");
                else
                {
                    Task <PetsDTO> pet1= UIMain.api.FeedAnimalAsync(ac);
                    Console.WriteLine("feeding your pet...");
                    pet1.Wait();
                    if (pet1.Result != null)
                    {
                        pe = pet1.Result;
                        Console.WriteLine($"the pet ate {ac.actionName}");
                    }
                        
                    else
                        Console.WriteLine("something wrong happened!");

                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("something wrong happened!");
                Console.WriteLine($"Error message: {e.Message}");
                //Console.WriteLine(e);

            }
            Console.WriteLine("press any key to get back to menu!");

            Console.ReadKey(true);
        }
    }
}
