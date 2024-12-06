using SneakyLink;

namespace SneakyLink.Commands
{
    public class MuteCommand : ICommand
    {
        private Game1 _game;

        public MuteCommand(Game1 game)
        {
            _game = game;
        }

        public void Execute()
        {
            _game.isMuted = !_game.isMuted;

            if (_game.playerSounds != null)
                _game.playerSounds.SetMute(_game.isMuted);

            if (_game.itemSounds != null)
                _game.itemSounds.SetMute(_game.isMuted);

            if (_game.titleScene != null)
                _game.MuteTitleMusic(_game.isMuted);
        }
    }
}
