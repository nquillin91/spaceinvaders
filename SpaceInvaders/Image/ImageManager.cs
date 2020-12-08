using SpaceInvaders.Textures;
using System.Diagnostics;

namespace SpaceInvaders.Images
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

            Image pImage = ImageManager.Add(Image.Name.NullObject, Texture.Name.NullObject, 0, 0, 128, 128);
            Debug.Assert(pImage != null);

            pImage = ImageManager.Add(Image.Name.Default, Texture.Name.Default, 0, 0, 128, 128);
            Debug.Assert(pImage != null);
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

            imageMan.poCompareNode.SetName(name);

            Image image = (Image)imageMan.BaseFind(imageMan.poCompareNode);

            return image;
        }

        protected override DLink CreateNode()
        {
            Image image = new Image(Image.Name.Uninitialized);
            Debug.Assert(image != null);

            return image;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Image imageA = (Image)pLinkA;
            Image imageB = (Image)pLinkB;

            if (imageA.GetName() == imageB.GetName())
            {
                return true;
            }

            return false;
        }

        public static void Destroy()
        {
            ImageManager imageMan = ImageManager.GetInstance();
            Debug.Assert(imageMan != null);
            imageMan.BaseDestroy();
        }
    }
}
