using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTamaguchiApp.DataTransferObjects;
using System.Text.RegularExpressions;

namespace Tamagotchi.UI
{
    class SignUpScreen : Screen
    {
        public SignUpScreen() : base("sign up")
        {

        }
        public override void Show()
        {

            base.Show();
            Console.WriteLine("enter user name");
            string UserName = Console.ReadLine();
            while(UIMain.api.PlayerExistByUserName(UserName) || UserName == "")
            {
                if(UserName == "")
                    Console.WriteLine("invalid user name! Try somthing else: ");
                if(UIMain.api.PlayerExistByUserName(UserName))
                Console.WriteLine("This user name alreadt exist! Try somthing else: ");
                UserName = Console.ReadLine();
            }
            Console.WriteLine("enter your first name");
            string PlayerName = Console.ReadLine();
            PlayerName = UIMain.api.checkString(PlayerName, "first name");
            Console.WriteLine("enter last name");
            string LastName = Console.ReadLine();
           LastName= UIMain.api.checkString(LastName, "last name");
            Console.WriteLine("enter mail");

            string Email = Console.ReadLine();
           Email= UIMain.api.checkString(Email, "mail");
            Console.WriteLine("enter gender");
            string Gender = Console.ReadLine();
            Gender= UIMain.api.checkGender(Gender);

            Console.WriteLine("enter birth year");
            int bdYear = int.Parse(Console.ReadLine());
            while(bdYear<1900 || bdYear>2020)
            {
                Console.WriteLine("invalid year, try something else");
                bdYear = int.Parse(Console.ReadLine());

            }
            Console.WriteLine("enter birth month");
            int bdMonth = int.Parse(Console.ReadLine());
            while (bdMonth < 1 || bdMonth > 12)
            {
                Console.WriteLine("invalid month, try something else");
                bdMonth = int.Parse(Console.ReadLine());

            }
            Console.WriteLine("enter birth day");
            int bdDay = int.Parse(Console.ReadLine());
            while (bdDay < 1 || bdDay > 31)
            {
                Console.WriteLine("invalid day, try something else");
                bdDay = int.Parse(Console.ReadLine());

            }
            DateTime BirthDate = new DateTime(bdYear, bdMonth, bdDay);
            //Console.WriteLine("enter birth date");
            //string playerDateTimeString = Console.ReadLine(); 
            //try
            //{
            //    DateTime.Parse(playerDateTimeString);
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine("date is not valid");
            //}
            ////DateTime playerDateTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("enter password");
            string Password = Console.ReadLine();
            Password = UIMain.api.checkString(Password, "password");

            PlayerDTO P = new PlayerDTO();
            P.UserName = UserName;
            P.PlayerName = PlayerName;
            P.LastName = LastName;
            P.Email = Email;
            P.Gender = Gender;
            P.BirthDate = BirthDate;
            P.Password = Password;

            try
            {
                UIMain.api.AddPlayer(P);
                UIMain.api.SaveChanges();
                Console.WriteLine($"you singed up succesfully! {P.UserName}");
                //Console.ReadKey();
                UIMain.CurrentPlayer = P;
                PlayerNotPetScreen s = new PlayerNotPetScreen();
                s.Show();
               
            }
            catch(Exception e)
            {
                Console.WriteLine("sign up failed, try again later");
                Console.WriteLine(e);
                Console.ReadKey();
            }
            

        }

    }
}

