using SpaceInvaders.Batches;
using SpaceInvaders.Fonts;
using SpaceInvaders.GameObjects;
using SpaceInvaders.Player;
using SpaceInvaders.Scenes;
using SpaceInvaders.Sprites;
using SpaceInvaders.Textures;
using SpaceInvaders.Timer;
using System;
using System.Diagnostics;

namespace SpaceInvaders.HUD
{
    class HUDManager
    {
        private static int playerLives = 3;
        private static int player1Score = 0;
        private static int player2Score = 0;
        private static int highScore = 0;

        private static Font pPlayer1ScoreText;
        private static Font pPlayer2ScoreText;
        private static Font pHighScoreText;

        private static Font pLives;
        private static ProxySprite pPlayerSecondLife;
        private static ProxySprite pPlayerFirstLife;

        public static void Setup()
        {
            TextureManager.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphManager.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            Font pPlayer1ScoreTitle = FontManager.Add(Font.Name.Player1ScoreTitle, SpriteBatch.Name.HUD, "SCORE < 1 >", Glyph.Name.Consolas36pt, 50, 725);
            pPlayer1ScoreTitle.SetColor(1.0f, 1.0f, 1.0f);

            pPlayer1ScoreText = FontManager.Add(Font.Name.Player1ScoreValue, SpriteBatch.Name.HUD, HUDManager.PadScore(HUDManager.player1Score), Glyph.Name.Consolas36pt, 100, 675);
            pPlayer1ScoreText.SetColor(1.0f, 1.0f, 1.0f);

            Font pHighScoreTitle = FontManager.Add(Font.Name.HighScore, SpriteBatch.Name.HUD, "HI-SCORE", Glyph.Name.Consolas36pt, 550, 725);
            pHighScoreTitle.SetColor(1.0f, 1.0f, 1.0f);

            pHighScoreText = FontManager.Add(Font.Name.HighScoreValue, SpriteBatch.Name.HUD, HUDManager.PadScore(HUDManager.highScore), Glyph.Name.Consolas36pt, 580, 675);
            pHighScoreText.SetColor(1.0f, 1.0f, 1.0f);

            Font pPlayer2ScoreTitle = FontManager.Add(Font.Name.Player2ScoreTitle, SpriteBatch.Name.HUD, "SCORE < 2 >", Glyph.Name.Consolas36pt, 940, 725);
            pPlayer2ScoreTitle.SetColor(1.0f, 1.0f, 1.0f);

            pPlayer2ScoreText = FontManager.Add(Font.Name.Player2ScoreValue, SpriteBatch.Name.HUD, HUDManager.PadScore(HUDManager.player2Score), Glyph.Name.Consolas36pt, 990, 675);
            pPlayer2ScoreText.SetColor(1.0f, 1.0f, 1.0f);

            LoadUserInfo();
        }

        private static void LoadUserInfo()
        {
            pLives = FontManager.Add(Font.Name.PlayerLives, SpriteBatch.Name.HUD, HUDManager.playerLives.ToString(), Glyph.Name.Consolas36pt, 25, 25);
            pLives.SetColor(1.0f, 1.0f, 1.0f);

            SpriteBatch pSpriteBatch = SpriteBatchManager.Find(SpriteBatch.Name.HUD);

            pPlayerSecondLife = ProxySpriteManager.Add(GameSprite.Name.Player);
            pPlayerSecondLife.x = 75;
            pPlayerSecondLife.y = 25;

            pPlayerFirstLife = ProxySpriteManager.Add(GameSprite.Name.Player);
            pPlayerFirstLife.x = 125;
            pPlayerFirstLife.y = 25;

            pSpriteBatch.Attach(pPlayerSecondLife);
            pSpriteBatch.Attach(pPlayerFirstLife);
        }

        public static void RemovePlayerLife()
        {
            switch(playerLives)
            {
                case 1:
                    playerLives = 3;
                    UpdateHighScore();
                    TimerManager.Add(TimerEvent.Name.PlayerExplosion2, new GameOverCommand(), 0.25f);
                    break;
                case 2:
                    RemovePlayerLifeSprite(pPlayerSecondLife);
                    TimerManager.Add(TimerEvent.Name.PlayerReset, new ResetPlayerCommand(), 1.0f);
                    break;
                case 3:
                    RemovePlayerLifeSprite(pPlayerFirstLife);
                    TimerManager.Add(TimerEvent.Name.PlayerReset, new ResetPlayerCommand(), 1.0f);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        private static void RemovePlayerLifeSprite(ProxySprite pPlayerLifeSprite)
        {
            SpriteNode pSpriteNode = pPlayerLifeSprite.GetSpriteNode();

            Debug.Assert(pSpriteNode != null);

            SpriteBatchManager.Remove(pSpriteNode);

            playerLives--;
            pLives.UpdateMessage(playerLives.ToString());
        }

        public static void UpdateScore(int newScoreValue)
        {
            if (PlayerManager.GetPlayerNumber() == PlayerManager.PlayerNumber.Player1)
            {
                HUDManager.player1Score += newScoreValue;
                String newScore = HUDManager.PadScore(HUDManager.player1Score);

                HUDManager.pPlayer1ScoreText.UpdateMessage(newScore);
            } else
            {
                HUDManager.player2Score += newScoreValue;
                String newScore = HUDManager.PadScore(HUDManager.player2Score);

                HUDManager.pPlayer2ScoreText.UpdateMessage(newScore);
            }
        }

        public static void UpdateHighScore()
        {
            if (PlayerManager.GetPlayerNumber() == PlayerManager.PlayerNumber.Player1)
            {
                if (HUDManager.player1Score > HUDManager.highScore)
                {
                    HUDManager.highScore = HUDManager.player1Score;
                    String newScore = HUDManager.PadScore(HUDManager.highScore);

                    HUDManager.pHighScoreText.UpdateMessage(newScore);
                }

                HUDManager.player1Score = 0;
                String zeroedOut = HUDManager.PadScore(HUDManager.player1Score);

                HUDManager.pPlayer1ScoreText.UpdateMessage(zeroedOut);
            }
            else
            {
                if (HUDManager.player2Score > HUDManager.highScore)
                {
                    HUDManager.highScore = HUDManager.player2Score;
                    String newScore = HUDManager.PadScore(HUDManager.highScore);

                    HUDManager.pHighScoreText.UpdateMessage(newScore);
                }

                HUDManager.player2Score = 0;
                String zeroedOut = HUDManager.PadScore(HUDManager.player2Score);

                HUDManager.pPlayer2ScoreText.UpdateMessage(zeroedOut);
            }
        }

        private static String PadScore(int score)
        {
            String stringifiedScore = score.ToString();
            String temp = "";

            for (int i = 0; i < (4 - stringifiedScore.Length); i++)
            {
                temp += "0";
            }

            stringifiedScore = temp + stringifiedScore;

            return stringifiedScore;
        }
    }
}