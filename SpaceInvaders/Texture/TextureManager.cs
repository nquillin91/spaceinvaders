﻿using System;
using System.Diagnostics;

namespace SpaceInvaders.Textures
{
    class TextureManager : Manager
    {
        private static TextureManager pTextureManager;
        private readonly Texture poCompareNode;

        private TextureManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poCompareNode = (Texture)this.CreateNode();
        }

        public static void Create(int reserveSize = 3, int growthSize = 1)
        {
            if (pTextureManager == null)
            {
                pTextureManager = new TextureManager(reserveSize, growthSize);
            }

            // NullObject texture
            Texture pTexture = TextureManager.Add(Texture.Name.NullObject, "HotPink.tga");
            Debug.Assert(pTexture != null);

            pTexture = TextureManager.Add(Texture.Name.Default, "HotPink.tga");
            Debug.Assert(pTexture != null);
        }

        private static TextureManager GetInstance()
        {
            Debug.Assert(pTextureManager != null);

            return pTextureManager;
        }

        public static Texture Add(Texture.Name name, String poAzulTextureName)
        {
            TextureManager textureMan = TextureManager.GetInstance();

            Texture texture = TextureManager.Find(name);

            // Preventing duplicates
            if (texture == null)
            {
                texture = (Texture)textureMan.BaseAddNode();

                texture.Set(name, poAzulTextureName);
            }

            Debug.Assert(texture != null);

            return texture;
        }

        public static void Remove(Texture texture)
        {
            Debug.Assert(texture != null);

            TextureManager textureMan = TextureManager.GetInstance();
            Debug.Assert(textureMan != null);

            textureMan.BaseRemove(texture);
        }

        public static Texture Find(Texture.Name name)
        {
            TextureManager textureMan = TextureManager.GetInstance();

            textureMan.poCompareNode.SetName(name);

            Texture texture = (Texture)textureMan.BaseFind(textureMan.poCompareNode);

            return texture;
        }

        protected override DLink CreateNode()
        {
            Texture node = new Texture();
            Debug.Assert(node != null);

            return node;
        }

        protected override bool CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Texture textureA = (Texture)pLinkA;
            Texture textureB = (Texture)pLinkB;

            if (textureA.GetName() == textureB.GetName())
            {
                return true;
            }

            return false;
        }

        public static void Destroy()
        {
            TextureManager textureMan = TextureManager.GetInstance();
            Debug.Assert(textureMan != null);
            textureMan.BaseDestroy();
        }
    }
}
