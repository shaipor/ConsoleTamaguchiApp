using System;
using System.Collections.Generic;
using System.Text;
using Tamagotchi.Models;
using Microsoft.EntityFrameworkCore;



namespace Tamagotchi.UI
{
    class CreatePetScreen : Screen
    {
        public CreatePetScreen() : base("Create new Pet!")
        {

        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("enter pet name");
            string petName = Console.ReadLine();
            try
            {
                Pets pet = UIMain.db.Pets.CreateProxy(petName);
                UIMain.CurrentPlayer.Pets.Add(pet);
                UIMain.db.SaveChanges();
                Console.WriteLine($"you created pet succesfully!");
                Console.ReadKey();
                MainMenu sc = new MainMenu();
                sc.Show();
                
            }

            //Pets s = new Pets();

            //s.UserName = UIMain.CurrentPlayer.UserName;
            //s.PetName = petName;
            //s.StatusId = 1;
            //s.PetBirthDate = DateTime.Now;
            //s.Weigth = 3;
            //s.HappinesLevel = 5;
            //s.HungerLevel = 5;
            //s.HygieneLevel = 5;
            //s.UserNameNavigation = UIMain.CurrentPlayer;
            //s.LifeCycleId = 1;


            //try
            //{
            //    UIMain.db.AddPet(s);
            //    //UIMain.db.Pets.Add(s);
            //    //UIMain.db.Pets.Update(s);
            //    UIMain.db.SaveChanges();
            //    Console.WriteLine($"you created pet succesfully! {s.UserName}");
            //    MainMenu sc = new MainMenu();
            //    sc.Show();
            //    Console.ReadKey();
            //}
            catch (Exception e)
            {
                Console.WriteLine("creating pet failed ");
                Console.WriteLine(e);
                Console.ReadKey();

            }


        }

    }
}
