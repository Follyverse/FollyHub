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
    public enum ZipResult { None, Unselected, Selected, All }
    public partial class ZipForm : Form
    {
        public ZipResult result = ZipResult.None;
        public List<int> selection = new List<int>();
        public ZipForm()
        {
            InitializeComponent();
        }
        public void SetList(List<string> list)
        {
            checkedListBox1.Items.Clear();  
            foreach(string s in list)
             checkedListBox1.Items.Add(s);  
                
        }
        private void button2_Click(object sender, EventArgs e)
        {
            selection.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                selection.Add(i);
            result = ZipResult.All;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selection.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.CheckedIndices[i] == 1) selection.Add(i);
            result = ZipResult.Selected;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selection.Clear();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.CheckedIndices[i] != 1) selection.Add(i);
            result = ZipResult.Unselected;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selection.Clear();
            result = ZipResult.None;
        }
    }
}
