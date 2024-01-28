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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //User anmelden
            string Benutzername;
            string Passwort;
            Benutzername = textBox1.Text;
            Passwort = textBox2.Text;

            if (Benutzername == "")
            {
                MessageBox.Show("Bitte Benutzername eingeben.", "...::ERROR:::::....");
            }

            if (Passwort == "")
            {
                MessageBox.Show("Bitte Passwort eingeben.", "...::ERROR:::::....");
            }
            else
            {
                pictureBox1.Visible = true;
                
                //User einlesen
                try
                {
                    
                    System.Net.WebClient wc = new System.Net.WebClient();
                    string webData = wc.DownloadString("http://disord3r.square7.ch/chat/user.php");
                    string[] lines = Regex.Split(webData, "<br>");
                    int zaehler = 0;
                    int arrayplatz = 0;
                    int login = 0;
                    foreach (string line in lines)
                    {
                        if (line == Benutzername)
                        {
                            arrayplatz = zaehler;

                        }
                        zaehler++;
                    }
                    //die letzte zeile vom array lines ist leer also ziehe ich an der zaehlervariable 1 ab!!!
                    zaehler = zaehler - 1;
                    //PWs einlesen
                    System.Net.WebClient wcpw = new System.Net.WebClient();
                    string webDataPw = wcpw.DownloadString("http://disord3r.square7.ch/chat/usercheck.php?stop=1");
                    string[] linespw = Regex.Split(webDataPw, "<br>");

                    if (linespw[arrayplatz].Equals(Passwort))
                    {
                        WebRequest log1 = WebRequest.Create("http://disord3r.square7.ch/chat/schreiben.php?txt=" + Benutzername + " hat den Raum betreten.");
                        log1.GetResponse();
                        //MessageBox.Show("Erfolgreich angemeldet. \n Bitte warten - Die Verbindung zum Server wird aufgebaut.", "...::LogIn:::::....");
                        login = login + 1;
                        WebRequest wr = WebRequest.Create("http://disord3r.square7.ch/chat/login.php?user=" + Benutzername);
                        wr.GetResponse();
                        pictureBox1.Visible = false;
                        Visible = false;
                        Form2 frm = new Form2(Benutzername);
                        frm.Show();
                        
                    }
                    if (login == 0)
                    {
                        MessageBox.Show("Falsche Eingabe.", "...::ERROR:::::....");
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Keine oder schlechte Internetverbindung.", "...::ERROR:::::....");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //User registrieren
            string RegBenutzername;
            string RegPasswort;
            RegBenutzername = textBox1.Text;
            RegPasswort = textBox2.Text;

            if (RegBenutzername == "")
            {
                MessageBox.Show("Bitte Benutzername eingeben.", "...::ERROR:::::....");
            }

            if (RegPasswort == "")
            {
                MessageBox.Show("Bitte Passwort eingeben.", "...::ERROR:::::....");
            }
            else
            {
                pictureBox1.Visible = true;
                try
                {
                    //User einlesen
                    System.Net.WebClient wc = new System.Net.WebClient();
                    string webData = wc.DownloadString("http://disord3r.square7.ch/chat/user.php");
                    string[] lines = Regex.Split(webData, "<br>");
                    int zaehler = 0;
                    int abbruch = 0;
                    foreach (string line in lines)
                    {
                        if (RegBenutzername == line)
                        {
                            MessageBox.Show("Dieser Benutzername ist schon vergeben!\n", "...::Error:::::....");
                            abbruch = abbruch + 1;
                        }
                        zaehler++;
                    }
                    //die letzte zeile vom array lines ist leer also ziehe ich an der zaehlervariable 1 ab!!!
                    zaehler = zaehler - 1;

                    if (abbruch == 0)
                    {
                        WebRequest wr = WebRequest.Create("http://disord3r.square7.ch/chat/registrieren.php?user=" + RegBenutzername + "&pw=" + RegPasswort + "&status=0");
                        wr.GetResponse();
                        MessageBox.Show("Benutzer erfolgreich registriert. Das Anmelden ist jetzt möglich.", "...::Registriert:::::....");
                    }
                    else
                    {
                        MessageBox.Show("Fehler.", "...::ERROR:::::....");
                    }
                }catch (Exception exc)
                {
                    MessageBox.Show("Keine oder schlechte Internetverbindung.", "...::ERROR:::::....");
                }
                pictureBox1.Visible = false;
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://disord3r.square7.ch");
        }
    }
}
