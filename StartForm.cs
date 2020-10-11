using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
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
        TelegramClient client;
        //int api_id = 1929836;
        //string api_hash = "71b59f552c59293894b11ee9479ff72f";
        TelegramBotClient botClient;
        //string hash;

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
        }

        private void StaticInfo_Ev_LoginSchool(DataUser dp)
        {
            var dta = dp.Data;
            if (dp != null)
            {
                fio_lbl.Text = dta.Name + " " + dta.Surname + " " + dta.Patronymic;
                group_lbl.Text = dta.GroupName;
                school_name_lbl.Text = dta.SchoolName;
                if (!string.IsNullOrEmpty(dta.SchoolLogoUrl))
                    school_img.BackgroundImage = GetImage(dta.SchoolLogoUrl);
                theory_progress_lbl.Text = dta.MethodicProgress.ToString();
                category_lbl.Text = dta.Category;
                drive_status_lbl.Text = dta.AllowDrive ? "Да" : "Нет";
                balance_lbl.Text = dta.Balance.ToString();
                date_of_driving_lbl.Text = dta.NextDriveDateLocal.ToString();
                //autodrom_list.DataSource = dta.Autodromes;
                foreach (var item in dta.Autodromes)
                {
                    autodrom_list_chk.Items.Add(item);
                }
                this.Visible = true;
            }
        }
        public Image GetImage(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return null;
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            stream.Flush();
            stream.Close();
            client.Dispose();
            if (bitmap != null)
            {
                return bitmap;
            }
            else
                return null;
        }
        private void StaticInfo_Ev_LoginTelegram(TelegramClient state, TelegramBotClient bot)
        {
            client = state;
            botClient = bot;
            if (client.IsConnected && client.IsUserAuthorized())
                telegram_status_lbl.Text = "Телеграм успешно подключен";
        }
        //student info theory https://app.dscontrol.ru/Api/StudentLessons?StudentId=433390
        private void button1_Click(object sender, EventArgs e)
        {
            if (start_time_dtp.Value > DateTime.Now)
            {
                if (MessageBox.Show($"Выбранная дата {start_time_dtp.Value}\nРанее чем сегодняшняя.\nПродолжить поиск?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }
            }
            DateTime dt_telegram_start = DateTime.Now;
            string dt_st = start_time_dtp.Value.ToString("yyyy-MM-dd");
            string dt_en = end_time_dtp.Value.ToString("yyyy-MM-dd");
            string famtecher = fio_teacher_txt.Text;
            if (only_end_chk.Checked)
                dt_st = dt_en;
            int i = 0;
            DataCalender zs = new DataCalender();
            Task.Run(async () =>
            {
                while (true)
                {
                    i++;
                    wc.Headers.Clear();
                    wc.Headers.Add(HttpRequestHeader.Cookie, StaticInfo.VeriToken);
                    var t = wc.DownloadString($"https://app.dscontrol.ru/Api/StudentSchedulerList?Kinds=D&OnlyMine=false&timeshift=-360&from={dt_st}&to={dt_en}");
                    zs = JsonConvert.DeserializeObject<DataCalender>(t);

                    var bb = zs.data.Where(q => q.Completed != true && q.start_date.DayOfYear > start_time_dtp.Value.DayOfYear).ToList();
                    bb = bb.Where(q => q.EmployeeName.Contains(famtecher)).ToList();
                    if (selected_autodrom_list.Items.Count > 0)
                    {
                        //выборка из листа указанных площадок по айди
                        foreach (var item in selected_autodrom_list.Items)
                        {
                            var ii = item as ItemUser.Autodrome;
                            bb = bb.Where(q => q.autodrom == ii.Id).ToList();
                        }
                    }
                    if (bb.Count > 0)
                    {
                        //AALLLEEERT!!
                        if (!not_use_sound_chk.Checked)
                        {
                            smm.Stop();
                            smm.Play();
                        }
                        if (use_telegram_chk.Checked)
                        {
                            var teleg_time = (DateTime.Now - dt_telegram_start).TotalMinutes;
                            if ((int)teleg_time >= telega_time_out_num.Value)
                            {
                                var updbot = await botClient.GetUpdatesAsync();
                                var userdialog = updbot.Where(x => x.Message.From.Id == (int)client.Session.TLUser.Id).ToList().FirstOrDefault();
                                var userdialog_id = userdialog.Message.Chat.Id;
                                var str = "";
                                foreach (var item in bb)
                                {
                                    str += $"{item}\n";
                                }
                                await botClient.SendTextMessageAsync(userdialog_id, $"Внимание найдены доступные записи!\n");
                                await botClient.SendTextMessageAsync(userdialog_id, str);
                                dt_telegram_start = DateTime.Now;
                            }
                        }
                    }
                    BeginInvoke(new Action(() =>
                    {
                        all_res_list.Items.Clear();
                        foreach (var item in zs.data)
                        {
                            all_res_list.Items.Add(item);
                        }
                        counter_lbl.Text = i.ToString();
                        if (bb.Count > 0)
                        {
                            exect_res_list.Items.Clear();
                            foreach (var item in bb)
                            {
                                exect_res_list.Items.Add(item);
                            }
                        }
                    }));
                    GC.Collect(1, GCCollectionMode.Forced);
                    await Task.Delay((int)(time_out_num.Value * 60000));
                }
            });

        }
        private void use_telegram_chk_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult aa = DialogResult.None;
            if ((sender as CheckBox).Checked)
            {
                if (client == null)
                //if (client != null & !client.IsUserAuthorized())
                {
                    TelegramAuth ta = new TelegramAuth();
                    aa = ta.ShowDialog();
                }
                else
                {
                    if (!client.IsUserAuthorized())
                    {
                        TelegramAuth ta = new TelegramAuth();
                        aa = ta.ShowDialog();
                    }
                }
            }
            if(aa != DialogResult.OK)
            {
                use_telegram_chk.CheckedChanged -= use_telegram_chk_CheckedChanged;
                use_telegram_chk.Checked = false;
                use_telegram_chk.CheckedChanged += use_telegram_chk_CheckedChanged;
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
    }
}
