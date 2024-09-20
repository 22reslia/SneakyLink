
using Microsoft.Xna.Framework;
using SneakyLink;

public class GameExit : ICommand {

    private Game1 _game; //Reference to Game1

    //Constructor that takes in Exit
    public GameExit(Game1 exit){
        
        _game = exit;
    }

    public void Execute () {

        _game.Exit();
    }
    
}