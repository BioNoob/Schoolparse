using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeleSharp.TL;
using TLSharp.Core;

namespace Schoolparse
{
    public partial class Form1 : Form
    {
        static string ExPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\alarm.wav";
        System.Media.SoundPlayer smm = new System.Media.SoundPlayer();
        WebClient wc = new WebClient();
        public Form1()
        {
            InitializeComponent();
            smm.SoundLocation = ExPath;
            smm.LoadAsync();
            wc.Encoding = System.Text.Encoding.UTF8;
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
        private void login_btn_Click(object sender, EventArgs e)
        {
            wc.Headers.Clear();
            var request = (HttpWebRequest)WebRequest.Create("https://app.dscontrol.ru/Login");
            var postData = "Login=43339046";
            postData += "&TextPassword=";
            postData += "&Password=FVAC%24";
            postData += "&PreventPass=false";
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.Accept = "*/*";
            request.Referer = "https://app.dscontrol.ru/login";
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var aa = response.Headers["Set-Cookie"].Split(';')[0];
            var za = wc.DownloadString("https://app.dscontrol.ru/Api/StudentSchedulerList?Kinds=D&OnlyMine=falsetimeshift=-360&from=2020-10-01&to=2020-10-30");
            HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
            hd.LoadHtml(za);
            HtmlNode formNode = hd.DocumentNode.SelectSingleNode("//input[@name='__RequestVerificationToken']");
            var signupFormId = formNode.GetAttributeValue("value", "");
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var abb = $"__RequestVerificationToken={signupFormId}; {aa};";
            wc.Headers.Add(HttpRequestHeader.Cookie, abb);
            var plochadki = wc.DownloadString("https://app.dscontrol.ru/api/AutodromeList");
            var plochadki_class = JsonConvert.DeserializeObject<DataPlace>(plochadki);
        }
        public static TelegramClient tc;
        private async void button2_Click(object sender, EventArgs e)
        {
            tc = new TelegramClient(1929836, "71b59f552c59293894b11ee9479ff72f");
            await tc.ConnectAsync();
           
            if(!tc.IsUserAuthorized())
            {
                var hash = await tc.SendCodeRequestAsync("+79162206436");
            }
            //else
            //{
            //    telega_code_txt.Text = "UUUUU";
            //}
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var code = telega_code_txt.Text; // you can change code in debugger
            var user = await tc.MakeAuthAsync("+79162206436", "71b59f552c59293894b11ee9479ff72f", code);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var result = await tc.GetContactsAsync();

            //find recipient in contacts
            var user = result.Users
                .Where(x => x.GetType() == typeof(TLUser))
                .Cast<TLUser>()
                .FirstOrDefault(x => x.Phone == "+79162206436");

            //send message
            await tc.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id }, "HELLO MA FACKA FROM PC");
        }
    }
    public class DataCalender
    {
        public List<ItemSc> data { get; set; }
    }
    public class DataPlace
    {
        public List<ItemPlace> data { get; set; }
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
    public class ItemPlace
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public override string ToString()
        {
            return $"{Id} :: {Name}";
        }
    }
}
