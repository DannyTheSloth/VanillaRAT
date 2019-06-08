namespace Telepathy
{
    public class Message
    {
        public int connectionId;
        public byte[] data;
        public EventType eventType;

        public Message(int connectionId, EventType eventType, byte[] data)
        {
            this.connectionId = connectionId;
            this.eventType = eventType;
            this.data = data;
        }
    }
}