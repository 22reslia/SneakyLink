using SneakyLink.Scene;

namespace SneakyLink
{
    public class PreviousSceneCommand : ICommand
    {
        private Game1 game;
        private string[] sceneList = [
            "Room1",
            "Room2",
            "Room3",
            "Room4",
            "Room5",
            "Room6",
            "Room7",
            "Room8",
            "Room9",
            "Room10",
            "Room11",
            "Room12",
            "Room13",
            "Room14",
            "Room15",
            "Room16",
            "Room17",
            "Room0"];

        public PreviousSceneCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (game.sceneCount > 1)
            {
                //clear the old collision box
                game.room = game.roomList[sceneList[game.sceneCount]];
                game.enemies = game.room.enemyList;
                game.itemList = game.room.itemList;
                game.sceneCount--;
            }
            else
            {
                game.sceneCount = 16;
            }
        }
    }
}

