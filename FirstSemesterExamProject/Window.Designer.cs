using System;
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
            this.HighScoreBox = new System.Windows.Forms.RichTextBox();
            this.LobbyPlayerListImage = new System.Windows.Forms.PictureBox();
            this.RedTeamLobbyLabel = new System.Windows.Forms.Label();
            this.BlueTeamLobbyLabel = new System.Windows.Forms.Label();
            this.GreenTeamLobbyLabel = new System.Windows.Forms.Label();
            this.YellowTeamLobbyLabel = new System.Windows.Forms.Label();
            this.RedCheckMark = new System.Windows.Forms.PictureBox();
            this.BlueCheckMark = new System.Windows.Forms.PictureBox();
            this.GreenCheckMark = new System.Windows.Forms.PictureBox();
            this.YellowCheckMark = new System.Windows.Forms.PictureBox();
            this.TextBoxImage = new System.Windows.Forms.PictureBox();
            this.UnitListBoxImage = new System.Windows.Forms.PictureBox();
            this.PointsLabelImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LobbyPlayerListImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedCheckMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueCheckMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenCheckMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YellowCheckMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitListBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointsLabelImage)).BeginInit();
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
            this.ListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox1.ForeColor = System.Drawing.Color.Maroon;
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 24;
            this.ListBox1.Location = new System.Drawing.Point(544, 300);
            this.ListBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.ListBox1.Size = new System.Drawing.Size(149, 216);
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
            this.PointsLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.PointsLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.PointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointsLabel.ForeColor = System.Drawing.Color.Maroon;
            this.PointsLabel.Location = new System.Drawing.Point(540, 541);
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
            this.Online.FlatAppearance.BorderSize = 0;
            this.Online.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Online.Image = ((System.Drawing.Image)(resources.GetObject("Online.Image")));
            this.Online.Location = new System.Drawing.Point(570, 579);
            this.Online.Name = "Online";
            this.Online.Size = new System.Drawing.Size(118, 44);
            this.Online.TabIndex = 38;
            this.Online.TabStop = false;
            this.Online.UseVisualStyleBackColor = true;
            this.Online.Click += new System.EventHandler(this.Online_Click);
            // 
            // Host
            // 
            this.Host.FlatAppearance.BorderSize = 0;
            this.Host.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Host.Image = ((System.Drawing.Image)(resources.GetObject("Host.Image")));
            this.Host.Location = new System.Drawing.Point(550, 422);
            this.Host.Name = "Host";
            this.Host.Size = new System.Drawing.Size(159, 61);
            this.Host.TabIndex = 39;
            this.Host.TabStop = false;
            this.Host.UseVisualStyleBackColor = true;
            this.Host.Visible = false;
            this.Host.Click += new System.EventHandler(this.Host_Click);
            // 
            // JoinGame
            // 
            this.JoinGame.FlatAppearance.BorderSize = 0;
            this.JoinGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinGame.Image = ((System.Drawing.Image)(resources.GetObject("JoinGame.Image")));
            this.JoinGame.Location = new System.Drawing.Point(748, 585);
            this.JoinGame.Name = "JoinGame";
            this.JoinGame.Size = new System.Drawing.Size(118, 44);
            this.JoinGame.TabIndex = 40;
            this.JoinGame.TabStop = false;
            this.JoinGame.UseVisualStyleBackColor = true;
            this.JoinGame.Visible = false;
            this.JoinGame.Click += new System.EventHandler(this.JoinGame_Click);
            // 
            // EnterIP
            // 
            this.EnterIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.EnterIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EnterIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterIP.ForeColor = System.Drawing.Color.Maroon;
            this.EnterIP.Location = new System.Drawing.Point(542, 591);
            this.EnterIP.Name = "EnterIP";
            this.EnterIP.Size = new System.Drawing.Size(166, 24);
            this.EnterIP.TabIndex = 41;
            this.EnterIP.Visible = false;
            this.EnterIP.TextChanged += new System.EventHandler(this.EnterIP_TextChanged);
            // 
            // HostIPAdress
            // 
            this.HostIPAdress.AutoSize = true;
            this.HostIPAdress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.HostIPAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostIPAdress.ForeColor = System.Drawing.Color.Maroon;
            this.HostIPAdress.Location = new System.Drawing.Point(540, 590);
            this.HostIPAdress.Name = "HostIPAdress";
            this.HostIPAdress.Size = new System.Drawing.Size(72, 25);
            this.HostIPAdress.TabIndex = 42;
            this.HostIPAdress.Text = "00000";
            this.HostIPAdress.Visible = false;
            this.HostIPAdress.Click += new System.EventHandler(this.HostIPAdress_Click);
            // 
            // StartOnlineGame
            // 
            this.StartOnlineGame.FlatAppearance.BorderSize = 0;
            this.StartOnlineGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartOnlineGame.Image = ((System.Drawing.Image)(resources.GetObject("StartOnlineGame.Image")));
            this.StartOnlineGame.Location = new System.Drawing.Point(1070, 560);
            this.StartOnlineGame.Name = "StartOnlineGame";
            this.StartOnlineGame.Size = new System.Drawing.Size(167, 57);
            this.StartOnlineGame.TabIndex = 45;
            this.StartOnlineGame.TabStop = false;
            this.StartOnlineGame.UseVisualStyleBackColor = true;
            this.StartOnlineGame.Visible = false;
            this.StartOnlineGame.Click += new System.EventHandler(this.StartOnlineGame_Click);
            // 
            // ReadyCheck
            // 
            this.ReadyCheck.FlatAppearance.BorderSize = 0;
            this.ReadyCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReadyCheck.Image = ((System.Drawing.Image)(resources.GetObject("ReadyCheck.Image")));
            this.ReadyCheck.Location = new System.Drawing.Point(1070, 491);
            this.ReadyCheck.Name = "ReadyCheck";
            this.ReadyCheck.Size = new System.Drawing.Size(167, 57);
            this.ReadyCheck.TabIndex = 46;
            this.ReadyCheck.TabStop = false;
            this.ReadyCheck.UseVisualStyleBackColor = true;
            this.ReadyCheck.Visible = false;
            this.ReadyCheck.Click += new System.EventHandler(this.ReadyCheck_Click);
            // 
            // HighScoreBox
            // 
            this.HighScoreBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.HighScoreBox.DetectUrls = false;
            this.HighScoreBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighScoreBox.Location = new System.Drawing.Point(-1, 385);
            this.HighScoreBox.Name = "HighScoreBox";
            this.HighScoreBox.Size = new System.Drawing.Size(529, 252);
            this.HighScoreBox.TabIndex = 47;
            this.HighScoreBox.Text = "";
            // 
            // LobbyPlayerListImage
            // 
            this.LobbyPlayerListImage.Image = global::FirstSemesterExamProject.Properties.Resources.PlayerBox;
            this.LobbyPlayerListImage.Location = new System.Drawing.Point(1031, 2);
            this.LobbyPlayerListImage.Name = "LobbyPlayerListImage";
            this.LobbyPlayerListImage.Size = new System.Drawing.Size(232, 221);
            this.LobbyPlayerListImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LobbyPlayerListImage.TabIndex = 48;
            this.LobbyPlayerListImage.TabStop = false;
            this.LobbyPlayerListImage.Visible = false;
            // 
            // RedTeamLobbyLabel
            // 
            this.RedTeamLobbyLabel.AutoSize = true;
            this.RedTeamLobbyLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.RedTeamLobbyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RedTeamLobbyLabel.ForeColor = System.Drawing.Color.Black;
            this.RedTeamLobbyLabel.Location = new System.Drawing.Point(1049, 23);
            this.RedTeamLobbyLabel.Name = "RedTeamLobbyLabel";
            this.RedTeamLobbyLabel.Size = new System.Drawing.Size(112, 25);
            this.RedTeamLobbyLabel.TabIndex = 49;
            this.RedTeamLobbyLabel.Text = "RedTeam";
            this.RedTeamLobbyLabel.Visible = false;
            // 
            // BlueTeamLobbyLabel
            // 
            this.BlueTeamLobbyLabel.AutoSize = true;
            this.BlueTeamLobbyLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.BlueTeamLobbyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlueTeamLobbyLabel.ForeColor = System.Drawing.Color.Black;
            this.BlueTeamLobbyLabel.Location = new System.Drawing.Point(1049, 74);
            this.BlueTeamLobbyLabel.Name = "BlueTeamLobbyLabel";
            this.BlueTeamLobbyLabel.Size = new System.Drawing.Size(117, 25);
            this.BlueTeamLobbyLabel.TabIndex = 50;
            this.BlueTeamLobbyLabel.Text = "BlueTeam";
            this.BlueTeamLobbyLabel.Visible = false;
            // 
            // GreenTeamLobbyLabel
            // 
            this.GreenTeamLobbyLabel.AutoSize = true;
            this.GreenTeamLobbyLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.GreenTeamLobbyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GreenTeamLobbyLabel.ForeColor = System.Drawing.Color.Black;
            this.GreenTeamLobbyLabel.Location = new System.Drawing.Point(1049, 129);
            this.GreenTeamLobbyLabel.Name = "GreenTeamLobbyLabel";
            this.GreenTeamLobbyLabel.Size = new System.Drawing.Size(134, 25);
            this.GreenTeamLobbyLabel.TabIndex = 51;
            this.GreenTeamLobbyLabel.Text = "GreenTeam";
            this.GreenTeamLobbyLabel.Visible = false;
            // 
            // YellowTeamLobbyLabel
            // 
            this.YellowTeamLobbyLabel.AutoSize = true;
            this.YellowTeamLobbyLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.YellowTeamLobbyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YellowTeamLobbyLabel.ForeColor = System.Drawing.Color.Black;
            this.YellowTeamLobbyLabel.Location = new System.Drawing.Point(1049, 179);
            this.YellowTeamLobbyLabel.Name = "YellowTeamLobbyLabel";
            this.YellowTeamLobbyLabel.Size = new System.Drawing.Size(140, 25);
            this.YellowTeamLobbyLabel.TabIndex = 52;
            this.YellowTeamLobbyLabel.Text = "YellowTeam";
            this.YellowTeamLobbyLabel.Visible = false;
            // 
            // RedCheckMark
            // 
            this.RedCheckMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.RedCheckMark.Image = global::FirstSemesterExamProject.Properties.Resources.CheckMark;
            this.RedCheckMark.Location = new System.Drawing.Point(1207, 17);
            this.RedCheckMark.Name = "RedCheckMark";
            this.RedCheckMark.Size = new System.Drawing.Size(41, 35);
            this.RedCheckMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RedCheckMark.TabIndex = 53;
            this.RedCheckMark.TabStop = false;
            this.RedCheckMark.Visible = false;
            // 
            // BlueCheckMark
            // 
            this.BlueCheckMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.BlueCheckMark.Image = global::FirstSemesterExamProject.Properties.Resources.CheckMark;
            this.BlueCheckMark.Location = new System.Drawing.Point(1207, 69);
            this.BlueCheckMark.Name = "BlueCheckMark";
            this.BlueCheckMark.Size = new System.Drawing.Size(41, 35);
            this.BlueCheckMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BlueCheckMark.TabIndex = 54;
            this.BlueCheckMark.TabStop = false;
            this.BlueCheckMark.Visible = false;
            // 
            // GreenCheckMark
            // 
            this.GreenCheckMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.GreenCheckMark.Image = global::FirstSemesterExamProject.Properties.Resources.CheckMark;
            this.GreenCheckMark.Location = new System.Drawing.Point(1207, 123);
            this.GreenCheckMark.Name = "GreenCheckMark";
            this.GreenCheckMark.Size = new System.Drawing.Size(41, 35);
            this.GreenCheckMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GreenCheckMark.TabIndex = 55;
            this.GreenCheckMark.TabStop = false;
            this.GreenCheckMark.Visible = false;
            // 
            // YellowCheckMark
            // 
            this.YellowCheckMark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(122)))), ((int)(((byte)(87)))));
            this.YellowCheckMark.Image = global::FirstSemesterExamProject.Properties.Resources.CheckMark;
            this.YellowCheckMark.Location = new System.Drawing.Point(1207, 174);
            this.YellowCheckMark.Name = "YellowCheckMark";
            this.YellowCheckMark.Size = new System.Drawing.Size(41, 35);
            this.YellowCheckMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.YellowCheckMark.TabIndex = 56;
            this.YellowCheckMark.TabStop = false;
            this.YellowCheckMark.Visible = false;
            // 
            // TextBoxImage
            // 
            this.TextBoxImage.Image = global::FirstSemesterExamProject.Properties.Resources.TextBox;
            this.TextBoxImage.Location = new System.Drawing.Point(534, 579);
            this.TextBoxImage.Name = "TextBoxImage";
            this.TextBoxImage.Size = new System.Drawing.Size(186, 48);
            this.TextBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TextBoxImage.TabIndex = 57;
            this.TextBoxImage.TabStop = false;
            this.TextBoxImage.Visible = false;
            // 
            // UnitListBoxImage
            // 
            this.UnitListBoxImage.Image = global::FirstSemesterExamProject.Properties.Resources.unitsstackListboxImage;
            this.UnitListBoxImage.Location = new System.Drawing.Point(534, 291);
            this.UnitListBoxImage.Name = "UnitListBoxImage";
            this.UnitListBoxImage.Size = new System.Drawing.Size(186, 234);
            this.UnitListBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UnitListBoxImage.TabIndex = 58;
            this.UnitListBoxImage.TabStop = false;
            this.UnitListBoxImage.Visible = false;
            // 
            // PointsLabelImage
            // 
            this.PointsLabelImage.Image = global::FirstSemesterExamProject.Properties.Resources.TextBox;
            this.PointsLabelImage.Location = new System.Drawing.Point(534, 531);
            this.PointsLabelImage.Name = "PointsLabelImage";
            this.PointsLabelImage.Size = new System.Drawing.Size(186, 42);
            this.PointsLabelImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PointsLabelImage.TabIndex = 59;
            this.PointsLabelImage.TabStop = false;
            this.PointsLabelImage.Visible = false;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 639);
            this.Controls.Add(this.PointsLabelImage);
            this.Controls.Add(this.UnitListBoxImage);
            this.Controls.Add(this.TextBoxImage);
            this.Controls.Add(this.YellowCheckMark);
            this.Controls.Add(this.GreenCheckMark);
            this.Controls.Add(this.BlueCheckMark);
            this.Controls.Add(this.RedCheckMark);
            this.Controls.Add(this.YellowTeamLobbyLabel);
            this.Controls.Add(this.GreenTeamLobbyLabel);
            this.Controls.Add(this.BlueTeamLobbyLabel);
            this.Controls.Add(this.RedTeamLobbyLabel);
            this.Controls.Add(this.LobbyPlayerListImage);
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
            this.Controls.Add(this.HighScoreBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Window";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fps:";
            this.Load += new System.EventHandler(this.Window_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Window_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.LobbyPlayerListImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedCheckMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueCheckMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenCheckMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YellowCheckMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitListBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PointsLabelImage)).EndInit();
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
        private System.Windows.Forms.RichTextBox HighScoreBox;
        private System.Windows.Forms.PictureBox LobbyPlayerListImage;
        private System.Windows.Forms.Label RedTeamLobbyLabel;
        private System.Windows.Forms.Label BlueTeamLobbyLabel;
        private System.Windows.Forms.Label GreenTeamLobbyLabel;
        private System.Windows.Forms.Label YellowTeamLobbyLabel;
        private System.Windows.Forms.PictureBox RedCheckMark;
        private System.Windows.Forms.PictureBox BlueCheckMark;
        private System.Windows.Forms.PictureBox GreenCheckMark;
        private System.Windows.Forms.PictureBox YellowCheckMark;
        private System.Windows.Forms.PictureBox TextBoxImage;
        private System.Windows.Forms.PictureBox UnitListBoxImage;
        private System.Windows.Forms.PictureBox PointsLabelImage;
    }
}