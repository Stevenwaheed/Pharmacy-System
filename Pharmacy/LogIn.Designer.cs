
namespace Pharmacy
{
    partial class LogIn
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
            this.LogInbutton = new System.Windows.Forms.Button();
            this.AddNewUser = new System.Windows.Forms.Button();
            this.LogInpanel = new System.Windows.Forms.Panel();
            this.WrongPasswordlabel = new System.Windows.Forms.Label();
            this.WrongUsernamelabel = new System.Windows.Forms.Label();
            this.PasswordtextBox = new System.Windows.Forms.TextBox();
            this.UserNametextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NewUserpanel = new System.Windows.Forms.Panel();
            this.NotMatchlabel = new System.Windows.Forms.Label();
            this.Confirmlabel = new System.Windows.Forms.Label();
            this.ConfirmtextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AddWrongPasslabel = new System.Windows.Forms.Label();
            this.AddWrongUserlabel = new System.Windows.Forms.Label();
            this.NewPasstextBox = new System.Windows.Forms.TextBox();
            this.AddNewUsertextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Createbutton = new System.Windows.Forms.Button();
            this.Backbutton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LogInpanel.SuspendLayout();
            this.NewUserpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogInbutton
            // 
            this.LogInbutton.BackColor = System.Drawing.Color.Tan;
            this.LogInbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogInbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogInbutton.Location = new System.Drawing.Point(167, 353);
            this.LogInbutton.Name = "LogInbutton";
            this.LogInbutton.Size = new System.Drawing.Size(213, 54);
            this.LogInbutton.TabIndex = 4;
            this.LogInbutton.Text = "Log In";
            this.LogInbutton.UseVisualStyleBackColor = false;
            this.LogInbutton.Click += new System.EventHandler(this.LogInbutton_Click);
            // 
            // AddNewUser
            // 
            this.AddNewUser.BackColor = System.Drawing.Color.Coral;
            this.AddNewUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewUser.Location = new System.Drawing.Point(187, 413);
            this.AddNewUser.Name = "AddNewUser";
            this.AddNewUser.Size = new System.Drawing.Size(170, 51);
            this.AddNewUser.TabIndex = 7;
            this.AddNewUser.Text = "Add User";
            this.AddNewUser.UseVisualStyleBackColor = false;
            this.AddNewUser.Visible = false;
            this.AddNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
            // 
            // LogInpanel
            // 
            this.LogInpanel.BackColor = System.Drawing.Color.White;
            this.LogInpanel.Controls.Add(this.WrongPasswordlabel);
            this.LogInpanel.Controls.Add(this.WrongUsernamelabel);
            this.LogInpanel.Controls.Add(this.PasswordtextBox);
            this.LogInpanel.Controls.Add(this.UserNametextBox);
            this.LogInpanel.Controls.Add(this.label2);
            this.LogInpanel.Controls.Add(this.label1);
            this.LogInpanel.Location = new System.Drawing.Point(106, 200);
            this.LogInpanel.Name = "LogInpanel";
            this.LogInpanel.Size = new System.Drawing.Size(342, 120);
            this.LogInpanel.TabIndex = 8;
            // 
            // WrongPasswordlabel
            // 
            this.WrongPasswordlabel.AutoSize = true;
            this.WrongPasswordlabel.BackColor = System.Drawing.Color.White;
            this.WrongPasswordlabel.ForeColor = System.Drawing.Color.Red;
            this.WrongPasswordlabel.Location = new System.Drawing.Point(120, 99);
            this.WrongPasswordlabel.Name = "WrongPasswordlabel";
            this.WrongPasswordlabel.Size = new System.Drawing.Size(114, 17);
            this.WrongPasswordlabel.TabIndex = 12;
            this.WrongPasswordlabel.Text = "Wrong password";
            this.WrongPasswordlabel.Visible = false;
            // 
            // WrongUsernamelabel
            // 
            this.WrongUsernamelabel.AutoSize = true;
            this.WrongUsernamelabel.BackColor = System.Drawing.Color.White;
            this.WrongUsernamelabel.ForeColor = System.Drawing.Color.Red;
            this.WrongUsernamelabel.Location = new System.Drawing.Point(120, 35);
            this.WrongUsernamelabel.Name = "WrongUsernamelabel";
            this.WrongUsernamelabel.Size = new System.Drawing.Size(117, 17);
            this.WrongUsernamelabel.TabIndex = 11;
            this.WrongUsernamelabel.Text = "Wrong username";
            this.WrongUsernamelabel.Visible = false;
            // 
            // PasswordtextBox
            // 
            this.PasswordtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordtextBox.Location = new System.Drawing.Point(116, 68);
            this.PasswordtextBox.Name = "PasswordtextBox";
            this.PasswordtextBox.PasswordChar = '*';
            this.PasswordtextBox.Size = new System.Drawing.Size(217, 28);
            this.PasswordtextBox.TabIndex = 10;
            // 
            // UserNametextBox
            // 
            this.UserNametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNametextBox.Location = new System.Drawing.Point(116, 4);
            this.UserNametextBox.Name = "UserNametextBox";
            this.UserNametextBox.Size = new System.Drawing.Size(217, 28);
            this.UserNametextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username";
            // 
            // NewUserpanel
            // 
            this.NewUserpanel.BackColor = System.Drawing.Color.White;
            this.NewUserpanel.Controls.Add(this.NotMatchlabel);
            this.NewUserpanel.Controls.Add(this.Confirmlabel);
            this.NewUserpanel.Controls.Add(this.ConfirmtextBox);
            this.NewUserpanel.Controls.Add(this.label8);
            this.NewUserpanel.Controls.Add(this.AddWrongPasslabel);
            this.NewUserpanel.Controls.Add(this.AddWrongUserlabel);
            this.NewUserpanel.Controls.Add(this.NewPasstextBox);
            this.NewUserpanel.Controls.Add(this.AddNewUsertextBox);
            this.NewUserpanel.Controls.Add(this.label5);
            this.NewUserpanel.Controls.Add(this.label6);
            this.NewUserpanel.Location = new System.Drawing.Point(118, 165);
            this.NewUserpanel.Name = "NewUserpanel";
            this.NewUserpanel.Size = new System.Drawing.Size(314, 183);
            this.NewUserpanel.TabIndex = 9;
            this.NewUserpanel.Visible = false;
            // 
            // NotMatchlabel
            // 
            this.NotMatchlabel.AutoSize = true;
            this.NotMatchlabel.BackColor = System.Drawing.Color.White;
            this.NotMatchlabel.ForeColor = System.Drawing.Color.Red;
            this.NotMatchlabel.Location = new System.Drawing.Point(120, 158);
            this.NotMatchlabel.Name = "NotMatchlabel";
            this.NotMatchlabel.Size = new System.Drawing.Size(72, 17);
            this.NotMatchlabel.TabIndex = 16;
            this.NotMatchlabel.Text = "Not Match";
            this.NotMatchlabel.Visible = false;
            // 
            // Confirmlabel
            // 
            this.Confirmlabel.AutoSize = true;
            this.Confirmlabel.BackColor = System.Drawing.Color.White;
            this.Confirmlabel.ForeColor = System.Drawing.Color.Red;
            this.Confirmlabel.Location = new System.Drawing.Point(119, 160);
            this.Confirmlabel.Name = "Confirmlabel";
            this.Confirmlabel.Size = new System.Drawing.Size(125, 17);
            this.Confirmlabel.TabIndex = 15;
            this.Confirmlabel.Text = "Enter Confirmation";
            this.Confirmlabel.Visible = false;
            // 
            // ConfirmtextBox
            // 
            this.ConfirmtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmtextBox.Location = new System.Drawing.Point(115, 129);
            this.ConfirmtextBox.Name = "ConfirmtextBox";
            this.ConfirmtextBox.PasswordChar = '*';
            this.ConfirmtextBox.Size = new System.Drawing.Size(195, 28);
            this.ConfirmtextBox.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 48);
            this.label8.TabIndex = 13;
            this.label8.Text = "  Confirm\r\nPassword";
            // 
            // AddWrongPasslabel
            // 
            this.AddWrongPasslabel.AutoSize = true;
            this.AddWrongPasslabel.BackColor = System.Drawing.Color.White;
            this.AddWrongPasslabel.ForeColor = System.Drawing.Color.Red;
            this.AddWrongPasslabel.Location = new System.Drawing.Point(120, 99);
            this.AddWrongPasslabel.Name = "AddWrongPasslabel";
            this.AddWrongPasslabel.Size = new System.Drawing.Size(114, 17);
            this.AddWrongPasslabel.TabIndex = 12;
            this.AddWrongPasslabel.Text = "Wrong password";
            this.AddWrongPasslabel.Visible = false;
            // 
            // AddWrongUserlabel
            // 
            this.AddWrongUserlabel.AutoSize = true;
            this.AddWrongUserlabel.BackColor = System.Drawing.Color.White;
            this.AddWrongUserlabel.ForeColor = System.Drawing.Color.Red;
            this.AddWrongUserlabel.Location = new System.Drawing.Point(120, 35);
            this.AddWrongUserlabel.Name = "AddWrongUserlabel";
            this.AddWrongUserlabel.Size = new System.Drawing.Size(117, 17);
            this.AddWrongUserlabel.TabIndex = 11;
            this.AddWrongUserlabel.Text = "Wrong username";
            this.AddWrongUserlabel.Visible = false;
            // 
            // NewPasstextBox
            // 
            this.NewPasstextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewPasstextBox.Location = new System.Drawing.Point(116, 68);
            this.NewPasstextBox.Name = "NewPasstextBox";
            this.NewPasstextBox.PasswordChar = '*';
            this.NewPasstextBox.Size = new System.Drawing.Size(195, 28);
            this.NewPasstextBox.TabIndex = 10;
            // 
            // AddNewUsertextBox
            // 
            this.AddNewUsertextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewUsertextBox.Location = new System.Drawing.Point(116, 4);
            this.AddNewUsertextBox.Name = "AddNewUsertextBox";
            this.AddNewUsertextBox.Size = new System.Drawing.Size(195, 28);
            this.AddNewUsertextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 24);
            this.label6.TabIndex = 7;
            this.label6.Text = "Username";
            // 
            // Createbutton
            // 
            this.Createbutton.BackColor = System.Drawing.Color.Tan;
            this.Createbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Createbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Createbutton.Location = new System.Drawing.Point(167, 354);
            this.Createbutton.Name = "Createbutton";
            this.Createbutton.Size = new System.Drawing.Size(213, 54);
            this.Createbutton.TabIndex = 10;
            this.Createbutton.Text = "Create";
            this.Createbutton.UseVisualStyleBackColor = false;
            this.Createbutton.Visible = false;
            this.Createbutton.Click += new System.EventHandler(this.Createbutton_Click);
            // 
            // Backbutton
            // 
            this.Backbutton.BackColor = System.Drawing.Color.Coral;
            this.Backbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Backbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Backbutton.Location = new System.Drawing.Point(186, 414);
            this.Backbutton.Name = "Backbutton";
            this.Backbutton.Size = new System.Drawing.Size(170, 51);
            this.Backbutton.TabIndex = 11;
            this.Backbutton.Text = "Back";
            this.Backbutton.UseVisualStyleBackColor = false;
            this.Backbutton.Visible = false;
            this.Backbutton.Click += new System.EventHandler(this.Backbutton_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(502, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 38);
            this.button2.TabIndex = 12;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pharmacy.Properties.Resources._1010101;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(575, 540);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.NewUserpanel);
            this.Controls.Add(this.LogInpanel);
            this.Controls.Add(this.Createbutton);
            this.Controls.Add(this.AddNewUser);
            this.Controls.Add(this.LogInbutton);
            this.Controls.Add(this.Backbutton);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(593, 587);
            this.MinimumSize = new System.Drawing.Size(593, 587);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            this.LogInpanel.ResumeLayout(false);
            this.LogInpanel.PerformLayout();
            this.NewUserpanel.ResumeLayout(false);
            this.NewUserpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button LogInbutton;
        private System.Windows.Forms.Button AddNewUser;
        private System.Windows.Forms.Panel LogInpanel;
        private System.Windows.Forms.Label WrongPasswordlabel;
        private System.Windows.Forms.Label WrongUsernamelabel;
        private System.Windows.Forms.TextBox PasswordtextBox;
        private System.Windows.Forms.TextBox UserNametextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel NewUserpanel;
        private System.Windows.Forms.Label NotMatchlabel;
        private System.Windows.Forms.Label Confirmlabel;
        private System.Windows.Forms.TextBox ConfirmtextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label AddWrongPasslabel;
        private System.Windows.Forms.Label AddWrongUserlabel;
        private System.Windows.Forms.TextBox NewPasstextBox;
        private System.Windows.Forms.TextBox AddNewUsertextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Createbutton;
        private System.Windows.Forms.Button Backbutton;
        private System.Windows.Forms.Button button2;
    }
}