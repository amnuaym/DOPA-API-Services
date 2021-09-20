using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ThaiSmartCardPlayer;
using GeneralHelper;

namespace EGA.SmartCard.Sample.Offline.Simple
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private ThaiSmartCardReader _reader;

        private void Form_Main_Load(object sender, EventArgs e)
        {
            // initial ThaiSmartCardReader

            _reader = ThaiSmartCardReader.GetInstance(ReadCard, ReadCard);
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // must do this event to close process

            _reader = ThaiSmartCardReader.GetInstance();
            _reader.ShutDown();
        }

        private void ReadCard()
        {
            _reader.TimeReadDelay = 1000;   // set delay 1000-3000 before read card to avoid conflict

            string text = _reader.ReadAllText();
            ThaiSmartCardInfo info = _reader.ConvertTextToInfo(text);
            AssignForm_Field_CardInfo(info);
        }

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
        }
    }
}
