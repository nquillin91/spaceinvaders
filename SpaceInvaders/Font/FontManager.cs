using System;
using System.Xml;
using System.Diagnostics;
using SpaceInvaders.Batches;
using SpaceInvaders.Textures;

namespace SpaceInvaders.Fonts
{
    class FontManager : Manager
    {
        private static FontManager pInstance = null;
        private readonly Font poCompareNode;

        private FontManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poCompareNode = (Font)this.CreateNode();
        }

        ~FontManager()
        {

        }

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            if (pInstance == null)
            {
                pInstance = new FontManager(reserveNum, reserveGrow);
            }
        }

        public static void Destroy()
        {
            FontManager fontManager = FontManager.GetInstance();
            Debug.Assert(fontManager != null);
            fontManager.BaseDestroy();
        }

        private static FontManager GetInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        public static Font Add(Font.Name name, SpriteBatch.Name SpriteBatch_Name, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            FontManager pMan = FontManager.GetInstance();

            Font pNode = (Font)pMan.BaseAddNode();
            Debug.Assert(pNode != null);

            pNode.Set(name, pMessage, glyphName, xStart, yStart);

            SpriteBatch pSpriteBatch = SpriteBatchManager.Find(SpriteBatch_Name);
            Debug.Assert(pSpriteBatch != null);
            Debug.Assert(pNode.pFontSprite != null);
            pSpriteBatch.Attach(pNode.pFontSprite);

            return pNode;
        }

        public static void AddXml(Glyph.Name glyphName, String assetName, Texture.Name textName)
        {
            GlyphManager.AddXml(glyphName, assetName, textName);
        }

        public static void Remove(Glyph pNode)
        {
            Debug.Assert(pNode != null);
            FontManager pMan = FontManager.GetInstance();

            pMan.BaseRemove(pNode);
        }

        public static Font Find(Font.Name name)
        {
            FontManager pMan = FontManager.GetInstance();

            // Compare functions only compares two Nodes
            pMan.poCompareNode.name = name;

            Font pData = (Font)pMan.BaseFind(pMan.poCompareNode);

            return pData;
        }

        protected override DLink CreateNode()
        {
            DLink pNode = new Font();
            Debug.Assert(pNode != null);
            return pNode;
        }

        protected override Boolean CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Font pDataA = (Font)pLinkA;
            Font pDataB = (Font)pLinkB;

            Boolean status = false;

            if (pDataA.name == pDataB.name )
            {
                status = true;
            }

            return status;
        }
    }
}
