using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FirstSemesterExamProject
{
    public enum PlayerTeam { RedTeam, BlueTeam, GreenTeam, YellowTeam }
    public enum Units { Archer, Artifact, Cleric, Knight, Mage, Scout }

    static class Constant
    {
        //MapPaths to make map out of.
        #region Maps
        //addMap
        // 2 player Maps
        public static string map1 = @"Maps/Map1.txt";
        public static string map2 = @"Maps/Map2.txt";
        public static string map3 = @"Maps/Map3.txt";
        // 4 player Maps
        public static string p4Map1 = @"Maps/P4Map1.txt";
        public static string p4Map2 = @"Maps/P4Map2.txt";
        public static string p4Map3 = @"Maps/P4Map3.txt";
        public static string p4Map4 = @"Maps/P4Map4.txt";
        #region MapNumber
        //addMap
        public static int numberPlayerMaps2 = 3;
        public static int lessPlayerThan4 = numberPlayerMaps2;
        public static int numberPlayerMaps4 = 4;
        #endregion
        #endregion

        //Unit Numbers For Easy Balancing
        #region Unit
        //sound for moving a unit
        public static string playerMoveUnit = "PlayerMoveUnit.wav";
        //how many point a player can buy units for
        public static int unitBuyPoints = 1400;
        #region Archer
        public static int archerRange = 3;
        public static string archerName = "Archer";
        public static int archerHealth = 85;
        public static int archerArmor = 4;
        public static int archerMove = 3;
        public static int archerDamage = 28;
        public static int archerUnitCost = 150;
        public static string archerSound = "Archer_sound.wav";
        public static string archerSoundArmor = "Archer_sound_armor.wav";

        public static string archerImagePath = @"Sprites/Units/Archer/archer1.png;Sprites/Units/Archer/archer2.png";
        #endregion

        #region Knight
        public static int knightRange = 1;//melee
        public static string knightName = "Knight";
        public static int knightHealth = 120;
        public static int knightArmor = 10;
        public static int knightMove = 3;
        public static int knightDamage = 30;
        public static int knightUnitCost = 250;
        public static string knightSound = "Knight_sound.wav";
        public static string knightSoundArmor = "Knight_sound_armor.wav";

        public static string knightImagePath = @"Sprites/Units/Knight/knight1.png;Sprites/Units/Knight/knight2.png";
        #endregion

        #region Mage
        public static int mageRange = 3;
        public static string mageName = "Mage";
        public static int mageHealth = 105;
        public static int mageArmor = 0;
        public static int mageMove = 2;
        public static int mageDamage = 20;
        public static int mageUnitCost = 275;
        public static string mageSound = "Mage_sound.wav";
        public static string mageImagePath = @"Sprites/Units/Mage/mage1.png;Sprites/Units/Mage/mage2.png;Sprites/Units/Mage/mage3.png;Sprites/Units/Mage/mage2.png
                                              ;Sprites/Units/Mage/mage4.png;Sprites/Units/Mage/mage5.png;Sprites/Units/Mage/mage6.png;Sprites/Units/Mage/mage5.png";
        #endregion

        #region Cleric
        public static int clericRange = 1;//melee
        public static string clericName = "Cleric";
        public static int clericHealth = 80;
        public static int clericArmor = 5;
        public static int clericMove = 3;
        public static int clericDamage = 21;
        public static int clericUnitCost = 250;
        public static string clericSound = "Cleric_Heal.wav";

        public static string clericImagePath = @"Sprites/Units/Cleric/cleric.png;Sprites/Units/Cleric/cleric1.png";
        #endregion

        #region Artifact
        public static int artifactRange = 5;
        public static string artifactName = "Artifact";
        public static int artifactHealth = 60;
        public static int artifactArmor = 12;
        public static int artifactMove = 1;
        public static int artifactDamage = 30;
        public static int artifactUnitCost = 500;
        public static string artifactAttackSound = @"artifact_attack.wav";
        public static string artifactHealSound = @"artifact_heal.wav";
        public static string artifactImagePath = @"Sprites/Units/Artifact/artifact1.png;Sprites/Units/Artifact/artifact2.png;Sprites/Units/Artifact/artifact3.png;Sprites/Units/Artifact/artifact4.png;Sprites/Units/Artifact/artifact3.png;Sprites/Units/Artifact/artifact2.png";
        #endregion

        #region Scout
        public static int scoutRange = 1;
        public static string scoutName = "Scout";
        public static int scoutHealth = 75;
        public static int scoutArmor = 2;
        public static int scoutMove = 4;
        public static int scoutDamage = 20;
        public static int scoutBonusDamage = 20;
        public static int scoutUnitCost = 175;
        public static string scoutSound = "Scout_sound.wav";
        public static string scoutSoundArmor = "Scout_sound_armor.wav";

        public static string scoutImagePath = @"Sprites/Units/Scout/scout.png;Sprites/Units/Scout/scout1.png";
        #endregion

        #endregion

        //Tiles
        #region Tiles
        //Rock1
        public static string rock1 = @"Sprites/Tiles/Rock1.png";
        public static bool rock1Solid = false;
        //Rock2
        public static string rock2 = @"Sprites/Tiles/Rock2.png";
        public static bool rock2Solid = false;
        //Grass1
        public static string grass1 = @"Sprites/Tiles/Grass1.png";
        public static bool grass1Solid = false;
        //Grass2
        public static string grass2 = @"Sprites/Tiles/Grass2.png";
        public static bool grass2Solid = false;
        //GrassRoad1
        public static string grassRoad1 = @"Sprites/Tiles/GrassRoad1.png";
        public static bool grassRoad1Solid = false;
        //WaterEdge1
        public static string waterEdge1 = @"Sprites/Tiles/WaterEdge1.png";
        public static bool waterEdge1Solid = false;
        //Water1
        public static string water1 = @"Sprites/Tiles/Water1.png";
        public static bool water1Solid = true;
        //WaterCorner1
        public static string waterCorner1 = @"Sprites/Tiles/WaterCorner1.png";
        public static bool waterCorner1Solid = false;
        #region TileSize
        public static int tileSizeNormal = 64;
        public static int tileSizeSmall = 32;
        #endregion
        #endregion

        //player marksers & selected tiles
        #region Player
        public static float animationSpeed = 8f;
        public static int playerMove = 5;
        //Player Markers
        public static string playerRedImagePath = @"Sprites\PlayerMarkers\PlayerRed.png;Sprites\PlayerMarkers\PlayerRed1.png;Sprites\PlayerMarkers\PlayerRed2.png";
        public static string playerBlueImagePath = @"Sprites\PlayerMarkers\PlayerBlue.png;Sprites\PlayerMarkers\PlayerBlue1.png;Sprites\PlayerMarkers\PlayerBlue2.png";
        public static string playerGreenImagePath = @"Sprites\PlayerMarkers\PlayerGreen.png;Sprites\PlayerMarkers\PlayerGreen1.png;Sprites\PlayerMarkers\PlayerGreen2.png";
        public static string playerYellowImagePath = @"Sprites\PlayerMarkers\PlayerYellow.png;Sprites\PlayerMarkers\PlayerYellow1.png;Sprites\PlayerMarkers\PlayerYellow2.png";

        //Selected Tiles
        public static string selectedMarkerRed = @"Sprites\PlayerMarkers\PlayerRedSelect.png";
        public static string selectedMarkerBlue = @"Sprites\PlayerMarkers\PlayerBlueSelection.png";
        public static string selectedMarkerGreen = @"Sprites\PlayerMarkers\PlayerGreenSelection.png";
        public static string selectedMarkerYellow = @"Sprites\PlayerMarkers\PlayerYellowSelect.png";

        //Attacked Tiles
        public static string attackedMarkerRed = @"Sprites\PlayerMarkers\PlayerRedAttack.png;Sprites\PlayerMarkers\PlayerRedAttack1.png;Sprites\PlayerMarkers\PlayerRedAttack2.png";
        public static string attackedMarkerBlue = @"Sprites\PlayerMarkers\PlayerBlueAttack.png;Sprites\PlayerMarkers\PlayerBlueAttack1.png;Sprites\PlayerMarkers\PlayerBlueAttack2.png";
        public static string attackedMarkerGreen = @"Sprites\PlayerMarkers\PlayerGreenAttack.png;Sprites\PlayerMarkers\PlayerGreenAttack1.png;Sprites\PlayerMarkers\PlayerGreenAttack2.png";
        public static string attackedMarkerYellow = @"Sprites\PlayerMarkers\PlayerYellowAttack.png;Sprites\PlayerMarkers\PlayerYellowAttack1.png;Sprites\PlayerMarkers\PlayerYellowAttack2.png";
        #endregion

        //used for tweeking the ui.
        #region UI
        //Menu Screen
        public static string menuScreen = @"Sprites/MenuScreen/MenuScreen.png";
        //stats background
        public static string statBackground = @"Sprites/UI/UI.png";
        public static int statBackgroundX = 640;
        public static int statBackgroundY = 0;
        public static float unitUiX = 1125;
        public static float unitUiY = 190;
        public static float targetUnitUiX = 1125;
        public static float targetUnitUiY = 27;

        //gap between text
        public static int textGap = 20;
        //Text font that doesnt work
        public static string fontType = "Robeto";
        //non selected unit stats coordinates
        public static int markerStatsX = 650;
        public static int markerStatsY = 10;
        public static int markerFontSize = 22;
        //selected unit stats coordinates
        public static int selectedStatsX = 650;
        public static int selectedStatsY = 170;
        public static int selectedFontSize = 24;
        //how many moves the player has left
        public static int playerMovesLeftX = 650;
        public static int playerMovesLeftY = 568;
        public static int playerMovesFontSize = 32;
        //Victory Screen
        public static string victoryRed = @"Sprites/victoryimages/RedWin.png";
        public static string victoryBlue = @"Sprites/victoryimages/BlueWin.png";
        public static string victoryGreen = @"Sprites/victoryimages/GreenWin.png";
        public static string victoryYellow = @"Sprites/victoryimages/YellowWin.png";
        public static int victoryX = 162;
        public static int victoryY = 150;
        public static int victoryWait = (10);
        //Menu Sound for on click
        public static string menuAddUnitSound = "MenuAddUnitSound.wav";
        public static string menuBackSound = "MenuBackSound.wav";
        public static string menuButtonSound = "MenuButtonSound.wav";
        public static string endTurnSound = "EndTurn.wav";
        #endregion

    }
}
