using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTamaguchiApp.DataTransferObjects;

namespace Tamagotchi.UI
{
    class PlayerScreen:Screen
    {
        public PlayerScreen():base("Show Player")
        {


        }

        public override void Show()
        {
            base.Show();
            ObjectView showPlayer = new ObjectView("", UIMain.CurrentPlayer);
            showPlayer.Show();
            Console.WriteLine("Press A to see Player Animals or other key to go back!");
            char c = Console.ReadKey().KeyChar;
            if (c == 'a' || c == 'A')
            {
                Console.WriteLine();
                //Create list to be displayed on screen
                //Format the desired fields to be shown! (screen is not wide enough to show all)
                Task<List<PetsDTO>> petl = UIMain.api.GetPlayerAnimalsAsync();
                petl.Wait();
                List <Object> animals = (from animalList in petl.Result
                                        select new
                                        {
                                            ID = animalList.petId,
                                            Name = animalList.petName,
                                            BirthDate = animalList.BirthDate.ToShortDateString(),
                                            Weight = $"{animalList.petWeight:F2}"
                                        }).ToList<Object>();
                ObjectsList list = new ObjectsList("Animals", animals);
                list.Show();
                Console.WriteLine();
                Console.WriteLine("Press any key to go back!");
                char d = Console.ReadKey().KeyChar;
                //if (d == 'a' || d == 'A')
                //{
                //    FeedingScreen f = new FeedingScreen();
                //    f.Show();
                //}
                Console.ReadKey();
            }

        }
    }
}
