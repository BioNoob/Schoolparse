namespace Schoolparse
{
    partial class StartForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.counter_lbl = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.use_telegram_chk = new System.Windows.Forms.CheckBox();
            this.telegram_status_lbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.school_img = new System.Windows.Forms.PictureBox();
            this.school_name_lbl = new System.Windows.Forms.Label();
            this.fio_lbl = new System.Windows.Forms.Label();
            this.drive_status_lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.balance_lbl = new System.Windows.Forms.Label();
            this.date_of_driving_lbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.theory_progress_lbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.group_lbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.category_lbl = new System.Windows.Forms.Label();
            this.autodrom_list_chk = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.school_img)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start parcer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(135, 327);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(313, 95);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Счетчик циклов";
            // 
            // counter_lbl
            // 
            this.counter_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.counter_lbl.Location = new System.Drawing.Point(40, 444);
            this.counter_lbl.Name = "counter_lbl";
            this.counter_lbl.Size = new System.Drawing.Size(35, 27);
            this.counter_lbl.TabIndex = 3;
            // 
            // listBox2
            // 
            this.listBox2.ForeColor = System.Drawing.Color.Red;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(135, 428);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(313, 43);
            this.listBox2.TabIndex = 4;
            // 
            // use_telegram_chk
            // 
            this.use_telegram_chk.Location = new System.Drawing.Point(483, 238);
            this.use_telegram_chk.Name = "use_telegram_chk";
            this.use_telegram_chk.Size = new System.Drawing.Size(166, 52);
            this.use_telegram_chk.TabIndex = 5;
            this.use_telegram_chk.Text = "Использовать телеграм для оповещений";
            this.use_telegram_chk.UseVisualStyleBackColor = true;
            this.use_telegram_chk.CheckedChanged += new System.EventHandler(this.use_telegram_chk_CheckedChanged);
            // 
            // telegram_status_lbl
            // 
            this.telegram_status_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.telegram_status_lbl.Location = new System.Drawing.Point(483, 293);
            this.telegram_status_lbl.Name = "telegram_status_lbl";
            this.telegram_status_lbl.Size = new System.Drawing.Size(166, 27);
            this.telegram_status_lbl.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.autodrom_list_chk);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.category_lbl);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.group_lbl);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.theory_progress_lbl);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.school_img);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.date_of_driving_lbl);
            this.groupBox1.Controls.Add(this.balance_lbl);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.drive_status_lbl);
            this.groupBox1.Controls.Add(this.fio_lbl);
            this.groupBox1.Controls.Add(this.school_name_lbl);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 247);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Автошкола";
            // 
            // school_img
            // 
            this.school_img.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.school_img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.school_img.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.school_img.Location = new System.Drawing.Point(226, 13);
            this.school_img.Name = "school_img";
            this.school_img.Size = new System.Drawing.Size(188, 95);
            this.school_img.TabIndex = 0;
            this.school_img.TabStop = false;
            // 
            // school_name_lbl
            // 
            this.school_name_lbl.AutoEllipsis = true;
            this.school_name_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.school_name_lbl.Location = new System.Drawing.Point(6, 19);
            this.school_name_lbl.Name = "school_name_lbl";
            this.school_name_lbl.Size = new System.Drawing.Size(205, 23);
            this.school_name_lbl.TabIndex = 2;
            this.school_name_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fio_lbl
            // 
            this.fio_lbl.AutoEllipsis = true;
            this.fio_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fio_lbl.Location = new System.Drawing.Point(6, 47);
            this.fio_lbl.Name = "fio_lbl";
            this.fio_lbl.Size = new System.Drawing.Size(205, 23);
            this.fio_lbl.TabIndex = 3;
            this.fio_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // drive_status_lbl
            // 
            this.drive_status_lbl.AutoEllipsis = true;
            this.drive_status_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drive_status_lbl.Location = new System.Drawing.Point(6, 173);
            this.drive_status_lbl.Name = "drive_status_lbl";
            this.drive_status_lbl.Size = new System.Drawing.Size(63, 23);
            this.drive_status_lbl.TabIndex = 4;
            this.drive_status_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Площадки АШ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Доступ к вождению";
            // 
            // balance_lbl
            // 
            this.balance_lbl.AutoEllipsis = true;
            this.balance_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balance_lbl.Location = new System.Drawing.Point(148, 173);
            this.balance_lbl.Name = "balance_lbl";
            this.balance_lbl.Size = new System.Drawing.Size(63, 23);
            this.balance_lbl.TabIndex = 7;
            this.balance_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // date_of_driving_lbl
            // 
            this.date_of_driving_lbl.AutoEllipsis = true;
            this.date_of_driving_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.date_of_driving_lbl.Location = new System.Drawing.Point(6, 214);
            this.date_of_driving_lbl.Name = "date_of_driving_lbl";
            this.date_of_driving_lbl.Size = new System.Drawing.Size(205, 23);
            this.date_of_driving_lbl.TabIndex = 8;
            this.date_of_driving_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Дата следующего вождения";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(130, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Остаток часов";
            // 
            // theory_progress_lbl
            // 
            this.theory_progress_lbl.AutoEllipsis = true;
            this.theory_progress_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.theory_progress_lbl.Location = new System.Drawing.Point(103, 103);
            this.theory_progress_lbl.Name = "theory_progress_lbl";
            this.theory_progress_lbl.Size = new System.Drawing.Size(108, 23);
            this.theory_progress_lbl.TabIndex = 11;
            this.theory_progress_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Прогерсс теории";
            // 
            // group_lbl
            // 
            this.group_lbl.AutoEllipsis = true;
            this.group_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.group_lbl.Location = new System.Drawing.Point(54, 75);
            this.group_lbl.Name = "group_lbl";
            this.group_lbl.Size = new System.Drawing.Size(157, 23);
            this.group_lbl.TabIndex = 13;
            this.group_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Группа";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(37, 137);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Категория";
            // 
            // category_lbl
            // 
            this.category_lbl.AutoEllipsis = true;
            this.category_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.category_lbl.Location = new System.Drawing.Point(103, 132);
            this.category_lbl.Name = "category_lbl";
            this.category_lbl.Size = new System.Drawing.Size(108, 23);
            this.category_lbl.TabIndex = 15;
            this.category_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // autodrom_list_chk
            // 
            this.autodrom_list_chk.FormattingEnabled = true;
            this.autodrom_list_chk.HorizontalScrollbar = true;
            this.autodrom_list_chk.Location = new System.Drawing.Point(226, 132);
            this.autodrom_list_chk.Name = "autodrom_list_chk";
            this.autodrom_list_chk.Size = new System.Drawing.Size(188, 109);
            this.autodrom_list_chk.TabIndex = 8;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 527);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.telegram_status_lbl);
            this.Controls.Add(this.use_telegram_chk);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.counter_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.Text = "Парсер школы";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.school_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label counter_lbl;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.CheckBox use_telegram_chk;
        private System.Windows.Forms.Label telegram_status_lbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox school_img;
        private System.Windows.Forms.Label fio_lbl;
        private System.Windows.Forms.Label school_name_lbl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label date_of_driving_lbl;
        private System.Windows.Forms.Label balance_lbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label drive_status_lbl;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label category_lbl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label group_lbl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label theory_progress_lbl;
        private System.Windows.Forms.CheckedListBox autodrom_list_chk;
    }
}

