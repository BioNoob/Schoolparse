using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoolparse
{
    public partial class AutoSchoolAuth : Form
    {
        WebClient wc = new WebClient();
        DataUser plochadki_class = new DataUser();
        public AutoSchoolAuth()
        {
            InitializeComponent();
            wc.Encoding = System.Text.Encoding.UTF8;
            this.FormClosed += AutoSchoolAuth_FormClosed;
        }

        private void AutoSchoolAuth_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticInfo.Do_LoginSchool(plochadki_class);
        }

        private async void login_btn_Click(object sender, EventArgs e)
        {
            wc.Headers.Clear();
            pictureBox1.Visible = true;
            var request = (HttpWebRequest)WebRequest.Create("https://app.dscontrol.ru/Login");
            var postData = $"Login={login_txt.Text}";
            postData += "&TextPassword=";
            byte[] bytes = Encoding.Default.GetBytes(pass_txt.Text);
            postData += $"&Password={Encoding.UTF8.GetString(bytes)}";
            postData += "&PreventPass=false";
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.Accept = "*/*";
            request.Referer = "https://app.dscontrol.ru/login";
            await Task.Run(() =>
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                HttpWebResponse response;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (Exception)
                {
                    BeginInvoke(new Action(() => pictureBox1.Visible = false));
                    BeginInvoke(new Action(() => status_lbl.Text = "Ошибка логина"));
                    return;
                }

                var aa = response.Headers["Set-Cookie"].Split(';')[0];
                var za = wc.DownloadString("https://app.dscontrol.ru/Api/StudentSchedulerList?Kinds=D&OnlyMine=false&timeshift=-360&from=2020-10-01&to=2020-10-30");

                string plochadki = string.Empty;
                try
                {
                    var zs = JsonConvert.DeserializeObject<DataCalender>(za);
                    plochadki = wc.DownloadString("https://app.dscontrol.ru/api/MobilePersonalData");
                    plochadki_class = JsonConvert.DeserializeObject<DataUser>(plochadki);
                }
                catch (Exception)
                {
                    HtmlAgilityPack.HtmlDocument hd = new HtmlAgilityPack.HtmlDocument();
                    hd.LoadHtml(za);
                    HtmlNode formNode = hd.DocumentNode.SelectSingleNode("//input[@name='__RequestVerificationToken']");
                    var signupFormId = formNode.GetAttributeValue("value", "");
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    var abb = $"__RequestVerificationToken={signupFormId}; {aa};";
                    StaticInfo.VeriToken = abb;
                    wc.Headers.Add(HttpRequestHeader.Cookie, abb);

                    //из токенов выбрать айди = валетовским айди
                    //получить сешентайп с цветом равным выбранным токенам
                    //лист сешнтайп айди = айди площадок при поиске


                    plochadki = wc.DownloadString("https://app.dscontrol.ru/api/MobilePersonalData");
                    try
                    {
                        plochadki_class = JsonConvert.DeserializeObject<DataUser>(plochadki);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        BeginInvoke(new Action(() => pictureBox1.Visible = false));
                        BeginInvoke(new Action(() => status_lbl.Text = "Ошибка логина"));
                        return;
                    }
                }
            });
            if (plochadki_class.Success)
            {
                StaticInfo.login = login_txt.Text;
                StaticInfo.pass = pass_txt.Text;
                DoEnd(plochadki_class);
            }

        }

        private void DoEnd(DataUser dt)
        {
            BeginInvoke(new Action(() =>
            {
                //pictureBox1.Visible = false;
                this.Close();
            }));
        }
    }
}
