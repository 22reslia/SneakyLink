using SneakyLink;

namespace SneakyLink.Commands
{
    public class GoToBossRoomCommand : ICommand
    {
        private Game1 _game;

        public GoToBossRoomCommand(Game1 game)
        {
            _game = game;
        }

        public void Execute()
        {
            if (_game.roomList.ContainsKey("BossRoom"))
            {
                _game.oldRoom = _game.room;
                _game.room = _game.roomList["BossRoom"];
                _game.link.PlayerPosition = new Microsoft.Xna.Framework.Vector2(200, 200);
            }
        }
    }
}
