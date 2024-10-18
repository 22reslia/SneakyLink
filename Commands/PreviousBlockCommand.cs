//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SneakyLink
//{
//    public class PreviousBlockCommand : ICommand
//    {
//        private Game1 game;
//        private int blockCount;
//        private bool isTriggred;
//        private int clock;

//        public PreviousBlockCommand(Game1 game)
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
//                if (blockCount > 0)
//                {
//                    game.currentBlock = game.blockList[blockCount - 1];
//                }
//                else
//                {
//                    game.currentBlock = game.blockList[game.blockList.Count - 1];
//                }
//                isTriggred = true;
//            }
//        }
//    }
//}
