using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Models;

namespace Tamagotchi.UI
{
    class ActionsHistoryScreen : Screen
    {
        public ActionsHistoryScreen():base("actions history screen:")
            {
            }

        public override void Show()
        {
            base.Show();

            try
            {
                List<Object> list = UIMain.db.GetHistory();
                ObjectsList history = new ObjectsList("", list.ToList<object>());
                history.Show();
                Console.WriteLine();
            }

            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("somthing happend!");
                Console.WriteLine($"error: {e.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("please press any key to go back");
            Console.ReadKey(true);

        }
    }
}
