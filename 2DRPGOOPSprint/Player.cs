using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2DRPGOOPSprint
{
    public class Player : GameEntity, IDrawable
    {
        private Texture2D texture;
        private Vector2 _previousPosition;
        private Vector2 _position;

        public Texture2D Texture { get => texture; }
        public Vector2 Position { get => _position; }

        public Rectangle Bounds => new((int)_position.X, (int)_position.Y, texture.Width, texture.Height);

        private KeyboardState _currentState;
        private KeyboardState _previousState;
        Vector2 _moveDirection;
        float _moveSpeed = 5f;
        private bool canMove = true;
        public Player(Vector2 position)
        {
            _position = position;
        }

        public void LoadContent(TextureManager textureManager)
        {
            texture = textureManager.GetTexture("player");
            if (texture == null)
            {
                Console.WriteLine("Failed to load player texture!");
                return;
            }
            else
            {
                Console.WriteLine("Player texture loaded successfully!");
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.EasyDraw(spriteBatch, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            GetInput();
        }

        private void GetInput()
        {
            _currentState = Keyboard.GetState();

            _previousPosition = _position;
            if (_currentState.IsKeyDown(Keys.W) && !_previousState.IsKeyDown(Keys.W)) _position.Y -= 16;
            if (_currentState.IsKeyDown(Keys.S) && !_previousState.IsKeyDown(Keys.S)) _position.Y += 16;
            if (_currentState.IsKeyDown(Keys.A) && !_previousState.IsKeyDown(Keys.A)) _position.X -= 16;
            if (_currentState.IsKeyDown(Keys.D) && !_previousState.IsKeyDown(Keys.D)) _position.X += 16;
            
            _previousState = _currentState;
        }

        

        public void OnCollision(IDrawable other)
        {
            if (other is Tile tile) 
            {
                if (tile.IsCollidable)
                {
                    _position = _previousPosition;
                }
            }
            
        }
    }
}
