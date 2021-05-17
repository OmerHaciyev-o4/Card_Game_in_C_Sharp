using System;
using System.Collections.Generic;
using System.Threading;

namespace Card_Game
{
    public class Player
    {
        public Dictionary<int, string> card;
        public int Password { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public int CardLenght { get; set; }


        public void AddCards(Dictionary<int,string> cards)
        {
            card = new Dictionary<int, string>();

            foreach (var item in cards) { card[item.Key] = item.Value; }

            CardLenght = card.Count;
        }

        public void ShowCards()
        {
            while (true)
            {
                Console.WriteLine($"The game order is {Username}: \n");
                Console.Write("Enter password: ");
                int password = Convert.ToInt32(Console.ReadLine());
                if (password == Password) { break; }
                else 
                { 
                    Console.WriteLine("Incorrect password");
                    Thread.Sleep(2000);
                    Console.Clear(); 
                }
            }
            foreach (var item in card)
            {
                Console.Write($"{item.Key})[{item.Value}]    ");
            }
            Console.WriteLine();
        }

        public string PlayYourChoice()
        {
            Console.Write("Select card: ");
            int select = Convert.ToInt32(Console.ReadLine());

            foreach (var item in card)
            {
                if (item.Key == select) 
                {
                    string temp = item.Value;
                    card.Remove(select);
                    CardLenght -= 1;
                    return temp; 
                }
            }
            return "pass";
        }
    }
}
