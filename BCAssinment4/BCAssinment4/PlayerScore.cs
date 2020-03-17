/*Brian Chaves
 * November 28,2012
 * Assinment 4
 * Ping pong game
 * Player Score class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCAssinment4
{
    class PlayerScore
    {
        public static int Player1_Score = 0;
        public static int Player2_Score = 0;
        public static bool GameInPlay = false;
        public static bool GameOver = false;

        /// <summary>
        /// Resets the score of both players to zero
        /// </summary>
        public static void ResetScore()
        {
            Player1_Score = 0;
            Player2_Score = 0;
        }
    }
}
