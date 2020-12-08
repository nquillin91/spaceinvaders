using SpaceInvaders.Nodes;
using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageManager : Manager
    {
        private static ImageManager pImageManager;
        private readonly Image poCompareNode;

        private ImageManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poCompareNode = (Image)this.CreateNode();
        }

        public static void Create(int reserveSize = 3, int growthSize = 1)
        {
            if (pImageManager == null)
            {
                pImageManager = new ImageManager(reserveSize, growthSize);
            }
        }

        private static ImageManager GetInstance()
        {
            Debug.Assert(pImageManager != null);

            return pImageManager;
        }

        public static Image Add(Image.Name name, Texture.Name textureName, float x, float y, float width, float height)
        {
            ImageManager imageMan = ImageManager.GetInstance();
            Debug.Assert(imageMan != null);

            Texture pTexture = TextureManager.Find(textureName);
            Debug.Assert(pTexture != null);

            Image image = ImageManager.Find(name);

            // Preventing duplicate images
            if (image == null)
            {
                image = (Image)imageMan.BaseAddNode();

                Debug.Assert(image != null);

                image.Set(name, pTexture, x, y, width, height);
            }

            Debug.Assert(image != null);

            return image;
        }

        public static void Remove(Image image)
        {
            ImageManager imageMan = ImageManager.GetInstance();

            Debug.Assert(image != null);

            imageMan.BaseRemove(image);
        }

        public static Image Find(Image.Name name)
        {
            ImageManager imageMan = ImageManager.GetInstance();

            imageMan.poCompareNode.name = name;

            Image image = (Image)imageMan.BaseFind(imageMan.poCompareNode);

            return image;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Image imageA = (Image)pLinkA;
            Image imageB = (Image)pLinkB;

            if (imageA.name == imageB.name)
            {
                return true;
            }

            return false;
        }

        protected override DLink CreateNode()
        {
            Image image = new Image(Image.Name.Uninitialized);
            Debug.Assert(image != null);

            return image;
        }
    }
}
