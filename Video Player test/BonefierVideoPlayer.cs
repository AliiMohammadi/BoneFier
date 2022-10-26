using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Player_test
{
    public partial class BonefierVideoPlayer : Form
    {
        public BonefierVideoPlayer()
        {
            InitializeComponent();
        }
        //TESTING code
        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            
        }

        private void BonefierVideoPlayer_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.URL = @"C:\Users\msi PC\Desktop\Cristiano_Ronaldo_yells_siuuu_1,048,576_times_em5rwYX8DVY.mp4";
            axWindowsMediaPlayer1.stretchToFit = true;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer1.PlayStateChange += AxWindowsMediaPlayer1_PlayStateChange; 
        }

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
                Application.Exit();
        }
    }
}
