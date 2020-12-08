using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Textures
{
    class TextureFactory
    {
        public void LoadTextures()
        {
            TextureManager.Add(Texture.Name.SpaceInvaders, "SpaceInvaders.tga");
            TextureManager.Add(Texture.Name.Shields, "Birds_N_Shield.tga");
        }
    }
}
