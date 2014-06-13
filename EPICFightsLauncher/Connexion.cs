using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace EPICFightsLauncher
{
    public class Connexion
    {

        private string login;
        private string password;

        private HttpWebRequest wb;
        private HttpWebResponse wr;

        public Connexion(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        /*public string Connect()
        {
            try
            {
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                s.Connect("epic-fights.sebb-dev.org", 80);
                Stream stream = new NetworkStream(s);
                StreamWriter streamwriter = new StreamWriter(stream);
                streamwriter.WriteLine("POST /launcher/login.php HTTP/1.1\nHost : epic-fights.sebb-dev.org \nConnection : close\nContent-type: application/x-www-form-urlencoded\nContent-Length: " + (password.Length + login.Length) + "\n\nlogin=" + login + "&password=" + password);
                streamwriter.Flush();

                StreamReader streamreader = new StreamReader(stream);
                string result = streamreader.ReadToEnd();

                streamwriter.Close();
                streamreader.Close();
                stream.Close();
                s.Close();
                
                return HttpFormating.Convert(result);
            }
            catch
            {
                return "erreur_connexion";
            }
        }*/

        public string Connect()
        {
            try
            {
                wb = (HttpWebRequest)WebRequest.Create("http://epic-fights.sebb-dev.org/launcher/login.php");

                wb.Method = "POST";

                string request = ("login=" + login + "&password=" + password);
                byte[] data = Encoding.UTF8.GetBytes(request);

                wb.ContentType = "application/x-www-form-urlencoded";
                //wb.Connection = "close";
                wb.ContentLength = request.Length;
                
                StreamWriter streamwriter = new StreamWriter(wb.GetRequestStream());
                streamwriter.Write(request);
                //Stream stream = wb.GetRequestStream();
                //stream.Write(data,0 , data.Length);
                //stream.Flush();
                streamwriter.Flush();

                wr = (HttpWebResponse)wb.GetResponse();

                StreamReader streamreader = new StreamReader(wr.GetResponseStream());
                string result = streamreader.ReadToEnd();

                //stream.Close();
                streamwriter.Close();
                streamreader.Close();
                wr.Close();
                wb.Abort();

                return result;

                //return "ok";
            }
            catch
            {
                return "erreur_connexion";
            }
        }
    }
}
