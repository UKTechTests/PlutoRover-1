using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlutoRoverClient
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }

        private PlutoRoverAPI.Core _rover = null;

        private void client_Load(object sender, EventArgs e)
        {
            _rover = new PlutoRoverAPI.Core();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _rover.Move(txtCommand.Text);

            lblPosition.Text = _rover.GetPosition();
        }
    }
}
