using System;
using System.Collections.Generic;
using System.Threading;

namespace Card_Game
{
    public class Game
    {
        private Dictionary<string, int> cardsValues;
        private int score;

        public Game()
        {
            cardsValues = new Dictionary<string, int>();
            this.setKeysAndValue();
        }


        private void setKeysAndValue()
        {
            for (int i = 1; i < 14; i++)
            {
                if (i == 1) { cardsValues["C.Ace"] = i; }
                else if (i == 11) { cardsValues["C.Jack"] = i; }
                else if (i == 12) { cardsValues["C.Queen"] = i; }
                else if (i == 13) { cardsValues["C.King"] = i; }
                else { cardsValues["C" + i.ToString()] = i; }
            }
            for (int i = 14, j = 1; i < 27; i++)
            {
                if (i == 14) { cardsValues["D.Ace"] = i; j++; }
                else if (i == 24) { cardsValues["D.Jack"] = i; }
                else if (i == 25) { cardsValues["D.Queen"] = i; }
                else if (i == 26) { cardsValues["D.King"] = i; }
                else { cardsValues["D" + j.ToString()] = i; j++; }
            }
            for (int i = 27, j = 1; i < 40; i++)
            {
                if (i == 27) { cardsValues["H.Ace"] = i; j++; }
                else if (i == 37) { cardsValues["H.Jack"] = i; }
                else if (i == 38) { cardsValues["H.Queen"] = i; }
                else if (i == 39) { cardsValues["H.King"] = i; }
                else { cardsValues["H" + j.ToString()] = i; j++; }
            }
            for (int i = 40, j = 1; i < 53; i++)
            {
                if (i == 40) { cardsValues["S.Ace"] = i; j++; }
                else if (i == 50) { cardsValues["S.Jack"] = i; }
                else if (i == 51) { cardsValues["S.Queen"] = i; }
                else if (i == 52) { cardsValues["S.King"] = i; }
                else { cardsValues["S" + j.ToString()] = i; j++; }
            }
        }

        public void StartGame()
        {
            Console.Write("Do you know information about the game(y/n)? ");
            string tempp = Console.ReadLine();
            if (tempp == "Y" || tempp == "y" || tempp == "yes" || tempp == "Yes")
            {
                Console.Clear();

                Card card = new Card();

                Console.Write("Enter player lenght: ");
                int playerLenght = Convert.ToInt32(Console.ReadLine());
                if (playerLenght >= 2)
                {
                    List<Player> players = new List<Player>();
                    Player player = new Player();

                    for (int i = 0; i < playerLenght; i++)
                    {
                        Console.Clear();
                        player = new Player();
                        Console.Write("Enter username: ");
                        player.Username = Convert.ToString(Console.ReadLine());

                        Console.Write("Enter password: ");
                        player.Password = Convert.ToInt32(Console.ReadLine());

                        players.Add(player);

                        Console.Clear();
                    }

                    card.CardShuffling(players);

                    int number1 = 0, number2 = 0;
                    string temp2;
                    bool finishplayer = false;

                    while (true)
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (score == 0)
                            {
                                number1 = 0;
                                number2 = 0;

                                players[i].ShowCards();
                                string temp = players[i].PlayYourChoice();
                                Console.Clear(); i++;

                                foreach (var item in cardsValues)
                                {
                                    if (item.Key == temp)
                                    {
                                        number1 = item.Value;
                                        break;
                                    }
                                }

                                Console.WriteLine($"The value of the first card: {number1}\n");
                                try
                                {
                                    players[i].ShowCards();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine($"{players[i].card.Keys}) [{players[i].card.Values}]");
                                }
                                  
                                temp2 = players[i].PlayYourChoice();
                                Console.Clear();

                                foreach (var item in cardsValues)
                                {
                                    if (item.Key == temp2) 
                                    { 
                                        number2 = item.Value;
                                        break;
                                    }
                                }

                                if (number2 > number1) 
                                {
                                    Console.WriteLine($"{players[i].Username} and took this tour\n");
                                    players[i].Score += number2 + number1;
                                    score = 0;
                                    Console.WriteLine($"Game score: {score}");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                }
                                else 
                                {
                                    Console.WriteLine("no one got this tour\n");

                                    score += number1 + number2; 
                                    number1 = number2; number2 = 0;

                                    Console.WriteLine($"Game score: {score}");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine($"The value of the first card: {number1}\n");
                                players[i].ShowCards();
                                temp2 = players[i].PlayYourChoice();
                                Console.Clear();

                                foreach (var item in cardsValues) 
                                { 
                                    if (item.Key == temp2) 
                                    {
                                        number2 = item.Value; break; 
                                    }
                                }

                                if (number2 > number1) 
                                {
                                    Console.WriteLine($"{players[i].Username} and took this tour");
                                    players[i].Score += number2 + number1;
                                    score = 0;
                                    Console.WriteLine($"Game score: {score}");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                }
                                else 
                                {
                                    Console.WriteLine("no one got this tour");
                                    score += number1 + number2; 
                                    number1 = number2;
                                    number2 = 0;
                                    Console.WriteLine($"Game score: {score}");
                                    Thread.Sleep(3000);
                                    Console.Clear();
                                }
                            }

                            Console.Clear();

                            for (int j = 0; j < players.Count; j++)
                            {
                                if (players[j].CardLenght == 0) 
                                {
                                    Thread.Sleep(3000);
                                    finishplayer = true;
                                    break;
                                }
                            }
                        }
                        if (finishplayer == true)
                        {
                            Console.Clear();
                            Console.WriteLine("Game end");
                            break;
                        }
                    }
                    int counter = 0, index = 0;
                    for (int i = 0; i < players.Count; i++)
                    {
                        if (players[index].Score > players[i].Score) { counter++; }
                        else if(counter == players.Count - 1) 
                        {
                            Console.WriteLine($">>>>>>>>>>>>>>>>>>>>{players[index].Username} won the forensic player game :) <<<<<<<<<<<<<<<<<<<<<<");
                            Thread.Sleep(3000);
                            finishplayer = true;
                            break; 
                        }
                        else { index++; i = 0; counter = 0; }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Miniumum 2 player.");
                }
            }
            else
            {
                Console.WriteLine("The cards shown on the screen and their values. \n    Please play according to these values when playing the game.\n");
                this.printCardsNames();
                Console.WriteLine("\n Will re-enter the game.");
                Console.ReadLine();
                Console.Clear();

                Game game = new Game();
                game.StartGame();
            }
        }

        private void printCardsNames()
        {
            Console.WriteLine("Keys) [Values]");

            int counter = 0;
            foreach (var item in cardsValues)
            {
                if (counter == 13) { Console.WriteLine(); counter = 0; }
                Console.Write($"{item.Key})  [{item.Value}]   ");
                counter++;
            }
        }
    }
}
