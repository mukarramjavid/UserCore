using System;
using System.Collections.Generic;
using System.Text;

namespace Inferastructure.APIResponses
{

    public class SignalRExtensionMethods
    {
        public static HashSet<HubClientModel> CurrentConnections = new HashSet<HubClientModel>();
    }

    public class HubClientModel
    {
        public string connections { get; set; }
        public string groupType { get; set; }
    }

}
