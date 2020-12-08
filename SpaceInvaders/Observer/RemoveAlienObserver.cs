using SpaceInvaders.Aliens;
using SpaceInvaders.Collision;
using SpaceInvaders.Composites;
using SpaceInvaders.GameObjects;
using SpaceInvaders.HUD;
using SpaceInvaders.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Observers
{
    class RemoveAlienObserver : ColObserver
    {
        public static int aliensRemoved = 0;

        public override void Notify()
        {
            this.Execute();
        }

        public override void Execute()
        {
            this.pSubject.pObjB.GetColObject().poColRect.Set(0, 0, 0, 0);
            this.pSubject.pObjB.Update();

            GameObject pParent = (GameObject)this.pSubject.pObjB.pParent;
            pParent.Update();

            this.UpdateScore(this.pSubject.pObjB);

            this.pSubject.pObjB.Remove();

            if (pParent.GetName() == GameObject.Name.AlienColumn &&
                Iterator.GetChild(pParent) == null)
            {
                AlienManager.GetAlienGrid().Remove(pParent);

                if (Iterator.GetChild(AlienManager.GetAlienGrid()) == null)
                {
                    GameObjectNode pParentNode = GameObjectManager.Find(GameObject.Name.AlienGrid, pParent.instanceId);
                    pParentNode.poGameObj.Remove();
                    GameObjectManager.Remove(pParentNode);

                    SceneManager.MarkForTransition();
                }
            }
        }

        private void UpdateScore(GameObject pGameObj)
        {
            AlienCategory pAlien = (AlienCategory)pGameObj;
            HUDManager.UpdateScore(pAlien.GetPoints());

            aliensRemoved++;
            if (aliensRemoved > 4)
            {
                aliensRemoved = 0;
                AlienManager.UpdateSpeed();
            }
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}
