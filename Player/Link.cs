using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;

namespace SneakyLink.Player
{
    public class Link
    {
        public Vector2 PlayerPosition { get; set; }
        public PlayerStateMachine StateMachine { get; private set; }
        public CollisionBox CollisionBox { get; private set; }
        public ISprite PlayerSprite { get; private set; }

        public int Velocity { get; set; }
        private int _originalVelocity;

        public bool IsBlockedTop { get; set; }
        public bool IsBlockedBottom { get; set; }
        public bool IsBlockedLeft { get; set; }
        public bool IsBlockedRight { get; set; }

        public bool IsV { get; set; }
        public bool IsMovable { get; set; }

        private int _maxHealth;
        public int MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value > 0 ? value : 1;
        }

        private int _currentHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value >= 0 ? value : 0;
        }

        public int Damage { get; set; }
        public int CoinNum { get; set; }
        public int KeyNum { get; set; }
        public int BombNum { get; set; }
        public bool HasBluePotion { get; set; }
        public bool HasRedPotion { get; set; }

        private bool _isDrinkingRedPotion;
        public bool IsDrinkingRedPotion
        {
            get => _isDrinkingRedPotion;
            set
            {
                if (value)
                {
                    _originalVelocity = Velocity;
                    Velocity -= 2;
                }
                else
                {
                    Velocity = _originalVelocity;
                }
                _isDrinkingRedPotion = value;
            }
        }

        private double _drinkCounter;
        private double _drinkDuration = 2.0;
        private double _healCounter;
        private double _healTime = 1.0;

        public int Experience { get; private set; }
        public int Level { get; private set; }
        public int XpToNextLevel { get; private set; }

        private Texture2D _xpBarBackground;
        private Texture2D _xpBarFill;

        private float _timer;
        private float _stopTime = 1f;

        private int _vCounter;
        private int _mCounter;

        public Link(Game1 game)
        {
            MaxHealth = 5;
            CurrentHealth = MaxHealth;
            IsV = false;
            IsMovable = true;

            Velocity = 3;
            _originalVelocity = Velocity;

            PlayerPosition = new Vector2(100, 100);

            IsBlockedTop = false;
            IsBlockedBottom = false;
            IsBlockedLeft = false;
            IsBlockedRight = false;

            StateMachine = new PlayerStateMachine(PlayerPosition, this, game);
            CollisionBox = new CollisionBox(CollisionObjectType.Player, 38, 38, (int)PlayerPosition.X, (int)PlayerPosition.Y);

            CoinNum = 0;
            KeyNum = 0;
            BombNum = 0;
            HasBluePotion = false;
            HasRedPotion = false;
            IsDrinkingRedPotion = false;

            Damage = 1;
            Level = 1;
            Experience = 0;
            XpToNextLevel = 200;

            _xpBarBackground = new Texture2D(game.GraphicsDevice, 1, 1);
            _xpBarBackground.SetData(new[] { Color.Gray });
            _xpBarFill = new Texture2D(game.GraphicsDevice, 1, 1);
            _xpBarFill.SetData(new[] { Color.Green });
        }

        public void SetSprite()
        {
            PlayerSprite = StateMachine.GetCurrentIdleSprite();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (PlayerSprite != null)
            {
                StateMachine.Draw(spriteBatch, PlayerSprite, (int)PlayerPosition.X, (int)PlayerPosition.Y);
            }

            // Draw the XP bar
            int width = 800;
            int height = 20;

            spriteBatch.Begin();
            spriteBatch.Draw(_xpBarBackground, new Rectangle(0, 620, width, height), Color.Gray);
            float xpPercentage = (float)Experience / XpToNextLevel;
            spriteBatch.Draw(_xpBarFill, new Rectangle(0, 620, (int)(xpPercentage * width), height), Color.Green);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
            PlayerSprite = StateMachine.Update(gameTime);
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= _stopTime)
            {
                StateMachine.currentState = PlayerState.playerIdle;
                _timer = 0f;
            }
            else
            {
                _timer += deltaTime;
            }

            CollisionBox.x = (int)PlayerPosition.X;
            CollisionBox.y = (int)PlayerPosition.Y;

            if (CollisionBox.side == CollisionType.None)
            {
                IsBlockedTop = false;
                IsBlockedBottom = false;
                IsBlockedLeft = false;
                IsBlockedRight = false;
            }

            // Update invincibility
            if (IsV)
            {
                _vCounter++;
                if (_vCounter == 60)
                {
                    IsV = false;
                    _vCounter = 0;
                }
            }

            // Update movement state
            if (CollisionBox.side == CollisionType.None)
            {
                _mCounter++;
                if (_mCounter == 50)
                {
                    IsMovable = true;
                    _mCounter = 0;
                }
            }

            // Check potion consumption
            if (IsDrinkingRedPotion)
            {
                if (_drinkCounter == 0)
                {
                    _drinkCounter = _drinkDuration;
                    _originalVelocity = Velocity;
                    Velocity -= 2;
                }

                _drinkCounter -= gameTime.ElapsedGameTime.TotalSeconds;
                _healCounter += gameTime.ElapsedGameTime.TotalSeconds;
                if (_healCounter >= _healTime)
                {
                    if (CurrentHealth < MaxHealth)
                    {
                        CurrentHealth++;
                    }
                    _healCounter -= _healTime;
                }

                if (_drinkCounter <= 0)
                {
                    IsDrinkingRedPotion = false;
                    _drinkCounter = 0;
                    _healCounter = 0;
                    Velocity = _originalVelocity;
                }
            }
            else
            {
                Velocity = _originalVelocity;
            }

            PlayerSprite.Update();
        }

        public void GainExperience(int xp)
        {
            Experience += xp;
            if (Experience >= XpToNextLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Experience -= XpToNextLevel;
            Level++;
            Damage += 1;
            XpToNextLevel = (int)(XpToNextLevel * 1.5); // XP curve
        }
    }
}
