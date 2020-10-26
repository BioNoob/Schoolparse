using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using TLSharp.Core;

namespace Schoolparse
{
    static public class StaticInfo
    {
        public delegate void LoginSchool(DataUser dp);
        public static event LoginSchool Ev_LoginSchool;
        public static void Do_LoginSchool(DataUser dp)
        {
            Ev_LoginSchool?.Invoke(dp);
        }

        public delegate void LoginTelegram(TelegramWorker tlw);
        public static event LoginTelegram Ev_LoginTelegram;
        public static void Do_LoginTelegram(TelegramWorker tlw)
        {
            Ev_LoginTelegram?.Invoke(tlw);
        }
        public static string VeriToken = string.Empty;
        public enum LoginState
        {
            succ,
            denied,
            error
        }
        public static string login;
        public static string pass;
        public static async Task<LoginState> Relogin()
        {
            WebClient wc = new WebClient();
            DataUser plochadki_class = new DataUser();
            wc.Encoding = Encoding.UTF8;
            var request = (HttpWebRequest)WebRequest.Create("https://app.dscontrol.ru/Login");
            var postData = $"Login={login}";
            postData += "&TextPassword=";
            byte[] bytes = Encoding.Default.GetBytes(pass);
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
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                return LoginState.denied;
            }
            var aa = response.Headers["Set-Cookie"].Split(';')[0];
            var za = wc.DownloadString("https://app.dscontrol.ru/Api/StudentSchedulerList?Kinds=D&OnlyMine=falsetimeshift=-360&from=2020-10-01&to=2020-10-30");

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
                plochadki = wc.DownloadString("https://app.dscontrol.ru/api/MobilePersonalData");
                try
                {
                    plochadki_class = JsonConvert.DeserializeObject<DataUser>(plochadki);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return LoginState.error;
                }
            }
            return LoginState.succ;
        }
    }
    public class TelegBotWithID
    {
        public TelegramBotClient BotClient {get;set;}
        public int BotChatID { get; set; }
    }
    public class FilterSettings
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public TimeSpan TimeStart { get; set; }
        public List<ItemUser.Autodrome> SelectedAutodromes { get; set; }
        public string TeacherLast { get; set; }
        public override string ToString()
        {
            string drome = "";
            foreach (var item in SelectedAutodromes)
            {
                drome += item.Name + "\n";
            }
            if (SelectedAutodromes.Count < 1)
                drome = "Все";

            return $"Дата начала {DateStart.ToString("dd.MM")}\nДата конца {DateEnd.ToString("dd.MM")}\n" +
                $"Время старта занятия больше чем {string.Format("{0:00}:{1:00}:{2:00}",TimeStart.Hours,TimeStart.Minutes,TimeStart.Seconds)}\nВыбранные площадки \"{drome}\"\n" +
                $"Искомая фамилия учителя \"{TeacherLast}\"";
        }
    }
    public class DataCalender
    {
        public List<ItemDrive> data { get; set; }
    }
    public partial class DataUser
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public ItemUser Data { get; set; }
    }
    public class ItemDrive : IEquatable<ItemDrive>
    {
        public string Key { get; set; }
        public int Id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int State { get; set; }
        public bool Completed { get; set; }
        [JsonProperty("DriveSessionTypeId")]
        public int DriveID { get; set; }
        [JsonProperty("AutodromeId")]
        public int autodrom { get; set; }
        public override string ToString()
        {
            return $"{EmployeeName} :: {start_date}";
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as ItemDrive);
        }

        public bool Equals(ItemDrive other)
        {
            if (other == null)
                return false;
            if (Key == other.Key & Id == other.Id & start_date == other.start_date & end_date == other.end_date &
                EmployeeId == other.EmployeeId & EmployeeName == other.EmployeeName & State == other.State &
                Completed == other.Completed & autodrom == other.autodrom)
            {
                return true;
            }
            else
                return false;
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
        public DateTime? NextDriveDateLocal { get; set; }
        //!!!!!!!!!!!!!!!! NULL CHECK

        [JsonProperty("GroupName")]
        public string GroupName { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Autodromes")]
        public List<Autodrome> Autodromes { get; set; }
        [JsonProperty("Wallets")]
        public List<Wallet> Wallets { get; set; }
        [JsonProperty("SessionTypes")]
        public List<SessionType> SessionTypes { get; set; }
        [JsonProperty("Tokens")]
        public List<Token> Tokens { get; set; }

        public void GetTotalDrive()
        {
            List<Token> asdf = new List<Token>();
            foreach (var item in Wallets)
            {
                asdf.Add(Tokens.Where(t => t.Id == item.TokenId).ToList().FirstOrDefault());
            }
            foreach (var item in asdf)
            {
                SessionTypes.Where(t => t.Color == item.Color).Select(w=>w.Id).ToList();
            }

        }
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
        public partial class SessionType
        {
            [JsonProperty("Id")]
            public long Id { get; set; }

            [JsonProperty("Color")]
            public string Color { get; set; }

            [JsonProperty("Code")]
            public string Code { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("IsDefault")]
            public bool IsDefault { get; set; }

            [JsonProperty("ForStudents")]
            public bool ForStudents { get; set; }

            [JsonProperty("Hidden")]
            public bool Hidden { get; set; }
        }
        public partial class Token
        {
            [JsonProperty("Id")]
            public long Id { get; set; }

            [JsonProperty("Color")]
            public string Color { get; set; }

            [JsonProperty("Code")]
            public string Code { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }

            [JsonProperty("Order")]
            public long Order { get; set; }

            [JsonProperty("Hidden")]
            public bool Hidden { get; set; }

            [JsonProperty("AllowAdd")]
            public bool AllowAdd { get; set; }

            [JsonProperty("AllowWriteOff")]
            public bool AllowWriteOff { get; set; }
        }
        public partial class Wallet
        {
            [JsonProperty("TokenId")]
            public long TokenId { get; set; }

            [JsonProperty("Balance")]
            public long Balance { get; set; }
        }
    }
}
