using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectNode : DLink
    {
        public GameObject pGameObj;

        public GameObjectNode()
            : base()
        {
            this.pGameObj = null;
        }

        ~GameObjectNode()
        {

        }

        public void Set(GameObject pGameObject)
        {
            Debug.Assert(pGameObject != null);
            this.pGameObj = pGameObject;
        }

        public override void Wash()
        {
            base.Wash();
            this.pGameObj = null;
        }

        public Enum GetName()
        {
            return this.pGameObj.name;
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}
