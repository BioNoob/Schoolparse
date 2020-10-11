namespace Schoolparse
{
    partial class TelegramAuth
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
            this.label2 = new System.Windows.Forms.Label();
            this.confirm_code_btn = new System.Windows.Forms.Button();
            this.telega_code_txt = new System.Windows.Forms.TextBox();
            this.start_auth_telegram_btn = new System.Windows.Forms.Button();
            this.phone_num_mtxt = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.status_lbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Номер телефона";
            // 
            // confirm_code_btn
            // 
            this.confirm_code_btn.Enabled = false;
            this.confirm_code_btn.Location = new System.Drawing.Point(11, 45);
            this.confirm_code_btn.Name = "confirm_code_btn";
            this.confirm_code_btn.Size = new System.Drawing.Size(137, 26);
            this.confirm_code_btn.TabIndex = 18;
            this.confirm_code_btn.Text = "Отправить";
            this.confirm_code_btn.UseVisualStyleBackColor = true;
            this.confirm_code_btn.Click += new System.EventHandler(this.confirm_code_btn_Click);
            // 
            // telega_code_txt
            // 
            this.telega_code_txt.Enabled = false;
            this.telega_code_txt.Location = new System.Drawing.Point(11, 19);
            this.telega_code_txt.Name = "telega_code_txt";
            this.telega_code_txt.Size = new System.Drawing.Size(137, 20);
            this.telega_code_txt.TabIndex = 17;
            // 
            // start_auth_telegram_btn
            // 
            this.start_auth_telegram_btn.Location = new System.Drawing.Point(11, 56);
            this.start_auth_telegram_btn.Name = "start_auth_telegram_btn";
            this.start_auth_telegram_btn.Size = new System.Drawing.Size(137, 26);
            this.start_auth_telegram_btn.TabIndex = 15;
            this.start_auth_telegram_btn.Text = "Авторизация";
            this.start_auth_telegram_btn.UseVisualStyleBackColor = true;
            this.start_auth_telegram_btn.Click += new System.EventHandler(this.start_auth_telegram_Click);
            // 
            // phone_num_mtxt
            // 
            this.phone_num_mtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phone_num_mtxt.Location = new System.Drawing.Point(11, 29);
            this.phone_num_mtxt.Mask = "+7(000)000-00-00";
            this.phone_num_mtxt.Name = "phone_num_mtxt";
            this.phone_num_mtxt.PromptChar = '*';
            this.phone_num_mtxt.Size = new System.Drawing.Size(137, 21);
            this.phone_num_mtxt.TabIndex = 21;
            this.phone_num_mtxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.phone_num_mtxt.TextChanged += new System.EventHandler(this.phone_num_mtxt_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.telega_code_txt);
            this.groupBox1.Controls.Add(this.confirm_code_btn);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 79);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ответный код";
            // 
            // status_lbl
            // 
            this.status_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.status_lbl.Location = new System.Drawing.Point(11, 85);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(137, 60);
            this.status_lbl.TabIndex = 23;
            this.status_lbl.Text = "Статус";
            this.status_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TelegramAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(158, 227);
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.phone_num_mtxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.start_auth_telegram_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelegramAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Вход в телеграм";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TelegramAuth_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button confirm_code_btn;
        private System.Windows.Forms.TextBox telega_code_txt;
        private System.Windows.Forms.Button start_auth_telegram_btn;
        private System.Windows.Forms.MaskedTextBox phone_num_mtxt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label status_lbl;
    }
}