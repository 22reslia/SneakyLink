﻿using SneakyLink.Scene;

namespace SneakyLink
{
    public class PreviousSceneCommand : ICommand
    {
        private Game1 game;
        private string[] sceneList = [
            "..\\..\\..\\Scene\\RoomOne.csv",
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

        public PreviousSceneCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            if (game.sceneCount > 1)
            {
                //clear the old collision box
                game.blocks.Clear();
                game.doors.Clear();
                game.room = new Room(game, sceneList[game.sceneCount]);
                game.sceneCount--;
            }
            else
            {
                game.sceneCount = 16;
            }
        }
    }
}

