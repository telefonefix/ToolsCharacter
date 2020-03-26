using System;
using System.Linq;
using System.Windows.Forms;

namespace ToolsCharacterForm
{
    public partial class FrmGender : Form
    {   
        public string GenderValue { get; internal set; }

        public FrmGender()
        {
            InitializeComponent();
            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GenderValue = GetGender();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private string GetGender()
        {
            RadioButton checkedButton = grpBoxGender.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            return checkedButton.Text;
        }
    }
}
