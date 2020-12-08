using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Sound
{
    class SoundManager : Manager
    {
        private static SoundManager pSoundManagerInstance;
        private readonly IrrKlang.ISoundEngine sndEngine;
        private readonly AudioSource poCompareNode;

        private SoundManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.sndEngine = new IrrKlang.ISoundEngine();

            this.poCompareNode = (AudioSource)this.CreateNode();
        }

        public static void Create(int reserveSize = 3, int growthSize = 1)
        {
            if (pSoundManagerInstance == null)
            {
                pSoundManagerInstance = new SoundManager(reserveSize, growthSize);
            }
        }

        public static SoundManager GetInstance()
        {
            Debug.Assert(pSoundManagerInstance != null);

            return pSoundManagerInstance;
        }

        public static IrrKlang.ISoundEngine GetSoundEngine()
        {
            SoundManager soundManager = SoundManager.GetInstance();

            return soundManager.sndEngine;
        }

        public static AudioSource Add(AudioSource.Name name, string fileName, bool playLooped = false)
        {
            SoundManager soundManager = SoundManager.GetInstance();

            AudioSource audioSource = (AudioSource)soundManager.BaseAddNode();
            audioSource.LoadAudio(name, fileName, playLooped);

            return audioSource;
        }

        public static void Remove(AudioSource audioSource)
        {
            Debug.Assert(audioSource != null);

            SoundManager soundManager = SoundManager.GetInstance();
            Debug.Assert(soundManager != null);

            soundManager.BaseRemove(audioSource);
        }

        public static AudioSource Find(AudioSource.Name name)
        {
            SoundManager soundManager = SoundManager.GetInstance();

            soundManager.poCompareNode.Wash();
            soundManager.poCompareNode.name = name;

            AudioSource audioSource = (AudioSource)soundManager.BaseFind(soundManager.poCompareNode);

            return audioSource;
        }

        protected override DLink CreateNode()
        {
            AudioSource audioSource = new AudioSource();
            Debug.Assert(audioSource != null);

            return audioSource;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            AudioSource audioSourceA = (AudioSource)pLinkA;
            AudioSource audioSourceB = (AudioSource)pLinkB;

            if (audioSourceA.name == audioSourceB.name)
            {
                return true;
            }

            return false;
        }

        public static void Destroy()
        {
            SoundManager soundManager = SoundManager.GetInstance();
            Debug.Assert(soundManager != null);

            soundManager.BaseDestroy();
        }
    }
}