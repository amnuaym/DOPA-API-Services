namespace EGA.SmartCard.Sample.Online.NoLib
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.textBox_Data = new System.Windows.Forms.TextBox();
            this.button_Fetch = new System.Windows.Forms.Button();
            this.button_GetToken = new System.Windows.Forms.Button();
            this.textBox_Secret = new System.Windows.Forms.TextBox();
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.textBox_Token = new System.Windows.Forms.TextBox();
            this.textBox_CitizenID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_FirstName = new System.Windows.Forms.TextBox();
            this.textBox_LastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Data
            // 
            this.textBox_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Data.Location = new System.Drawing.Point(67, 132);
            this.textBox_Data.Multiline = true;
            this.textBox_Data.Name = "textBox_Data";
            this.textBox_Data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Data.Size = new System.Drawing.Size(478, 248);
            this.textBox_Data.TabIndex = 22;
            // 
            // button_Fetch
            // 
            this.button_Fetch.Location = new System.Drawing.Point(173, 77);
            this.button_Fetch.Name = "button_Fetch";
            this.button_Fetch.Size = new System.Drawing.Size(75, 23);
            this.button_Fetch.TabIndex = 20;
            this.button_Fetch.Text = "Fetch Data";
            this.button_Fetch.UseVisualStyleBackColor = true;
            this.button_Fetch.Click += new System.EventHandler(this.button_Fetch_Click);
            // 
            // button_GetToken
            // 
            this.button_GetToken.Location = new System.Drawing.Point(478, 10);
            this.button_GetToken.Name = "button_GetToken";
            this.button_GetToken.Size = new System.Drawing.Size(75, 23);
            this.button_GetToken.TabIndex = 21;
            this.button_GetToken.Text = "Get Token";
            this.button_GetToken.UseVisualStyleBackColor = true;
            this.button_GetToken.Click += new System.EventHandler(this.button_GetToken_Click);
            // 
            // textBox_Secret
            // 
            this.textBox_Secret.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Secret.Location = new System.Drawing.Point(372, 12);
            this.textBox_Secret.Name = "textBox_Secret";
            this.textBox_Secret.Size = new System.Drawing.Size(100, 20);
            this.textBox_Secret.TabIndex = 17;
            // 
            // textBox_Key
            // 
            this.textBox_Key.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Key.Location = new System.Drawing.Point(67, 12);
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.Size = new System.Drawing.Size(242, 20);
            this.textBox_Key.TabIndex = 18;
            // 
            // textBox_Token
            // 
            this.textBox_Token.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Token.Location = new System.Drawing.Point(67, 38);
            this.textBox_Token.Name = "textBox_Token";
            this.textBox_Token.Size = new System.Drawing.Size(405, 20);
            this.textBox_Token.TabIndex = 19;
            // 
            // textBox_PID
            // 
            this.textBox_CitizenID.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_CitizenID.Location = new System.Drawing.Point(67, 79);
            this.textBox_CitizenID.Name = "textBox_PID";
            this.textBox_CitizenID.Size = new System.Drawing.Size(100, 20);
            this.textBox_CitizenID.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(328, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Secret";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Token";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Key";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "CitizenID";
            // 
            // textBox_FirstName
            // 
            this.textBox_FirstName.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_FirstName.Location = new System.Drawing.Point(67, 106);
            this.textBox_FirstName.Name = "textBox_FirstName";
            this.textBox_FirstName.Size = new System.Drawing.Size(100, 20);
            this.textBox_FirstName.TabIndex = 17;
            // 
            // textBox_LastName
            // 
            this.textBox_LastName.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_LastName.Location = new System.Drawing.Point(173, 106);
            this.textBox_LastName.Name = "textBox_LastName";
            this.textBox_LastName.Size = new System.Drawing.Size(100, 20);
            this.textBox_LastName.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Name";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 393);
            this.Controls.Add(this.textBox_Data);
            this.Controls.Add(this.button_Fetch);
            this.Controls.Add(this.button_GetToken);
            this.Controls.Add(this.textBox_LastName);
            this.Controls.Add(this.textBox_FirstName);
            this.Controls.Add(this.textBox_Secret);
            this.Controls.Add(this.textBox_Key);
            this.Controls.Add(this.textBox_Token);
            this.Controls.Add(this.textBox_CitizenID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartCard Sample Online - Simple";
            this.Shown += new System.EventHandler(this.Form_Main_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Data;
        private System.Windows.Forms.Button button_Fetch;
        private System.Windows.Forms.Button button_GetToken;
        private System.Windows.Forms.TextBox textBox_Secret;
        private System.Windows.Forms.TextBox textBox_Key;
        private System.Windows.Forms.TextBox textBox_Token;
        private System.Windows.Forms.TextBox textBox_CitizenID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_FirstName;
        private System.Windows.Forms.TextBox textBox_LastName;
        private System.Windows.Forms.Label label6;
    }
}

