using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMPLib;

namespace Revisi_Stegano_Audio.Lib
{
    class MediaPlayer
    {
        private WindowsMediaPlayer wmp;
        private bool paused;
        private double position;

        public MediaPlayer()
        {
            wmp = new WindowsMediaPlayer();
            wmp.controls.stop();
        }

        public void play(string path)
        {
            wmp.URL = @path;
            if (paused == false)
                wmp.controls.play();
            else
            {
                wmp.controls.currentPosition = position;
                wmp.controls.play();
            }
        }

        public void pause()
        {
            position = wmp.controls.currentPosition;
            wmp.controls.pause();
            paused = true;
        }

        public void stop()
        {
            position = 0;
            wmp.controls.stop();
        }
    }
}
