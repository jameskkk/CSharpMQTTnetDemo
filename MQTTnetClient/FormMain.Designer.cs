namespace MQTTnetClient
{
    partial class FormMain
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
            this.txtSubTopic = new System.Windows.Forms.TextBox();
            this.lblTopic = new System.Windows.Forms.Label();
            this.txtReceiveMessage = new System.Windows.Forms.TextBox();
            this.lblReceiveMessage = new System.Windows.Forms.Label();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.lblPubTopic = new System.Windows.Forms.Label();
            this.txtPubTopic = new System.Windows.Forms.TextBox();
            this.lblSendMessage = new System.Windows.Forms.Label();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSubTopic
            // 
            this.txtSubTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTopic.Location = new System.Drawing.Point(12, 31);
            this.txtSubTopic.Name = "txtSubTopic";
            this.txtSubTopic.Size = new System.Drawing.Size(419, 25);
            this.txtSubTopic.TabIndex = 0;
            // 
            // lblTopic
            // 
            this.lblTopic.AutoSize = true;
            this.lblTopic.Location = new System.Drawing.Point(12, 9);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(70, 15);
            this.lblTopic.TabIndex = 1;
            this.lblTopic.Text = "Sub Topic:";
            // 
            // txtReceiveMessage
            // 
            this.txtReceiveMessage.Location = new System.Drawing.Point(12, 81);
            this.txtReceiveMessage.Multiline = true;
            this.txtReceiveMessage.Name = "txtReceiveMessage";
            this.txtReceiveMessage.Size = new System.Drawing.Size(519, 75);
            this.txtReceiveMessage.TabIndex = 2;
            // 
            // lblReceiveMessage
            // 
            this.lblReceiveMessage.AutoSize = true;
            this.lblReceiveMessage.Location = new System.Drawing.Point(12, 63);
            this.lblReceiveMessage.Name = "lblReceiveMessage";
            this.lblReceiveMessage.Size = new System.Drawing.Size(107, 15);
            this.lblReceiveMessage.TabIndex = 3;
            this.lblReceiveMessage.Text = "Receive Message:";
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(438, 32);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(93, 24);
            this.btnSubscribe.TabIndex = 4;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.BtnSubscribe_ClickAsync);
            // 
            // lblPubTopic
            // 
            this.lblPubTopic.AutoSize = true;
            this.lblPubTopic.Location = new System.Drawing.Point(12, 171);
            this.lblPubTopic.Name = "lblPubTopic";
            this.lblPubTopic.Size = new System.Drawing.Size(70, 15);
            this.lblPubTopic.TabIndex = 6;
            this.lblPubTopic.Text = "Pub Topic:";
            // 
            // txtPubTopic
            // 
            this.txtPubTopic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPubTopic.Location = new System.Drawing.Point(12, 194);
            this.txtPubTopic.Name = "txtPubTopic";
            this.txtPubTopic.Size = new System.Drawing.Size(419, 25);
            this.txtPubTopic.TabIndex = 5;
            // 
            // lblSendMessage
            // 
            this.lblSendMessage.AutoSize = true;
            this.lblSendMessage.Location = new System.Drawing.Point(12, 230);
            this.lblSendMessage.Name = "lblSendMessage";
            this.lblSendMessage.Size = new System.Drawing.Size(91, 15);
            this.lblSendMessage.TabIndex = 8;
            this.lblSendMessage.Text = "Send Message:";
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(12, 248);
            this.txtSendMessage.Multiline = true;
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(519, 75);
            this.txtSendMessage.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 25);
            this.button1.TabIndex = 9;
            this.button1.Text = "Publish";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnPublish_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 339);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblSendMessage);
            this.Controls.Add(this.txtSendMessage);
            this.Controls.Add(this.lblPubTopic);
            this.Controls.Add(this.txtPubTopic);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.lblReceiveMessage);
            this.Controls.Add(this.txtReceiveMessage);
            this.Controls.Add(this.lblTopic);
            this.Controls.Add(this.txtSubTopic);
            this.Name = "FormMain";
            this.Text = "MQTTnetClient";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubTopic;
        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.TextBox txtReceiveMessage;
        private System.Windows.Forms.Label lblReceiveMessage;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.Label lblPubTopic;
        private System.Windows.Forms.TextBox txtPubTopic;
        private System.Windows.Forms.Label lblSendMessage;
        private System.Windows.Forms.TextBox txtSendMessage;
        private System.Windows.Forms.Button button1;
    }
}

