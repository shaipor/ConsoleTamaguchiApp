using System;
using System.Collections.Generic;
using System.Text;
using Tamagotchi.Models;

namespace Tamagotchi.UI
{
    class LoginScreen : Screen
    {
        public LoginScreen() : base("Login")
        {

        }
        private TamagotchiContext bl;
        public override void Show()
        {
            //Clear screen and set title (implemented by Screen Show)
            base.Show();

            //Check if we should logout first
            if (UIMain.CurrentPlayer != null)
            {
                Console.WriteLine($"Currently, ${UIMain.CurrentPlayer.UserName} is logged in. Press Y to log out or other key to go back to menu!");
                char c = Console.ReadKey().KeyChar;
                if (c == 'Y' || c == 'y')
                {
                    //Save all changes to DB before logging out
                    UIMain.db.SaveChanges();
                    UIMain.CurrentPlayer = null;
                }
            }

            //if user is still logged in, we should go out!= back to menu
            while (UIMain.CurrentPlayer == null)
            {
                //Clear screen again
                base.Show();

                Console.WriteLine($"Please enter your user name: ");
                string userName = Console.ReadLine();
                Console.WriteLine($"Please enter your password: ");
                string password = Console.ReadLine();

                UIMain.CurrentPlayer = UIMain.db.Login(userName, password);
                //UIMain.CurrentPlayer = UIMain.db.Login("odedporat@gmail.com", "12345");

                if (UIMain.CurrentPlayer == null)
                {
                    Console.WriteLine("Login fail!! Press any key to try again!");
                    Console.ReadKey();
                } 
            }

            //if (UIMain.CurrentPlayer.Pets.Count != 0)
            //if (UIMain.CurrentPlayer.Pets != null)
            if(UIMain.CurrentPlayer.HasActiveAnimal())
            {
                MainMenu menu = new MainMenu();
                menu.Show();
            }

            //    }
            else
            {
                //int c = UIMain.CurrentPlayer.Pets.Count;
                //Console.WriteLine(c);
                //Console.ReadKey();
                PlayerNotPetScreen pn = new PlayerNotPetScreen();
                pn.Show();
            }
            //}

            //else
            //{
            //    CreatePetScreen cp = new CreatePetScreen();
            //    cp.Show();
            //}

            //}


            //if(UIMain.CurrentPlayer.Pets.Count)
        }
    }
}
