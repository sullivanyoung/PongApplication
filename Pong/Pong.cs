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
            // this is the main timer event and will trigger every 20 milliseconds

            playerScore.Text = "" + userScore;
            cpuLabel.Text = "" + cpuScore;

            ball.Top -= bally; // assigns the ball TOP to all Y integer
            ball.Left -= ballx; // assigns the ball LEFT to ball X integer

            cpu.Top += speed; //assignment the CPU top speed integer

            if (cpuScore < 5)
            {
                //if the cpu has reached the top or bottom of the screen
                if (cpu.Top < 0 || cpu.Top > 455)
                {
                    //changes the speed direction to move it back up/down
                    speed = -speed;
                }
            }
            else
            {
                //if score isgreater than 5 make the game more difficult by allowing CPU to follow ball
                cpu.Top = ball.Top + 30;
            }

            //create cpu point and reset

            if (ball.Left < 0)
            {
                ball.Left = 434; //resets ball
                ballx = -ballx; //changes ball direction
                ballx -= 2; //increases speed
                cpuScore++;
            }

            //create user point and reset

            if(ball.Left + ball.Width > ClientSize.Width)
            {
                ball.Left = 434; //resets ball
                ballx = -ballx; //changes ball direction
                ballx += 2; //increases speed
                userScore++;
            }

            //ball movement
            //if ball reaches top or bottom of screen
            if(ball.Top < 0 || ball.Top + ball.Height > ClientSize.Height)
            {
                //reverse speed of ball to stay on screen
                bally = -bally;
            }

            if(ball.Bounds.IntersectsWith(player.Bounds) || ball.Bounds.IntersectsWith(cpu.Bounds))
            {
                ballx = -ballx;
            }

            //player movement
            //checking if boolean is true and heigh of boundary has not been reached
            if(goUp == true && player.Top > 0)
            {
                player.Top -= 8;
            }
            if(goDown == true && player.Top < 455)
            {
                player.Top += 8;
            }

            //final score / ending the game if the player scores more than 10 timer will stop and message box shown
            if(userScore > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("You Win!");
                Application.Exit();
            }
            if(cpuScore > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("CPU Wins!");
                Application.Exit();
            }
        }


    }
}
