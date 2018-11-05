using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrrKlang;
using System.Windows.Forms;

namespace FirstSemesterExamProject
{
    class SoundEngine
    {
        //uses our using IrrKlang; to refer to IrrKlang's sound engine preset. We set IrrKlang up under References
        static ISoundEngine engine = new ISoundEngine();


        public static void PlayBackgroundMusic()
        {
            // plays some background music. true sets it to loop
            var sound = engine.Play2D("media/ForestChaseLooping.wav", true, false, StreamMode.AutoDetect, true);
            //var sound = engine.Play2D("media/getout.ogg", true);
        }

        public static void PlayMenuBackgroundMusic()
        {
            // plays some background music. true sets it to loop
            var sound = engine.Play2D("media/RPGBattleClimax2_low.wav", true, false, StreamMode.AutoDetect, true);
        }

        /// <summary>
        /// Plays the chosen audio file from the media folder
        /// </summary>
        /// <param name="soundPath"></param>
        public static void PlaySound(string soundPath)
        {
            var sound = engine.Play2D(@"media\"+soundPath);
        }

        public static void StopSound()
        {
            engine.StopAllSounds();
        }
    }
}
