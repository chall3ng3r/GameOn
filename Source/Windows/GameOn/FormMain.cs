using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOn
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public void initUnity(string url)
        {
            // HACK
            // save state from designer control with new src set
            this.axUnityWebPlayer1.src = url;
            System.Windows.Forms.AxHost.State state = this.axUnityWebPlayer1.OcxState;
            this.axUnityWebPlayer1.Dispose();

            // re-init with saved state data
            this.axUnityWebPlayer1 = new AxUnityWebPlayerAXLib.AxUnityWebPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // axUnityWebPlayer1
            // 
            this.axUnityWebPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axUnityWebPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axUnityWebPlayer1.Size = new System.Drawing.Size(635, 451);
            this.axUnityWebPlayer1.Enabled = true;
            this.axUnityWebPlayer1.Name = "axUnityWebPlayer1";
            this.axUnityWebPlayer1.OcxState = state;
            this.Controls.Add(this.axUnityWebPlayer1);
            ((System.ComponentModel.ISupportInitialize)(this.axUnityWebPlayer1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
