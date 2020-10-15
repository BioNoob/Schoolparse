using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public delegate void LoginHandler(LoginState state);
        public event LoginHandler LoginEvent;
        public delegate void LoginConfirmHandler(LoginState state);
        public event LoginConfirmHandler LoginConfirmEvent;
        public delegate void BotRunnerHandler(LoginState state);
        public event BotRunnerHandler BotRunnerEvent;

        TelegramClient TelClient { get; set; }
        TelegramBotClient TelBotClient { get; set; }
        public TLUser CurrUser { get; set; }
        FileSessionStore TelSesStore { get; set; }
        public string SessionHash { get; set; }

        public int DialogBotUserID { get; set; }


        public TelegramWorker()
        {
            TelSesStore = new FileSessionStore();
            TelClient = new TelegramClient(api_id, api_hash, TelSesStore);
            TelBotClient = new TelegramBotClient(botkey);
            TelBotClient.OnMessage += TelBotClient_OnMessage;
        }



        public async Task<LoginState> ClientConneectAsync(string phone_num)
        {
            try
            {
                await TelClient.ConnectAsync();
                if (!TelClient.IsUserAuthorized())
                {
                    SessionHash = await TelClient.SendCodeRequestAsync(phone_num);
                    //status_lbl.Text = "Нужно подверждение..";
                    return LoginState.confirm_req;
                }
                else
                {
                    //status_lbl.Text = "Авторизация успешна..";
                    //StartDialogBot();
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
            }
            catch (Exception)
            {
                //MessageBox.Show("Похоже вы заблокировали бота!\nПустите его в свою жизнь @yasma_test_bot", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //status_lbl.Text = "Бот не может с вами связаться(";
                return;
            }

            var w = await TelBotClient.GetUpdatesAsync();
            var userdialog = w.Where(x => x.Message.From.Id == (int)CurrUser.Id).ToList().FirstOrDefault();
            DialogBotUserID = (int)userdialog.Message.Chat.Id;
        }
        public async Task BotSendMess(string mess)
        {
            await TelBotClient.SendTextMessageAsync(DialogBotUserID, mess);
        }
        private async void TelBotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var z = e.Message;
            if (z.From.Id == CurrUser.Id)
            {
                if (z.Text == "/start" || z.Text == "/help")
                {
                    await BotSendMess("Привет, я твой оповещатор!\nМои команды:\n" +
                        "/i_got_it - Вы говорите мне что приняли мое оповещение. Я буду искать другие варианты. И оповещать вас о них!\n" +
                        "/stop_watch - Остановлю работу программы парсер\n" +
                        "/go_watch - Запущу программу парсер дальше\n" +
                        "/get_settings - Отправлю текущие настройки парсера");
                    //добавить команды базовых настроек фильтра (дата,время, фамилия)
                }
                if (z.Text == "/i_got_it")
                {
                    //if (see_btn.Enabled)
                    //{
                    //    BeginInvoke(new Action(() => see_btn.PerformClick()));
                    await BotSendMess("Понял. Не спамлю, ищу дальше)");
                    //}
                    //else
                    await BotSendMess("Я не работаю(");
                }
                if (z.Text == "/stop_watch")
                {
                    // if (stop_btn.Enabled)
                    //{
                    await BotSendMess("Я остановил парсер!");
                    //   BeginInvoke(new Action(() => stop_btn.PerformClick()));
                    // }
                    //else
                    //{
                    await BotSendMess("Я уже остановлен..");
                    // }

                }
                if (z.Text == "/go_watch")
                {
                    //if (button1.Enabled)
                    //{
                    await BotSendMess("Я запустил парсер в работу");
                    //    BeginInvoke(new Action(() => button1.PerformClick()));
                    //}
                    //else
                    //{
                    await BotSendMess("Я уже работаю..");
                    //}

                }
                if (z.Text == "/get_settings")
                {
                    //GetSettings();
                    //await botClient.SendTextMessageAsync(e.Message.Chat.Id, filterSettings.ToString());
                }
                if (z.Text == "/hi_again")
                {
                    await BotSendMess("И снова здаравствуй!");
                }
            }
        }
    }

}
