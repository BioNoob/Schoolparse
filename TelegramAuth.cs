using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TLSharp.Core;

namespace Schoolparse
{
    public partial class TelegramAuth : Form
    {
        TelegramClient client;
        int api_id = 1929836;
        string api_hash = "71b59f552c59293894b11ee9479ff72f";
        string hash = string.Empty;
        int BotId = 0;
        TelegramBotClient botClient = new TelegramBotClient("1364306156:AAGmMNZa1wOqL0LtKemcpYOYGEKXNvrJIpM");
        public TelegramAuth()
        {
            InitializeComponent();
            start_auth_telegram_btn.Enabled = false;
            Load += TelegramAuth_Load;
            status_lbl.Text = "Запрос связи с ботом..";
        }

        private  async void TelegramAuth_Load(object sender, EventArgs e)
        {
            BotId = await StartBot();
            if (BotId < 1)
            {
                status_lbl.Text = "Связь с ботом не установлена..";
            }
            else
            {
                status_lbl.Text = "Бот запущен..\nВойдите в телеграм..";
            }
            
        }

        private async Task<int> StartBot()
        {
            try
            {
                var me = await botClient.GetMeAsync();
                return me.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        private async void start_auth_telegram_Click(object sender, EventArgs e)
        {
            TLSharp.Core.FileSessionStore store = new TLSharp.Core.FileSessionStore();
            client = new TelegramClient(api_id, api_hash, store, "session");
            try
            {
                await client.ConnectAsync();
                if (!client.IsUserAuthorized())
                {
                    hash = await client.SendCodeRequestAsync("+79162206436");
                    confirm_code_btn.Enabled = true;
                    telega_code_txt.Enabled = true;
                    status_lbl.Text = "Нужно подверждение..";
                }
                else
                {
                    status_lbl.Text = "Авторизация успешна..";
                    StartDialogBot();
                    //StaticInfo.Do_LoginTelegram(client, botClient);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async void confirm_code_btn_Click(object sender, EventArgs e)
        {
            var code = telega_code_txt.Text;  // this is a TextBox that you must insert the code that Telegram sent to you
            try
            {
                var user = await client.MakeAuthAsync("+79162206436", hash, code);
                status_lbl.Text = "Авторизация успешна..";
                StartDialogBot();
                //StaticInfo.Do_LoginTelegram(client, botClient);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async void StartDialogBot()
        {
            var dialogsResult = (TLDialogs)await client.GetUserDialogsAsync();
            var users = dialogsResult.Users.OfType<TLUser>();
            var bot = users.FirstOrDefault(x => x.Id == botClient.BotId);
            if (bot == null)
            {
                //написал боту
                TeleSharp.TL.Contacts.TLFound found = await this.client.SearchUserAsync("yasma_test_bot");
                long hashs = ((TeleSharp.TL.TLUser)found.Users[0]).AccessHash.Value;
                int id = ((TeleSharp.TL.TLUser)found.Users[0]).Id;
                TeleSharp.TL.TLInputPeerUser peer = new TeleSharp.TL.TLInputPeerUser() { UserId = id, AccessHash = hashs };
                TeleSharp.TL.TLAbsUpdates up = await this.client.SendMessageAsync(peer, "/start");
                status_lbl.Text = "Бот установил с вами контакт..";
            }
            await Task.Delay(1000);
            status_lbl.Text = "Авторизация завершена..";
            StaticInfo.Do_LoginTelegram(client, botClient);
            await Task.Delay(1000);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void phone_num_mtxt_TextChanged(object sender, EventArgs e)
        {
            if (phone_num_mtxt.MaskCompleted)
                start_auth_telegram_btn.Enabled = true;
        }

        private void TelegramAuth_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
