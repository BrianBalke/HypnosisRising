using HypnosisRising.CaseWork.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HypnosisRising.SharedConfiguration.ViewModels
{
    public class DesignData
    {
        public static Location HQ = new Location()
        {
            Street1 = "1 Cloud Nine Way",
            Street2 = "Healing Court",
            District = "Shangra-la",
            Region = "Peaks of Peace",
            MailCode = "00000",
            Country = "Nepal"
        };

        public static LocationFormViewModel HQVM = new LocationFormViewModel()
        {
            Location = HQ
        };
    }
}
