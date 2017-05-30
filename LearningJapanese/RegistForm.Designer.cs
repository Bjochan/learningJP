using System.Windows.Forms;

namespace LearningJapanese
{
    partial class RegistForm
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
            this.tbxNick = new System.Windows.Forms.TextBox();
            this.lblNick = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.tbxPass = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbxMail = new System.Windows.Forms.TextBox();
            this.lblBirth = new System.Windows.Forms.Label();
            this.dtBirth = new System.Windows.Forms.DateTimePicker();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnCnl = new System.Windows.Forms.Button();
            this.lblInf = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxNick
            // 
            this.tbxNick.Location = new System.Drawing.Point(116, 47);
            this.tbxNick.Name = "tbxNick";
            this.tbxNick.Size = new System.Drawing.Size(269, 19);
            this.tbxNick.TabIndex = 0;
            // 
            // lblNick
            // 
            this.lblNick.AutoSize = true;
            this.lblNick.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNick.Location = new System.Drawing.Point(29, 50);
            this.lblNick.Name = "lblNick";
            this.lblNick.Size = new System.Drawing.Size(68, 12);
            this.lblNick.TabIndex = 1;
            this.lblNick.Text = "ニックネーム:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPass.Location = new System.Drawing.Point(29, 98);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(60, 12);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "パスワード:";
            // 
            // tbxPass
            // 
            this.tbxPass.Location = new System.Drawing.Point(116, 95);
            this.tbxPass.Name = "tbxPass";
            this.tbxPass.Size = new System.Drawing.Size(269, 19);
            this.tbxPass.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblEmail.Location = new System.Drawing.Point(29, 144);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(47, 12);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Eメール:";
            // 
            // tbxMail
            // 
            this.tbxMail.Location = new System.Drawing.Point(116, 141);
            this.tbxMail.Name = "tbxMail";
            this.tbxMail.Size = new System.Drawing.Size(269, 19);
            this.tbxMail.TabIndex = 5;
            // 
            // lblBirth
            // 
            this.lblBirth.AutoSize = true;
            this.lblBirth.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblBirth.Location = new System.Drawing.Point(29, 194);
            this.lblBirth.Name = "lblBirth";
            this.lblBirth.Size = new System.Drawing.Size(60, 12);
            this.lblBirth.TabIndex = 6;
            this.lblBirth.Text = "生年月日:";
            // 
            // dtBirth
            // 
            this.dtBirth.Location = new System.Drawing.Point(116, 189);
            this.dtBirth.Name = "dtBirth";
            this.dtBirth.Size = new System.Drawing.Size(200, 19);
            this.dtBirth.TabIndex = 7;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(84, 260);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(85, 29);
            this.btnReg.TabIndex = 8;
            this.btnReg.Text = "登録";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnCnl
            // 
            this.btnCnl.Location = new System.Drawing.Point(243, 260);
            this.btnCnl.Name = "btnCnl";
            this.btnCnl.Size = new System.Drawing.Size(85, 29);
            this.btnCnl.TabIndex = 9;
            this.btnCnl.Text = "キャンセル";
            this.btnCnl.UseVisualStyleBackColor = true;
            this.btnCnl.Click += new System.EventHandler(this.btnCnl_Click);
            // 
            // lblInf
            // 
            this.lblInf.AutoSize = true;
            this.lblInf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInf.Location = new System.Drawing.Point(154, 330);
            this.lblInf.Name = "lblInf";
            this.lblInf.Size = new System.Drawing.Size(0, 20);
            this.lblInf.TabIndex = 88;
            // 
            // RegistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 351);
            this.Controls.Add(this.btnCnl);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.dtBirth);
            this.Controls.Add(this.lblBirth);
            this.Controls.Add(this.tbxMail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.tbxPass);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblNick);
            this.Controls.Add(this.tbxNick);
            this.Controls.Add(this.lblInf);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistForm";
            this.Text = "新規登録フォーム";
            this.Load += new System.EventHandler(this.frmRegist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

  
        #endregion

        private TextBox tbxNick;
        private Label lblNick;
        private Label lblPass;
        private TextBox tbxPass;
        private Label lblEmail;
        private TextBox tbxMail;
        private Label lblBirth;
        private DateTimePicker dtBirth;
        private Button btnReg;
        private Button btnCnl;
        private Label lblInf;
    }
}


