using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTamaguchiApp.DataTransferObjects;
using ConsoleTamaguchiApp.WebServices;

namespace Tamagotchi.UI
{
    class UIMain
    {
        //UI Main object is perfect for storing all UI state as it is initialized first and detroyed last.
        public static PlayerDTO CurrentPlayer { get; set; }
        public static TamagotchiWebAPI api { get; private set; }

        private Screen initialScreen;
        public UIMain(Screen initial)
        {
            //Initialize db context and current player
            //api = new TamagotchiWebAPI(@"https://localhost:44311/");

            this.initialScreen = initial;
        }
        public void ApplicationStart()
        {
            CurrentPlayer = null;
            api = new TamagotchiWebAPI(@"https://localhost:44311/");
            //UIMain.CurrentPlayer = UIMain.db.Login("talsi@ramon.com", "a1233");
            //Show Screen and start app!
            initialScreen.Show();
            //Save changes to db
            //db.SaveChanges();
        }
    }
}
