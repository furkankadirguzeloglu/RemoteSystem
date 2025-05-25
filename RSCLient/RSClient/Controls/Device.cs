using System;

namespace RSClient
{
    public class Device
    {
        private string id;
        private string userid;
        private string hwid;
        private string lastseen;
        private string hardwareinfo;
        private string clientinfo;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }

        public string Hwid
        {
            get { return hwid; }
            set { hwid = value; }
        }
    }
}
