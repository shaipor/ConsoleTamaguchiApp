using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTamaguchiApp.DataTransferObjects;
using System.Linq;

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
                List<Actions> list = UIMain.api.showFeedingActions();

                ObjectsList list1 = new ObjectsList(" ", list.ToList<object>());
                //ObjectsList list1 = new ObjectsList("Animals", list);
                //list.Print();

                list1.Show();
                int idfeed = int.Parse(Console.ReadLine());
                const int DEAD_STATUS_ID = 4;
                Pets pe = UIMain.CurrentPlayer.Pets.Where(p => p.LifeCycleId != DEAD_STATUS_ID).FirstOrDefault();
                Actions ac = UIMain.db.Actions.Where(a => a.ActionId == idfeed).FirstOrDefault();
                if (pe == null)
                    Console.WriteLine("there is no active pet");
                else
                {
                    pe.FeedAnimal(ac);

                    Console.WriteLine($"the pet ate {ac.ActionName}");
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
