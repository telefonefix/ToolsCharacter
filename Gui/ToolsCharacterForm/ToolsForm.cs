using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WriteToJson;

namespace ToolsCharacterForm
{
    enum Error
    {
        Empty,
        InvalidData
    }



    public partial class ToolsForm : Form
    {
        public ToolsForm()
        {
            InitializeComponent();
        }

        private void btn_Serial_Click(object sender, EventArgs e)
        {
            TryImport();




            //Export export = new Export(import.Appointement);

            //export.SetAppointment();

            //if (GetErrorMessage(export.Exp)) return;

        }

        private void TryImport()
        {
            try
            {
                ImportData import = new ImportData(txtBox_Appt.Text);
                import.ImportText();
            }
            catch (CharacterException e)
            {
                GetErrorMessage(e, Error.InvalidData);
            }
                
        }

        private void btn_ToDB_Click(object sender, EventArgs e)
        {

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private bool GetErrorMessage(CharacterException e,Error error)
        {
            DialogResult dialog = DialogResult.Yes; 
            if (e != null)
            {
                switch (error)
                {
                    case Error.Empty:
                        MessageBox.Show(e.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                        break;
                    case Error.InvalidData:
                        dialog = MessageBox.Show(string.Concat(e.Message, System.Environment.NewLine, "Voulez-vous effacer le contenu ?"), "Erreur", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }

                if (dialog == DialogResult.Yes)
                {
                    ClearTextBox();
                }
                return true;
            }
            return false;
        }

        private void ClearTextBox()
        {
            txtBox_Appt.Clear();
        }

        private void btn_Example_Click(object sender, EventArgs e)
        {
            ExampleForm form = new ExampleForm();
            form.ShowDialog();

        }
    }
}
