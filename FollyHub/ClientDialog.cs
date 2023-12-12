using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Follyverse
{
    public partial class ClientDialog : Form
    {
        public TamesProject project;
        public string IP { get { return IPBox.Text; } }
        public string Nickname { get { return nickBox.Text; } }
        public ClientDialog()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void SetLabel(string s)
        {
            label3.Text = s;
        }
    }
}
