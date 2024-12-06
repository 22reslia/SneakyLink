using SneakyLink;

namespace SneakyLink.Commands
{
    public class GameExit : ICommand
    {
        private Game1 _game;

        public GameExit(Game1 exit)
        {
            _game = exit;
        }

        public void Execute()
        {
            _game.Exit();
        }
    }
}
