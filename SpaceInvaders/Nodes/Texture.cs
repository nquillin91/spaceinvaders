using System;
using System.Diagnostics;

namespace SpaceInvaders.Nodes
{
    class Texture : DLink
    {
        static private Azul.Texture psDefaultAzulTexture = new Azul.Texture("HotPink.tga");

        public Name name;
        public Azul.Texture poAzulTexture;

        public enum Name
        {
            Default,
            Aliens,
            Birds,
            Stitch,
            Uninitialized
        }

        public Texture() : base()
        {
            this.name = Name.Default;

            Debug.Assert(psDefaultAzulTexture != null);
            this.poAzulTexture = psDefaultAzulTexture;
        }

        public void Set(Name name, String poAzulTextureName)
        {
            this.name = name;

            Debug.Assert(poAzulTextureName != null);
            Debug.Assert(this.poAzulTexture != null);

            this.poAzulTexture = new Azul.Texture(poAzulTextureName, Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
            Debug.Assert(this.poAzulTexture != null);
        }

        public override void Wash()
        {
            base.Wash();

            this.name = Name.Uninitialized;
        }

        public override void DumpNode()
        {
            System.Diagnostics.Debug.WriteLine("Name: " + this.name + ", Texture:" + (this.poAzulTexture == null ? "Null" : "Texture Initialized"));
        }
    }
}
