using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tamagotchi.UI
{
    class MainMenu : Menu
    {
        public MainMenu() : base($"Main Menu - {UIMain.CurrentPlayer.UserName} is logged in")
        {
            //Build items in main menu!
            AddItem("Show Player", new PlayerScreen());
            AddItem("feed animal", new FeedingScreen());
            AddItem("play with your animal", new PlayingScreen());
            //AddItem("watch actions history", new ActionsHistoryScreen());
            //AddItem("show animal", new PetInformationScreen());


        }


    }
}
