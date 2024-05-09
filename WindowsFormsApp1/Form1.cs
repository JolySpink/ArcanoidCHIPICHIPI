using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const int mapWidth = 20;
        const int mapHeight = 30;

        public int[,] map = new int[mapHeight, mapWidth];
        public int dirX = 0;
        public int dirY = 0;
        public int platformX;
        public int platformY;
        public int ballX;
        public int ballY;
        public int score;

        public Image arcanoidSet;

        public Label scoreLabel;
        public Form1()
        {
            InitializeComponent();

            scoreLabel = new Label();
            scoreLabel.Location = new Point((mapWidth) * 20 + 1, 50);
            scoreLabel.Text = "Score: " + score;
            this.Controls.Add(scoreLabel);
            timer1.Tick += new EventHandler(update);
            this.KeyUp += new KeyEventHandler(inputCheck);
            Init();
        }
        public void AddLine()
        {
            for (int i = mapHeight - 2; i > 0; i--)
            {
                for (int j = 0; j < mapWidth; j += 2)
                {
                    map[i, j] = map[i - 1, j];
                }
            }
            Random r = new Random();
            for (int j = 0; j < mapWidth; j += 2)
            {
                int currPlatform = r.Next(1, 5);
                map[0, j] = currPlatform;
                map[0, j + 1] = currPlatform + currPlatform * 10;
            }
        }
        public void DrawArea(Graphics g)
        {
            g.DrawRectangle(Pens.Black, new Rectangle(0, 0, mapWidth * 20, mapHeight * 20));
        }
        public void GeneratePlatforms()
        {
            Random r = new Random();
            for (int i = 0; i < mapHeight / 3; i++)
            {
                for (int j = 0; j < mapWidth; j += 2)
                {
                    int currPlatform = r.Next(1, 5);
                    map[i, j] = currPlatform;
                    map[i, j + 1] = currPlatform + currPlatform * 10;
                }
            }
        }
        public void Init()
        {
            this.Width = (mapWidth + 5) * 20;
            this.Height = (mapHeight + 2) * 20;

            arcanoidSet = new Bitmap("C:\\Users\\rr033\\Desktop\\arcanoid.png");// вот здесь нужно поменть расположение и поставить что то другое и внести в проект чтобы не было зависимости от устройства
            timer1.Interval = 40;

            score = 0;

            scoreLabel.Text = "Score: " + score;

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    map[i, j] = 0;
                }
            }

            platformX = (mapWidth - 1) / 2;
            platformY = mapHeight - 1;

            map[platformY, platformX] = 9;
            map[platformY, platformX + 1] = 99;
            map[platformY, platformX + 2] = 999;

            ballY = platformY - 1;
            ballX = platformX + 1;

            map[ballY, ballX] = 8;

            dirX = 1;
            dirY = -1;

            GeneratePlatforms();

            timer1.Start();
        }
        private void update(object sender, EventArgs e)
        {
            if (ballY + dirY > mapHeight - 1)
            {
                Init();
            }


            map[ballY, ballX] = 0;
           
            map[ballY, ballX] = 8;

            map[platformY, platformX] = 9;
            map[platformY, platformX + 1] = 99;
            map[platformY, platformX + 2] = 999;

            Invalidate();
        }
        private void inputCheck(object sender, KeyEventArgs e)
        {
            map[platformY, platformX] = 0;
            map[platformY, platformX + 1] = 0;
            map[platformY, platformX + 2] = 0;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (platformX + 1 < mapWidth - 1)
                        platformX++;
                    break;
                case Keys.Left:
                    if (platformX > 0)
                        platformX--;
                    break;
            }
            map[platformY, platformX] = 9;
            map[platformY, platformX + 1] = 99;
            map[platformY, platformX + 2] = 999;
        }
    }
}
