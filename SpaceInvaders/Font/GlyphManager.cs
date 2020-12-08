using System;
using System.Xml;
using System.Diagnostics;
using SpaceInvaders.Textures;

namespace SpaceInvaders.Fonts
{
    class GlyphManager : Manager
    {
        private static GlyphManager pInstance = null;
        private readonly Glyph poCompareNode;

        private GlyphManager(int reserveSize, int growthSize) : base(reserveSize, growthSize)
        {
            this.poCompareNode = (Glyph)this.CreateNode();
        }

        ~GlyphManager()
        {

        }

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            if (pInstance == null)
            {
                pInstance = new GlyphManager(reserveNum, reserveGrow);
            }
        }

        public static void Destroy()
        {

        }

        private static GlyphManager GetInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        public static Glyph Add(Glyph.Name name, int key, Texture.Name textName, float x, float y, float width, float height)
        {
            GlyphManager pMan = GlyphManager.GetInstance();

            Glyph pNode = (Glyph)pMan.BaseAddNode();
            Debug.Assert(pNode != null);

            pNode.Set(name, key, textName, x, y, width, height);
            return pNode;
        }

        public static void AddXml(Glyph.Name glyphName, String assetName, Texture.Name textName)
        {
            System.Xml.XmlTextReader reader = new XmlTextReader(assetName);

            int key = -1;
            int x = -1;
            int y = -1;
            int width = -1;
            int height = -1;

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.GetAttribute("key") != null)
                        {
                            key = Convert.ToInt32(reader.GetAttribute("key"));
                        }
                        else if (reader.Name == "x")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    x = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "y")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    y = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "width")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    width = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "height")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    height = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        break;

                    case XmlNodeType.EndElement:
                        if (reader.Name == "character")
                        {
                            // have all the data... so now create a glyph
                            //  Debug.WriteLine("key:{0} x:{1} y:{2} w:{3} h:{4}", key, x, y, width, height);
                            GlyphManager.Add(glyphName, key, textName, x, y, width, height);
                        }
                        break;
                }
            }
        }

        public static void Remove(Glyph pNode)
        {
            Debug.Assert(pNode != null);
            GlyphManager pMan = GlyphManager.GetInstance();
            pMan.BaseRemove(pNode);
        }

        public static Glyph Find(Glyph.Name name, int key)
        {
            GlyphManager pMan = GlyphManager.GetInstance();

            // Compare functions only compares two Nodes
            pMan.poCompareNode.name = name;
            pMan.poCompareNode.key = key;

            Glyph pData = (Glyph)pMan.BaseFind(pMan.poCompareNode);
            return pData;
        }

        protected override DLink CreateNode()
        {
            DLink pNode = new Glyph();
            Debug.Assert(pNode != null);

            return pNode;
        }

        protected override Boolean CompareNodes(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            Glyph pDataA = (Glyph)pLinkA;
            Glyph pDataB = (Glyph)pLinkB;

            Boolean status = false;

            if (pDataA.name == pDataB.name && pDataA.key == pDataB.key)
            {
                status = true;
            }

            return status;
        }
    }
}
