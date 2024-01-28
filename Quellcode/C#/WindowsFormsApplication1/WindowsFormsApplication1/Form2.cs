using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        string Benutzername;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string Name)
        {
            InitializeComponent();
            Benutzername = Name;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try{
            //Vorher MySQL User abmelden und Text im Chat das der User gegangen ist
            WebRequest log2 = WebRequest.Create("http://disord3r.square7.ch/chat/schreiben.php?txt=" + Benutzername + " hat den Raum verlassen.");
            log2.GetResponse();
            WebRequest loff = WebRequest.Create("http://disord3r.square7.ch/chat/logout.php?user=" + Benutzername);
            loff.GetResponse();
            Application.Exit();
            
            }
            catch (Exception exoff)
            {
                MessageBox.Show("Keine oder schlechte Internetverbindung.", "...::ERROR:::::....");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Nachricht an MySQL senden
            string Chattext;
            string Sendtext;
            DateTime datum = DateTime.Now;
            Chattext = textBox2.Text;
            int jump = 0;          

            if (Chattext == "")
            {
                MessageBox.Show("Bitte Nachricht eingeben.", "...::ERROR:::::....");
                jump = 1;
            }

            if (jump == 0)
            {
                Sendtext = "[" + datum + "] " + Benutzername + ": " + Chattext;
                try
                {
                    WebRequest wr = WebRequest.Create("http://disord3r.square7.ch/chat/schreiben.php?txt=" + Sendtext);
                    wr.GetResponse();
                    textBox2.Clear();
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Keine oder schlechte Internetverbindung.", "...::ERROR:::::....");
                }
            }
            jump = 0;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                string webData = wc.DownloadString("http://disord3r.square7.ch/chat/useronline.php");
                listBox1.Items.Clear();
                string[] lines = Regex.Split(webData, "<br>");

                foreach (string line in lines)
                {
                    listBox1.Items.Add(line);
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Keine oder schlechte Internetverbindung.", "...::ERROR:::::....");
            }


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //wieder entfernt!!!
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            
            try { 
                System.Net.WebClient wchat = new System.Net.WebClient();
            string chatData = wchat.DownloadString("http://disord3r.square7.ch/chat/lesen.php");
            listBox2.Items.Clear();
            string[] chat = Regex.Split(chatData, "<br>");
            
            foreach (string chat1 in chat)
            {
                listBox2.Items.Add(chat1);
            }
            this.listBox2.TopIndex = this.listBox2.Items.Count - 1;
            textBox2.Focus();
            }catch(Exception ex){
                MessageBox.Show("Keine oder schlechte Internetverbindung.", "...::ERROR:::::....");
            }

        }
    }
}
