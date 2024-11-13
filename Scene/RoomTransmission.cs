using Microsoft.Xna.Framework;
using SneakyLink.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Scene
{
    public class RoomTransmission
    {
        public static void roomTransmission(Room oldRoom, Room newRoom, Game1 game, GameTime gameTime)
        {
            foreach (IBlock blocks in newRoom.blockList)
            {
                //move 
            }

            foreach (Doors door in newRoom.doorList)
            {

            }
            game.gameState = GameState.GamePlay;
        }
    }
}
