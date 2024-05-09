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

        }
        private void update(object sender, EventArgs e)
        {
          


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
