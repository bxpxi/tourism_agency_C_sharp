using System.ComponentModel;

namespace UI
{
    partial class LoginWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            panel1 = new System.Windows.Forms.Panel();
            LoginButton = new System.Windows.Forms.Button();
            PasswordBox = new System.Windows.Forms.TextBox();
            AgencyNameBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(LoginButton);
            panel1.Controls.Add(PasswordBox);
            panel1.Controls.Add(AgencyNameBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new System.Drawing.Point(129, 43);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(548, 358);
            panel1.TabIndex = 0;
            // 
            // LoginButton
            // 
            LoginButton.Location = new System.Drawing.Point(223, 264);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new System.Drawing.Size(101, 46);
            LoginButton.TabIndex = 4;
            LoginButton.Text = "LOGIN";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new System.Drawing.Point(240, 146);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new System.Drawing.Size(234, 31);
            PasswordBox.TabIndex = 3;
            PasswordBox.UseSystemPasswordChar = true;
            // 
            // AgencyNameBox
            // 
            AgencyNameBox.Location = new System.Drawing.Point(240, 50);
            AgencyNameBox.Name = "AgencyNameBox";
            AgencyNameBox.Size = new System.Drawing.Size(234, 31);
            AgencyNameBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(56, 148);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(113, 29);
            label2.TabIndex = 1;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(56, 50);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(139, 38);
            label1.TabIndex = 0;
            label1.Text = "Agency Name:";
            // 
            // LoginWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panel1);
            Text = "LoginWindow";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AgencyNameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button LoginButton;

        private System.Windows.Forms.Panel panel1;

        #endregion
        }
}