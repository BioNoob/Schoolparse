using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using TeleSharp.TL;
using TeleSharp.TL.Contacts;
using TeleSharp.TL.Messages;
using TLSharp.Core;

namespace Schoolparse
{
    public class TelegramWorker
    {
        private static readonly string api_hash = "71b59f552c59293894b11ee9479ff72f";
        private static readonly int api_id = 1929836;
        private static readonly string botkey = "1364306156:AAGmMNZa1wOqL0LtKemcpYOYGEKXNvrJIpM";
        public enum LoginState
        {
            success,
            confirm_req,
            denied
        }
        public enum MessgeType
        {
            help,
            start,
            stop,
            seen,
            hi,
            getsettings,
            setsetting
        }
        public delegate void StartFullHandler(LoginState state);
        public event StartFullHandler StartTelegrammEvent;
        public delegate void BotMessgeRecive(MessgeType state);
        public event BotMessgeRecive MessgeRecive;
        public TelegramClient TelClient { get; set; }
        public TelegramBotClient TelBotClient { get; set; }
        public TLUser CurrUser { get; set; }
        FileSessionStore TelSesStore { get; set; }
        public string SessionHash { get; set; }
        public int DialogBotUserID { get; set; }
        private Timer timer { get; set; }
        public string SendData { get; set; }
        public bool IsListning { get; set; }
        public TelegramWorker()
        {
            TelSesStore = new FileSessionStore();
            TelClient = new TelegramClient(api_id, api_hash, TelSesStore);
            TelBotClient = new TelegramBotClient(botkey);
            TelBotClient.OnMessage += TelBotClient_OnMessage;
        }

        public void StartTelegramMonitor(int timeout_min)
        {
            IsListning = true;
            timer = new Timer(new TimerCallback(SendByTimer), null, 1000, timeout_min * 60000);
        }
        public async void StopTelegramMonitor()
        {
            timer.Dispose();
            await BotSendMess("Сервер отключил парсер! Приходите ещё.\n");
            IsListning = false;
        }
        async void SendByTimer(object state)
        {
            if (!string.IsNullOrEmpty(SendData))
                await BotSendMess($"Внимание найдены доступные записи!\n{SendData}");
        }
        public async Task<LoginState> ClientConneectAsync(string phone_num)
        {
            try
            {
                await TelClient.ConnectAsync();
                if (!TelClient.IsUserAuthorized())
                {
                    SessionHash = await TelClient.SendCodeRequestAsync(phone_num);
                    return LoginState.confirm_req;
                }
                else
                {
                    CurrUser = TelClient.Session.TLUser;
                    return LoginState.success;
                }
            }
            catch (Exception)
            {
                return LoginState.denied;
            }
        }
        public async Task<LoginState> SendClientCodeAsync(string phone_num, string code)
        {
            try
            {
                CurrUser = await TelClient.MakeAuthAsync(phone_num, SessionHash, code);
                return LoginState.success;
            }
            catch (Exception)
            {
                return LoginState.denied;
            }

        }
        public async Task<LoginState> StartBot()
        {
            try
            {
                var me = await TelBotClient.GetMeAsync();
                return LoginState.success;
            }
            catch (Exception)
            {
                return LoginState.denied;
            }
        }
        public async Task BotClientHandshakeAsync()
        {
            var dialogsResult = (TLDialogs)await TelClient.GetUserDialogsAsync();
            var users = dialogsResult.Users.OfType<TLUser>();
            var bot = users.FirstOrDefault(x => x.Id == TelBotClient.BotId);
            //написал боту
            TLFound found = await TelClient.SearchUserAsync("yasma_test_bot");
            long hashs = ((TLUser)found.Users[0]).AccessHash.Value;
            int id = ((TLUser)found.Users[0]).Id;
            TLInputPeerUser peer = new TeleSharp.TL.TLInputPeerUser() { UserId = id, AccessHash = hashs };
            try
            {
                if (bot == null)
                {
                    await TelClient.SendMessageAsync(peer, "/start");
                }
                else
                {
                    await TelClient.SendMessageAsync(peer, "/hi_again");
                }
                var w = await TelBotClient.GetUpdatesAsync();
                var userdialog = w.Where(x => x.Message.From.Id == (int)CurrUser.Id).ToList().FirstOrDefault();
                DialogBotUserID = (int)userdialog.Message.Chat.Id;
                if (userdialog.Message.Text == "/hi_again")
                {
                    await BotSendMess("И снова здаравствуй!");
                }
                else if (userdialog.Message.Text == "/start")
                {
                    await BotSendMess("Привет, я твой оповещатор!\nМои команды:\n" +
    "/i_got_it - Вы говорите мне что приняли мое оповещение. Я буду искать другие варианты. И оповещать вас о них!\n" +
    "/stop_watch - Остановлю работу программы парсер\n" +
    "/go_watch - Запущу программу парсер дальше\n" +
    "/get_settings - Отправлю текущие настройки парсера");
                }

                TelBotClient.StartReceiving();
                StartTelegrammEvent?.Invoke(LoginState.success);
            }
            catch (Exception)
            {
                StartTelegrammEvent?.Invoke(LoginState.denied);
                return;
            }
        }
        public void StopTelegramBot()
        {
            if (TelBotClient.IsReceiving)
                TelBotClient.StopReceiving();
        }
        public async Task BotSendMess(string mess)
        {
            await TelBotClient.SendTextMessageAsync(DialogBotUserID, mess);
        }
        private void TelBotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var z = e.Message;
            if (z.From.Id == CurrUser.Id)
            {
                if (z.Text == "/start" || z.Text == "/help")
                {
                    MessgeRecive?.Invoke(MessgeType.help);
                }
                if (z.Text == "/i_got_it")
                {
                    MessgeRecive?.Invoke(MessgeType.seen);
                }
                if (z.Text == "/stop_watch")
                {
                    MessgeRecive?.Invoke(MessgeType.stop);

                }
                if (z.Text == "/go_watch")
                {
                    MessgeRecive?.Invoke(MessgeType.start);

                }
                if (z.Text == "/get_settings")
                {
                    MessgeRecive?.Invoke(MessgeType.getsettings);
                }
                if (z.Text == "/hi_again")
                {
                    MessgeRecive?.Invoke(MessgeType.hi);
                }
            }
        }
    }

}
