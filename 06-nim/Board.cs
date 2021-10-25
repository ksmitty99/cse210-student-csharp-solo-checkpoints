using System;
using System.Collections.Generic;

namespace _06_nim
{
    /// <summary>
    /// Keeps track of all of the pieces in play.
    /// 
    /// Stereotype:
    ///     Information Holder
    /// </summary>
    class Board
    {
        List<int> _piles = new List<int>();

        /// <summary>
        /// Initialize the Board
        /// </summary>
        public Board()
        {
            Prepare();
        }

        /// <summary>
        /// A helper method that sets up the board in a new random state.
        /// This could be called by the constructor, or if it is desired
        /// to play again.
        /// 
        /// It should have 2-5 piles with 1-9 stones in each.
        /// </summary>
        private void Prepare()
        {
            Random randomGenerator = new Random();
            int piles = randomGenerator.Next(2,6);
            for (int i = 0; i < piles; i++) {
                int stones = randomGenerator.Next(1,10);
                _piles.Add(stones);
            }
        }

        /// <summary>
        /// Applies this move by removing the number of stones
        /// from the pile specified in the move.
        /// </summary>
        /// <param name="move">Contains the pile and the number of stones</param>
        public void Apply(Move move)
        {
            int stone = move.GetStones();
            int pile = move.GetPile();    

            int newStoneAmount = _piles[pile] - stone;

            _piles[pile] = Math.Max(0, newStoneAmount);   
        }

        /// <summary>
        /// Indicates if the board is empty (no more stones)
        /// </summary>
        /// <returns>True, if there are no more stones</returns>
        public bool IsEmpty()
        {
            bool stonesLeft = false;

            foreach(int piles in _piles)
            {
                if (piles > 0){
                    stonesLeft = true;
                    break;
                }
                else {
                    stonesLeft = false;
                }
            }
            return stonesLeft;
        }

        /// <summary>
        /// Get's a string representation of the board in the format:
        /// 
        /// --------------------
        /// 0: O O O O O O 
        /// 1: O O O O O O O
        /// 2: O O O O O O O O 
        /// 3: O O O O 
        /// --------------------
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            string text = "\n----------------------------------\n";

            for (int i = 0; i < _piles.Count; i++){
                text+= GetTextForPile(i, _piles[i]);
            }
            text += "-----------------------------------\n";

            return text;
        }

        /// <summary>
        /// A helper function that is used by the general ToString method.
        /// This one gets the text for a specific pile in the format:
        /// 
        /// 2: O O O O O O O O 
        /// 
        /// </summary>
        /// <param name="pileNumber">The pile number to display at the front of the line.</param>
        /// <param name="stone">The number of stones in the pile</param>
        /// <returns></returns>
        private string GetTextForPile(int pileNumber, int stone)
        {
            string text = $"{pileNumber}: ";

            for (int i = 0; i < stone; i++)
            {
                text += 'o';
            }
            text+= "\n";

            return text;
        }
    }
}
