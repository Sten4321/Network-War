using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace FirstSemesterExamProject
{
    public partial class Window : Form
    {
        private Graphics dc;
        private GameState gs;
        //Time Keeping
        private DateTime endTime;
        private float currentFps;
        public static float deltaTime;
        private BufferedGraphics backbuffer;
        //team setup
        private int number;
        private static Stack<Enum> blueteam; //List for each team to contain every unit they choose
        private static Stack<Enum> redteam;
        private static Stack<Enum> greenteam;
        private static Stack<Enum> yellowteam;
        private PlayerTeam teamSelect;
        //UnitSelect
        private int pointUsed;
        private int pointMax = Constant.unitBuyPoints;
        //list of text for the selected units
        private BindingList<Enum> showList = new BindingList<Enum>();
        public static bool canEndTurn;
        public static bool canRestart;
        public static bool canMute;
        public static bool musicOn = true;
        public static bool menuMusicOn = true;







        /// <summary>
        /// getter for redteam stack
        /// </summary>
        public static Stack<Enum> RedTeamStack
        {
            get { return redteam; }
        }
        /// <summary>
        /// getter for blueteam stack
        /// </summary>
        public static Stack<Enum> BlueTeamStack
        {
            get { return blueteam; }
        }
        /// <summary>
        /// getter for greenteam stack
        /// </summary>
        public static Stack<Enum> GreenTeamStack
        {
            get { return greenteam; }
        }
        /// <summary>
        /// getter for yellowteam stack
        /// </summary>
        public static Stack<Enum> YellowTeamStack
        {
            get { return yellowteam; }
        }

        public Window()
        {
            InitializeComponent();
            SoundEngine.PlayMenuBackgroundMusic();
            this.DoubleBuffered = true;
        }

        /// <summary>
        /// Timer that runs the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick_Tick(object sender, EventArgs e)
        {
            //We use TimeKeeping to keep the Tick manageable
            TimeKeeping();

            //Updates the visibility of buttons on the form
            //UpdateButtons();

            //Updates the game each (Tick)
            Ticking();

            //calls my Render function
            Render();

        }

        /// <summary>
        /// keeps track of time and fps
        /// </summary>
        private void TimeKeeping()
        {
            //log start time
            DateTime startTime = DateTime.Now;

            //Time it took since last loop
            TimeSpan Fps = startTime - endTime;

            //log end time
            endTime = DateTime.Now;

            //get milliseconds since last gameloop from the deltatime
            int milliSeconds = Fps.Milliseconds > 0 ? Fps.Milliseconds : 1;

            //calculate Fps
            currentFps = 1000f / milliSeconds;

            //updates deltatime
            deltaTime = 1 / currentFps;
        }

        /// <summary>
        /// Ticks The Game
        /// </summary>
        private void Ticking()
        {
            //updates the games every tick
            if (gs != null)
            {
                gs.Tick(deltaTime);
            }
            CheckEndTurn();
            CheckRestart();
            MuteMusic();
        }
        /// <summary>
        /// Shows the list of units depending on what team is choosing
        /// </summary>
        private void ListUpdate()
        {
            if (redteam != null)
            {
                //empties the list
                showList.Clear();

                switch (teamSelect)
                {
                    //makes the listbox contain the chosen units depending on the team chosen
                    case PlayerTeam.RedTeam:
                        foreach (Enum unit in redteam)
                        {
                            showList.Add(unit);
                        }
                        break;

                    case PlayerTeam.BlueTeam:
                        foreach (Enum unit in blueteam)
                        {
                            showList.Add(unit);
                        }
                        break;

                    case PlayerTeam.GreenTeam:
                        foreach (Enum unit in greenteam)
                        {
                            showList.Add(unit);
                        }
                        break;

                    case PlayerTeam.YellowTeam:
                        foreach (Enum unit in yellowteam)
                        {
                            showList.Add(unit);
                        }
                        break;

                }

            }
        }

        /// <summary>
        /// Renders The Game
        /// </summary>
        private void Render()
        {
            if (gs != null)
            {
                //clears the screen so it is ready for redraw.
                dc.Clear(Color.Black);
                //updates the game meny text
                this.Text = "War of Arauwen (fps: " + (int)currentFps + ")";
                //renders the graphical objects in the game depending on the gamestate
                if (gs != null)
                {
                    gs.Render(dc);
                }

                //switches the shown with backbuffer for next render
                backbuffer.Render();
            }
        }

        /// <summary>
        /// code run when the form has loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Load(object sender, EventArgs e)
        {
            //stores an end time for first runthrough
            endTime = DateTime.Now;
            //creates graphics and backbuffer
            if (dc == null)
            {
                dc = CreateGraphics();
                backbuffer = BufferedGraphicsManager.Current.Allocate(dc, DisplayRectangle);
                dc = backbuffer.Graphics;
            }
            ListBox1.DataSource = showList;

            #region ChangeToolTips;
            //Changes the Unit tooltips
            this.myTooltip.SetToolTip(this.AddScout, "A unit with high mobility but medium-low damage. Does increased damage against Artifacts. Moves do not consume Player-moves (cost: " + Constant.scoutUnitCost + ")");
            this.myTooltip.SetToolTip(this.AddArcher, "A medium ranged Unit with medium damage. Does reduced damage to armored Units (cot: " + Constant.archerUnitCost + ")");
            this.myTooltip.SetToolTip(this.AddKnight, "An armored melee Unit, with medium-high damage (cost: " + Constant.knightUnitCost + ")");
            this.myTooltip.SetToolTip(this.AddMage, "A ranged Unit with low mobility, but potentially high damage. Does increased damage against armored Units. (cost: " + Constant.mageUnitCost + ")");
            this.myTooltip.SetToolTip(this.AddCleric, "A close range healer, with medium survivability. (cost: " + Constant.clericUnitCost + ")");
            this.myTooltip.SetToolTip(this.AddArtifact, "An expensive, heavily armored Unit with high damage and range, but low health and mobility. Ignores enemy armor, and has the Ability to heal small wounds. (cost: " + Constant.artifactUnitCost + ")");
            PointsLabel.Text = pointUsed + "/" + pointMax + " Points Used";
            #endregion

            //line for gameplay testing
            //gs = new BattleGameState(this, 2, dc);


            //starts the game at the menu screen
            gs = new UnitChoiceGameState(this);

            // SoundEngine.PlayMenuBackgroundMusic();
        }


        /// <summary>
        /// Calculates the amount of points used out of max points
        /// </summary>
        public void PointUsing()
        {
            pointUsed = 0;

            switch (teamSelect)
            {
                //makes the listbox contain the chosen units depending on the team chosen
                case PlayerTeam.RedTeam:
                    foreach (Enum unit in redteam)
                    {
                        PointAdd(unit);
                    }
                    break;

                case PlayerTeam.BlueTeam:
                    foreach (Enum unit in blueteam)
                    {
                        PointAdd(unit);
                    }
                    break;

                case PlayerTeam.GreenTeam:
                    foreach (Enum unit in greenteam)
                    {
                        PointAdd(unit);
                    }
                    break;

                case PlayerTeam.YellowTeam:
                    foreach (Enum unit in yellowteam)
                    {
                        PointAdd(unit);
                    }
                    break;

            }

            PointsLabel.Text = pointUsed + "/" + pointMax + " Points Used";
        }

        /// <summary>
        /// adds point to points used depending on the unit
        /// </summary>
        /// <param name="unit"></param>
        private void PointAdd(Enum unit)
        {
            switch (unit)
            {
                case Units.Archer:
                    pointUsed += Constant.archerUnitCost;
                    break;

                case Units.Knight:
                    pointUsed += Constant.knightUnitCost;
                    break;

                case Units.Mage:
                    pointUsed += Constant.mageUnitCost;
                    break;

                case Units.Cleric:
                    pointUsed += Constant.clericUnitCost;
                    break;

                case Units.Artifact:
                    pointUsed += Constant.artifactUnitCost;
                    break;

                case Units.Scout:
                    pointUsed += Constant.scoutUnitCost;
                    break;

            }
        }

        //List of all the buttons used and how they react when clicked
        #region Buttons interface
        /// <summary>
        /// the button that ends the current players turn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndTurn_MouseClick(object sender, EventArgs e)
        {

            System.Diagnostics.Debug.WriteLine("EndTurn Clicked");
            EndTurnKeyPress();

        }

        /// <summary>
        /// ends the players turn
        /// </summary>
        public void EndTurnKeyPress()
        {
            if (gs is BattleGameState bs)
            {
                bs.ChangeTurn();
                SoundEngine.PlaySound(Constant.endTurnSound);
            }
        }

        /// <summary>
        /// ends turn on backspace keypress
        /// </summary>
        public void CheckEndTurn()
        {
            if (Keyboard.IsKeyDown(Keys.Back))
            {
                if (canEndTurn)
                {
                    EndTurnKeyPress();

                    canEndTurn = false;
                }

            }
        }

        public void CheckRestart()
        {
            if (Keyboard.IsKeyDown(Keys.F5))
            {
                if (canRestart)
                {
                    Application.Restart();

                    canRestart = false;
                }

            }
        }
        public void MuteMusic()
        {
            if (Keyboard.IsKeyDown(Keys.M))
            {
                if (canMute)
                {
                    if (musicOn == true)
                    {
                        SoundEngine.StopSound();
                        canMute = false;
                        musicOn = false;

                    }
                    else if (musicOn == false)
                    {
                        SoundEngine.PlayBackgroundMusic();
                        canMute = false;
                        musicOn = true;
                    }
                }

            }
        }
        private void MuteButton_Click(object sender, EventArgs e)
        {
            if (menuMusicOn == true)
            {
                SoundEngine.StopSound();
                menuMusicOn = false;
                muteButton.Image = Image.FromFile(@"Sprites/Buttons/mute2.png");

            }
            else if (menuMusicOn == false)
            {
                SoundEngine.PlayMenuBackgroundMusic();
                muteButton.Image = Image.FromFile(@"Sprites/Buttons/mute1.png");

                menuMusicOn = true;
            }

        }
        /// <summary>
        /// the buttom that starts the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, EventArgs e)
        {
            if (((redteam != null && redteam.Count > 0) || (redteam == null))
                && ((blueteam != null && blueteam.Count > 0) || (blueteam == null))
                && ((greenteam != null && greenteam.Count > 0) || (greenteam == null))
                && ((yellowteam != null && yellowteam.Count > 0) || (yellowteam == null)))
            {
                RedTeam.Visible = false;
                BlueTeam.Visible = false;
                GreenTeam.Visible = false;
                YellowTeam.Visible = false;
                TwoPlayer.Visible = false;
                ThreePlayer.Visible = false;
                FourPlayer.Visible = false;
                Back.Visible = false;
                Label.Visible = false;
                Start.Visible = false;
                PointsLabel.Visible = false;
                ListBox1.Visible = false;
                AddArcher.Visible = false;
                AddCleric.Visible = false;
                AddKnight.Visible = false;
                AddScout.Visible = false;
                AddArtifact.Visible = false;
                AddMage.Visible = false;
                RemoveUnit.Visible = false;
                muteButton.Visible = false;
                Host.Visible = false;
                JoinGame.Visible = false;
                Online.Visible = false;
                EnterIP.Visible = false;
                EndTurn.Visible = true;
                //Starts the game
                gs = new BattleGameState(this, number, dc);
                SoundEngine.StopSound();
                SoundEngine.PlaySound(Constant.menuButtonSound);
                SoundEngine.PlayBackgroundMusic();

            }
            else
            {
                SoundEngine.PlaySound(Constant.menuBackSound);
                MessageBox.Show("All teams must have at least one Unit!", "Oops", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// buttom to go back and select a different amount of players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuBackSound);
            TwoPlayer.Visible = true;
            ThreePlayer.Visible = true;
            FourPlayer.Visible = true;
            Label.Visible = true;
            ListBox1.Visible = false;
            AddArcher.Visible = false;
            AddCleric.Visible = false;
            AddKnight.Visible = false;
            AddScout.Visible = false;
            AddArtifact.Visible = false;
            AddMage.Visible = false;
            RemoveUnit.Visible = false;
            Start.Visible = false;
            PointsLabel.Visible = false;
            Back.Visible = false;
            PointsLabel.Visible = false;
            Online.Visible = true;
            JoinGame.Visible = false;
            Host.Visible = false;
            if (RedTeam.Visible == true)
            {
                RedTeam.Visible = false;
            }
            if (BlueTeam.Visible == true)
            {
                BlueTeam.Visible = false;
            }
            if (GreenTeam.Visible == true)
            {
                GreenTeam.Visible = false;
            }
            if (YellowTeam.Visible == true)
            {
                YellowTeam.Visible = false;
            }
            //Resets the stacks
            if (redteam != null)
            {
                redteam = null;
            }
            if (blueteam != null)
            {
                blueteam = null;
            }
            if (greenteam != null)
            {
                greenteam = null;
            }
            if (yellowteam != null)
            {
                yellowteam = null;
            }
        }


        /// <summary>
        /// select 2 players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwoPlayer_Click(object sender, EventArgs e)
        {
            number = 2;
            RedTeam.Visible = true;
            BlueTeam.Visible = true;
            TwoPlayer.Visible = false;
            ThreePlayer.Visible = false;
            FourPlayer.Visible = false;
            Back.Visible = true;
            Label.Visible = false;
            Start.Visible = true;
            PointsLabel.Visible = true;
            redteam = new Stack<Enum>();
            blueteam = new Stack<Enum>();
            SoundEngine.PlaySound(Constant.menuButtonSound);
        }

        /// <summary>
        /// select 3 players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreePlayer_Click(object sender, EventArgs e)
        {
            number = 3;
            RedTeam.Visible = true;
            BlueTeam.Visible = true;
            GreenTeam.Visible = true;
            TwoPlayer.Visible = false;
            ThreePlayer.Visible = false;
            FourPlayer.Visible = false;
            Back.Visible = true;
            Label.Visible = false;
            Start.Visible = true;
            PointsLabel.Visible = true;
            redteam = new Stack<Enum>();
            blueteam = new Stack<Enum>();
            greenteam = new Stack<Enum>();
            SoundEngine.PlaySound(Constant.menuButtonSound);
        }

        /// <summary>
        /// select 4 players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FourPlayer_Click(object sender, EventArgs e)
        {
            number = 4;
            RedTeam.Visible = true;
            BlueTeam.Visible = true;
            GreenTeam.Visible = true;
            YellowTeam.Visible = true;
            TwoPlayer.Visible = false;
            ThreePlayer.Visible = false;
            FourPlayer.Visible = false;
            Back.Visible = true;
            Label.Visible = false;
            Start.Visible = true;
            PointsLabel.Visible = true;
            redteam = new Stack<Enum>();
            blueteam = new Stack<Enum>();
            greenteam = new Stack<Enum>();
            yellowteam = new Stack<Enum>();
            SoundEngine.PlaySound(Constant.menuButtonSound);
        }
        /// <summary>
        /// Add the string "Archer" into the selected teams stacks. The stack is choosen when you click the team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddArcher_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuAddUnitSound);
            if (pointUsed + Constant.archerUnitCost <= pointMax)
            {
                switch (teamSelect)
                {
                    case PlayerTeam.RedTeam:
                        redteam.Push(Units.Archer);
                        System.Diagnostics.Debug.WriteLine("Add Archer");
                        break;

                    case PlayerTeam.BlueTeam:
                        blueteam.Push(Units.Archer);
                        break;

                    case PlayerTeam.GreenTeam:
                        greenteam.Push(Units.Archer);
                        break;

                    case PlayerTeam.YellowTeam:
                        yellowteam.Push(Units.Archer);
                        break;

                }
                ListUpdate();
                PointUsing();
            }
        }

        /// <summary>
        /// Add the string "Knight" into the selected teams stacks. The stack is choosen when you click the team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddKnight_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuAddUnitSound);
            if (pointUsed + Constant.knightUnitCost <= pointMax)
            {
                switch (teamSelect)
                {
                    case PlayerTeam.RedTeam:
                        redteam.Push(Units.Knight);
                        break;

                    case PlayerTeam.BlueTeam:
                        blueteam.Push(Units.Knight);
                        break;

                    case PlayerTeam.GreenTeam:
                        greenteam.Push(Units.Knight);
                        break;

                    case PlayerTeam.YellowTeam:
                        yellowteam.Push(Units.Knight);
                        break;

                }
                ListUpdate();
                PointUsing();
            }
        }
        /// <summary>
        /// Adds a mage to the unit list when the button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMage_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuAddUnitSound);
            if (pointUsed + Constant.mageUnitCost <= pointMax)
            {
                switch (teamSelect)
                {
                    case PlayerTeam.RedTeam:
                        redteam.Push(Units.Mage);
                        break;

                    case PlayerTeam.BlueTeam:
                        blueteam.Push(Units.Mage);
                        break;

                    case PlayerTeam.GreenTeam:
                        greenteam.Push(Units.Mage);
                        break;

                    case PlayerTeam.YellowTeam:
                        yellowteam.Push(Units.Mage);
                        break;

                }
                ListUpdate();
                PointUsing();
            }
        }

        /// <summary>
        /// Adds a cleric to the unit list when the button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCleric_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuAddUnitSound);
            if (pointUsed + Constant.clericUnitCost <= pointMax)
            {
                switch (teamSelect)
                {
                    case PlayerTeam.RedTeam:
                        redteam.Push(Units.Cleric);
                        break;

                    case PlayerTeam.BlueTeam:
                        blueteam.Push(Units.Cleric);
                        break;

                    case PlayerTeam.GreenTeam:
                        greenteam.Push(Units.Cleric);
                        break;

                    case PlayerTeam.YellowTeam:
                        yellowteam.Push(Units.Cleric);
                        break;

                }
                ListUpdate();
                PointUsing();
            }
        }
        /// <summary>
        /// Adds a Artifact (siege unit) to the unit list when the button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddArtifact_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuAddUnitSound);
            if (pointUsed + Constant.artifactUnitCost <= pointMax)
            {
                switch (teamSelect)
                {
                    case PlayerTeam.RedTeam:
                        redteam.Push(Units.Artifact);
                        break;

                    case PlayerTeam.BlueTeam:
                        blueteam.Push(Units.Artifact);
                        break;

                    case PlayerTeam.GreenTeam:
                        greenteam.Push(Units.Artifact);
                        break;

                    case PlayerTeam.YellowTeam:
                        yellowteam.Push(Units.Artifact);
                        break;

                }
                ListUpdate();
                PointUsing();
            }
        }

        /// <summary>
        /// Adds a Scout to the unit list when the button is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddScout_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuAddUnitSound);
            if (pointUsed + Constant.scoutUnitCost <= pointMax)
            {
                switch (teamSelect)
                {
                    case PlayerTeam.RedTeam:
                        redteam.Push(Units.Scout);
                        break;

                    case PlayerTeam.BlueTeam:
                        blueteam.Push(Units.Scout);
                        break;

                    case PlayerTeam.GreenTeam:
                        greenteam.Push(Units.Scout);
                        break;

                    case PlayerTeam.YellowTeam:
                        yellowteam.Push(Units.Scout);
                        break;

                }
                ListUpdate();
                PointUsing();
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Removing the unit depending on what team is choosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveUnit_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuBackSound);
            Enum removed;

            switch (teamSelect)
            {

                case PlayerTeam.RedTeam:
                    if (!(redteam.Count <= 0))
                    {
                        removed = redteam.Pop();
                    }
                    break;

                case PlayerTeam.BlueTeam:
                    if (!(blueteam.Count <= 0))
                    {
                        removed = blueteam.Pop();
                    }
                    break;

                case PlayerTeam.GreenTeam:
                    if (!(greenteam.Count <= 0))
                    {
                        removed = greenteam.Pop();
                    }
                    break;

                case PlayerTeam.YellowTeam:
                    if (!(yellowteam.Count <= 0))
                    {
                        removed = yellowteam.Pop();
                    }
                    break;
            }
            ListUpdate();
            PointUsing();
        }

        /// <summary>
        /// select the red team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedTeam_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuButtonSound);
            ListBox1.Visible = true;
            AddArcher.Visible = true;
            AddCleric.Visible = true;
            AddKnight.Visible = true;
            AddScout.Visible = true;
            AddArtifact.Visible = true;
            AddMage.Visible = true;
            RemoveUnit.Visible = true;
            teamSelect = PlayerTeam.RedTeam;
            RedTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_red_team_colour2.png");
            BlueTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_blue_team_colour.png");
            GreenTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_green_team_colour.png");
            YellowTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_yellow_team_colour.png");
            ListUpdate();
            PointUsing();
        }

        /// <summary>
        /// selects the blue team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlueTeam_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuButtonSound);
            ListBox1.Visible = true;
            AddArcher.Visible = true;
            AddCleric.Visible = true;
            AddKnight.Visible = true;
            AddScout.Visible = true;
            AddArtifact.Visible = true;
            AddMage.Visible = true;
            RemoveUnit.Visible = true;
            teamSelect = PlayerTeam.BlueTeam;
            RedTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_red_team_colour.png");
            BlueTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_blue_team_colour2.png");
            GreenTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_green_team_colour.png");
            YellowTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_yellow_team_colour.png");
            ListUpdate();
            PointUsing();
        }
        /// <summary>
        /// selects the green team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GreenTeam_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuButtonSound);
            ListBox1.Visible = true;
            AddArcher.Visible = true;
            AddCleric.Visible = true;
            AddKnight.Visible = true;
            AddScout.Visible = true;
            AddArtifact.Visible = true;
            AddMage.Visible = true;
            RemoveUnit.Visible = true;
            teamSelect = PlayerTeam.GreenTeam;
            RedTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_red_team_colour.png");
            BlueTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_blue_team_colour.png");
            GreenTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_green_team_colour2.png");
            YellowTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_yellow_team_colour.png");
            ListUpdate();
            PointUsing();
        }
        /// <summary>
        /// selects the yellow team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YellowTeam_Click(object sender, EventArgs e)
        {
            SoundEngine.PlaySound(Constant.menuButtonSound);
            ListBox1.Visible = true;
            AddArcher.Visible = true;
            AddCleric.Visible = true;
            AddKnight.Visible = true;
            AddScout.Visible = true;
            AddArtifact.Visible = true;
            AddMage.Visible = true;
            RemoveUnit.Visible = true;
            teamSelect = PlayerTeam.YellowTeam;
            RedTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_red_team_colour.png");
            BlueTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_blue_team_colour.png");
            GreenTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_green_team_colour.png");
            YellowTeam.Image = Image.FromFile(@"Sprites\Buttons\knap_yellow_team_colour2.png");
            ListUpdate();
            PointUsing();
        }

        /// <summary>
        /// Just a label dont mind it! you better not!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// a label that displays the amount of points that a player has used out of how many kan be used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PointsLabel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Button that takes you to a screen where you have to choose between hosting a game or joining a game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Online_Click(object sender, EventArgs e)
        {
            RedTeam.Visible = false;
            BlueTeam.Visible = false;
            GreenTeam.Visible = false;
            YellowTeam.Visible = false;
            TwoPlayer.Visible = false;
            ThreePlayer.Visible = false;
            FourPlayer.Visible = false;
            Back.Visible = true;
            Label.Visible = false;
            Start.Visible = false;
            PointsLabel.Visible = false;
            ListBox1.Visible = false;
            AddArcher.Visible = false;
            AddCleric.Visible = false;
            AddKnight.Visible = false;
            AddScout.Visible = false;
            AddArtifact.Visible = false;
            AddMage.Visible = false;
            RemoveUnit.Visible = false;
            muteButton.Visible = true;
            EnterIP.Visible = true;
            Client.Instance.ValidIp = false;
            // TODO: Online Buttom
        }

        /// <summary>
        /// Makes you the host/server that is in control of the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Host_Click(object sender, EventArgs e)
        {
            if (Server.Instance.isOnline == false)
            {
                Server.Instance.StartServer();
                UpdateIpLabelText();
            }
        }
        private void UpdateIpLabelText()
        {
            JoinGame.Visible = false;
            EnterIP.Visible = false;
            HostIPAdress.Visible = true;

            //portLabel.Visible = true;

            HostIPAdress.Text = Server.Instance.serverIp;
            //portLabel.Text = Server.Instance.port;

        }
        /// <summary>
        /// Make it possible to join a host through their IP-adress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JoinGame_Click(object sender, EventArgs e)
        {
            CheckIP();

            if (Client.Instance.ValidIp == true)
            {
                Client.Instance.ConnectClient();
            }
            // TODO: JoinGame Buttom
        }

        /// <summary>
        /// Handles what happens after a successfull join
        /// </summary>
        public void ApplyJoined()
        {
            // TODO: ApplyJoined
        }

        /// <summary>
        /// To enter IP adress given from the host
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterIP_TextChanged(object sender, EventArgs e)
        {
            // TODO: Change ip field
        }
        /// <summary>
        /// Shall contain the IP adress of the host
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HostIPAdress_Click(object sender, EventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// Checks if the text in EnterIP TextBox is valid
        /// </summary>
        private void CheckIP()
        {
            IPAddress ipAddress;
            if (IPAddress.TryParse(EnterIP.Text, out ipAddress))
            {
                Client.Instance.IP = ipAddress;
                Client.Instance.ValidIp = true;
                //valid ip
            }
            else
            {
                Client.Instance.ValidIp = false;
                //is not valid ip
            }
            // TODO: Check valid ip
        }

        /// <summary>
        /// Allows the player to use the mouse to select units
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseClick(object sender, MouseEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("X: {0} , Y: {1}", Cursor.Position.X, Cursor.Position.Y);
            if (gs is BattleGameState)
            {
                //Saves the cursor position based on where the cursor is on the screen
                Point curserPos = this.PointToClient(Cursor.Position);
                //System.Diagnostics.Debug.WriteLine("X: {0} , Y: {1}", curserPos.X, curserPos.Y);
                //tries to select a unit if the cursor is on the screen
                if (curserPos.X < 640 && curserPos.Y < 640)
                {
                    int x = (int)((curserPos.X - curserPos.X % GameBoard.TileSize) / GameBoard.TileSize);
                    int y = (int)((curserPos.Y - curserPos.Y % GameBoard.TileSize) / GameBoard.TileSize);
                    //System.Diagnostics.Debug.WriteLine("X: {0} , Y: {1}", x, y);
                    BattleGameState.Players[BattleGameState.PlayerTurn - 1].MouseClickSelect(x, y);
                }
            }
        }

        private void EndTurn_MouseClick(object sender, MouseEventArgs e)
        {
            if (gs is BattleGameState bs)
            {
                bs.ChangeTurn();
                SoundEngine.PlaySound(Constant.endTurnSound);
            }
        }

    }
}






