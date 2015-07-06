namespace JumpOnAHeadGame.Controller.States
{
    using JumpOnAHeadGame.Controller.Managers;
    using JumpOnAHeadGame.Model.Players;
    using JumpOnAHeadGame.View;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class UpdateState : State
    {
        public UpdateState(State nextState)
            : base(nextState)
        {
            this.NextState = nextState;
            this.IsDone = false;

            // Creating Background
            this.SpritesInState.Add(UIInitializer.LevelBackground);

            // Creating players' Animation
            foreach (var playerUI in UIInitializer.ListOfPlayerUIs)
            {
                this.SpritesInState.Add(playerUI.PlayerAnimation);
            }

            //// Creating names, healthbars and snowballBars
            // Player 1
            UIInitializer.Player1Name.Position = new Vector2(20, 0);
            this.SpritesInState.Add(UIInitializer.Player1Name);

            UIInitializer.HealthBarEmptyPlayer1.Position = new Vector2(175, 5);
            this.SpritesInState.Add(UIInitializer.HealthBarEmptyPlayer1);

            UIInitializer.HealthbarFullPlayer1.Position = new Vector2(180, 10);
            this.SpritesInState.Add(UIInitializer.HealthbarFullPlayer1);

            UIInitializer.SnowballBarEmptyPlayer1.Position = new Vector2(180, 45);
            this.SpritesInState.Add(UIInitializer.SnowballBarEmptyPlayer1);

            UIInitializer.SnowballBarFullPlayer1.Position = new Vector2(180, 45);
            this.SpritesInState.Add(UIInitializer.SnowballBarFullPlayer1);
            // Player 2
            UIInitializer.Player2Name.Position = new Vector2(790, 0);
            this.SpritesInState.Add(UIInitializer.Player2Name);

            UIInitializer.HealthBarEmptyPlayer2.Position = new Vector2(945, 5);
            this.SpritesInState.Add(UIInitializer.HealthBarEmptyPlayer2);

            UIInitializer.HealthbarFullPlayer2.Position = new Vector2(950, 10);
            this.SpritesInState.Add(UIInitializer.HealthbarFullPlayer2);

            UIInitializer.SnowballBarEmptyPlayer2.Position = new Vector2(950, 45);
            this.SpritesInState.Add(UIInitializer.SnowballBarEmptyPlayer2);

            UIInitializer.SnowballBarFullPlayer2.Position = new Vector2(950, 45);
            this.SpritesInState.Add(UIInitializer.SnowballBarFullPlayer2);
        }

        private bool IsDone { get; set; }

        public override void Execute()
        {
            if (!this.IsDone)
            {
                this.NextState = this;

                CheckForPause();

                // Creating blocks
                foreach (var block in StateMachine.CurrentLevel.ListOfBlocks)
                {
                    if (!block.IsDrawn)
                    {
                        block.IsDrawn = true;
                        block.Sprite.Position = block.Position;
                        block.Bounds = new Rectangle((int)block.Position.X, (int)block.Position.Y, block.Sprite.Texture.Width, block.Sprite.Texture.Height);
                        this.SpritesInState.Add(block.Sprite);
                    }
                }

                // Creating Piles of snow
                foreach (var pile in StateMachine.CurrentLevel.ListOfPilesOfSnow)
                {
                    if (!pile.IsDrawn)
                    {
                        pile.IsDrawn = true;
                        pile.Sprite.Position = pile.Position;
                        pile.Bounds = new Rectangle((int)pile.Position.X, (int)pile.Position.Y, pile.Sprite.Texture.Width, pile.Sprite.Texture.Height);
                        this.SpritesInState.Add(pile.Sprite);
                    }
                    // Snowballs refill
                    pile.RefillSnowballs(StateMachine.CurrentLevel.ListOfPlayers);
                }

                for (int i = 0; i < StateMachine.CurrentLevel.ListOfPlayers.Count; i++)
                {
                    // Adjusting snowballbars
                    UIInitializer.ListOfSnowballBars[i].SourceRectangle = new Rectangle(UIInitializer.ListOfSnowballBars[i].SourceRectangle.X, UIInitializer.ListOfSnowballBars[i].SourceRectangle.Y, 20 * StateMachine.CurrentLevel.ListOfPlayers[i].Snowballs, UIInitializer.ListOfSnowballBars[i].SourceRectangle.Height);
                   
                    // Adjusting Healthbars 
                    UIInitializer.ListOfHealthbars[i].SourceRectangle = new Rectangle(UIInitializer.ListOfHealthbars[i].SourceRectangle.X, UIInitializer.ListOfHealthbars[i].SourceRectangle.Y, 3 * StateMachine.CurrentLevel.ListOfPlayers[i].Health, UIInitializer.ListOfHealthbars[i].SourceRectangle.Height);
                    if (UIInitializer.ListOfHealthbars[i].SourceRectangle.Width == 0)
                    {
                        this.IsDone = true;
                        this.NextState = new GameOverState(this);
                        // Stop sounds
                        for (int m = 1; m < 7; m++)
                        {
                            SoundManager.Stop("Sound" + m.ToString());
                        }
                    }

                    // Base Movement, Animation and Bounds
                    StateMachine.CurrentLevel.ListOfPlayers[i].Move(StateMachine.CurrentLevel.ListOfBlocks);
                    UIInitializer.ListOfPlayerUIs[i].PlayerAnimation.Position = StateMachine.CurrentLevel.ListOfPlayers[i].Position;
                    UIInitializer.ListOfPlayerUIs[i].PlayerAnimation.IsFacingRight = StateMachine.CurrentLevel.ListOfPlayers[i].IsFacingRight;
                    StateMachine.CurrentLevel.ListOfPlayers[i].Bounds = new Rectangle((int)StateMachine.CurrentLevel.ListOfPlayers[i].Position.X, (int)StateMachine.CurrentLevel.ListOfPlayers[i].Position.Y, UIInitializer.ListOfPlayerUIs[i].PlayerAnimation.SourceRectangle.Width, UIInitializer.ListOfPlayerUIs[i].PlayerAnimation.SourceRectangle.Height);
                    UIInitializer.ListOfPlayerUIs[i].PlayerAnimation.ChangeAnimation(StateMachine.CurrentLevel.ListOfPlayers[i].State);

                    // Shooting
                    if (StateMachine.CurrentLevel.ListOfPlayers[i].IsShooting)
                    {
                        StateMachine.CurrentLevel.ListOfPlayers[i].IsShooting = false;
                        Vector2 snowballPosition = new Vector2();
                        if (StateMachine.CurrentLevel.ListOfPlayers[i].IsFacingRight)
                        {
                            snowballPosition = new Vector2(StateMachine.CurrentLevel.ListOfPlayers[i].Bounds.Right, StateMachine.CurrentLevel.ListOfPlayers[i].Position.Y + (StateMachine.CurrentLevel.ListOfPlayers[i].Bounds.Height * 0.2f));
                        }
                        else
                        {
                            snowballPosition = new Vector2(StateMachine.CurrentLevel.ListOfPlayers[i].Bounds.Left - 40, StateMachine.CurrentLevel.ListOfPlayers[i].Position.Y + (StateMachine.CurrentLevel.ListOfPlayers[i].Bounds.Height * 0.2f));
                        }

                        Snowball newSnowball = new Snowball(snowballPosition, UIInitializer.CreateSprite("Snowball"), StateMachine.CurrentLevel.ListOfPlayers[i].IsFacingRight);
                        StateMachine.CurrentLevel.ListOfSnowballs.Add(newSnowball);
                        this.SpritesInState.Add(newSnowball.Sprite);
                    }
                }

                // Movement and Bounds of the Snowballs
                for (int i = 0; i < StateMachine.CurrentLevel.ListOfSnowballs.Count; i++)
                {
                    // Collision
                    for (int j = 0; j < StateMachine.CurrentLevel.ListOfPlayers.Count; j++)
                    {
                        StateMachine.CurrentLevel.ListOfSnowballs[i].ActOnPlayer(StateMachine.CurrentLevel.ListOfPlayers[j]);
                    }

                    for (int j = 0; j < StateMachine.CurrentLevel.ListOfBlocks.Count; j++)
                    {
                        StateMachine.CurrentLevel.ListOfSnowballs[i].ActOnBlock(StateMachine.CurrentLevel.ListOfBlocks[j]);
                    }

                    // Movement and Destruction
                    if (!StateMachine.CurrentLevel.ListOfSnowballs[i].IsMelting)
                    {
                        StateMachine.CurrentLevel.ListOfSnowballs[i].Move();
                        StateMachine.CurrentLevel.ListOfSnowballs[i].Sprite.Position = StateMachine.CurrentLevel.ListOfSnowballs[i].Position;
                        StateMachine.CurrentLevel.ListOfSnowballs[i].Bounds = new Rectangle(
                            (int)StateMachine.CurrentLevel.ListOfSnowballs[i].Position.X,
                            (int)StateMachine.CurrentLevel.ListOfSnowballs[i].Position.Y,
                            StateMachine.CurrentLevel.ListOfSnowballs[i].Sprite.Texture.Width,
                            StateMachine.CurrentLevel.ListOfSnowballs[i].Sprite.Texture.Height);
                    }
                    else
                    {
                        this.SpritesInState.Remove(StateMachine.CurrentLevel.ListOfSnowballs[i].Sprite);
                        StateMachine.CurrentLevel.ListOfSnowballs.Remove(StateMachine.CurrentLevel.ListOfSnowballs[i]);
                    }
                }
            }
        }

        private void CheckForPause()
        {
            foreach (KeyboardButtonState key in InputHandler.ActiveKeys)
            {
                if (key.Button == Keys.Escape && key.ButtonState == KeyboardButtonState.KeyState.Clicked)
                {
                    this.IsDone = true;
                    this.NextState = new PausedState(this);
                }
            }
        }

        public override void Draw(AbstractRenderer renderer)
        {

            renderer.DrawState(this.SpritesInState);
            //// foreach (KeyboardButtonState Key in InputHandler.ActiveKeys)
            // {
            //     if (Key.Button == Keys.N && Key.ButtonState == KeyboardButtonState.KeyState.Clicked)
            //     {
            //        Globals.Graphics.GraphicsDevice.Clear(Color.Red);
            //     }
            //     else if (Key.Button == Keys.N && Key.ButtonState == KeyboardButtonState.KeyState.Held)
            //     {
            //         Globals.Graphics.GraphicsDevice.Clear(Color.Yellow);
            //     }
            //     else if (Key.Button == Keys.N && Key.ButtonState == KeyboardButtonState.KeyState.Released)
            //     {
            //         Globals.Graphics.GraphicsDevice.Clear(Color.Green);
            //     }    
            // }
        }
    }
}
