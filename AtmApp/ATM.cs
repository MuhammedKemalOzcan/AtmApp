using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AtmApp
{
    internal class ATM
    {
        private List<User> users = new List<User>();
        private User currentUser;
        public bool isLoggedIn = false;

        public ATM()
        {
            users.Add(new User("Kemal","Özcan",123456,"1234",13000));
            users.Add(new User("Muhammed", "Özcan", 654321, "4321", 13000));
            users.Add(new User("Gülseren","Temel",012345,"0123",9000));
            
        }
        public void Login(int id,string password)
        {
            currentUser = users.Find(user => user.Id == id && user.Password == password);
            if (currentUser == null)
            {
                Console.WriteLine("Geçersiz kullanıcı adı veya şifre!");
                Logger.DosyaYaz($" {DateTime.Now} tarihinde hatalı giriş denemesi yapıldı");
            }
            else if (currentUser.Id == id && currentUser.Password == password)
            {
                isLoggedIn = true;
                Console.WriteLine($"Hoşgeldiniz, {currentUser.FirstName} {currentUser.LastName}!");
                Logger.DosyaYaz($"{currentUser.FirstName} {DateTime.Now} tarihinde giriş yaptı");
                ShowMenu();
            }
            
            //else
            //{
            //    Console.WriteLine("Geçersiz kullanıcı adı veya şifre!");
            //    Logger.DosyaYaz($" {DateTime.Now} tarihinde hatalı giriş denemesi yapıldı");
            //}
            
        }
        //Para çekme
        public void Withdraw(decimal amount)
        {
            if (isLoggedIn == true)
            {
                if (amount <= currentUser.Balance)
                {
                    currentUser.Balance -= amount;
                    Console.WriteLine($"{amount} çekildi yeni bakiyeniz {currentUser.Balance:C}");
                    Logger.DosyaYaz($"{currentUser.FirstName} {DateTime.Now} tarihinde {amount} miktarda para çekti");
                }
                else
                {
                    Logger.DosyaYaz($"{currentUser.FirstName} {DateTime.Now} tarihinde geçersiz para çekme denemesi yaptı");
                    Console.WriteLine("Yetersiz bakiye!");
                }
            }
            else
            {
                Console.WriteLine("Önce giriş yapmalısınız!");
            }

        }
        public void Deposit(decimal amount)
        {
            if(isLoggedIn == true)
            {
                if (amount > 0)
                {
                    currentUser.Balance += amount;
                    Console.WriteLine($"{amount} yatırıldı yeni bakiyeniz {currentUser.Balance.ToString()}");
                    Logger.DosyaYaz($"{currentUser.FirstName} {DateTime.Now} tarihinde {amount} miktarda para yatırdı");
                }
                else
                {
                    Logger.DosyaYaz($"{currentUser.FirstName} {DateTime.Now} tarihinde geçersiz para yatırma denemesi yaptı");
                    Console.WriteLine("Geçersiz miktar girdiniz!");
                }
            }
            else { Console.WriteLine("İşlem yapmadan önce giriş yapmalısınız"); }

        }
        public void CheckBalance()
        {
            if (isLoggedIn == true)
            {
                Console.WriteLine($"Mevcut bakiyeniz {currentUser.Balance}");
            }
            else { Console.WriteLine("İşlem yapmadan önce giriş yapmalısınız"); }
            Logger.DosyaYaz($"{currentUser.FirstName} {DateTime.Now} tarihinde bakiye görüntüledi");

        }
        private void ShowMenu()
        {
            Console.WriteLine("1. Para Çekme\n2.Para Yatırma\n3.Bakiye Görüntüleme\n4. Çıkış");
            Console.WriteLine("İşlem seçiniz");
            string choice = Console.ReadLine();
            ProccessChoice(choice);
        }
        public void ProccessChoice(string choice)
        {
            if (!isLoggedIn)
            {
                Console.WriteLine("Çıkış yapıldı iyi günler dileriz.");
            }

            switch (choice)
            {
                
                case "1":
                    Console.WriteLine("Çekmek istediğiniz miktarı giriniz:");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                    Withdraw(amount);
                    break;
                case "2": Console.WriteLine("Yatırmak istediğiniz miktarı giriniz:");
                    decimal depositamount = Convert.ToDecimal(Console.ReadLine());
                    Deposit(depositamount);
                    break;
                case "3": CheckBalance();
                    break;
                case "4":
                    Console.WriteLine("Çıkış yapılıyor");
                    isLoggedIn = false;
                    Logger.DosyaYaz($" {DateTime.Now} tarihinde {currentUser.FirstName} çıkış yaptı");
                    return;
            }
            if (isLoggedIn == true)
            {
                ShowMenu(); //Kullanıcı çıkış yapmadıysa menüyü bir daha göster.
            }
        }
       

    }
}
