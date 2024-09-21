
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

//Moves Link to the right
public class MoveRight : ICommand
{
    private Game1 _game;
    int velocity = 10;

    public MoveRight(Game1 game){
        _game = game;
    }

    public void Execute () {

        _game.linkPosition.X += velocity;
    }
}

//Moves Link to the left
public class MoveLeft : ICommand
{
    private Game1 _game;
    int velocity = 10;

    public MoveLeft(Game1 game){
        _game = game;
    }

    public void Execute () {

        _game.linkPosition.X -= velocity;
    }
}

public class MoveUp : ICommand
{
    private Game1 _game;
    int velocity = 10;

    public MoveUp(Game1 game){
        _game = game;
    }

    public void Execute () {

        _game.linkPosition.Y += velocity;
    }
}

public class MoveDown : ICommand
{
    private Game1 _game;
    int velocity = 10;

    public MoveDown(Game1 game){
        _game = game;
    }

    public void Execute () {

        _game.linkPosition.Y -= velocity;
    }
}