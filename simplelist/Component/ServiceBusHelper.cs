using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using simplelist.Models;
using simplelist.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace simplelist.Component
{
    public static class ServiceBusHelper
    {
        public static void SendToAll(MyEntitySample itm)
        {
            try
            {
                TopicClient Client = TopicClient.CreateFromConnectionString(
                    Settings.Default.SERVICEBUS_URI
                    , "mytopic");
                var msg = new BrokeredMessage(
                     JsonConvert.SerializeObject(itm, Formatting.Indented));
                msg.Properties.Add("Category", itm.Name);
                Client.Send(msg);
            }
            catch (Exception ex)
            {

            }
        }
    }
}