using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallThatCouldBeConsideredBouncing
{
    public partial class Form1 : Form
    {

        Timer mainTime = null;

        int horVel = 0;
        int verVel = 0;
        int ballStep = 1;
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            InitilizeApp();
        }

        private void InitilizeApp()
        {
            InitializeMainTimer();
            InitializeBouncerMovement();

            this.KeyDown += new KeyEventHandler(App_Keydown);
        }

        private void App_Keydown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Z)
            {
                mainTime.Interval += 10;
            }
            else if(e.KeyCode == Keys.X)
            {
                if(mainTime.Interval > 1)
                {
                    mainTime.Interval -= 10;
                }
            }
        }

        private void InitializeMainTimer()
        {
            mainTime = new Timer();
            mainTime.Interval = 1;
            mainTime.Tick += new EventHandler(MainTime_Tick);
            mainTime.Start();
        }

        private void InitializeBouncerMovement()
        {
            verVel = ballStep;
            horVel = ballStep;
        }

        private void MainTime_Tick(object sender, EventArgs e)
        {
            MoveBall();
            ChangeDirection();
        }

        private void MoveBall()
        {
            if (pboxBouncer.Top + verVel > ClientRectangle.Height - pboxBouncer.Height)
            {
                pboxBouncer.Top = ClientRectangle.Height - pboxBouncer.Height;
            }
            else if(pboxBouncer.Top + verVel < 0)
            {
                pboxBouncer.Top = 0;
            }
            else
            {
                pboxBouncer.Top += verVel;
            }
            if (pboxBouncer.Left + horVel > ClientRectangle.Width - pboxBouncer.Width)
            {
                pboxBouncer.Left = ClientRectangle.Width - pboxBouncer.Width;
            }
            else if (pboxBouncer.Left + horVel < 0)
            {
                pboxBouncer.Left = 0;
            }
            else
            {
                pboxBouncer.Left += horVel;
            }
        }

        private void ChangeDirection()
        {
            if(pboxBouncer.Top == ClientRectangle.Height - pboxBouncer.Height || pboxBouncer.Top == 0)
            {
                verVel = -verVel;
                pboxBouncer.BackColor = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            }
            if(pboxBouncer.Left == ClientRectangle.Width - pboxBouncer.Width || pboxBouncer.Left == 0)
            {
                horVel = -horVel;
                pboxBouncer.BackColor = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            }
        }
    }

}
