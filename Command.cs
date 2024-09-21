
using Microsoft.Xna.Framework;
using SneakyLink;
using SneakyLink.Player;

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
    private Player link;
    int velocity = 10;

    public MoveRight(Game1 game, Player player){
        _game = game;
        link = player;
    }

    public void Execute () {

        link.playerPosition.X += velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.RightNormal;
    }
}

//Moves Link to the left
public class MoveLeft : ICommand
{
    private Game1 _game;
    private Player link;
    int velocity = 10;

    public MoveLeft(Game1 game, Player player){
        _game = game;
        link = player;
    }

    public void Execute () {

        link.playerPosition.X -= velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.LeftNormal;
    }
}

public class MoveUp : ICommand
{
    private Game1 _game;
    private Player link;
    int velocity = 10;

    public MoveUp(Game1 game, Player player){
        _game = game;
        link = player;
    }

    public void Execute () {

        link.playerPosition.Y += velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.BackwardNormal;
    }
}

public class MoveDown : ICommand
{
    private Game1 _game;
    private Player link;
    int velocity = 10;

    public MoveDown(Game1 game, Player player){
        _game = game;
        link = player;
    }

    public void Execute () {

        link.playerPosition.Y -= velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.ForwardNormal;
    }
}