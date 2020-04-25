namespace ToolsCharacterForm
{
    partial class ToolsForm
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
            this.btn_Serial = new System.Windows.Forms.Button();
            this.btn_ToDB = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.txtBox_Appt = new System.Windows.Forms.TextBox();
            this.btn_Example = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeGender = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Serial
            // 
            this.btn_Serial.Location = new System.Drawing.Point(490, 569);
            this.btn_Serial.Name = "btn_Serial";
            this.btn_Serial.Size = new System.Drawing.Size(106, 24);
            this.btn_Serial.TabIndex = 3;
            this.btn_Serial.Text = "Exporter en Json";
            this.btn_Serial.UseVisualStyleBackColor = true;
            this.btn_Serial.Click += new System.EventHandler(this.Btn_Serial_Click);
            // 
            // btn_ToDB
            // 
            this.btn_ToDB.Location = new System.Drawing.Point(602, 569);
            this.btn_ToDB.Name = "btn_ToDB";
            this.btn_ToDB.Size = new System.Drawing.Size(106, 24);
            this.btn_ToDB.TabIndex = 4;
            this.btn_ToDB.Text = "Exporter vers Base";
            this.btn_ToDB.UseVisualStyleBackColor = true;
            this.btn_ToDB.Click += new System.EventHandler(this.Btn_ToDB_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Clear.Location = new System.Drawing.Point(826, 569);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(106, 24);
            this.btn_Clear.TabIndex = 5;
            this.btn_Clear.Text = "Vider le texte";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.Btn_Clear_Click);
            // 
            // txtBox_Appt
            // 
            this.txtBox_Appt.Location = new System.Drawing.Point(12, 36);
            this.txtBox_Appt.Multiline = true;
            this.txtBox_Appt.Name = "txtBox_Appt";
            this.txtBox_Appt.Size = new System.Drawing.Size(920, 527);
            this.txtBox_Appt.TabIndex = 2;
            // 
            // btn_Example
            // 
            this.btn_Example.Location = new System.Drawing.Point(12, 569);
            this.btn_Example.Name = "btn_Example";
            this.btn_Example.Size = new System.Drawing.Size(106, 24);
            this.btn_Example.TabIndex = 6;
            this.btn_Example.Text = "Exemple";
            this.btn_Example.UseVisualStyleBackColor = true;
            this.btn_Example.Click += new System.EventHandler(this.Btn_Example_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Insérer le texte ci-dessous";
            // 
            // btnChangeGender
            // 
            this.btnChangeGender.Location = new System.Drawing.Point(714, 569);
            this.btnChangeGender.Name = "btnChangeGender";
            this.btnChangeGender.Size = new System.Drawing.Size(106, 24);
            this.btnChangeGender.TabIndex = 3;
            this.btnChangeGender.Text = "Changer le genre";
            this.btnChangeGender.UseVisualStyleBackColor = true;
            this.btnChangeGender.Click += new System.EventHandler(this.BtnChangeGender_Click_1);
            // 
            // ToolsForm
            // 
            this.AcceptButton = this.btn_Serial;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Clear;
            this.ClientSize = new System.Drawing.Size(944, 605);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Example);
            this.Controls.Add(this.btnChangeGender);
            this.Controls.Add(this.btn_Serial);
            this.Controls.Add(this.btn_ToDB);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.txtBox_Appt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToolsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outil importation de personnage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Serial;
        private System.Windows.Forms.Button btn_ToDB;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.TextBox txtBox_Appt;
        private System.Windows.Forms.Button btn_Example;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeGender;
    }
}