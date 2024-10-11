using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class ChangeSceneCommand : ICommand
    {
        private Game1 game;
        private int sceneCount;
        private bool isTriggred;
        private int clock;
        private string[] sceneList = ["..\\..\\..\\Scene\\RoomOne.csv", 
            "..\\..\\..\\Scene\\RoomTwo.csv", 
            "..\\..\\..\\Scene\\RoomThree.csv",
            "..\\..\\..\\Scene\\RoomFour.csv",
            "..\\..\\..\\Scene\\RoomFive.csv",
            "..\\..\\..\\Scene\\RoomSix.csv",
            "..\\..\\..\\Scene\\RoomSeven.csv",
            "..\\..\\..\\Scene\\RoomEight.csv",
            "..\\..\\..\\Scene\\RoomNine.csv",
            "..\\..\\..\\Scene\\RoomTen.csv",
            "..\\..\\..\\Scene\\RoomEleven.csv",
            "..\\..\\..\\Scene\\RoomTwelve.csv",
            "..\\..\\..\\Scene\\RoomThirteen.csv",
            "..\\..\\..\\Scene\\RoomFourteen.csv",
            "..\\..\\..\\Scene\\RoomFifteen.csv",
            "..\\..\\..\\Scene\\RoomSixteen.csv",
            "..\\..\\..\\Scene\\RoomSeventeen.csv"];

        public ChangeSceneCommand(Game1 game)
        {
            this.game = game;
            sceneCount = 0;
            isTriggred = false;
            clock = 0;
        }
        public void Execute()
        {
            if (isTriggred)
            {
                if (clock <= 10)
                {
                    clock++;
                }
                else
                {
                    isTriggred = false;
                    clock = 0;
                }
            }
            else
            {
                if (sceneCount < sceneList.Length)
                {
                    game.scene = new Room(game, sceneList[sceneCount]);
                    sceneCount++;
                }
                else
                {
                    sceneCount = 0;
                }
                isTriggred = true;
            }
        }
    }
}
