﻿using System;

namespace SharpStoreDB
{
   public class Message
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
    }
}
