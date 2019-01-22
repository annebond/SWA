namespace Example2.Model
{
    public class Message
    {
        public string Messageline { get; set; }
        public string Timestamp { get; set; }

        public Message(string messageline, string timestamp)
        {
            Messageline = messageline;
            Timestamp = timestamp;
        }
    }
}
