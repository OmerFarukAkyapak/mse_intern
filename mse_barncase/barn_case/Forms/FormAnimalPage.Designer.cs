﻿
namespace barn_case.Forms
{
    partial class FormAnimalPage
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
            this.pnlAnimalPage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlAnimalPage
            // 
            this.pnlAnimalPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAnimalPage.Location = new System.Drawing.Point(0, 0);
            this.pnlAnimalPage.Name = "pnlAnimalPage";
            this.pnlAnimalPage.Size = new System.Drawing.Size(995, 609);
            this.pnlAnimalPage.TabIndex = 0;
            // 
            // FormAnimalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(995, 609);
            this.ControlBox = false;
            this.Controls.Add(this.pnlAnimalPage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAnimalPage";
            this.Text = "FormAnimal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAnimalPage;
    }
}