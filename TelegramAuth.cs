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
        //TelegramClient client;
        //int api_id = 1929836;
        //string api_hash = "71b59f552c59293894b11ee9479ff72f";
        //string hash = string.Empty;
        //int BotId = 0;
        //TelegramBotClient botClient = new TelegramBotClient("1364306156:AAGmMNZa1wOqL0LtKemcpYOYGEKXNvrJIpM");
        public TelegramWorker Tlw { get; set; }
        public TelegramAuth()
        {
            InitializeComponent();
            Tlw = new TelegramWorker();
            start_auth_telegram_btn.Enabled = false;
            Load += TelegramAuth_Load;
            status_lbl.Text = "Запрос связи с ботом..";
            Tlw.StartTelegrammEvent += Tlw_StartTelegrammEvent;
        }

        private async void Tlw_StartTelegrammEvent(TelegramWorker.LoginState state)
        {
            switch (state)
            {
                case TelegramWorker.LoginState.success:
                    //var w = await botClient.GetUpdatesAsync();
                    //var userdialog = w.Where(x => x.Message.From.Id == (int)client.Session.TLUser.Id).ToList().FirstOrDefault();
                    //dialID = (int)userdialog.Message.Chat.Id;
                    status_lbl.Text = "Бот установил с вами контакт..";
                    await Task.Delay(1000);
                    status_lbl.Text = "Авторизация завершена..";
                    StaticInfo.Do_LoginTelegram(client, new TelegBotWithID() { BotClient = botClient, BotChatID = dialID });
                    await Task.Delay(1000);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case TelegramWorker.LoginState.denied:
                    MessageBox.Show("Похоже вы заблокировали бота!\nПустите его в свою жизнь @yasma_test_bot", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    status_lbl.Text = "Бот не может с вами связаться(";
                    break;

            }
        }

        private async void TelegramAuth_Load(object sender, EventArgs e)
        {
            if (await Tlw.StartBot() == TelegramWorker.LoginState.denied)
            {
                status_lbl.Text = "Связь с ботом не установлена..";
            }
            else
            {
                status_lbl.Text = "Бот запущен..\nВойдите в телеграм..";
            }

        }
        private async void start_auth_telegram_Click(object sender, EventArgs e)
        {
            var state = await Tlw.ClientConneectAsync(phone_num_mtxt.Text);
            switch (state)
            {
                case TelegramWorker.LoginState.success:
                    status_lbl.Text = "Авторизация успешна..";
                    break;
                case TelegramWorker.LoginState.confirm_req:
                    confirm_code_btn.Enabled = true;
                    telega_code_txt.Enabled = true;
                    status_lbl.Text = "Нужно подверждение..";
                    break;
                case TelegramWorker.LoginState.denied:
                    status_lbl.Text = "Ошибка авторизации..";
                    break;
            }
        }
        private async void confirm_code_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var state = await Tlw.SendClientCodeAsync(phone_num_mtxt.Text, telega_code_txt.Text);
                switch (state)
                {
                    case TelegramWorker.LoginState.success:
                        status_lbl.Text = "Авторизация успешна..";
                        break;
                    case TelegramWorker.LoginState.denied:
                        status_lbl.Text = "Ошибка авторизации кода..";
                        break;
                }
            }
            catch (Exception)
            {
                status_lbl.Text = "Ошибка авторизации кода..";
            }
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
