﻿using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.MyHub
{
    [HubName("CommentHub")]
    public class CommentHub:Hub
    {

    }
}