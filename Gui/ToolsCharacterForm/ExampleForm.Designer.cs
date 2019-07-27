namespace ToolsCharacterForm
{
    partial class ExampleForm
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
            this.components = new System.ComponentModel.Container();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.toolTip_example = new System.Windows.Forms.ToolTip(this.components);
            this.rTxtBox_Example = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(426, 465);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(106, 24);
            this.btn_Ok.TabIndex = 7;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.Btn_Ok_Click);
            // 
            // rTxtBox_Example
            // 
            this.rTxtBox_Example.Location = new System.Drawing.Point(12, 12);
            this.rTxtBox_Example.Margin = new System.Windows.Forms.Padding(2);
            this.rTxtBox_Example.Name = "rTxtBox_Example";
            this.rTxtBox_Example.ReadOnly = true;
            this.rTxtBox_Example.Size = new System.Drawing.Size(920, 448);
            this.rTxtBox_Example.TabIndex = 8;
            this.rTxtBox_Example.Text = "";
            this.rTxtBox_Example.MouseEnter += new System.EventHandler(this.RTxtBox_Example_MouseEnter);
            // 
            // ExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.rTxtBox_Example);
            this.Controls.Add(this.btn_Ok);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExampleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exemple de texte à importer";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.ToolTip toolTip_example;
        private System.Windows.Forms.RichTextBox rTxtBox_Example;
    }
}