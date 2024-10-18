//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SneakyLink
//{
//    public class NextBlockCommand : ICommand
//    {
//        private Game1 game;
//        private int blockCount;
//        private bool isTriggred;
//        private int clock;

//        public NextBlockCommand(Game1 game)
//        {
//            this.game = game;
//            isTriggred = false;
//            clock = 0;
//        }

//        public void Execute()
//        {
//            if (isTriggred)
//            {
//                if (clock <= 10)
//                {
//                    clock++;
//                }
//                else
//                {
//                    isTriggred = false;
//                    clock = 0;
//                }
//            }
//            else
//            {
//                blockCount = game.blockList.IndexOf(game.currentBlock);
//                if (blockCount < game.blockList.Count - 1)
//                {
//                    game.currentBlock = game.blockList[blockCount + 1];
//                }
//                else
//                {
//                    game.currentBlock = game.blockList[0];
//                }
//                isTriggred = true;
//            }
//        }
//    }
//}
