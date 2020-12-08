using System;
using System.Diagnostics;

namespace SpaceInvaders.GameObjects
{
    class GameObjectNode : DLink
    {
        public GameObject poGameObj;

        public GameObjectNode()
            : base()
        {
            this.poGameObj = null;
        }

        ~GameObjectNode()
        {

        }

        public void Set(GameObject pGameObject)
        {
            Debug.Assert(pGameObject != null);
            this.poGameObj = pGameObject;
        }

        public override void Wash()
        {
            base.Wash();
            this.poGameObj = null;
        }

        public Enum GetName()
        {
            return this.poGameObj.name;
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}
