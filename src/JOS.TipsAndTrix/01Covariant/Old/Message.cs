using System;

namespace JOS.TipsAndTrix._01Covariant.Old
{
    public abstract class Message
    {
        protected Message(string id, string correlationId, object data)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            CorrelationId = correlationId ?? throw new ArgumentNullException(nameof(correlationId));
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public string Id { get; }
        public string CorrelationId { get; }
        public object Data { get; }
    }

    public class Message<T> : Message where T : class
    {
        public Message(string id, string correlationId, T data) : base(id, correlationId, data)
        {
        }
    }
}