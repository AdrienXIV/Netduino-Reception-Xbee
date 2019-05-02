using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;

namespace Reception_Xbee
{
    /// <summary>
    /// PortSerie() retourne les valeurs du port,
    /// Lecture() retourne les valeurs carteID, heure, numéro portique dans un tableau String en List
    /// </summary>
    class CPortSerie
    {
        private static List<String> valeur = new List<String>();
        private static String portique = "2";

        /// <summary>
        /// Choisir le numéro du port.
        /// </summary>
        /// <returns>Retourne les valeurs du port série.</returns>
        public SerialPort PortSerie(String portCom)
        {
            return new SerialPort(portCom, 9600, Parity.None, 8, StopBits.One);
        }

        /// <summary>
        /// Retourne CarteId, heure, numéro portique dans un tableau String en List.
        /// </summary>
        /// <param name="sp">Valeur du port série.</param>
        /// <returns>Tableau de String en List.</returns>
        public List<String> Lecture(SerialPort sp)
        {
            var Heure = DateTime.Now.ToString("HH:mm:ss");
            if (sp.BytesToRead > 0)
            {
                valeur.Add(sp.ReadExisting());
                valeur.Add(Heure);
                valeur.Add(portique);
            }
            return valeur;
        }
    }
}
