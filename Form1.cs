using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoolparse
{
    public partial class Form1 : Form
    {
        static string ExPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\alarm.wav";
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            System.Media.SoundPlayer smm = new System.Media.SoundPlayer();
            smm.SoundLocation = ExPath;
            smm.LoadAsync();
            wc.Encoding = System.Text.Encoding.UTF8;
            wc.Headers.Add(HttpRequestHeader.Cookie, "__RequestVerificationToken=mua0s4X3GtpDs-Y9l4c4Sc-3-nWpBVImC8gjaKVGYNzPq3NRYU5HkZcaAMNYDRYtheg1xCFd_l1JU9njtxLvxsSiaLVMgg_jf3GBalWdTMs1; supportOnlineTalkID=WXwwZgW2wQ3Rbq9QkOEyx3Hl77VGsyxW; _ym_uid=1602165385308781638; _ym_d=1602165385; _ym_isad=1; _ym_visorc_39917430=w; .AspNet.ApplicationCookie=G6lVJUeywtPBYxok5L82wyRYVFdgS5b00Z5tuzZ9XrmyouQmvZrvDGKIbxuw-NDbohU_eKhXiURaP-N2kAoDMZHg_brWIO9pvVtmDuXJPdR3d4-OBzpJFIBywSLZ5kLF8vBxdVn1gdPoJKU1vZZ0pK56ZW8Mqw4DqwyAN9HgcM1M4YdwigTyIpEsB2hX9pJmqHUfyF372sMOAi2aK4JniWoQhq7T9FVA_qNfNaW1w4aM0Zh2VVTtBysDDQY9mmWO9E69uFV3aq5EW1dc72p0byz7iKGM6eS7khaPGUyzhB0R2hOyJ4-e6DVukfNSiqPBPTuKydwzk8az-JZ8MfMu76bAb0KnRNdLtvQfGEGRcUf0tvO8APSXJF_IxFZb3kw7glFb1bBpGqAQshmG7jHPY1XCn6Pj9oB7q5QixL8zoYPNtryqPbz3oOTDV4ontRT5T1tCZfG9dtVusgLXKA59f2ltln2CuUv6d51Qq45WchN-yEKIp-rhPaIDUQ1l5a_0A-V9Z_N9Qc34LHa4qATJOgxAXnRnse65PLokGTMMrqgm-TkqX0Ix0PSUpVdGQc_vvBQn2aSbVwW80gBWD0u0kDI6lPt35Mgb79ocYdjTld2VIBLJPMcrX5_mBVxOr3FDVzNgsZAx5DCe0H2X6Tw-ZLdrgmYrRpsKxgieBTVSWhynAJvCm1IXyp3xDNuLU3Xccf70RyPSef34SdGxnkKe8dq3LOmhK1Va1rGTuFEFMOUxQvCSKziIzBTNH-kLA20Ygb4omBDR5K0WyUgLDYDYD6f6wzbndiia_3Wa_Swssm8M-etsHU2Oba4na5Rb_aeo3VVTFLawo2ZXRnF4pNrP9Ql1DTMRehpjWnMvjQLarPjkztQlRcDK2irCApn4Ent52R3K6Mc4Ftydqut7XrF3TQ");
            int i = 0;
            Task.Run(async () =>
            {
                var z = wc.DownloadString("https://app.dscontrol.ru/content/deploy/app.js?1602083001025");
                while (true)
                {
                    i++;
                    var t = wc.DownloadString("https://app.dscontrol.ru/Api/StudentSchedulerList?Kinds=D&OnlyMine=falsetimeshift=-360&from=2020-10-01&to=2020-10-30");
                    var zs = JsonConvert.DeserializeObject<Data>(t);
                    var bb = zs.data.Where(q => q.Completed != true && q.start_date.DayOfYear > DateTime.Now.DayOfYear).ToList();
                    if (bb.Count > 0)
                    {
                        //AALLLEEERT!!
                        smm.Stop();
                        smm.Play();
                    }
                    BeginInvoke(new Action(() =>
                    {
                        listBox1.Items.Clear();
                        foreach (var item in zs.data)
                        {
                            listBox1.Items.Add(item);
                        }
                        counter_lbl.Text = i.ToString();
                        if(bb.Count > 0)
                        {
                            listBox2.Items.Clear();
                            foreach (var item in bb)
                            {
                                listBox2.Items.Add(item);
                            }
                        }
                    }));

                    GC.Collect(1, GCCollectionMode.Forced);
                    await Task.Delay(60001);
                }
            });

        }
    }
    public class Data
    {
        public List<ItemSc> data { get; set; }
    }
    public class ItemSc
    {
        public string Key { get; set; }
        public int Id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int State { get; set; }
        public bool Completed { get; set; }
        public override string ToString()
        {
            return $"{EmployeeName} :: {start_date}";
        }
    }
}
