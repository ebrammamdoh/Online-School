using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace OnlineSchool.Hubs
{
    [HubName("CommentHub")]
    public class CommentHub:Hub
    {
        [HubMethodName("NewUserConnected")]
        public void NewUserConnected(string UserName)
        {
            Clients.All.NewUserNotification(UserName);
        }
    }
}