using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsCharacterForm
{
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
            GetExample();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetExample()
        {
            rTxtBox_Example.LoadFile(@".\example.rtf");
        }

        private void rTxtBox_Example_MouseEnter(object sender, EventArgs e)
        {
            toolTip_example.SetToolTip(this.rTxtBox_Example, File.ReadAllText(@".\info.txt"));
        }
    }
}
