using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Battle;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class UI
{
    //Dialogue UI for player and enemy!
    public class Dialogue
    {

        //General Setup
        private Texture2D playerDialogueTexture;
        public Rectangle playerDialogueRectangle;
        private Texture2D enemyDialogueTexture;
        public Rectangle enemyDialogueRectangle;
        private SpriteFont font;
        public List<String> dialogues = new List<string>();
        // see over here, things like options.Add("an option"); --> this isn't allowed for the sole reason that classes are meant to 
        // declare members, they aren't meant to have procedural code --> i mean this is what google says so:D  
        public void SetupDialogue(GraphicsDevice graphicsDevice, SpriteFont Font)
        {
            //Dialogue
            //start
            dialogues.Add("So we're playing the waiting game...");
            //attacks
            dialogues.Add("After months in the toaster, it's ready. BEIGEL GOD, I SUMMON YOU");
            // getting attacked/died
            dialogues.Add("Wow you hit me, I'm so scared");
            dialogues.Add("ig you win this time");

            //Player UI
            playerDialogueRectangle = new Rectangle(165, 230, 450, 80);
            playerDialogueTexture = new Texture2D(graphicsDevice, 1, 1);
            playerDialogueTexture.SetData(new[]{Color.White});
            //Enemy UI
            enemyDialogueRectangle = new Rectangle();
            enemyDialogueTexture = new Texture2D(graphicsDevice, 1,1);
            enemyDialogueTexture.SetData(new[] {Color.White});
            //Others
            font = Font;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerDialogueTexture, playerDialogueRectangle, Color.Gray);


            //TBD --> Moves CHANGE THE WAY THE DIALOGUE IS SETUP :D (VARIABLE NAME = Moves.option)
            String dia = "OKAY BUD, LET'S \nSEE YOU SURVIVE THIS!";
            spriteBatch.DrawString(font, dia, new Vector2(playerDialogueRectangle.X+10, playerDialogueRectangle.Y+font.MeasureString(dia).Y/2), Color.Black);
        }
    }
    public class Moves
    {
        public Rectangle selectionRect;
        public Texture2D selectionTexture;
        public static int option;
        private KeyboardState current;
        private KeyboardState previous;
        private SpriteFont font;
        //colors
        private Color attackCol; 
        private Color fleeCol;
        private Color itemCol;
        // Option texts
        private string attack;
        public bool attacking;
        private string flee;
        public static bool fleeing;
        private string items;
        public bool iteming;
        // item constraints
        public bool heal;
        public bool emd;
        public bool si;

        //beigel stuff
        public bool beigleSummon;
        public double beigelTime;

        public bool movement;

        //attacks
        public Rectangle beigleRect;
        public void Initialize()
        {
            option = 0;
            heal = true;
            emd = true;
            si = true;
            //options setup
            attack = "ATTACK";// option = 1
            flee = "FLEE";// option = 2
            items = "ITEMS";// option = 3
        }
        public void LoadContent(GraphicsDevice graphicsDevice, SpriteFont Font)
        {
            attackCol = Color.White;
            itemCol = Color.White;
            fleeCol = Color.White;
            selectionTexture = new Texture2D(graphicsDevice, 1, 1);
            selectionTexture.SetData(new[]{Color.White});
            previous = Keyboard.GetState();
            font = Font;

            beigleSummon = false;
            beigleRect = new Rectangle(0, 134, 64, 64);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //options
            attackCol = Color.White;
            fleeCol = Color.White;
            itemCol = Color.White;
            if(option == 0) attackCol = Color.Blue;
            if(option == 1) fleeCol = Color.Blue;
            if(option == 2) itemCol = Color.Blue;

            spriteBatch.DrawString(font, attack, new Vector2(400, 240), attackCol);
            spriteBatch.DrawString(font, flee, new Vector2(400, 265), fleeCol);
            spriteBatch.DrawString(font, items, new Vector2(400, 290), itemCol);
            if(beigleSummon)
            {
                spriteBatch.Draw(Game1.beigleTexture, beigleRect, Color.White);
                spriteBatch.DrawString(font, attack, new Vector2(554 - font.MeasureString(attack).X, beigleRect.Y - 50), Color.BlanchedAlmond);
            }

        }
        public void Update(GameTime gameTime)
        {
            if(beigleSummon)
            {
                beigelTime += gameTime.ElapsedGameTime.TotalSeconds;
                BeigelGod();
            }
            
            OptionSelection();
        }
        public void OptionSelection()
        {
            current = Keyboard.GetState();

            if(current.IsKeyDown(Keys.Down))
            {
                if(previous.IsKeyUp(Keys.Down))
                {
                    option++;
                }
            }
            if(current.IsKeyDown(Keys.Up))
            {
                if(previous.IsKeyUp(Keys.Up))
                {
                    option--;
                }
            }
            if(current.IsKeyDown(Keys.Enter))
            {
                //options
                if(previous.IsKeyUp(Keys.Enter) && option == 1 && attacking == false && iteming == false && fleeing == false) // flee
                {
                    fleeing = true;
                }

                if(previous.IsKeyUp(Keys.Enter) && attacking == true)
                {
                    if(option == 0 && beigleSummon == false && attack != "wait")
                    {
                        beigleSummon = true;
                        attack = "wait";
                    }
                }

                if(previous.IsKeyUp(Keys.Enter) && option == 0 && fleeing == false && iteming == false && attacking == false) // attack
                {
                    attack = "The Wrath of The Beigel God";
                    flee = "The Arm of Sporks";
                    items = "The Rage of The Beetroot";
                    attacking = true;

                }

                //*options* options
                if(previous.IsKeyUp(Keys.Enter) && iteming == true)
                {
                    if(option == 0 && attack != "item used" && heal == true)
                    {
                        Player.health+=25;
                        attack = "item used";
                        heal = false;
                    }
                    if(option == 1 && flee != "item used" && emd == true)
                    {
                        Player.health -= 25;
                        flee = "item used";
                        emd = false;
                    }
                    //last option tbd once enemy has been added! (si for bool)
                    if(option == 2 && items != "item used" && si == true)
                    {
                        //prolly smth like enemy.health -=
                        items = "item used";
                        si = false;
                    }
                }
                if(previous.IsKeyUp(Keys.Enter) && option == 2 && fleeing == false && attacking == false && iteming == false) // items
                {
                    attack = "bleh bleh bleh (+25 health)";
                    flee = "emotional damage (-25 to you)";
                    items= "self infliction (-25 to enemy)";
                    iteming = true;
                    if(heal == false) attack = "item used";
                    if(emd == false) flee = "item used";
                    if(si == false) items = "item used";
                }
            }


            if(current.IsKeyDown(Keys.Q))
            {
                if(previous.IsKeyUp(Keys.Q))
                {
                    attack = "ATTACK";
                    items = "ITEMS";
                    flee = "FLEE"; 
                    attacking = false;
                    fleeing = false;
                    iteming = false;
                }
            }

            if(option < 0) option = 2;
            if(option > 2) option = 0;
            
            previous = current;
        }
        public void BeigelGod()
        {
            movement = false;
            if (beigleRect.X < 554)
            {
                beigleRect.X += 1;            
            }
            else
            {
                movement = true;
            }
            //beigleSummon = false;
        }
    }    
}   