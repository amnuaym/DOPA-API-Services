using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ThaiSmartCardPlayer;
using GeneralHelper;

namespace EGA.SmartCard.Sample.Offline
{
    public partial class Form_Main : Form 
    {
        public Form_Main()
        {
            // require .NET 4 Client Profile

            InitializeComponent();
        }

        private ThaiSmartCardReader _reader;

        #region Form

        private void Form_Main_Load(object sender, EventArgs e)
        {
            // initial ThaiSmartCardReader

            _reader = ThaiSmartCardReader.GetInstance(ReadCard, ReadCard);
        }

        private void Form_Main_Shown(object sender, EventArgs e)
        {
            button_Field_Read.Focus();
            AssignCheckBox_Status();
            AssignCheckBox_Field();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // must do this event to close process

            _reader = ThaiSmartCardReader.GetInstance();
            _reader.ShutDown();
        }

        #endregion Form

        #region Read Card

        private void button_Field_Read_Click(object sender, EventArgs e)
        {
            ReadCard();
        }

        private void ReadCard()
        {
            _reader.IsReadAll = false;
            _reader.IsReadName = checkBox_Field_Name.Checked;
            _reader.IsReadAddress = checkBox_Field_Address.Checked;
            _reader.IsReadIssue = checkBox_Field_Issue.Checked;
            _reader.IsReadVersion = checkBox_Field_Version.Checked;
            _reader.IsReadImageNumber = checkBox_Field_ImageNumber.Checked;
            _reader.IsReadCardNumber = checkBox_Field_CardNumber.Checked;
            _reader.IsReadIssuer = checkBox_Field_Issuer.Checked;
            _reader.IsReadIssuerNumber = checkBox_Field_IssuerNumber.Checked;
            _reader.IsReadImage = checkBox_Field_Image.Checked;

            int delay = 500;
            int.TryParse(textBox_Field_Delay.Text, out delay);
            _reader.TimeReadDelay = delay;   // set delay 1000-3000 before read card to avoid conflict

            if (radioButton_Field_ReadField.Checked)
            {
                _reader.ReadCard();
                AssignForm_Field_CardInfo(_reader.CardInfo);
            }
            else
            {
                string text = _reader.ReadAllText();
                ThaiSmartCardInfo info = _reader.ConvertTextToInfo(text);
                AssignForm_Field_CardInfo(info);
            }

            AssignLogList();
            AssignCheckBox_Status();
        }

        private void radioButton_Field_ReadField_CheckedChanged(object sender, EventArgs e)
        {
            AssignCheckBox_Field();
        }

        #endregion Read Card

        #region Log

        private void checkBox_Status_ReaderConnected_CheckedChanged(object sender, EventArgs e)
        {
            AssignCheckBox_Status();
        }

        private void checkBox_Status_CardInserted_CheckedChanged(object sender, EventArgs e)
        {
            AssignCheckBox_Status();
        }

        private void checkBox_Status_CardSupported_CheckedChanged(object sender, EventArgs e)
        {
            AssignCheckBox_Status();
        }

        private void listBox_Log_Click(object sender, EventArgs e)
        {
            string text = (string)listBox_Status_Log.SelectedItem;
            if (!string.IsNullOrEmpty(text))
            {
                Clipboard.SetText(text);
            }
        }

        private void button_Status_CopyLog_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in listBox_Status_Log.Items)
            {
                sb.AppendLine(item);
            }
            Clipboard.SetData(DataFormats.Text, sb.ToString());
        }

        private void button_Status_ClearLog_Click(object sender, EventArgs e)
        {
            _reader.LogList.Clear();
            ControlHelper.SetListBoxClear(listBox_Status_Log);
        }

        #endregion Log

        #region Form Helper

        private void AssignForm_Field_CardInfo(ThaiSmartCardInfo info)
        {
            if (info == null)
                return;

            ControlHelper.SetControlText(textBox_Field_PID, info.CitizenID);
            ControlHelper.SetControlText(textBox_Field_PrefixNameTH, info.NameTH_Prefix);
            ControlHelper.SetControlText(textBox_Field_FirstNameTH, info.NameTH_FirstName);
            ControlHelper.SetControlText(textBox_Field_LastNameTH, info.NameTH_SurName);
            ControlHelper.SetControlText(textBox_Field_PrefixName, info.NameEN_Prefix);
            ControlHelper.SetControlText(textBox_Field_FirstName, info.NameEN_FirstName);
            ControlHelper.SetControlText(textBox_Field_LastName, info.NameEN_SurName);
            ControlHelper.SetControlText(textBox_Field_GenderTH, info.Sex);
            ControlHelper.SetControlText(textBox_Field_BirthDate, info.BirthDateTH);
            ControlHelper.SetControlText(textBox_Field_AddressTH, info.Address);
            ControlHelper.SetControlText(textBox_Field_IssueDate, info.IssueDateTH);
            ControlHelper.SetControlText(textBox_Field_ExpireDate, info.ExpireDateTH);
            ControlHelper.SetControlText(textBox_Field_CardType, info.CardType);
            ControlHelper.SetControlText(textBox_Field_Version, info.Version);
            ControlHelper.SetControlText(textBox_Field_ImageNumber, info.ImageNumber);
            ControlHelper.SetControlText(textBox_Field_CardNumber, info.CardNumber);
            ControlHelper.SetControlText(textBox_Field_RequestNumber, info.RequestNumber);
            ControlHelper.SetControlText(textBox_Field_IssuerPlace, info.IssuerPlace);
            ControlHelper.SetControlText(textBox_Field_IssuerAgency, info.IssuerAgency);
            ControlHelper.SetControlText(textBox_Field_IssuerCode, info.IssuerID);
            ControlHelper.SetPictureBoxImage(pictureBox_Field_Person, info.Image);
        }

        private void AssignLogList()
        {
            ControlHelper.SetListBoxClear(listBox_Status_Log);
            ControlHelper.SetListBoxAddRange(listBox_Status_Log, _reader.LogList.ToArray());
            ControlHelper.SetListBoxLastSelected(listBox_Status_Log);
        }

        private void AssignLogList(string log)
        {
            ControlHelper.SetListBoxAddText(listBox_Status_Log, log);
            ControlHelper.SetListBoxLastSelected(listBox_Status_Log);
        }

        private void AssignCheckBox_Status()
        {
            ControlHelper.SetCheckBoxChecked(checkBox_Status_ReaderConnected, _reader.IsCardReaderConnected);
            ControlHelper.SetCheckBoxChecked(checkBox_Status_CardInserted, _reader.IsCardInserted);
            ControlHelper.SetCheckBoxChecked(checkBox_Status_CardSupported, _reader.IsCardSupported);
        }

        private void AssignCheckBox_Field()
        {
            bool isEnabled = radioButton_Field_ReadField.Checked;
            checkBox_Field_Address.Enabled = isEnabled;
            checkBox_Field_CardNumber.Enabled = isEnabled;
            checkBox_Field_Image.Enabled = isEnabled;
            checkBox_Field_ImageNumber.Enabled = isEnabled;
            checkBox_Field_Issue.Enabled = isEnabled;
            checkBox_Field_Issuer.Enabled = isEnabled;
            checkBox_Field_IssuerNumber.Enabled = isEnabled;
            checkBox_Field_Name.Enabled = isEnabled;
            checkBox_Field_Version.Enabled = isEnabled;
        }

        #endregion Form Helper
    }
}
