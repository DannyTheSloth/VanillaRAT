namespace VanillaStub.Helpers.Telepathy
{
    public class Message
    {
        public int connectionId;
        public EventType eventType;
        public byte[] data;

        public Message(int connectionId, EventType eventType, byte[] data)
        {
            this.connectionId = connectionId;
            this.eventType = eventType;
            this.data = data;
        }
    }
}