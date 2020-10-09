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

    }
}
