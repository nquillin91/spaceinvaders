using SpaceInvaders.Sprites;
using System;
using System.Diagnostics;

namespace SpaceInvaders.Fonts
{
    public class Font : DLink
    {
        public Name name;
        public FontSprite pFontSprite = new FontSprite();
        static private String pNullString = "null";

        public enum Name
        {
            Play,
            Space,
            Invaders,

            Player1ScoreTitle,
            Player1ScoreValue,
            HighScore,
            HighScoreValue,
            Player2ScoreTitle,
            Player2ScoreValue,

            PlayerLives,

            UFOPoints,
            SquidPoints,
            CrabPoints,
            OctopusPoints,

            NullObject,
            Uninitialized
        };

        public Font() : base()
        {
            this.name = Name.Uninitialized;
            this.pFontSprite = new FontSprite();
        }

        ~Font()
        {

        }

        public void UpdateMessage(String pMessage)
        {
            Debug.Assert(pMessage != null);
            Debug.Assert(this.pFontSprite != null);
            this.pFontSprite.UpdateMessage(pMessage);
        }

        public void Set(Font.Name name, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            Debug.Assert(pMessage != null);

            this.name = name;
            this.pFontSprite.Set(name, pMessage, glyphName, xStart, yStart);
        }

        public void SetColor(float red, float green, float blue)
        {
            this.pFontSprite.SetColor(red, green, blue);
        }

        public override void Wash()
        {
            base.Wash();

            this.name = Name.Uninitialized;
            this.pFontSprite.Set(Font.Name.NullObject, pNullString, Glyph.Name.NullObject, 0.0f,0.0f);
        }

        public override void Dump()
        {
        }
    }
}
