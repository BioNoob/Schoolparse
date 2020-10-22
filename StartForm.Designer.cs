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
            this.all_res_list = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.counter_lbl = new System.Windows.Forms.Label();
            this.exect_res_list = new System.Windows.Forms.ListBox();
            this.use_telegram_chk = new System.Windows.Forms.CheckBox();
            this.telegram_status_lbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.autodrom_list_chk = new System.Windows.Forms.CheckedListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.category_lbl = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.group_lbl = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.theory_progress_lbl = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.school_img = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.date_of_driving_lbl = new System.Windows.Forms.Label();
            this.balance_lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.drive_status_lbl = new System.Windows.Forms.Label();
            this.fio_lbl = new System.Windows.Forms.Label();
            this.school_name_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.telega_time_out_num = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.time_filter_dtp = new System.Windows.Forms.DateTimePicker();
            this.fio_teacher_txt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.selected_autodrom_list = new System.Windows.Forms.ListBox();
            this.only_end_chk = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.end_time_dtp = new System.Windows.Forms.DateTimePicker();
            this.start_time_dtp = new System.Windows.Forms.DateTimePicker();
            this.not_use_sound_chk = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.see_btn = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.work_time_lbl = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.stop_btn = new System.Windows.Forms.Button();
            this.time_out_num = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.log_rich = new System.Windows.Forms.RichTextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.school_img)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.telega_time_out_num)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time_out_num)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Старт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // all_res_list
            // 
            this.all_res_list.FormattingEnabled = true;
            this.all_res_list.HorizontalScrollbar = true;
            this.all_res_list.Location = new System.Drawing.Point(101, 16);
            this.all_res_list.Name = "all_res_list";
            this.all_res_list.Size = new System.Drawing.Size(237, 108);
            this.all_res_list.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Счетчик циклов работы";
            // 
            // counter_lbl
            // 
            this.counter_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.counter_lbl.Location = new System.Drawing.Point(303, 469);
            this.counter_lbl.Name = "counter_lbl";
            this.counter_lbl.Size = new System.Drawing.Size(35, 23);
            this.counter_lbl.TabIndex = 3;
            // 
            // exect_res_list
            // 
            this.exect_res_list.ForeColor = System.Drawing.Color.Red;
            this.exect_res_list.FormattingEnabled = true;
            this.exect_res_list.HorizontalScrollbar = true;
            this.exect_res_list.Location = new System.Drawing.Point(101, 132);
            this.exect_res_list.Name = "exect_res_list";
            this.exect_res_list.Size = new System.Drawing.Size(237, 134);
            this.exect_res_list.TabIndex = 4;
            // 
            // use_telegram_chk
            // 
            this.use_telegram_chk.BackColor = System.Drawing.Color.Transparent;
            this.use_telegram_chk.Location = new System.Drawing.Point(6, 7);
            this.use_telegram_chk.Name = "use_telegram_chk";
            this.use_telegram_chk.Size = new System.Drawing.Size(211, 52);
            this.use_telegram_chk.TabIndex = 5;
            this.use_telegram_chk.Text = "Использовать телеграм для оповещений";
            this.use_telegram_chk.UseVisualStyleBackColor = false;
            this.use_telegram_chk.CheckedChanged += new System.EventHandler(this.use_telegram_chk_CheckedChanged);
            // 
            // telegram_status_lbl
            // 
            this.telegram_status_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.telegram_status_lbl.Location = new System.Drawing.Point(6, 54);
            this.telegram_status_lbl.Name = "telegram_status_lbl";
            this.telegram_status_lbl.Size = new System.Drawing.Size(211, 55);
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
            // autodrom_list_chk
            // 
            this.autodrom_list_chk.FormattingEnabled = true;
            this.autodrom_list_chk.HorizontalScrollbar = true;
            this.autodrom_list_chk.Location = new System.Drawing.Point(226, 132);
            this.autodrom_list_chk.Name = "autodrom_list_chk";
            this.autodrom_list_chk.Size = new System.Drawing.Size(188, 109);
            this.autodrom_list_chk.TabIndex = 8;
            this.autodrom_list_chk.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.autodrom_list_chk_ItemCheck);
            this.autodrom_list_chk.SelectedIndexChanged += new System.EventHandler(this.autodrom_list_chk_SelectedIndexChanged);
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Группа";
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Прогерсс теории";
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(130, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Остаток часов";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Дата следующего вождения";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Доступ к вождению";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Статус телеграм";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.telega_time_out_num);
            this.groupBox2.Controls.Add(this.telegram_status_lbl);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.use_telegram_chk);
            this.groupBox2.Location = new System.Drawing.Point(12, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 172);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Телеграм";
            // 
            // telega_time_out_num
            // 
            this.telega_time_out_num.Location = new System.Drawing.Point(158, 142);
            this.telega_time_out_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.telega_time_out_num.Name = "telega_time_out_num";
            this.telega_time_out_num.Size = new System.Drawing.Size(59, 20);
            this.telega_time_out_num.TabIndex = 11;
            this.telega_time_out_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 27);
            this.label11.TabIndex = 10;
            this.label11.Text = "Период отправки уведомлений в минутах";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.time_filter_dtp);
            this.groupBox3.Controls.Add(this.fio_teacher_txt);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.selected_autodrom_list);
            this.groupBox3.Controls.Add(this.only_end_chk);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.end_time_dtp);
            this.groupBox3.Controls.Add(this.start_time_dtp);
            this.groupBox3.Location = new System.Drawing.Point(249, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 298);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Фильтры оповещения";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 124);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "Время, не позже";
            // 
            // time_filter_dtp
            // 
            this.time_filter_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time_filter_dtp.Location = new System.Drawing.Point(6, 140);
            this.time_filter_dtp.Name = "time_filter_dtp";
            this.time_filter_dtp.ShowCheckBox = true;
            this.time_filter_dtp.ShowUpDown = true;
            this.time_filter_dtp.Size = new System.Drawing.Size(170, 20);
            this.time_filter_dtp.TabIndex = 17;
            // 
            // fio_teacher_txt
            // 
            this.fio_teacher_txt.Location = new System.Drawing.Point(6, 272);
            this.fio_teacher_txt.Name = "fio_teacher_txt";
            this.fio_teacher_txt.Size = new System.Drawing.Size(171, 20);
            this.fio_teacher_txt.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Фамилия преподавателя";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Выбранные площадки";
            // 
            // selected_autodrom_list
            // 
            this.selected_autodrom_list.FormattingEnabled = true;
            this.selected_autodrom_list.Location = new System.Drawing.Point(6, 181);
            this.selected_autodrom_list.Name = "selected_autodrom_list";
            this.selected_autodrom_list.Size = new System.Drawing.Size(171, 69);
            this.selected_autodrom_list.TabIndex = 14;
            // 
            // only_end_chk
            // 
            this.only_end_chk.AutoSize = true;
            this.only_end_chk.Location = new System.Drawing.Point(6, 101);
            this.only_end_chk.Name = "only_end_chk";
            this.only_end_chk.Size = new System.Drawing.Size(170, 17);
            this.only_end_chk.TabIndex = 13;
            this.only_end_chk.Text = "Искать только в день конца";
            this.only_end_chk.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Дата конца интервала";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Дата начала интервала";
            // 
            // end_time_dtp
            // 
            this.end_time_dtp.CustomFormat = "dd.MM.yyyy";
            this.end_time_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.end_time_dtp.Location = new System.Drawing.Point(6, 75);
            this.end_time_dtp.Name = "end_time_dtp";
            this.end_time_dtp.Size = new System.Drawing.Size(171, 20);
            this.end_time_dtp.TabIndex = 1;
            // 
            // start_time_dtp
            // 
            this.start_time_dtp.CustomFormat = "dd.MM.yyyy";
            this.start_time_dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.start_time_dtp.Location = new System.Drawing.Point(6, 35);
            this.start_time_dtp.Name = "start_time_dtp";
            this.start_time_dtp.Size = new System.Drawing.Size(171, 20);
            this.start_time_dtp.TabIndex = 0;
            // 
            // not_use_sound_chk
            // 
            this.not_use_sound_chk.Location = new System.Drawing.Point(6, 24);
            this.not_use_sound_chk.Name = "not_use_sound_chk";
            this.not_use_sound_chk.Size = new System.Drawing.Size(211, 43);
            this.not_use_sound_chk.TabIndex = 11;
            this.not_use_sound_chk.Text = "Не воспроизводить звуковой сигнал при нахождении";
            this.not_use_sound_chk.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(7, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 27);
            this.label13.TabIndex = 13;
            this.label13.Text = "Период опроса календаря в минутах";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.log_rich);
            this.groupBox4.Controls.Add(this.see_btn);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.work_time_lbl);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.all_res_list);
            this.groupBox4.Controls.Add(this.exect_res_list);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.counter_lbl);
            this.groupBox4.Location = new System.Drawing.Point(438, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(344, 498);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Результаты";
            // 
            // see_btn
            // 
            this.see_btn.Location = new System.Drawing.Point(9, 198);
            this.see_btn.Name = "see_btn";
            this.see_btn.Size = new System.Drawing.Size(86, 68);
            this.see_btn.TabIndex = 9;
            this.see_btn.Text = "Проверил";
            this.see_btn.UseVisualStyleBackColor = true;
            this.see_btn.Click += new System.EventHandler(this.see_btn_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 453);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 13);
            this.label19.TabIndex = 8;
            this.label19.Text = "Время работы";
            // 
            // work_time_lbl
            // 
            this.work_time_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.work_time_lbl.Location = new System.Drawing.Point(9, 469);
            this.work_time_lbl.Name = "work_time_lbl";
            this.work_time_lbl.Size = new System.Drawing.Size(147, 23);
            this.work_time_lbl.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(6, 132);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 37);
            this.label17.TabIndex = 6;
            this.label17.Text = "Совпадения по фильтру";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(6, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 42);
            this.label16.TabIndex = 5;
            this.label16.Text = "Доступные варианты";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(693, 516);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(89, 41);
            this.stop_btn.TabIndex = 15;
            this.stop_btn.Text = "Стоп";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // time_out_num
            // 
            this.time_out_num.Location = new System.Drawing.Point(159, 74);
            this.time_out_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.time_out_num.Name = "time_out_num";
            this.time_out_num.Size = new System.Drawing.Size(59, 20);
            this.time_out_num.TabIndex = 16;
            this.time_out_num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.time_out_num);
            this.groupBox5.Controls.Add(this.not_use_sound_chk);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(12, 437);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(231, 120);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Настройки парсера";
            // 
            // log_rich
            // 
            this.log_rich.Location = new System.Drawing.Point(9, 334);
            this.log_rich.Name = "log_rich";
            this.log_rich.Size = new System.Drawing.Size(329, 116);
            this.log_rich.TabIndex = 10;
            this.log_rich.Text = "";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 318);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 13);
            this.label20.TabIndex = 11;
            this.label20.Text = "Лог";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 567);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.Text = "Парсер школы";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.school_img)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.telega_time_out_num)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time_out_num)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox all_res_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label counter_lbl;
        private System.Windows.Forms.ListBox exect_res_list;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox fio_teacher_txt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox selected_autodrom_list;
        private System.Windows.Forms.CheckBox only_end_chk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker end_time_dtp;
        private System.Windows.Forms.DateTimePicker start_time_dtp;
        private System.Windows.Forms.CheckBox not_use_sound_chk;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label work_time_lbl;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.NumericUpDown telega_time_out_num;
        private System.Windows.Forms.NumericUpDown time_out_num;
        private System.Windows.Forms.DateTimePicker time_filter_dtp;
        private System.Windows.Forms.Button see_btn;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.RichTextBox log_rich;
    }
}

