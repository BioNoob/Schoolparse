﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TLSharp.Core;

namespace Schoolparse
{
    public partial class StartForm : Form
    {
        static string ExPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\alarm.wav";
        System.Media.SoundPlayer smm = new System.Media.SoundPlayer();
        WebClient wc = new WebClient();
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken token;
        System.Windows.Forms.Timer work_timer = new System.Windows.Forms.Timer();
        DateTime start_time;
        List<ItemDrive> ConfirmItems { get; set; }
        public bool BotCommand = false;

        TelegramWorker Tlw;

        public StartForm()
        {
            InitializeComponent();
            smm.SoundLocation = ExPath;
            smm.LoadAsync();
            wc.Encoding = System.Text.Encoding.UTF8;
            StaticInfo.Ev_LoginTelegram += StaticInfo_Ev_LoginTelegram;
            StaticInfo.Ev_LoginSchool += StaticInfo_Ev_LoginSchool;
            this.Visible = false;
            AutoSchoolAuth au = new AutoSchoolAuth();
            au.ShowDialog();
            stop_btn.Enabled = false;
            see_btn.Enabled = false;
            end_time_dtp.Value = DateTime.Now.AddDays(7);
            token = tokenSource.Token;
            time_filter_dtp.Checked = false;
            work_timer.Interval = 100;
            work_timer.Tick += Work_timer_Tick;
            this.FormClosed += StartForm_FormClosed;
        }


        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Tlw != null)
                Tlw.StopTelegramBot();
        }
        DateTime dt_telegram_start;
        List<ItemDrive> FilteredList;
        private void Work_timer_Tick(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
                {
                    var a = (DateTime.Now - start_time);
                    work_time_lbl.Text = string.Format("{0:00}:{1:00}:{2:00}", a.Hours, a.Minutes, a.Seconds);
                }
                ));
            if (use_telegram_chk.Checked)
            {
                string str = "";
                foreach (var item in FilteredList)
                {
                    str += $"{item}\n";
                }
                Tlw.SendData = str;
            }

        }

        ItemUser _LocalUser { get; set; }
        StaticInfo.LoginState _StateLocUser {get;set;}

        private async void StaticInfo_Ev_LoginSchool(DataUser dp, bool relog)
        {
            _LocalUser = dp.Data;
            _StateLocUser = dp.Success;
            if (dp != null)
            {
                fio_lbl.Text = _LocalUser.Name + " " + _LocalUser.Surname + " " + _LocalUser.Patronymic;
                group_lbl.Text = _LocalUser.GroupName;
                school_name_lbl.Text = _LocalUser.SchoolName;
                theory_progress_lbl.Text = _LocalUser.MethodicProgress.ToString();
                category_lbl.Text = _LocalUser.Category;
                drive_status_lbl.Text = _LocalUser.AllowDrive ? "Да" : "Нет";
                balance_lbl.Text = _LocalUser.Balance.ToString();
                date_of_driving_lbl.Text = _LocalUser.NextDriveDateLocal.ToString();
                if(!relog)
                {
                    var b = _LocalUser.GetTotalDrive;
                    foreach (var item in b)
                    {
                        autodrom_list_chk.Items.Add(item, true);
                    }
                    this.Visible = true;
                    if (!string.IsNullOrEmpty(_LocalUser.SchoolLogoUrl))
                        school_img.BackgroundImage = await GetImage(_LocalUser.SchoolLogoUrl);
                }

            }
        }
        public async Task<Image> GetImage(string imageUrl)
        {
            Bitmap bitmap = null;
            if (string.IsNullOrEmpty(imageUrl))
                return null;
            await Task.Run(() =>
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead(imageUrl);
                bitmap = new Bitmap(stream);
                stream.Flush();
                stream.Close();
                client.Dispose();
            });

            if (bitmap != null)
            {
                return bitmap;
            }
            else
                return null;
        }
        private void StaticInfo_Ev_LoginTelegram(TelegramWorker tlw)
        {
            Tlw = tlw;
            telegram_status_lbl.Text = "Телеграм успешно подключен";
        }


        private async void Tlw_MessgeRecive(TelegramWorker.MessgeType state)
        {
            switch (state)
            {
                case TelegramWorker.MessgeType.help:
                    await Tlw.BotSendMess("Привет, я твой оповещатор!\nМои команды:\n" +
    "/i_got_it - Вы говорите мне что приняли мое оповещение. Я буду искать другие варианты. И оповещать вас о них!\n" +
    "/stop_watch - Остановлю работу программы парсер\n" +
    "/go_watch - Запущу программу парсер дальше\n" +
    "/get_settings - Отправлю текущие настройки парсера");
                    break;
                case TelegramWorker.MessgeType.start:
                    if (button1.Enabled)
                    {
                        await Tlw.BotSendMess("Я запустил парсер в работу");
                        BeginInvoke(new Action(() => button1.PerformClick()));
                        BotCommand = true;
                    }
                    else
                    {
                        await Tlw.BotSendMess("Я уже работаю..");
                    }
                    break;
                case TelegramWorker.MessgeType.stop:
                    if (stop_btn.Enabled)
                    {
                        await Tlw.BotSendMess("Я остановил парсер!");
                        BeginInvoke(new Action(() => stop_btn.PerformClick()));
                    }
                    else
                    {
                        await Tlw.BotSendMess("Я уже остановлен..");
                    }
                    break;
                case TelegramWorker.MessgeType.seen:
                    if (see_btn.Enabled)
                    {
                        BeginInvoke(new Action(() => see_btn.PerformClick()));
                        await Tlw.BotSendMess("Понял. Не спамлю, ищу дальше)");
                    }
                    else
                        await Tlw.BotSendMess("Я не работаю(");
                    break;
                case TelegramWorker.MessgeType.hi:
                    await Tlw.BotSendMess("И снова здаравствуй!");
                    break;
                case TelegramWorker.MessgeType.getsettings:
                    GetSettings();
                    await Tlw.BotSendMess(filterSettings.ToString());
                    break;
                case TelegramWorker.MessgeType.setsetting:
                    break;
                default:
                    await Tlw.BotSendMess("Я не знаю таких комманд(");
                    break;
            }
        }

        //student info theory https://app.dscontrol.ru/Api/StudentLessons?StudentId=433390
        //SEEEEEEEEEEEEEEEEEE https://tlgrm.ru/docs/bots/api
        FilterSettings filterSettings = new FilterSettings();
        void GetSettings()
        {
            filterSettings.DateEnd = end_time_dtp.Value;
            filterSettings.DateStart = start_time_dtp.Value;
            if (only_end_chk.Checked)
            {
                filterSettings.DateStart = filterSettings.DateEnd;
            }
            filterSettings.TeacherLast = fio_teacher_txt.Text;
            filterSettings.TimeStart = time_filter_dtp.Value.TimeOfDay;
            filterSettings.SelectedAutodromes = selected_autodrom_list.Items.Cast<ItemUser.FilterDrome>().ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //fl_to_stop = false;
            ConfirmItems = new List<ItemDrive>();
            FilteredList = new List<ItemDrive>();
            button1.Enabled = false;
            stop_btn.Enabled = true;
            use_telegram_chk.Enabled = false;
            not_use_sound_chk.Enabled = false;
            see_btn.Enabled = true;
            //bool checked_use_time = time_filter_dtp.Checked;
            StartWork(time_filter_dtp.Checked);

        }
        public void StartWork(bool checked_use_time)
        {
            if (!BotCommand)
            {
                if (start_time_dtp.Value < DateTime.Now)
                {
                    if (MessageBox.Show($"Выбранная дата {start_time_dtp.Value}\nРанее чем сегодняшняя.\nПродолжить поиск?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    {
                        button1.Enabled = true;
                        use_telegram_chk.Enabled = true;
                        not_use_sound_chk.Enabled = true;
                        stop_btn.Enabled = false;
                        see_btn.Enabled = false;
                        return;
                    }
                }
            }
            BotCommand = false;
            GetSettings();

            dt_telegram_start = start_time = DateTime.Now;

            work_timer.Start();
            string dt_st = filterSettings.DateStart.ToString("yyyy-MM-dd");
            string dt_en = filterSettings.DateEnd.ToString("yyyy-MM-dd");
            string famtecher = filterSettings.TeacherLast;
            string buf_response = string.Empty;
            //if (only_end_chk.Checked)
            //    dt_st = dt_en;


            if (use_telegram_chk.Checked)
            {
                Tlw.StartTelegramMonitor((int)telega_time_out_num.Value);
            }
            int i = 0;
            Task.Run(async () =>
            {
                while (true)
                {
                    i++;
                    try
                    {
                        wc.Headers.Clear();
                        wc.Headers.Add(HttpRequestHeader.Cookie, StaticInfo.VeriToken);
                        buf_response = wc.DownloadString($"https://app.dscontrol.ru/Api/StudentSchedulerList?Kinds=D&OnlyMine=false&timeshift=-360&from={dt_st}&to={dt_en}");
                        _LocalUser.DriveData = JsonConvert.DeserializeObject<DataCalender>(buf_response);
                    }
                    catch (Exception ex)
                    {
                        await StaticInfo.Relogin();
                        if ( _StateLocUser != StaticInfo.LoginState.succ)
                        {
                            BeginInvoke(new Action(() =>
                            {
                                log_rich.AppendText($"Выбило из учетки, повторный логин провален\n");
                                stop_btn.PerformClick();
                            }));

                            return;
                        }
                        else
                        {
                            BeginInvoke(new Action(() =>
                            {
                                log_rich.AppendText($"Выбило из учетки, повторный логин проведен\n");
                            }));
                        }
                        var bb = "";
                        if (string.IsNullOrEmpty(buf_response))
                        {
                            bb = buf_response;
                        }
                        BeginInvoke(new Action(() =>
                        {
                            log_rich.AppendText($"Ошибка {ex.Message}! Тип {ex.InnerException}\nОтвет был {bb}\n");
                        }));
                    }

                    var cnt = _LocalUser.DriveData.data.Count;

                    _LocalUser.DriveData.data = _LocalUser.DriveData.data.Where(q => q.Completed != true && q.State != 1 && q.start_date.DayOfYear >= filterSettings.DateStart.DayOfYear).ToList(); //первыичный фильтр, завершено или нет, состояние 1 = записан, 2 = не записан, дата больше чем дата старта
                    var cnt2 = cnt - _LocalUser.DriveData.data.Count;
                    FilteredList = _LocalUser.DriveData.data.Where(q => q.EmployeeName.Contains(famtecher)).ToList(); //фильтр фамилии
                    foreach (var item in ConfirmItems)
                    {
                        if (FilteredList.Contains(item))
                            FilteredList.Remove(item);
                    }
                    if (filterSettings.SelectedAutodromes.Count > 0)
                    {
                        //фильтр площадок по айди
                        foreach (var item in filterSettings.SelectedAutodromes)
                        {
                            FilteredList = FilteredList.Where(q => q.DriveID == item.SessionId).ToList();
                        }
                    }
                    //тут будет фильтр времени
                    if (checked_use_time)
                    {
                        FilteredList = FilteredList.Where(q => q.start_date.TimeOfDay >= filterSettings.TimeStart).ToList();
                    }

                    if (FilteredList.Count > 0)
                    {
                        if (!not_use_sound_chk.Checked)
                        {
                            smm.Stop();
                            smm.Play();
                        }
                    }
                    BeginInvoke(new Action(() =>
                    {
                        log_rich.AppendText($"{work_time_lbl.Text} Найдено без фильтров {cnt}\n");
                        log_rich.AppendText($"{work_time_lbl.Text} После первичного осталось {cnt - cnt2}\n");
                        log_rich.AppendText($"{work_time_lbl.Text} И того осталось {FilteredList.Count}\n");
                        //log_rich.AppendText(buf_response + "\n");
                        log_rich.ScrollToCaret();

                        all_res_list.Items.Clear();
                        exect_res_list.Items.Clear();
                        not_filtered_list.Items.Clear();
                        foreach (var item in _LocalUser.DriveData.data)
                        {
                            not_filtered_list.Items.Add(item);
                        }
                        var st = from aw in _LocalUser.GetTotalDrive
                                 join bw in _LocalUser.DriveData.data
                                 on aw.SessionId equals bw.DriveID
                                 select bw;
                        all_res_list.Items.AddRange(st.ToArray());

                        //foreach (var item in _LocalUser.DriveData.data)
                        //{
                        //    _LocalUser.GetTotalDrive.Where(t=>t.SessionId == item.Drive
                        //    if(item.DriveID != _LocalUser.)
                        //}

                        //all_res_list.Items.AddRange(_LocalUser.DriveData.data.Where(t=>t.));
                        counter_lbl.Text = i.ToString();
                        if (FilteredList.Count > 0)
                        {
                            exect_res_list.Items.Clear();
                            foreach (var item in FilteredList)
                            {
                                exect_res_list.Items.Add(item);
                            }
                        }
                    }));
                    GC.Collect(1, GCCollectionMode.Forced);
                    await Task.Delay((int)(time_out_num.Value * 59950)); //запас на телегу на 50 мил сек
                }
            }, token);
        }
        private void use_telegram_chk_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult aa = DialogResult.None;
            if ((sender as CheckBox).Checked)
            {
                if (Tlw == null)
                //if (client != null & !client.IsUserAuthorized())
                {
                    TelegramAuth ta = new TelegramAuth();
                    aa = ta.ShowDialog();
                }
                else
                {
                    if (!Tlw.TelClient.IsUserAuthorized())
                    {
                        TelegramAuth ta = new TelegramAuth();
                        aa = ta.ShowDialog();
                    }
                }
            }
            if (aa != DialogResult.OK)
            {
                use_telegram_chk.CheckedChanged -= use_telegram_chk_CheckedChanged;
                use_telegram_chk.Checked = false;
                use_telegram_chk.CheckedChanged += use_telegram_chk_CheckedChanged;
            }
            else
            {
                Tlw.MessgeRecive += Tlw_MessgeRecive;
            }
        }

        //добавитть удаление
        private void autodrom_list_chk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void autodrom_list_chk_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            selected_autodrom_list.Items.Clear();
            foreach (var item in autodrom_list_chk.CheckedItems)
            {
                selected_autodrom_list.Items.Add(item);
            }
            if (e.NewValue == CheckState.Checked)
            {
                selected_autodrom_list.Items.Add(autodrom_list_chk.Items[e.Index]);
            }
            else
            {
                selected_autodrom_list.Items.Remove(autodrom_list_chk.Items[e.Index]);
            }
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            //fl_to_stop = true;
            tokenSource.Cancel();
            BeginInvoke(new Action(() =>
            {
                smm.Stop();
                button1.Enabled = true;
                use_telegram_chk.Enabled = true;
                not_use_sound_chk.Enabled = true;
                stop_btn.Enabled = false;
                see_btn.Enabled = false;
                work_timer.Stop();
                if (Tlw != null && Tlw.IsListning)
                    Tlw.StopTelegramMonitor();
                return;
            }));
        }

        private void see_btn_Click(object sender, EventArgs e)
        {
            smm.Stop();
            if (exect_res_list.Items.Count > 0)
            {
                ConfirmItems.AddRange(exect_res_list.Items.Cast<ItemDrive>());
                foreach (var item in ConfirmItems)
                {
                    if (FilteredList.Contains(item))
                        FilteredList.Remove(item);
                }
                exect_res_list.Items.Clear();
            }

        }
    }
}
