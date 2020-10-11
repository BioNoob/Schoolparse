using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Schoolparse
{
    public partial class AutoSchoolAuth : Form
    {
        WebClient wc = new WebClient();
        public AutoSchoolAuth()
        {
            InitializeComponent();
            wc.Encoding = System.Text.Encoding.UTF8;
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            wc.Headers.Clear();
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
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var aa = response.Headers["Set-Cookie"].Split(';')[0];
            var za = wc.DownloadString("https://app.dscontrol.ru/Api/StudentSchedulerList?Kinds=D&OnlyMine=falsetimeshift=-360&from=2020-10-01&to=2020-10-30");
            DataUser plochadki_class = new DataUser();
            string plochadki = string.Empty;
            try
            {
                var zs = JsonConvert.DeserializeObject<DataCalender>(za);
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
                plochadki = wc.DownloadString("https://app.dscontrol.ru/api/MobilePersonalData");
                try
                {
                    plochadki_class = JsonConvert.DeserializeObject<DataUser>(plochadki);
                    StaticInfo.Do_LoginSchool(plochadki_class);
                    this.Close();
                    return;
                }
                catch (Exception)
                {
                    status_lbl.Text = "Ошибка логина";
                }

            }
            plochadki = wc.DownloadString("https://app.dscontrol.ru/api/MobilePersonalData");
            plochadki_class = JsonConvert.DeserializeObject<DataUser>(plochadki);
            StaticInfo.Do_LoginSchool(plochadki_class);
            this.Close();
        }
    }
}
