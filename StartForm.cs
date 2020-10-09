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
        int api_id = 1929836;
        string api_hash = "71b59f552c59293894b11ee9479ff72f";
        TelegramBotClient botClient;
        string hash;

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

                //foreach (var item in dta.Autodromes)
                //{
                //    //autodrom_list.
                //    autodrom_list.Items.Add(item);
                //}
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

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            Task.Run(async () =>
            {
                while (true)
                {
                    i++;
                    var t = wc.DownloadString("https://app.dscontrol.ru/Api/StudentSchedulerList?Kinds=D&OnlyMine=falsetimeshift=-360&from=2020-10-01&to=2020-10-30");
                    var zs = JsonConvert.DeserializeObject<DataCalender>(t);
                    var bb = zs.data.Where(q => q.Completed != true && q.start_date.DayOfYear > DateTime.Now.DayOfYear).ToList();
                    if (bb.Count > 0)
                    {
                        //AALLLEEERT!!
                        smm.Stop();
                        smm.Play();
                        var updbot = await botClient.GetUpdatesAsync();
                        var userdialog = updbot.Where(x => x.Message.From.Id == (int)client.Session.TLUser.Id).ToList().FirstOrDefault();
                        var userdialog_id = userdialog.Message.Chat.Id;
                        await botClient.SendTextMessageAsync(userdialog_id, "Ну првет сталкер)");
                    }
                    BeginInvoke(new Action(() =>
                    {
                        listBox1.Items.Clear();
                        foreach (var item in zs.data)
                        {
                            listBox1.Items.Add(item);
                        }
                        counter_lbl.Text = i.ToString();
                        if (bb.Count > 0)
                        {
                            listBox2.Items.Clear();
                            foreach (var item in bb)
                            {
                                listBox2.Items.Add(item);
                            }
                        }
                    }));
                    GC.Collect(1, GCCollectionMode.Forced);
                    await Task.Delay(60001);
                }
            });

        }
        private async void button2_Click(object sender, EventArgs e)
        {
            TLSharp.Core.FileSessionStore store = new TLSharp.Core.FileSessionStore();

            client = new TelegramClient(api_id, api_hash, store, "session");
            await client.ConnectAsync();
            if (!client.IsUserAuthorized())
                hash = await client.SendCodeRequestAsync("+79162206436");



        }

        private void use_telegram_chk_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                if (client == null)
                //if (client != null & !client.IsUserAuthorized())
                {
                    TelegramAuth ta = new TelegramAuth();
                    ta.ShowDialog();
                }
                else
                {
                    if(!client.IsUserAuthorized())
                    {
                        TelegramAuth ta = new TelegramAuth();
                        ta.ShowDialog();
                    }
                }
            }
        }
    }
    public class DataCalender
    {
        public List<ItemSc> data { get; set; }
    }
    public partial class DataUser
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public ItemUser Data { get; set; }
    }
    public class ItemSc
    {
        public string Key { get; set; }
        public int Id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int State { get; set; }
        public bool Completed { get; set; }
        public override string ToString()
        {
            return $"{EmployeeName} :: {start_date}";
        }
    }
    public class ItemUser
    {
        [JsonProperty("Surname")]
        public string Surname { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Patronymic")]
        public string Patronymic { get; set; }

        [JsonProperty("SchoolName")]
        public string SchoolName { get; set; }

        [JsonProperty("SchoolLogoUrl")]
        public string SchoolLogoUrl { get; set; }

        [JsonProperty("AllowDrive")]
        public bool AllowDrive { get; set; }

        [JsonProperty("Balance")]
        public long Balance { get; set; }

        [JsonProperty("MethodicProgress")]
        public long MethodicProgress { get; set; }

        [JsonProperty("NextDriveDateLocal")]
        public DateTimeOffset NextDriveDateLocal { get; set; }

        [JsonProperty("GroupName")]
        public string GroupName { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Autodromes")]
        public List<Autodrome> Autodromes { get; set; }

        public partial class Autodrome
        {
            [JsonProperty("Id")]
            public long Id { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }
            public override string ToString()
            {
                return $"{Id} {Name}";
            }
        }
    }
}
