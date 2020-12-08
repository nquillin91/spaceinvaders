using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Images
{
    class ImageHolder : SLink
    {
        public Image pImage;

        public ImageHolder(Image image)
            : base()
        {
            this.pImage = image;
        }

        public override void Dump()
        {
            throw new NotImplementedException();
        }
    }
}
