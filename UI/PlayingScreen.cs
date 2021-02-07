using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTamaguchiApp.DataTransferObjects;
using System.Linq;
using ConsoleTamaguchiApp.WebServices;


namespace Tamagotchi.UI
{
    class playingScreen : Screen
    {
        public playingScreen() : base("Feed your pet!")
        {

        }

        public override void Show()
        {
            base.Show();
            try
            {
                Console.WriteLine("which food would you like to give your pet?");
                List<ActionsDTO> list = UIMain.api.showPlayingActions();

                ObjectsList list1 = new ObjectsList(" ", list.ToList<object>());
              

                list1.Show();
                int idPlay = int.Parse(Console.ReadLine());
                const int DEAD_STATUS_ID = 4;
                PetsDTO pe = UIMain.api.GetPlayerAnimalsAsync().Where(p => p.LifeCycleId != DEAD_STATUS_ID).FirstOrDefault();
                ActionsDTO ac = UIMain.api. Actions.Where(a => a.ActionId == idPlay).FirstOrDefault();
                if (pe == null)
                    Console.WriteLine("there is no active pet");
                else
                {
                    pe.PlayAnimal(ac);

                    Console.WriteLine($"the pet played {ac.actionName}");
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
