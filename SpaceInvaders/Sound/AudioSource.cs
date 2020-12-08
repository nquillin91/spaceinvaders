using System;
using System.Diagnostics;

namespace SpaceInvaders.Sound
{
    class AudioSource : DLink
    {
        public Name name;
        private IrrKlang.ISound soundClip;
        private String fileName;
        private bool playLooped;

        public enum Name
        {
            Alien_1,
            Alien_2,
            Alien_3,
            Alien_4,
            DeathPlayer,
            DeathAlien,
            DeathUFO,
            UFOBeep,
            MissileShot,
            MissileExplosion,
            Uninitialized
        }

        public AudioSource() : base()
        {
            this.name = Name.Uninitialized;

            this.soundClip = null;
            this.fileName = null;
        }

        public void LoadAudio(Name name, string fileName, bool playLooped)
        {
            this.name = name;
            this.fileName = fileName;
            this.playLooped = playLooped;

            this.soundClip = SoundManager.GetSoundEngine().Play2D(this.fileName, playLooped, true);
        }

        public void Play()
        {
            Debug.Assert(this.soundClip != null);

            this.soundClip = SoundManager.GetSoundEngine().Play2D(this.fileName, this.playLooped, false);
        }

        public void Stop()
        {
            if (soundClip != null)
            {
                this.soundClip.Stop();
            }
        }

        public override void Wash()
        {
            base.Wash();
            this.Stop();

            this.name = Name.Uninitialized;

            this.soundClip = null;
            this.fileName = null;
            this.playLooped = false;
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }

        public override void Destroy()
        {
        }
    }
}