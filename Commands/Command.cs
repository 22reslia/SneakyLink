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
        link.stateMachine.currentDirection = PlayerDirection.playerRight;
        link.stateMachine.currentState = PlayerState.playerMoving;
        link.playerPosition.X += link.velocity;
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
        link.stateMachine.currentDirection = PlayerDirection.playerLeft;
        link.stateMachine.currentState = PlayerState.playerMoving;
        link.playerPosition.X -= link.velocity;
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
        link.stateMachine.currentDirection = PlayerDirection.playerUp;
        link.stateMachine.currentState = PlayerState.playerMoving;
        link.playerPosition.Y -= link.velocity;
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
        link.stateMachine.currentDirection = PlayerDirection.playerDown;
        link.stateMachine.currentState = PlayerState.playerMoving;
        link.playerPosition.Y += link.velocity;
    }
}

// link wooden sword attack command
public class WoodenAttack : ICommand
{
    private Link link;

    public WoodenAttack(Link player)
    {
        link = player;
    }

    public void Execute () 
    {   
        link.stateMachine.currentState = PlayerState.playerAttacking;
    }
}

public class DamagePlayer : ICommand
{
    private Link link;

    public DamagePlayer(Link player)
    {
        link = player;
    }

    public void Execute () 
    {   
        link.stateMachine.currentState = PlayerState.playerDamaged;
    }
}
public class UseItem : ICommand
{
    private Link link;

    public UseItem(Link player)
    {
        link = player;
    }

    public void Execute () 
    {   
        link.stateMachine.currentState = PlayerState.playerUseItem;
    }
    
}