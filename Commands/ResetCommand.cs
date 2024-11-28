using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Commands
{
    public class ResetCommand : ICommand
    {
        private Game1 game;
        public ResetCommand(Game1 game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.gameState = GameState.GamePlay;
            //load room
            game.roomList = new Dictionary<string, Room>();
            game.roomList.Add("Room0", new Room(game, "..\\..\\..\\Scene\\RoomZero.csv"));
            game.roomList.Add("Room1", new Room(game, "..\\..\\..\\Scene\\RoomOne.csv"));
            game.roomList.Add("Room2", new Room(game, "..\\..\\..\\Scene\\RoomTwo.csv"));
            game.roomList.Add("Room3", new Room(game, "..\\..\\..\\Scene\\RoomThree.csv"));
            game.roomList.Add("Room4", new Room(game, "..\\..\\..\\Scene\\RoomFour.csv"));
            game.roomList.Add("Room5", new Room(game, "..\\..\\..\\Scene\\RoomFive.csv"));
            game.roomList.Add("Room6", new Room(game, "..\\..\\..\\Scene\\RoomSix.csv"));
            game.roomList.Add("Room7", new Room(game, "..\\..\\..\\Scene\\RoomSeven.csv"));
            game.roomList.Add("Room8", new Room(game, "..\\..\\..\\Scene\\RoomEight.csv"));
            game.roomList.Add("Room9", new Room(game, "..\\..\\..\\Scene\\RoomNine.csv"));
            game.roomList.Add("Room10", new Room(game, "..\\..\\..\\Scene\\RoomTen.csv"));
            game.roomList.Add("Room11", new Room(game, "..\\..\\..\\Scene\\RoomEleven.csv"));
            game.roomList.Add("Room12", new Room(game, "..\\..\\..\\Scene\\RoomTwelve.csv"));
            game.roomList.Add("Room13", new Room(game, "..\\..\\..\\Scene\\RoomThirteen.csv"));
            game.roomList.Add("Room14", new Room(game, "..\\..\\..\\Scene\\RoomFourteen.csv"));
            game.roomList.Add("Room15", new Room(game, "..\\..\\..\\Scene\\RoomFifteen.csv"));
            game.roomList.Add("Room16", new Room(game, "..\\..\\..\\Scene\\RoomSixteen.csv"));
            game.roomList.Add("Room17", new Room(game, "..\\..\\..\\Scene\\RoomSeventeen.csv"));
            game.room = game.roomList["Room1"];
            game.enemies = game.room.enemyList;
            game.itemList = game.room.itemList;
            InitializeObject.initializeObject(game);
        }
    }
}
