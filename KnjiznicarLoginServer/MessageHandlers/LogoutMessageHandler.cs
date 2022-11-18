﻿using KnjiznicarLoginServer.Message;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KnjiznicarLoginServer.MessageHandlers
{
    class LogoutMessageHandler : BaseMessageHandler
    {
        public override void HandleMessage(int clientId, JObject dataJsonObject)
        {
            LogoutMessage message = JsonConvert.DeserializeObject<LogoutMessage>(dataJsonObject.ToString());

            if (message.responseNeeded)
            {
                ServerSend.SendTCPData(clientId, new LogoutMessage(false));
            }

            Server.Clients[clientId].Disconnect();
        }
    }
}