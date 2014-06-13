using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace EPICFightsLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Console.WriteLine(login.Text);
            //onsole.WriteLine(password.Text);
            if (login.Text != "" && password.Text != "")
            {
                Connexion connexion = new Connexion(login.Text, MD5Hashing.MD5Hash(password.Text));
                string result = connexion.Connect();

                switch(result)
                {
                    case "erreur_connexion":
                        erreur.Text = "Impossible de se connecter au serveur";
                        break;
                    case "erreur_log_or_pass":
                        erreur.Text = "Le login ou le mot de passe sont erronés";
                        break;
                    default:
                        try
                        {
                            erreur.Text = result;
                            Console.WriteLine(result);
                            //Process P = Process.Start("E:\\epita\\projet\\Soutenance2\\jeu_xna\\jeu_xna\\bin\\x86\\Release\\jeu_xna.exe", result);
                            //Application.Exit();
                        }
                        catch
                        {
                            erreur.Text = "Une erreur s'est produite";
                        }
                        break;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.sebb-dev.org/");
        }

    }
}
