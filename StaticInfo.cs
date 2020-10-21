using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public DateTimeOffset NextDriveDateLocal { get; set; }
        //!!!!!!!!!!!!!!!! NULL CHECK

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
