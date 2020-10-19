using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQTTnet;
using MQTTnet.Core;
using MQTTnet.Core.Client;
using MQTTnet.Core.Packets;
using MQTTnet.Core.Protocol;

namespace MQTTnetClient
{
    public partial class FormMain : Form
    {
        private MqttClient mqttClient = null;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Task.Run(async () => { await ConnectMqttServerAsync(); });
        }

        private async Task ConnectMqttServerAsync()
        {
            if (mqttClient == null)
            {
                mqttClient = new MqttClientFactory().CreateMqttClient() as MqttClient;
                mqttClient.ApplicationMessageReceived += MqttClient_ApplicationMessageReceived;
                mqttClient.Connected += MqttClient_Connected;
                mqttClient.Disconnected += MqttClient_Disconnected;
            }

            try
            {
                var options = new MqttClientTcpOptions
                {
                    Server = "127.0.0.1",
                    ClientId = Guid.NewGuid().ToString().Substring(0, 5),
                    UserName = "u001",
                    Password = "p001",
                    CleanSession = true
                };

                await mqttClient.ConnectAsync(options);
            }
            catch (Exception ex)
            {
                Invoke((new Action(() =>
                {
                    txtReceiveMessage.AppendText($"MQTT service connected failure！" + Environment.NewLine + ex.Message + Environment.NewLine);
                })));
            }
        }

        private void MqttClient_Connected(object sender, EventArgs e)
        {
            Invoke((new Action(() =>
            {
                txtReceiveMessage.AppendText("MQTT service was connected！" + Environment.NewLine);
            })));
        }

        private void MqttClient_Disconnected(object sender, EventArgs e)
        {
            Invoke((new Action(() =>
            {
                txtReceiveMessage.AppendText("MQTT was disconnected！" + Environment.NewLine);
            })));
        }

        private void MqttClient_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            Invoke((new Action(() =>
            {
                txtReceiveMessage.AppendText($">> {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}{Environment.NewLine}");
            })));
        }

        private void BtnSubscribe_ClickAsync(object sender, EventArgs e)
        {

        }

        private void BtnPublish_Click(object sender, EventArgs e)
        {
            string topic = txtPubTopic.Text.Trim();

            if (string.IsNullOrEmpty(topic))
            {
                MessageBox.Show("Topic was empty!");
                return;
            }

            string inputString = txtSendMessage.Text.Trim();
            var appMsg = new MqttApplicationMessage(topic, Encoding.UTF8.GetBytes(inputString), MqttQualityOfServiceLevel.AtMostOnce, false);
            mqttClient.PublishAsync(appMsg);
        }
    }
}
