using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace RotMG_Server_Latency
{
    /** RotMG Server Latency
     * Author: Devwarlt
     * 
     * An open source software to check RotMG server latencies.
     */

    public partial class Form1 : Form
    {
        #region "Settings"
        public static readonly string GITHUB = "https://github.com/Devwarlt/RotMG-Server-Latency";
        public static readonly string REALMEYE = "https://realmeye.com/player/Devwarlt";
        public static readonly List<string> ROTMG_SERVER_TTLS = new List<string>
        {
            "5 s",
            "10 s",
            "30 s",
            "60 s"
        };
        public static int TTL = GetTTL(ROTMG_SERVER_TTLS.Count - 1);
        public static List<Server> ROTMG_SERVERS = new List<Server>();
        public static List<Label> ROTMG_SERVER_LABELS = new List<Label>();
        public static List<TextBox> ROTMG_SERVER_BOXES = new List<TextBox>();
        public static List<PingHandler> ROTMG_SERVER_PING_HANDLERS = new List<PingHandler>();
        public static readonly List<string> ROTMG_SERVERS_DATA = new List<string>
        {
            "USWest:54.153.32.11",
            "USMidWest:18.220.226.127",
            "EUWest:52.47.149.74",
            "USEast:52.23.232.42",
            "AsiaSouthEast:52.77.221.237",
            "USSouth:52.91.68.60",
            "USSouthWest:54.183.179.205",
            "EUEast:18.195.167.79",
            "EUNorth:54.93.78.148",
            "EUSouthWest:52.47.178.13",
            "USEast3:54.157.6.58",
            "USWest2:54.215.251.128",
            "USMidWest2:18.218.255.91",
            "USEast2:52.91.203.118",
            "USNorthWest:54.234.151.78",
            "AsiaEast:54.199.197.208",
            "USSouth3:13.57.182.96",
            "EUNorth2:52.59.198.155",
            "EUWest2:34.243.37.98",
            "EUSouth:52.47.150.186",
            "USSouth2:54.183.236.213",
            "USWest3:54.67.119.179",
            "Australia:54.252.165.65",
            "Localhost:127.0.0.1"
        };
        #endregion

        private List<Server> SerializeServers(List<string> data)
        {
            List<Server> i = new List<Server>();

            foreach (string j in data)
                i.Add(new Server(j.Split(':')[0], j.Split(':')[1]));

            return i;
        }

        public Form1()
        { InitializeComponent(); }

        private static int GetTTL(int index) =>
            Convert.ToInt32(ROTMG_SERVER_TTLS[index].Split(' ')[0]);

        private void Form1_Load(object sender, EventArgs e)
        {
            ControlBox = false;

            for (int h = 0; h < ROTMG_SERVER_TTLS.Count; h++)
                comboBox1.Items.Add(ROTMG_SERVER_TTLS[h]);

            comboBox1.SelectedIndex = ROTMG_SERVER_TTLS.Count - 1;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            label26.Text = $"{GetTTL(comboBox1.SelectedIndex)} seconds";

            ROTMG_SERVERS = SerializeServers(ROTMG_SERVERS_DATA);

            #region "Labels"
            ROTMG_SERVER_LABELS.Add(label1);
            ROTMG_SERVER_LABELS.Add(label2);
            ROTMG_SERVER_LABELS.Add(label3);
            ROTMG_SERVER_LABELS.Add(label4);
            ROTMG_SERVER_LABELS.Add(label5);
            ROTMG_SERVER_LABELS.Add(label6);
            ROTMG_SERVER_LABELS.Add(label7);
            ROTMG_SERVER_LABELS.Add(label8);
            ROTMG_SERVER_LABELS.Add(label9);
            ROTMG_SERVER_LABELS.Add(label10);
            ROTMG_SERVER_LABELS.Add(label11);
            ROTMG_SERVER_LABELS.Add(label12);
            ROTMG_SERVER_LABELS.Add(label13);
            ROTMG_SERVER_LABELS.Add(label14);
            ROTMG_SERVER_LABELS.Add(label15);
            ROTMG_SERVER_LABELS.Add(label16);
            ROTMG_SERVER_LABELS.Add(label17);
            ROTMG_SERVER_LABELS.Add(label18);
            ROTMG_SERVER_LABELS.Add(label19);
            ROTMG_SERVER_LABELS.Add(label20);
            ROTMG_SERVER_LABELS.Add(label21);
            ROTMG_SERVER_LABELS.Add(label22);
            ROTMG_SERVER_LABELS.Add(label23);
            ROTMG_SERVER_LABELS.Add(label24);
            #endregion

            for (int i = 0; i < ROTMG_SERVER_LABELS.Count; i++)
                ROTMG_SERVER_LABELS[i].Text = ROTMG_SERVERS[i].Name;

            #region "Boxes"
            ROTMG_SERVER_BOXES.Add(textBox1);
            ROTMG_SERVER_BOXES.Add(textBox2);
            ROTMG_SERVER_BOXES.Add(textBox3);
            ROTMG_SERVER_BOXES.Add(textBox4);
            ROTMG_SERVER_BOXES.Add(textBox5);
            ROTMG_SERVER_BOXES.Add(textBox6);
            ROTMG_SERVER_BOXES.Add(textBox7);
            ROTMG_SERVER_BOXES.Add(textBox8);
            ROTMG_SERVER_BOXES.Add(textBox9);
            ROTMG_SERVER_BOXES.Add(textBox10);
            ROTMG_SERVER_BOXES.Add(textBox11);
            ROTMG_SERVER_BOXES.Add(textBox12);
            ROTMG_SERVER_BOXES.Add(textBox13);
            ROTMG_SERVER_BOXES.Add(textBox14);
            ROTMG_SERVER_BOXES.Add(textBox15);
            ROTMG_SERVER_BOXES.Add(textBox16);
            ROTMG_SERVER_BOXES.Add(textBox17);
            ROTMG_SERVER_BOXES.Add(textBox18);
            ROTMG_SERVER_BOXES.Add(textBox19);
            ROTMG_SERVER_BOXES.Add(textBox20);
            ROTMG_SERVER_BOXES.Add(textBox21);
            ROTMG_SERVER_BOXES.Add(textBox22);
            ROTMG_SERVER_BOXES.Add(textBox23);
            ROTMG_SERVER_BOXES.Add(textBox24);
            #endregion

            for (int j = 0; j < ROTMG_SERVER_BOXES.Count; j++)
                ROTMG_SERVER_PING_HANDLERS.Add(new PingHandler(ROTMG_SERVER_BOXES[j], ROTMG_SERVERS[j].IP));

            foreach (PingHandler k in ROTMG_SERVER_PING_HANDLERS)
                k.BeginThread();
        }

        #region "Custom classes"
        public class Server
        {
            public string Name { get; private set; }
            public string IP { get; private set; }

            public Server(string Name, string IP)
            {
                this.Name = Name;
                this.IP = IP;
            }
        }

        public class PingHandler
        {
            public TextBox Box { get; private set; }
            public string IP { get; private set; }

            public PingHandler(TextBox Box, string IP)
            {
                this.Box = Box;
                this.Box.Enabled = false;
                this.Box.Text = "unknown";
                this.Box.TextAlign = HorizontalAlignment.Center;

                this.IP = IP;
            }

            public void BeginThread()
            {
                Thread thread = new Thread(() =>
                {
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(IP);

                    do
                    {
                        if (pingReply.Status == IPStatus.Success)
                        {
                            UpdateBox($"{pingReply.RoundtripTime.ToString()} ms");
                            Thread.Sleep(TTL * 1000);
                        }
                        else
                        {
                            UpdateBox("loading...");
                            Thread.Sleep(2 * 1000);
                        }
                    } while (true);
                });
                thread.Start();
            }

            delegate void callback(string text);

            private void UpdateBox(string message)
            {
                if (Box.InvokeRequired)
                    Box.Invoke(new callback(UpdateBox), new object[] { message });
                else
                    Box.Text = message;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            TTL = GetTTL(comboBox1.SelectedIndex);
            label26.Text = $"{TTL} seconds";
        }

        private void button2_Click(object sender, EventArgs e) =>
            Environment.Exit(0);

        private void realmeye_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            Process.Start(REALMEYE);

        private void github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            Process.Start(GITHUB);
    }
}
