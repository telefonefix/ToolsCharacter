namespace ToolsCharacterForm
{
    partial class FrmGender
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBoxGender = new System.Windows.Forms.GroupBox();
            this.radBtnNoGender = new System.Windows.Forms.RadioButton();
            this.radBtnMale = new System.Windows.Forms.RadioButton();
            this.radBtnFemale = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBoxGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxGender
            // 
            this.grpBoxGender.Controls.Add(this.radBtnNoGender);
            this.grpBoxGender.Controls.Add(this.radBtnMale);
            this.grpBoxGender.Controls.Add(this.radBtnFemale);
            this.grpBoxGender.Location = new System.Drawing.Point(12, 12);
            this.grpBoxGender.Name = "grpBoxGender";
            this.grpBoxGender.Size = new System.Drawing.Size(157, 96);
            this.grpBoxGender.TabIndex = 0;
            this.grpBoxGender.TabStop = false;
            this.grpBoxGender.Text = "Genre";
            // 
            // radBtnNoGender
            // 
            this.radBtnNoGender.AutoSize = true;
            this.radBtnNoGender.Location = new System.Drawing.Point(18, 67);
            this.radBtnNoGender.Name = "radBtnNoGender";
            this.radBtnNoGender.Size = new System.Drawing.Size(84, 17);
            this.radBtnNoGender.TabIndex = 1;
            this.radBtnNoGender.Text = "Cyber Robot";
            this.radBtnNoGender.UseVisualStyleBackColor = true;
            // 
            // radBtnMale
            // 
            this.radBtnMale.AutoSize = true;
            this.radBtnMale.Checked = true;
            this.radBtnMale.Location = new System.Drawing.Point(18, 44);
            this.radBtnMale.Name = "radBtnMale";
            this.radBtnMale.Size = new System.Drawing.Size(61, 17);
            this.radBtnMale.TabIndex = 1;
            this.radBtnMale.TabStop = true;
            this.radBtnMale.Text = "Homme";
            this.radBtnMale.UseVisualStyleBackColor = true;
            // 
            // radBtnFemale
            // 
            this.radBtnFemale.AutoSize = true;
            this.radBtnFemale.Location = new System.Drawing.Point(18, 20);
            this.radBtnFemale.Name = "radBtnFemale";
            this.radBtnFemale.Size = new System.Drawing.Size(59, 17);
            this.radBtnFemale.TabIndex = 0;
            this.radBtnFemale.TabStop = true;
            this.radBtnFemale.Text = "Femme";
            this.radBtnFemale.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(13, 115);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Valider";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(94, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmGender
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(188, 148);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpBoxGender);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Genre du personnage";
            this.grpBoxGender.ResumeLayout(false);
            this.grpBoxGender.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxGender;
        private System.Windows.Forms.RadioButton radBtnNoGender;
        private System.Windows.Forms.RadioButton radBtnMale;
        private System.Windows.Forms.RadioButton radBtnFemale;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}