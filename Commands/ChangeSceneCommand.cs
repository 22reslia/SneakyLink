using SneakyLink.Scene;

namespace SneakyLink
{
    public class ChangeSceneCommand : ICommand
    {
        private Game1 game;
        private int sceneCount;
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
            clock = 0;
        }
        public void Execute()
        {
                if (sceneCount < sceneList.Length)
                {
                    //clear the old collision box
                    game.blocks.Clear();
                    game.doors.Clear();
                    game.room = new Room(game, sceneList[sceneCount]);
                    sceneCount++;
                }
                else
                {
                    sceneCount = 0;
                }
        }
    }
}
