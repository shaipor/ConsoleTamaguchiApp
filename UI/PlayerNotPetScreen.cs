using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagotchi.UI
{
    class PlayerNotPetScreen : Screen
    {
        public PlayerNotPetScreen() : base("you dont have pets!")
        {


        }

        public override void Show()
        {

            //Console.WriteLine($"no pets- {UIMain.CurrentPlayer.Mail}");
            //AddItem("show player", new PlayerScreen());
            //AddItem("create new pet", new CreatePetScreen());
            //Build items in main menu!
            base.Show();
            ObjectView showPlayer = new ObjectView("", UIMain.CurrentPlayer);
            showPlayer.Show();
            Console.WriteLine("Press A to crate Animals or other key to go back!");
            char c = Console.ReadKey().KeyChar;
            if (c == 'a' || c == 'A')
            {
                Console.WriteLine();
                //Create list to be displayed on screen
                //Format the desired fields to be shown! (screen is not wide enough to show all)
                //CreatePetScreen cp = new CreatePetScreen();
                //cp.Show();
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
