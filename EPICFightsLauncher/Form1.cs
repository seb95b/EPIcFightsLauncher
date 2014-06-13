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
                Console.WriteLine(result);

                switch (result)
                {
                    case "erreur_connexion":
                        erreur.Text = "Impossible de se connecter au serveur";
                        break;
                    case "erreur_log_or_pass1":
                        erreur.Text = "Veuillez entrer correctement vos infos";
                        break;
                    case "erreur_log_or_pass2":
                        erreur.Text = "Le login ou le mot de passe sont erronés";
                        break;
                    default:
                        try
                        {
                            erreur.Text = result;

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
            else
            {
                Console.WriteLine(0);
                erreur.Text = "0";
                //Process P = Process.Start("E:\\epita\\projet\\Soutenance2\\jeu_xna\\jeu_xna\\bin\\x86\\Release\\jeu_xna.exe", 0);
                //Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.sebb-dev.org/connexion.php");
        }

    }
}
