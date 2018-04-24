using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotMG_Server_Latency
{
    public partial class Form1 : Form
    {
        public static List<Server> ROTMG_SERVERS = new List<Server>();

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
            "Australia:54.252.165.65"
        };

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

        private List<Server> SerializeServers(List<string> data)
        {
            List<Server> i = new List<Server>();

            foreach (string j in data)
                i.Add(new Server(j.Split(':')[0], j.Split(':')[1]));

            return i;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ROTMG_SERVERS = SerializeServers(ROTMG_SERVERS_DATA);


        }
    }
}
