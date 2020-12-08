using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Pong : Form
    {
        bool goUp; // used to detect player up position
        bool goDown; // used to detect player down position
        int speed = 5; // integer called speed holding value of 5
        int ballx = 5; // horizontal X speed value for the ball object
        int bally = 5; // vertical Y speed value for ball object
        int userScore = 0; // score for player
        int cpuScore = 0; // score for computer

        public Pong()
        {
            InitializeComponent();
        }

        private void Pong_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                //if player presses up/down key changes boolean to true
                goUp = true;
            }
            if(e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
        }

        private void Pong_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                //if player leaves up/down key boolean changes to false
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {

        }
    }
}
