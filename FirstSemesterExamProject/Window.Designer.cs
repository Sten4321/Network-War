using System.Drawing;

namespace FirstSemesterExamProject
{
    partial class Window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.Tick = new System.Windows.Forms.Timer(this.components);
            this.EndTurn = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.AddArcher = new System.Windows.Forms.Button();
            this.AddKnight = new System.Windows.Forms.Button();
            this.RemoveUnit = new System.Windows.Forms.Button();
            this.Label = new System.Windows.Forms.Label();
            this.YellowTeam = new System.Windows.Forms.Button();
            this.BlueTeam = new System.Windows.Forms.Button();
            this.GreenTeam = new System.Windows.Forms.Button();
            this.RedTeam = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.PointsLabel = new System.Windows.Forms.Label();
            this.AddMage = new System.Windows.Forms.Button();
            this.AddCleric = new System.Windows.Forms.Button();
            this.AddArtifact = new System.Windows.Forms.Button();
            this.AddScout = new System.Windows.Forms.Button();
            this.FourPlayer = new System.Windows.Forms.Button();
            this.ThreePlayer = new System.Windows.Forms.Button();
            this.TwoPlayer = new System.Windows.Forms.Button();
            this.myTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.muteButton = new System.Windows.Forms.Button();
            this.Online = new System.Windows.Forms.Button();
            this.Host = new System.Windows.Forms.Button();
            this.JoinGame = new System.Windows.Forms.Button();
            this.EnterIP = new System.Windows.Forms.TextBox();
            this.HostIPAdress = new System.Windows.Forms.Label();
            this.StartOnlineGame = new System.Windows.Forms.Button();
            this.ReadyCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tick
            // 
            this.Tick.Enabled = true;
            this.Tick.Interval = 17;
            this.Tick.Tick += new System.EventHandler(this.Tick_Tick);
            // 
            // EndTurn
            // 
            this.EndTurn.FlatAppearance.BorderSize = 0;
            this.EndTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EndTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndTurn.Image = global::FirstSemesterExamProject.Properties.Resources.EndTurn;
            this.EndTurn.Location = new System.Drawing.Point(1070, 560);
            this.EndTurn.Margin = new System.Windows.Forms.Padding(5);
            this.EndTurn.Name = "EndTurn";
            this.EndTurn.Size = new System.Drawing.Size(167, 57);
            this.EndTurn.TabIndex = 0;
            this.EndTurn.TabStop = false;
            this.EndTurn.Text = "End Turn";
            this.EndTurn.UseVisualStyleBackColor = true;
            this.EndTurn.Visible = false;
            this.EndTurn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EndTurn_MouseClick);
            // 
            // Start
            // 
            this.Start.Cursor = System.Windows.Forms.Cursors.Default;
            this.Start.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Start.FlatAppearance.BorderSize = 0;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Image = global::FirstSemesterExamProject.Properties.Resources.knap_play;
            this.Start.Location = new System.Drawing.Point(734, 484);
            this.Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(94, 36);
            this.Start.TabIndex = 1;
            this.myTooltip.SetToolTip(this.Start, "Click to start game");
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Visible = false;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // ListBox1
            // 
            this.ListBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(550, 334);
            this.ListBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ListBox1.Size = new System.Drawing.Size(159, 186);
            this.ListBox1.TabIndex = 16;
            this.ListBox1.Visible = false;
            this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // AddArcher
            // 
            this.AddArcher.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddArcher.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddArcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddArcher.Image = global::FirstSemesterExamProject.Properties.Resources.add_archer1;
            this.AddArcher.Location = new System.Drawing.Point(333, 327);
            this.AddArcher.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddArcher.Name = "AddArcher";
            this.AddArcher.Size = new System.Drawing.Size(86, 30);
            this.AddArcher.TabIndex = 17;
            this.AddArcher.TabStop = false;
            this.AddArcher.UseVisualStyleBackColor = true;
            this.AddArcher.Visible = false;
            this.AddArcher.Click += new System.EventHandler(this.AddArcher_Click);
            // 
            // AddKnight
            // 
            this.AddKnight.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddKnight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddKnight.FlatAppearance.BorderSize = 0;
            this.AddKnight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddKnight.Image = global::FirstSemesterExamProject.Properties.Resources.add_knight;
            this.AddKnight.Location = new System.Drawing.Point(332, 372);
            this.AddKnight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddKnight.Name = "AddKnight";
            this.AddKnight.Size = new System.Drawing.Size(86, 30);
            this.AddKnight.TabIndex = 18;
            this.AddKnight.UseVisualStyleBackColor = true;
            this.AddKnight.Visible = false;
            this.AddKnight.Click += new System.EventHandler(this.AddKnight_Click);
            // 
            // RemoveUnit
            // 
            this.RemoveUnit.Cursor = System.Windows.Forms.Cursors.Default;
            this.RemoveUnit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RemoveUnit.FlatAppearance.BorderSize = 0;
            this.RemoveUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveUnit.Image = global::FirstSemesterExamProject.Properties.Resources.remove_unit1;
            this.RemoveUnit.Location = new System.Drawing.Point(734, 328);
            this.RemoveUnit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RemoveUnit.Name = "RemoveUnit";
            this.RemoveUnit.Size = new System.Drawing.Size(94, 36);
            this.RemoveUnit.TabIndex = 19;
            this.myTooltip.SetToolTip(this.RemoveUnit, "Click to remove the last selected Unit");
            this.RemoveUnit.UseVisualStyleBackColor = true;
            this.RemoveUnit.Visible = false;
            this.RemoveUnit.Click += new System.EventHandler(this.RemoveUnit_Click);
            // 
            // Label
            // 
            this.Label.BackColor = System.Drawing.Color.Transparent;
            this.Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Label.Location = new System.Drawing.Point(522, 295);
            this.Label.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(220, 45);
            this.Label.TabIndex = 20;
            this.Label.Text = "Select Players";
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label.Click += new System.EventHandler(this.Label_Click);
            // 
            // YellowTeam
            // 
            this.YellowTeam.Cursor = System.Windows.Forms.Cursors.Default;
            this.YellowTeam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.YellowTeam.FlatAppearance.BorderSize = 0;
            this.YellowTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YellowTeam.Image = global::FirstSemesterExamProject.Properties.Resources.knap_yellow_team_colour;
            this.YellowTeam.Location = new System.Drawing.Point(775, 240);
            this.YellowTeam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.YellowTeam.Name = "YellowTeam";
            this.YellowTeam.Size = new System.Drawing.Size(118, 44);
            this.YellowTeam.TabIndex = 28;
            this.myTooltip.SetToolTip(this.YellowTeam, "Click to customize Yellow Team\'s Units");
            this.YellowTeam.UseVisualStyleBackColor = true;
            this.YellowTeam.Visible = false;
            this.YellowTeam.Click += new System.EventHandler(this.YellowTeam_Click);
            // 
            // BlueTeam
            // 
            this.BlueTeam.Cursor = System.Windows.Forms.Cursors.Default;
            this.BlueTeam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BlueTeam.FlatAppearance.BorderSize = 0;
            this.BlueTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BlueTeam.Image = global::FirstSemesterExamProject.Properties.Resources.knap_blue_team_colour;
            this.BlueTeam.Location = new System.Drawing.Point(640, 240);
            this.BlueTeam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BlueTeam.Name = "BlueTeam";
            this.BlueTeam.Size = new System.Drawing.Size(118, 44);
            this.BlueTeam.TabIndex = 27;
            this.myTooltip.SetToolTip(this.BlueTeam, "Click to customize Blue Team\'s Units");
            this.BlueTeam.UseVisualStyleBackColor = true;
            this.BlueTeam.Visible = false;
            this.BlueTeam.Click += new System.EventHandler(this.BlueTeam_Click);
            // 
            // GreenTeam
            // 
            this.GreenTeam.Cursor = System.Windows.Forms.Cursors.Default;
            this.GreenTeam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.GreenTeam.FlatAppearance.BorderSize = 0;
            this.GreenTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GreenTeam.Image = global::FirstSemesterExamProject.Properties.Resources.knap_green_team_colour;
            this.GreenTeam.Location = new System.Drawing.Point(370, 240);
            this.GreenTeam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GreenTeam.Name = "GreenTeam";
            this.GreenTeam.Size = new System.Drawing.Size(118, 44);
            this.GreenTeam.TabIndex = 26;
            this.myTooltip.SetToolTip(this.GreenTeam, "Click to customize Green Team\'s Units");
            this.GreenTeam.UseVisualStyleBackColor = true;
            this.GreenTeam.Visible = false;
            this.GreenTeam.Click += new System.EventHandler(this.GreenTeam_Click);
            // 
            // RedTeam
            // 
            this.RedTeam.BackColor = System.Drawing.SystemColors.Control;
            this.RedTeam.Cursor = System.Windows.Forms.Cursors.Default;
            this.RedTeam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RedTeam.FlatAppearance.BorderSize = 0;
            this.RedTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RedTeam.Image = global::FirstSemesterExamProject.Properties.Resources.knap_red_team_colour;
            this.RedTeam.Location = new System.Drawing.Point(505, 240);
            this.RedTeam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RedTeam.Name = "RedTeam";
            this.RedTeam.Size = new System.Drawing.Size(118, 44);
            this.RedTeam.TabIndex = 25;
            this.myTooltip.SetToolTip(this.RedTeam, "Click to customize Red Team\'s Units");
            this.RedTeam.UseVisualStyleBackColor = false;
            this.RedTeam.Visible = false;
            this.RedTeam.Click += new System.EventHandler(this.RedTeam_Click);
            // 
            // Back
            // 
            this.Back.Cursor = System.Windows.Forms.Cursors.Default;
            this.Back.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Back.FlatAppearance.BorderSize = 0;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Image = global::FirstSemesterExamProject.Properties.Resources.back;
            this.Back.Location = new System.Drawing.Point(332, 496);
            this.Back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(94, 36);
            this.Back.TabIndex = 29;
            this.myTooltip.SetToolTip(this.Back, "Click to return to Player selection");
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Visible = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // PointsLabel
            // 
            this.PointsLabel.AutoSize = true;
            this.PointsLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.PointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointsLabel.Location = new System.Drawing.Point(554, 528);
            this.PointsLabel.Name = "PointsLabel";
            this.PointsLabel.Size = new System.Drawing.Size(31, 20);
            this.PointsLabel.TabIndex = 30;
            this.PointsLabel.Text = "0/0";
            this.PointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PointsLabel.Visible = false;
            this.PointsLabel.Click += new System.EventHandler(this.PointsLabel_Click);
            // 
            // AddMage
            // 
            this.AddMage.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddMage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddMage.FlatAppearance.BorderSize = 0;
            this.AddMage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddMage.Image = global::FirstSemesterExamProject.Properties.Resources.add_mage;
            this.AddMage.Location = new System.Drawing.Point(442, 372);
            this.AddMage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddMage.Name = "AddMage";
            this.AddMage.Size = new System.Drawing.Size(86, 30);
            this.AddMage.TabIndex = 33;
            this.AddMage.UseVisualStyleBackColor = true;
            this.AddMage.Visible = false;
            this.AddMage.Click += new System.EventHandler(this.AddMage_Click);
            // 
            // AddCleric
            // 
            this.AddCleric.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddCleric.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddCleric.FlatAppearance.BorderSize = 0;
            this.AddCleric.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddCleric.Image = global::FirstSemesterExamProject.Properties.Resources.add_cleric;
            this.AddCleric.Location = new System.Drawing.Point(332, 418);
            this.AddCleric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddCleric.Name = "AddCleric";
            this.AddCleric.Size = new System.Drawing.Size(86, 30);
            this.AddCleric.TabIndex = 34;
            this.AddCleric.UseVisualStyleBackColor = true;
            this.AddCleric.Visible = false;
            this.AddCleric.Click += new System.EventHandler(this.AddCleric_Click);
            // 
            // AddArtifact
            // 
            this.AddArtifact.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddArtifact.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddArtifact.FlatAppearance.BorderSize = 0;
            this.AddArtifact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddArtifact.Image = global::FirstSemesterExamProject.Properties.Resources.add_artifact;
            this.AddArtifact.Location = new System.Drawing.Point(442, 418);
            this.AddArtifact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddArtifact.Name = "AddArtifact";
            this.AddArtifact.Size = new System.Drawing.Size(86, 30);
            this.AddArtifact.TabIndex = 36;
            this.AddArtifact.UseVisualStyleBackColor = true;
            this.AddArtifact.Visible = false;
            this.AddArtifact.Click += new System.EventHandler(this.AddArtifact_Click);
            // 
            // AddScout
            // 
            this.AddScout.Cursor = System.Windows.Forms.Cursors.Default;
            this.AddScout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AddScout.FlatAppearance.BorderSize = 0;
            this.AddScout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddScout.Image = global::FirstSemesterExamProject.Properties.Resources.add_scout;
            this.AddScout.Location = new System.Drawing.Point(442, 328);
            this.AddScout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddScout.Name = "AddScout";
            this.AddScout.Size = new System.Drawing.Size(86, 30);
            this.AddScout.TabIndex = 35;
            this.AddScout.UseVisualStyleBackColor = true;
            this.AddScout.Visible = false;
            this.AddScout.Click += new System.EventHandler(this.AddScout_Click);
            // 
            // FourPlayer
            // 
            this.FourPlayer.Cursor = System.Windows.Forms.Cursors.Default;
            this.FourPlayer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FourPlayer.FlatAppearance.BorderSize = 0;
            this.FourPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FourPlayer.Image = global::FirstSemesterExamProject.Properties.Resources.knap_4_players;
            this.FourPlayer.Location = new System.Drawing.Point(570, 515);
            this.FourPlayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FourPlayer.Name = "FourPlayer";
            this.FourPlayer.Size = new System.Drawing.Size(118, 44);
            this.FourPlayer.TabIndex = 14;
            this.myTooltip.SetToolTip(this.FourPlayer, "click to play 1 vs 1 vs 1 vs 1");
            this.FourPlayer.UseVisualStyleBackColor = true;
            this.FourPlayer.Click += new System.EventHandler(this.FourPlayer_Click);
            // 
            // ThreePlayer
            // 
            this.ThreePlayer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ThreePlayer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ThreePlayer.FlatAppearance.BorderSize = 0;
            this.ThreePlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ThreePlayer.Image = global::FirstSemesterExamProject.Properties.Resources.knap_3_players;
            this.ThreePlayer.Location = new System.Drawing.Point(570, 444);
            this.ThreePlayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ThreePlayer.Name = "ThreePlayer";
            this.ThreePlayer.Size = new System.Drawing.Size(118, 44);
            this.ThreePlayer.TabIndex = 13;
            this.myTooltip.SetToolTip(this.ThreePlayer, "click to play 1 vs 1 vs 1");
            this.ThreePlayer.UseVisualStyleBackColor = true;
            this.ThreePlayer.Click += new System.EventHandler(this.ThreePlayer_Click);
            // 
            // TwoPlayer
            // 
            this.TwoPlayer.Cursor = System.Windows.Forms.Cursors.Default;
            this.TwoPlayer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TwoPlayer.FlatAppearance.BorderSize = 0;
            this.TwoPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TwoPlayer.Image = global::FirstSemesterExamProject.Properties.Resources.knap_2_players;
            this.TwoPlayer.Location = new System.Drawing.Point(570, 372);
            this.TwoPlayer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TwoPlayer.Name = "TwoPlayer";
            this.TwoPlayer.Size = new System.Drawing.Size(118, 44);
            this.TwoPlayer.TabIndex = 12;
            this.myTooltip.SetToolTip(this.TwoPlayer, "Click to play 1 vs 1");
            this.TwoPlayer.UseVisualStyleBackColor = true;
            this.TwoPlayer.Click += new System.EventHandler(this.TwoPlayer_Click);
            // 
            // muteButton
            // 
            this.muteButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.muteButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.muteButton.FlatAppearance.BorderSize = 0;
            this.muteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.muteButton.Image = global::FirstSemesterExamProject.Properties.Resources.mute1;
            this.muteButton.Location = new System.Drawing.Point(1236, 617);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(27, 20);
            this.muteButton.TabIndex = 37;
            this.muteButton.TabStop = false;
            this.muteButton.UseVisualStyleBackColor = false;
            this.muteButton.Click += new System.EventHandler(this.MuteButton_Click);
            // 
            // Online
            // 
            this.Online.Location = new System.Drawing.Point(587, 566);
            this.Online.Name = "Online";
            this.Online.Size = new System.Drawing.Size(75, 23);
            this.Online.TabIndex = 38;
            this.Online.Text = "Online";
            this.Online.UseVisualStyleBackColor = true;
            this.Online.Click += new System.EventHandler(this.Online_Click);
            // 
            // Host
            // 
            this.Host.Location = new System.Drawing.Point(587, 422);
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(75, 23);
            this.Host.TabIndex = 39;
            this.Host.Text = "Host";
            this.Host.UseVisualStyleBackColor = true;
            this.Host.Visible = false;
            this.Host.Click += new System.EventHandler(this.Host_Click);
            // 
            // JoinGame
            // 
            this.JoinGame.Location = new System.Drawing.Point(748, 596);
            this.JoinGame.Name = "JoinGame";
            this.JoinGame.Size = new System.Drawing.Size(75, 23);
            this.JoinGame.TabIndex = 40;
            this.JoinGame.Text = "Join Game";
            this.JoinGame.UseVisualStyleBackColor = true;
            this.JoinGame.Visible = false;
            this.JoinGame.Click += new System.EventHandler(this.JoinGame_Click);
            // 
            // EnterIP
            // 
            this.EnterIP.Location = new System.Drawing.Point(522, 598);
            this.EnterIP.Name = "EnterIP";
            this.EnterIP.Size = new System.Drawing.Size(220, 19);
            this.EnterIP.TabIndex = 41;
            this.EnterIP.Visible = false;
            this.EnterIP.TextChanged += new System.EventHandler(this.EnterIP_TextChanged);
            // 
            // HostIPAdress
            // 
            this.HostIPAdress.AutoSize = true;
            this.HostIPAdress.Location = new System.Drawing.Point(605, 601);
            this.HostIPAdress.Name = "HostIPAdress";
            this.HostIPAdress.Size = new System.Drawing.Size(37, 13);
            this.HostIPAdress.TabIndex = 42;
            this.HostIPAdress.Text = "00000";
            this.HostIPAdress.Visible = false;
            this.HostIPAdress.Click += new System.EventHandler(this.HostIPAdress_Click);
            // 
            // StartOnlineGame
            // 
            this.StartOnlineGame.Location = new System.Drawing.Point(1070, 560);
            this.StartOnlineGame.Name = "StartOnlineGame";
            this.StartOnlineGame.Size = new System.Drawing.Size(167, 57);
            this.StartOnlineGame.TabIndex = 45;
            this.StartOnlineGame.Text = "Start";
            this.StartOnlineGame.UseVisualStyleBackColor = true;
            this.StartOnlineGame.Visible = false;
            this.StartOnlineGame.Click += new System.EventHandler(this.StartOnlineGame_Click);
            // 
            // ReadyCheck
            // 
            this.ReadyCheck.Location = new System.Drawing.Point(1070, 491);
            this.ReadyCheck.Name = "ReadyCheck";
            this.ReadyCheck.Size = new System.Drawing.Size(167, 57);
            this.ReadyCheck.TabIndex = 46;
            this.ReadyCheck.Text = "Ready";
            this.ReadyCheck.UseVisualStyleBackColor = true;
            this.ReadyCheck.Visible = false;
            this.ReadyCheck.Click += new System.EventHandler(this.ReadyCheck_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 639);
            this.Controls.Add(this.ReadyCheck);
            this.Controls.Add(this.StartOnlineGame);
            this.Controls.Add(this.HostIPAdress);
            this.Controls.Add(this.EnterIP);
            this.Controls.Add(this.JoinGame);
            this.Controls.Add(this.Host);
            this.Controls.Add(this.Online);
            this.Controls.Add(this.muteButton);
            this.Controls.Add(this.AddArtifact);
            this.Controls.Add(this.AddScout);
            this.Controls.Add(this.AddCleric);
            this.Controls.Add(this.AddMage);
            this.Controls.Add(this.PointsLabel);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.YellowTeam);
            this.Controls.Add(this.BlueTeam);
            this.Controls.Add(this.GreenTeam);
            this.Controls.Add(this.RedTeam);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.RemoveUnit);
            this.Controls.Add(this.AddKnight);
            this.Controls.Add(this.AddArcher);
            this.Controls.Add(this.ListBox1);
            this.Controls.Add(this.FourPlayer);
            this.Controls.Add(this.ThreePlayer);
            this.Controls.Add(this.TwoPlayer);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.EndTurn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Window";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fps:";
            this.Load += new System.EventHandler(this.Window_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Window_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Tick;
        private System.Windows.Forms.Button EndTurn;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button TwoPlayer;
        private System.Windows.Forms.Button ThreePlayer;
        private System.Windows.Forms.Button FourPlayer;
        private System.Windows.Forms.ListBox ListBox1;
        private System.Windows.Forms.Button AddArcher;
        private System.Windows.Forms.Button AddKnight;
        private System.Windows.Forms.Button RemoveUnit;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button YellowTeam;
        private System.Windows.Forms.Button BlueTeam;
        private System.Windows.Forms.Button GreenTeam;
        private System.Windows.Forms.Button RedTeam;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label PointsLabel;
        private System.Windows.Forms.Button AddMage;
        private System.Windows.Forms.Button AddCleric;
        private System.Windows.Forms.Button AddScout;
        private System.Windows.Forms.Button AddArtifact;
        private System.Windows.Forms.ToolTip myTooltip;
        private System.Windows.Forms.Button muteButton;
        private System.Windows.Forms.Button Online;
        private System.Windows.Forms.Button Host;
        private System.Windows.Forms.Button JoinGame;
        private System.Windows.Forms.TextBox EnterIP;
        private System.Windows.Forms.Label HostIPAdress;
        private System.Windows.Forms.Button StartOnlineGame;
        private System.Windows.Forms.Button ReadyCheck;
    }
}