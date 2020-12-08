using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.Textures;

namespace SpaceInvaders.Images
{
    public class Image : DLink
    {
        private Name name;
        public Texture pTexture;
        public Azul.Rect poRect = new Azul.Rect();

        public enum Name
        {
            OctopusA,
            OctopusB,
            CrabA,
            CrabB,
            SquidA,
            SquidB,
            AlienExplosion,
            Saucer,
            SaucerExplosion,
            Player,
            PlayerExplosionA,
            PlayerExplosionB,
            AlienPullYA,
            AlienPullYB,
            AlienPullUpisdeDownYA,
            AlienPullUpsideDownYB,
            PlayerShot,
            PlayerShotExplosion,
            SquigglyShotA,
            SquigglyShotB,
            SquigglyShotC,
            SquigglyShotD,
            PlungerShotA,
            PlungerShotB,
            PlungerShotC,
            PlungerShotD,
            RollingShotA,
            RollingShotB,
            RollingShotC,
            RollingShotD,
            AlienShotExplosion,
            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V,
            W,
            X,
            Y,
            Z,
            Zero,
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            LessThan,
            GreaterThan,
            Space,
            Equals,
            Asterisk,
            Question,
            Hyphen,
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

        public void SetName(Image.Name name)
        {
            this.name = name;
        }

        public Image.Name GetName()
        {
            return this.name;
        }

        public override void Wash()
        {
            base.Wash();

            this.name = Name.Uninitialized;
            this.poRect.Clear();
            this.pTexture = null;
        }

        public override void Dump()
        {
            System.Diagnostics.Debug.WriteLine("Name: " + this.name +
                ", Texture:" + (this.pTexture == null ? "Null" : this.pTexture.GetName().ToString()) +
                ", Rect: " + (this.poRect == null ? "Null" : this.poRect.ToString()));
        }
    }
}
