using System;
using System.Collections.Generic;

namespace Card_Game
{
    public class Card
    {
        private Dictionary<int, string> cards = new Dictionary<int, string>();
        private Dictionary<int, string> temp = new Dictionary<int, string>();
        

        public Card()
        {
            this.setKeysAndValues();
        }


        private void setKeysAndValues()
        {
            for (int i = 1; i < 14; i++)
            {
                if (i == 1) { cards[i] = "C.Ace"; }
                else if (i == 11) { cards[i] = "C.Jack"; }
                else if (i == 12) { cards[i] = "C.Queen"; }
                else if (i == 13) { cards[i] = "C.King"; }
                else { cards[i] = "C" + i.ToString(); }
            }
            for (int i = 14, j = 1; i < 27; i++)
            {
                if (i == 14) { cards[i] = "D.Ace"; j++; }
                else if (i == 24) { cards[i] = "D.Jack"; }
                else if (i == 25) { cards[i] = "D.Queen"; }
                else if (i == 26) { cards[i] = "D.King"; }
                else { cards[i] = "D" + j.ToString(); j++; }
            }
            for (int i = 27, j = 1; i < 40; i++)
            {
                if (i == 27) { cards[i] = "H.Ace"; j++; }
                else if (i == 37) { cards[i] = "H.Jack"; }
                else if (i == 38) { cards[i] = "H.Queen"; }
                else if (i == 39) { cards[i] = "H.King"; }
                else { cards[i] = "H" + j.ToString(); j++; }
            }
            for (int i = 40, j = 1; i < 53; i++)
            {
                if (i == 40) { cards[i] = "S.Ace"; j++; }
                else if (i == 50) { cards[i] = "S.Jack"; }
                else if (i == 51) { cards[i] = "S.Queen"; }
                else if (i == 52) { cards[i] = "S.King"; }
                else { cards[i] = "S" + j.ToString(); j++; }
            }
        }

        public void CardShuffling(List<Player> players)
        {
            foreach (var item in cards) { temp[item.Key] = item.Value; }

            Random random = new Random();
            int temp1;
            Dictionary<int, string> player = new Dictionary<int, string>();

            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    temp1 = random.Next(1, 52);

                    try { player[temp1] = temp[temp1]; }
                    catch (Exception) { j--; continue; }
                    temp.Remove(temp1);

                    if (player.Count == 7) { break; }
                }
                players[i].AddCards(player);
                player.Clear();
            }
        }
    }
}