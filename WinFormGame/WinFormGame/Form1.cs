using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormGame
{
    public partial class Form1 : Form
    {
        private int dirX, dirY;
        private PictureBox fruit;
        private int _width =700;
        private int _height =700;
        private int f1, f2;
        private int sideOfSize = 40;
        private int score=0;
        public Form1()
        {
            InitializeComponent();
            this.Height = _height;
            this.Width = _width;
            fruit = new PictureBox();
            fruit.BackColor = Color.Yellow;
            fruit.Size = new Size(sideOfSize, sideOfSize);
            timer1.Tick += new EventHandler(update);
            timer1.Interval = 250;
            timer1.Start();
            generateMap();
            GenerateFruit();
            this.KeyDown += new KeyEventHandler(OKP);
            pctB.Size = new Size(sideOfSize, sideOfSize);
            label1.Width = this.Width;
        }
        private void generateMap()
        {
            for (int i = 0; i <_width/sideOfSize; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0, sideOfSize * i);
                pic.Size = new Size(_width - 100,1);
                this.Controls.Add(pic);
                pic.Visible = false;
            }
            for (int i = 0; i <= _height / sideOfSize; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point( sideOfSize * i,0);
                pic.Size = new Size(1,_width - 100);
                this.Controls.Add(pic);
                pic.Visible = false;
            }
        }
        private void GenerateFruit()
        {
            Random r = new Random();
            f1 = r.Next(0, _height-sideOfSize);
            int temp = f1 % sideOfSize;
            f1 -= temp;
            f2 = r.Next(0, _height- sideOfSize);
            int tmp2 = f2 % sideOfSize;
            f2 -= tmp2;
           
            fruit.Location = new Point(f1, f2);
            
            this.Controls.Add(fruit);

        } 
        private void chackBorders()
        {
            if (pctB.Location.X <0 )
            {
                dirX = 1;
            }
            else if (pctB.Location.X > _height-90)
            {
                dirX = -1;
            }
            if (pctB.Location.Y < label1.Height)
            {
                dirY = 1;
            }
            else if (pctB.Location.Y > _height-100)
            {
                dirY = -1;
            }
            
        }
        private void catchFruit()
        {
            if (pctB.Location.X == f1 && pctB.Location.Y == f2)
            {
                label1.Text = "Score:"+ ++score;
                GenerateFruit();
            } 
        }

        

        private void update(object sender,EventArgs e)
        {
            chackBorders();
            catchFruit();
            pctB.Location = new Point(pctB.Location.X + dirX * sideOfSize, pctB.Location.Y + dirY * sideOfSize);
        }
        private void OKP(object sender,KeyEventArgs e)
        {
            
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    dirX = 1;
                    dirY = 0;
                    break;
                case "Left":
                    dirX = -1;
                    dirY = 0;
                    break;
                case "Up":
                    dirY = -1;
                    dirX = 0;
                    break;
                case "Down":
                    dirY = 1;
                    dirX = 0;
                    break;
            }
        }
        
    }
}
