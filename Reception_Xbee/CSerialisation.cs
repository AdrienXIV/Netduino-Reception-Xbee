using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace Reception_Xbee
{
    /// <summary>
    /// Serialiser() sérialise les données au format JSON.
    /// </summary>
    class CSerialisation
    {
        private static String json;
        private static CInfoVetetiste info = new CInfoVetetiste();

        /// <summary>
        /// Retourne une valeur String avec les infos sérialisées en JSON (CarteId, heure, numéro portique).
        /// </summary>
        /// <param name="id">carteId.</param>
        /// <param name="heure">heure.</param>
        /// <param name="numPortique">numéro du Portique.</param>
        /// <returns>Infos converties en JSON.</returns>
        public String Serialiser(String id, String heure, String numPortique)
        {
            info.carteId = id;
            info.date = heure;
            info.portique = numPortique;

            json = JsonConvert.SerializeObject(info);

            return json;
        }


    }
}


