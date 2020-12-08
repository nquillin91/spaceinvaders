using System;
using System.Diagnostics;

namespace SpaceInvaders.Sound
{
	class AudioFactory
	{
		public void LoadAllAudio()
		{
			SoundManager.Add(AudioSource.Name.Alien_1, "fastinvader1.wav");
			SoundManager.Add(AudioSource.Name.Alien_2, "fastinvader2.wav");
			SoundManager.Add(AudioSource.Name.Alien_3, "fastinvader3.wav");
			SoundManager.Add(AudioSource.Name.Alien_4, "fastinvader4.wav");
			SoundManager.Add(AudioSource.Name.DeathPlayer, "explosion.wav");
			SoundManager.Add(AudioSource.Name.DeathAlien, "invaderKilled.wav");
			SoundManager.Add(AudioSource.Name.DeathUFO, "ufo_lowpitch.wav");
			SoundManager.Add(AudioSource.Name.UFOBeep, "ufo_highpitch.wav", true);
			SoundManager.Add(AudioSource.Name.MissileShot, "shoot.wav");
			SoundManager.Add(AudioSource.Name.MissileExplosion, "explosion.wav");
		}
	}
}