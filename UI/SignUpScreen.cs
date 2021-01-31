using System;
using System.Collections.Generic;
using System.Text;
using Tamagotchi.Models;
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
            string userName = Console.ReadLine();
            while(UIMain.db.PlayerExistByUserName(userName) || userName=="")
            {
                if(userName == "")
                    Console.WriteLine("invalid user name! Try somthing else: ");
                if(UIMain.db.PlayerExistByUserName(userName))
                Console.WriteLine("This user name alreadt exist! Try somthing else: ");
                userName = Console.ReadLine();
            }
            Console.WriteLine("enter your first name");
            string firstName = Console.ReadLine();
            firstName= UIMain.db.checkString(firstName,"first name");
            Console.WriteLine("enter last name");
            string lastName = Console.ReadLine();
           lastName= UIMain.db.checkString(lastName, "last name");
            Console.WriteLine("enter mail");

            string mail = Console.ReadLine();
           mail= UIMain.db.checkString(mail, "mail");
            Console.WriteLine("enter gender");
            string gender = Console.ReadLine();
            gender= UIMain.db.checkGender(gender);
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
            DateTime playerDateTime = new DateTime(bdYear, bdMonth, bdDay);
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
            string password = Console.ReadLine();
            password= UIMain.db.checkString(password, "password");

            Players P = new Players();
            P.UserName = userName;
            P.FirstName = firstName;
            P.LastName = lastName;
            P.Mail = mail;
            P.Gender = gender;
            P.PlayerBirthDate = playerDateTime;
            P.Password = password;
           
            try
            {
                UIMain.db.AddPlayer(P);
                UIMain.db.SaveChanges();
                Console.WriteLine($"you singed up succesfully! {P.UserName}");
                //Console.ReadKey();
                UIMain.CurrentPlayer = P;
                PlayerNotPetScreen s = new PlayerNotPetScreen();
                s.Show();
               
            }
            catch(Exception e)
            {
                Console.WriteLine("sign up failed, try again later");
            }
            

        }

    }
}

