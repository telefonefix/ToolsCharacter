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

        private void Btn_Serial_Click(object sender, EventArgs e)
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
                ImportData import = new ImportData();
                import.ImportText(txtBox_Appt.Text);
            }
            catch (CharacterException e)
            {
                GetErrorMessage(e, Error.InvalidData);
            }
                
        }

        private void Btn_ToDB_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Clear_Click(object sender, EventArgs e)
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
                        dialog = MessageBox.Show(string.Concat(e.Message, Environment.NewLine, Environment.NewLine, "Voulez-vous effacer le contenu ?"), "Erreur", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
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

        private void Btn_Example_Click(object sender, EventArgs e)
        {
            ExampleForm form = new ExampleForm();
            form.ShowDialog();

        }
    }
}
