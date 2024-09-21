
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
    private Link link;

    public MoveRight(Link player){
        link = player;
    }

    public void Execute () 
    {
        link.playerPosition.X += link.velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.RightMoving;
    }
}

//Moves Link to the left and changes link's sprite directionally
public class MoveLeft : ICommand
{
    private Link link;

    public MoveLeft(Link player)
    {
        link = player;
    }

    public void Execute () 
    {
        link.playerPosition.X -= link.velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.LeftMoving;
    }
}

//Moves link up and changes link's sprite directionally
public class MoveUp : ICommand
{
    private Link link;

    public MoveUp(Link player)
    {
        link = player;
    }

    public void Execute ()
    {
        link.playerPosition.Y -= link.velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.BackwardMoving;
    }
}

//Moves link down and changes link's sprite directionally
public class MoveDown : ICommand
{
    private Link link;

    public MoveDown(Link player)
    {
        link = player;
    }

    public void Execute () 
    {
        link.playerPosition.Y += link.velocity;
        link.stateMachine.currentState = PlayerStateMachine.PlayerState.ForwardMoving;
    }
}