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

        public delegate void LoginTelegram(TelegramClient state, TelegramBotClient bot);
        public static event LoginTelegram Ev_LoginTelegram;
        public static void Do_LoginTelegram(TelegramClient state, TelegramBotClient bot)
        {
            Ev_LoginTelegram?.Invoke(state,bot);
        }
        public static string VeriToken = string.Empty;
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
    public class ItemDrive
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
