
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

//Moves Link to the right and changes link's sprite directionally
public class MoveRight : ICommand
{
    private Game1 _game;
    private Link link;
    int velocity;

    public MoveRight(Game1 game, Link player){
        _game = game;
        link = player;
        velocity = player.velocity;
    }

    public void Execute () {

        link.playerPosition.X += velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.RightNormal;
    }
}

//Moves Link to the left and changes link's sprite directionally
public class MoveLeft : ICommand
{
    private Game1 _game;
    private Link link;
    int velocity;

    public MoveLeft(Game1 game, Link player){
        _game = game;
        link = player;
        velocity = player.velocity;
    }

    public void Execute () {

        link.playerPosition.X -= velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.LeftNormal;
    }
}

//Moves link up and changes link's sprite directionally
public class MoveUp : ICommand
{
    private Game1 _game;
    private Link link;
    int velocity;

    public MoveUp(Game1 game, Link player){
        _game = game;
        link = player;
        velocity = player.velocity;
    }

    public void Execute () {

        link.playerPosition.Y -= velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.BackwardNormal;
    }
}

//Moves link down and changes link's sprite directionally
public class MoveDown : ICommand
{
    private Game1 _game;
    private Link link;
    int velocity;

    public MoveDown(Game1 game, Link player){
        _game = game;
        link = player;
        velocity = player.velocity;
    }

    public void Execute () {

        link.playerPosition.Y += velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.ForwardNormal;
    }
}