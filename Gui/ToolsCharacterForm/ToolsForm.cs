using ExportToDB;
using System;
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
        private bool _genderValidated;
        private string _gender;
        //public string GenderName { get; private set; }
        public ToolsForm()
        {
            InitializeComponent();
            _genderValidated = false;
            btnChangeGender.Enabled = false;           
        }

        private void Btn_Serial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBox_Appt.Text))
            {
                MessageBox.Show("Aucune donnée à extraire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            while (!_genderValidated)
            {
                FrmGender frm = new FrmGender();

                DialogResult dialogResult = frm.ShowDialog();
                switch (dialogResult)
                {  
                    case DialogResult.OK:
                        _gender = frm.GenderValue;
                        _genderValidated = true;
                        btnChangeGender.Enabled = true;
                        break;
                    case DialogResult.Cancel:
                        return;
                    default:
                        return;
                }
            }
            Export();
        }

        private void Export()
        {
            string message;
            try
            {
                ExportToJson import = new ExportToJson();
                import.ImportText(txtBox_Appt.Text, _gender);
                if (import.Success)
                {
                    message = import.Message + Environment.NewLine + "Voulez-vous exporter un autre personnage ?";
                    DialogResult answer = MessageBox.Show(message, "Succés", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    switch (answer)
                    {
                        case DialogResult.None:
                            break;
                        case DialogResult.OK:
                            break;
                        case DialogResult.Cancel:
                            break;
                        case DialogResult.Abort:
                            break;
                        case DialogResult.Retry:
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.Yes:
                            btn_Clear.PerformClick();
                            break;
                        case DialogResult.No:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (CharacterException e)
            {
                GetErrorMessage(e, Error.InvalidData);
            }
        }

        private void Btn_ToDB_Click(object sender, EventArgs e)
        {
            ExportToDB();
        }


        private void ExportToDB()
        {
            ExportDatasToDB exportDatasToDB = new ExportDatasToDB();
            exportDatasToDB.SetToDb(_gender);
        }
        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            _genderValidated = false;
            btnChangeGender.Enabled = false;
            ClearTextBox();
        }

        private bool GetErrorMessage(CharacterException e, Error error)
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

        private void BtnChangeGender_Click(object sender, EventArgs e)
        {
            FrmGender frm = new FrmGender();
            DialogResult dialogResult = frm.ShowDialog();
            switch (dialogResult)
            {
                case DialogResult.OK:
                    _gender = frm.GenderValue;
                    _genderValidated = true;
                    btnChangeGender.Enabled = true;
                    break;
                case DialogResult.Cancel:
                    return;
                default:
                    return;
            }
        }

        private void BtnChangeGender_Click_1(object sender, EventArgs e)
        {

        }
    }
}
