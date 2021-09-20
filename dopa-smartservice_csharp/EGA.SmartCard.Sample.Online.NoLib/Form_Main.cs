using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace EGA.SmartCard.Sample.Online.NoLib
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();

            // require .NET 4 (not Client Profile)

            // use NuGet to get this library
            // - Json.Net
        }

        private string _Server;
        private string _Service;

        private void Form_Main_Shown(object sender, EventArgs e)
        {
            button_GetToken.Focus();
            JObject.Parse("{}");    // Init Json

            // Test Server is https://ws.ega.or.th:10443
            // Product Server is  https://ws.ega.or.th

            _Server = "https://ws.ega.or.th:10443";     // Init Server
            _Service = "/dopa/personal/profile/extra";  // Init Service

            textBox_Key.Text = "key";  // Init Key
            textBox_Secret.Text = "secret";    // Init Secret
            textBox_CitizenID.Text = "1234567890123";     // Init CitizenID
        }

        private void button_GetToken_Click(object sender, EventArgs e)
        {
            string data = "";

            Uri url = new Uri(string.Format("{0}/ws/auth/validate?ConsumerSecret={1}&AgentID={2}"
                , _Server, textBox_Secret.Text, textBox_CitizenID.Text));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "*/*";
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            request.Headers.Add("Consumer-Key", textBox_Key.Text);


            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream s = (Stream)response.GetResponseStream();
                    if (s != null)
                    {
                        StreamReader reader = new StreamReader(s);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            string output = reader.ReadToEnd();

                            JObject json = JObject.Parse(output);
                            if (json["Result"] != null)
                            {
                                textBox_Token.Text = Convert.ToString(json["Result"]);
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                using (HttpWebResponse response = ex.Response as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string output = reader.ReadToEnd();
                    try
                    {
                        JObject obj = JObject.Parse(output);
                        output = obj["Message"].ToString();
                    }
                    catch (Exception)
                    {
                    }
                    data = output;
                }
            }
            catch (Exception ex)
            {
                data = ex.Message;
            }
            textBox_Data.Text = data;
        }

        private void button_Fetch_Click(object sender, EventArgs e)
        {
            string data = "";

            Uri url = new Uri(string.Format("{0}/ws{1}?CitizenID={2}"
                , _Server, _Service, textBox_CitizenID.Text));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "*/*";
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            request.Headers.Add("Consumer-Key", textBox_Key.Text);
            request.Headers.Add("Token", textBox_Token.Text);

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream s = (Stream)response.GetResponseStream();
                    if (s != null)
                    {
                        StreamReader reader = new StreamReader(s);

                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            string output = reader.ReadToEnd();

                            JObject json = JObject.Parse(output);

                            if (json != null)
                            {
                                data = json.ToString();

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
                                data = "No data";
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                using (HttpWebResponse response = ex.Response as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string output = reader.ReadToEnd();
                    try
                    {
                        JObject obj = JObject.Parse(output);
                        output = obj["Message"].ToString();

                        if (output.Contains("00001")
                            || output.Contains("00410")
                            || output.Contains("00815")
                            || output.Contains("00870")
                            || output.Contains("99706")
                            || output.Contains("99707"))
                        {
                            data = "Not found: " + output;
                        }
                        else
                        {
                            data = output;
                        }
                    }
                    catch (Exception ex2)
                    {
                        data = output;
                    }
                }
            }
            catch (Exception ex)
            {
                data = ex.Message;
            }
            textBox_Data.Text = data;
        }
    }
}
