using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamagotchi.Models;

namespace Tamagotchi.UI
{
    class PetInformationScreen : Screen
    {

        public PetInformationScreen() : base("pet information")
        {

        }

        public override void Show()
        {
            base.Show();
            //ObjectView showInformation = new ObjectView("", UIMain.CurrentPlayer);
            //showInformation.Show();

            Console.WriteLine("Press P to see your pet information or other key to go back!");
            char c = Console.ReadKey().KeyChar;
            if (c == 'p' || c == 'P')

                Console.WriteLine();
            List<Object> pets = (from animalList in UIMain.CurrentPlayer.Pets
                                 select new
                                 {
                                     name = animalList.PetName,
                                     staus = animalList.Status.StatusName,
                                     LifeCycles = animalList.LifeCycleId,
                                     happines = animalList.HappinesLevel,
                                     hunger = animalList.HungerLevel,
                                     clean = animalList.HygieneLevel,
                                     weigth = $"{animalList.Weigth:F2}"
                                 }).ToList<Object>();
            ObjectsList list = new ObjectsList("", pets);
            list.Show();
            Console.WriteLine();
            Console.ReadKey();

        }



    }
}
