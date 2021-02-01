using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConsoleTamaguchiApp.WebServices;
using Tamagotchi.UI;

namespace ConsoleTamaguchiApp
{
    class Program
    {
        //try55
        static void Main(string[] args)
        {
            UIMain ui = new UIMain(new LoginScreen());
            ui.ApplicationStart();

            
            
        }
    }
}
