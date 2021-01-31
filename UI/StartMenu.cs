using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagotchi.UI
{
    class StartMenu:Menu
    {
        public StartMenu() : base($"welcome to Tamagotchi app ")
        {
            //Build items in main menu!
            AddItem("log into Existsing account", new LoginScreen());
            AddItem("sign up to Tamagotchi!", new SignUpScreen());

        }
    }
}
