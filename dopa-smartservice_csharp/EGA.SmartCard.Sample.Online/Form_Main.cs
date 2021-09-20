using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EGA.WS;
using Newtonsoft.Json.Linq;

namespace EGA.SmartCard.Sample.Online
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();

            // require .NET 4 (not Client Profile)

            // use NuGet to get these libraries
            // - EGA.WS
            // - EGA.Helper
            // - Json.Net
            // - AntiXSS
        }

        private EGAWSAPI _Api;
        private string _Service;

        private void Form_Main_Load(object sender, EventArgs e)
        {

        }

        private void Form_Main_Shown(object sender, EventArgs e)
        {
            button_GetToken.Focus();
            JObject.Parse("{}");    // Init Json

            _Service = "/dopa/personal/profile/extra";  // Init Service

            textBox_Key.Text = "key";  // Init Key
            textBox_Secret.Text = "secret";    // Init Secret
            textBox_CitizenID.Text = "1234567890123";     // Init CitizenID
        }
        
        private void button_GetToken_Click(object sender, EventArgs e)
        {
            try
            {
                _Api = EGAWSAPI.CreateInstance(textBox_Key.Text, textBox_Secret.Text);
                textBox_Token.Text = _Api.AccessToken;
            }
            catch (Exception ex)
            {
                textBox_Data.Text = "Exception: " + ex.Message;
            }
        }

        private void button_Fetch_Click(object sender, EventArgs e)
        {
            JObject json;
            string pid = textBox_CitizenID.Text;
            string url = _Service;

            try
            {
                Dictionary<string, string> args = new Dictionary<string, string>();
                args.Add("CitizenID", pid);
                json = _Api.Get(url, args);

                if (json != null)
                {
                    textBox_Data.Text = json.ToString();

                    if (json["NameTH_FirstName"] != null)
                    {
                        textBox_FirstName.Text = Convert.ToString(json["NameTH_FirstName"]);
                    }
                    if (json["NameTH_SurName"] != null)
                    {
                        textBox_LastName.Text = Convert.ToString(json["NameTH_SurName"]);
                    }
                }
                else
                {
                    textBox_Data.Text = "No data";
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (msg.Contains("00001")
                    || msg.Contains("00410")
                    || msg.Contains("00815")
                    || msg.Contains("00870")
                    || msg.Contains("99706")
                    || msg.Contains("99707"))
                {
                    textBox_Data.Text = "Not found: " + msg;
                }
                else
                {
                    textBox_Data.Text = "Exception: " + ex.Message;
                }
            }

        }

    }
}
