using System;
using System.Diagnostics;

namespace SpaceInvaders.Textures
{
    public class Texture : DLink
    {
        static private readonly Azul.Texture psDefaultAzulTexture = new Azul.Texture("HotPink.tga");

        private Name name;
        public Azul.Texture poAzulTexture;

        public enum Name
        {
            Default,
            SpaceInvaders,
            Shields,
            NullObject,
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
        public void SetName(Texture.Name name)
        {
            this.name = name;
        }

        public Texture.Name GetName()
        {
            return this.name;
        }

        public override void Wash()
        {
            base.Wash();

            this.name = Name.Uninitialized;
        }

        public override void Dump()
        {
            System.Diagnostics.Debug.WriteLine("Name: " + this.name + ", Texture:" + (this.poAzulTexture == null ? "Null" : "Texture Initialized"));
        }
    }
}
