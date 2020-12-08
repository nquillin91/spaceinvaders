using SpaceInvaders.Batches;
using SpaceInvaders.Collision;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Sound;
using SpaceInvaders.Sprites;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

class BombMissileCollision : ColObserver
{
    public override void Notify()
    {
        this.Execute();
    }

    public override void Execute()
    {
        Missile pMissile = (Missile)this.pSubject.pObjA;
        pMissile.delta = 0.0f;

        ProxySprite pDeadMissileProxy = ProxySpriteManager.Add(GameSprite.Name.DeadMissile);
        SpriteBatch pExplosionBatch = SpriteBatchManager.Find(SpriteBatch.Name.Explosions);
        pDeadMissileProxy.x = pMissile.x;
        pDeadMissileProxy.y = pMissile.y;
        pExplosionBatch.Attach(pDeadMissileProxy);

        TimerManager.Add(TimerEvent.Name.MissileReset, new RemoveProxySprite(pDeadMissileProxy), 0.25f);

        AudioSource pSound = SoundManager.Find(AudioSource.Name.MissileExplosion);
        Debug.Assert(pSound != null);
        pSound.Play();

        this.pSubject.pObjA.Remove();
        this.pSubject.pObjB.Remove();
    }

    public override void Dump()
    {
        throw new NotImplementedException();
    }
}