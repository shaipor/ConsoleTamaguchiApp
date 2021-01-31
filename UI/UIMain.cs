using System;
using System.Collections.Generic;
using System.Text;
using Tamagotchi.Models;

namespace Tamagotchi.UI
{
    class UIMain
    {
        //UI Main object is perfect for storing all UI state as it is initialized first and detroyed last.
        public static Players CurrentPlayer { get; set; }
        public static TamagotchiContext db { get; private set; }

        private Screen initialScreen;
        public UIMain(Screen initial)
        {
            //Initialize db context and current player
            db = new TamagotchiContext();

            this.initialScreen = initial;
        }
        public void ApplicationStart()
        {
            CurrentPlayer = null;
            //UIMain.CurrentPlayer = UIMain.db.Login("talsi@ramon.com", "a1233");
            //Show Screen and start app!
            initialScreen.Show();
            //Save changes to db
            //db.SaveChanges();
        }
    }
}
