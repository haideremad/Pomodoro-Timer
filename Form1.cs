using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pomodoro__Project
{
    public partial class Form1 : Form
    {
        private int Minutes = 0;
        private int Seconds = 0;

        public Form1()
        {
            InitializeComponent();
        }

        enum enStatus {Focus = 0,Break = 1};

        enStatus Status = enStatus.Focus;

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            if (Seconds == 0)
            {
                if (Minutes == 0)
                {
                    timer1.Enabled = false;
                    if(Status == enStatus.Focus)
                    {
                        notifyIcon1.BalloonTipTitle = "انتهت جلسة التركيز";
                        notifyIcon1.BalloonTipText = "حان وقت أخذ استراحة قصيرة (5 دقائق)";
                        Status = enStatus.Break;
                        btnStart.Text = "Start Break";
                        label1.Text = "5 : 0";
                        btnStart.Enabled = true;
                    }

                    else
                    {
                        notifyIcon1.BalloonTipTitle = "انتهت جلسة الإستراحة";
                        notifyIcon1.BalloonTipText = "حان وقت التركيز (25 دقيقة)";
                        Status = enStatus.Focus;
                        btnStart.Text = "Start Focus";
                        label1.Text = "25 : 0";
                        btnStart.Enabled = true;
                    }

                    notifyIcon1.Icon = SystemIcons.Application;
                    notifyIcon1.Text = "Pomodoro Program";
                    notifyIcon1.ShowBalloonTip(1000);
                  
                    btnStart.Enabled = true; 
                }
                else
                {
                    Minutes--;
                    Seconds = 59;
                    label1.Text = Minutes.ToString() + " : " + Seconds.ToString();
                }
            }

            else
            {
                Seconds--;
                label1.Text = Minutes.ToString() + " : " + Seconds.ToString();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            if (Status == enStatus.Focus)
            {
                Minutes = 25;
                Seconds = 0;
            }

            else
            {
                Minutes = 5;
                Seconds = 0;
            }
            timer1.Enabled = true;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled == true)
                timer1.Enabled = false;
            else if (Minutes != 0 || Seconds != 0)
                timer1.Enabled = true;
        }


    }
}
