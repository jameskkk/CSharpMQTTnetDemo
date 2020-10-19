using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MQTTnet;
using MQTTnet.Core.Adapter;
using MQTTnet.Core.Diagnostics;
using MQTTnet.Core.Protocol;
using MQTTnet.Core.Server;

namespace MQTTnetServer
{
    public partial class FormMain : Form
    {
        private static MqttServer mqttServer = null;
        private static Thread mStartMqttServerThread;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Console.WriteLine("MQTT program start!");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            MqttNetTrace.TraceMessagePublished += MqttNetTrace_TraceMessagePublished;
            mStartMqttServerThread = new Thread(StartMqttServer);
            mStartMqttServerThread.Start();

            if (cbxReadCmd.Checked)
            {
                timer1.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            mStartMqttServerThread.Abort();
            Console.WriteLine("MQTT service stop successfully！");
        }

        private void StartMqttServer()
        {
            if (mqttServer == null)
            {
                try
                {
                    var options = new MqttServerOptions
                    {
                        ConnectionValidator = p =>
                        {
                            if (p.ClientId == "c001")
                            {
                                if (p.Username != "u001" || p.Password != "p001")
                                {
                                    return MqttConnectReturnCode.ConnectionRefusedBadUsernameOrPassword;
                                }
                            }

                            return MqttConnectReturnCode.ConnectionAccepted;
                        }
                    };

                    mqttServer = new MqttServerFactory().CreateMqttServer(options) as MqttServer;
                    mqttServer.ApplicationMessageReceived += MqttServer_ApplicationMessageReceived;
                    mqttServer.ClientConnected += MqttServer_ClientConnected;
                    mqttServer.ClientDisconnected += MqttServer_ClientDisconnected;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            mqttServer.StartAsync();
            Console.WriteLine("MQTT service start successfully！");
        }

        private static void MqttServer_ClientConnected(object sender, MqttClientConnectedEventArgs e)
        {
            Console.WriteLine($"Cliend Id[{e.Client.ClientId}] was connected，Protocol Version:{e.Client.ProtocolVersion}");
        }

        private void MqttServer_ClientDisconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            Console.WriteLine($"Cliend Id[{e.Client.ClientId}] was disconnected！");
        }

        private void MqttServer_ApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            Console.WriteLine($"Cliend Id[{e.ClientId}]>> Topic：{e.ApplicationMessage.Topic} Payload：{Encoding.UTF8.GetString(e.ApplicationMessage.Payload)} Qos：{e.ApplicationMessage.QualityOfServiceLevel} Retain：{e.ApplicationMessage.Retain}");
        }

        private void MqttNetTrace_TraceMessagePublished(object sender, MqttNetTraceMessagePublishedEventArgs e)
        {
            Console.WriteLine($">> Thread ID：{e.ThreadId} Source：{e.Source} Level：{e.Level} Message: {e.Message}");
            if (e.Exception != null)
            {
                Console.WriteLine(e.Exception);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string command = Console.ReadLine();
            if (command == null)
                return;
            var inputString = command.ToLower().Trim();

            if (inputString == "exit")
            {
                mqttServer.StopAsync();
                Console.WriteLine("MQTT service stop！");

                timer1.Enabled = false;
                mStartMqttServerThread.Abort();
                Console.WriteLine("MQTT service stop successfully！");
                return;
            }
            else if (inputString == "clients")
            {
                foreach (var item in mqttServer.GetConnectedClients())
                {
                    Console.WriteLine($"Cliend Id:{item.ClientId}，Protocol Version:{item.ProtocolVersion}");
                }
            }
            else
            {
                Console.WriteLine($"Command [{inputString}] invalid！");
            }
        }
    }
}
