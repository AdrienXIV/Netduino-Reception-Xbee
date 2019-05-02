using System;
using System.Collections.Generic;
using System.Threading;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Diagnostics;

namespace Reception_Xbee
{
    class Reception
    {
        private static String portCOM = "COM4"; // choisir le port série
        private static String donneeSerialise = "";

        private static Thread ReceptionXbee = new Thread(ThreadReception);
        private static CPortSerie port = new CPortSerie();
        private static CSerialisation serialisation = new CSerialisation();
        private static List<String> lectureDonnees = new List<String>();
        static void Main(string[] args)
        {
            ReceptionXbee.Start();
            ReceptionXbee.Join();
        }

        static private void ThreadReception()
        {
            SerialPort sp = port.PortSerie(portCOM);
            sp.Open();

            while (true)
            {
                if (sp.BytesToRead > 0)
                {
                    lectureDonnees = port.Lecture(sp);
                    Thread.Sleep(100);
                    donneeSerialise = serialisation.Serialiser(lectureDonnees[0], lectureDonnees[1], lectureDonnees[2]);
                    Thread.Sleep(500);

                    Console.WriteLine(donneeSerialise);

                    var result = Post(donneeSerialise);
                }
            }
        }

        // Envoyer données au service web
        static public async Task Post(String msg)
        {
            // notre cible, remplacer URI
            string url = "http://10.3.242.56/Service1.svc/InsertXbee";

            using (HttpClient client = new HttpClient())
            {
                // la requête
                // StringContent = format web
                // str = données sérialisées en JSON
                // encoding ut8, text/plain = dire au format web que c'est du JSON
                using (HttpResponseMessage response = await client.PostAsync(url, new StringContent(msg, Encoding.UTF8, "text/plain")))
                {

                }
            }
        }
    }
}
