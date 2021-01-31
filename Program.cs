﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ConsoleTamaguchiApp.UI;

namespace ConsoleTamaguchiApp
{
    class Program
    {
        //try
        static void Main(string[] args)
        {
            UIMain ui = new UIMain(new LoginScreen());
            ui.ApplicationStart();

            
            
        }
    }
}
