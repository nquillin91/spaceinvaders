using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Nodes
{
    class Image : DLink
    {
        public Name name;
        public Texture pTexture;
        public Azul.Rect poRect = new Azul.Rect();

        public enum Name
        {
            RedBird,
            WhiteBird,
            GreenBird,
            YellowBird,
            Alien1,
            Alien2,
            Alien3,
            Alien4,
            Alien5,
            Stitch,
            Uninitialized
        }

        public Image(Name name) : base()
        {
            this.name = name;
        }

        public void Set(Name name, Texture pTexture, float x, float y, float width, float height)
        {
            this.name = name;

            Debug.Assert(pTexture != null);
            this.pTexture = pTexture;

            Debug.Assert(poRect != null);
            this.poRect.Set(x, y, width, height);
        }

        public override void Wash()
        {
            base.Wash();

            this.name = Name.Uninitialized;
            this.poRect.Clear();
            this.pTexture = null;
        }

        public override void DumpNode()
        {
            System.Diagnostics.Debug.WriteLine("Name: " + this.name +
                ", Texture:" + (this.pTexture == null ? "Null" : this.pTexture.name.ToString()) +
                ", Rect: " + (this.poRect == null ? "Null" : this.poRect.ToString()));
        }
    }
}
