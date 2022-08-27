using System;

namespace JOS.TipsAndTrix._01Covariant.Old
{
    public class HamburgerMessageHandler : MessageHandler
    {
        public override Message Poll()
        {
            var message = new Message<HamburgerMessageBody>(
                id: Guid.NewGuid().ToString(),
                correlationId: Guid.NewGuid().ToString(),
                new HamburgerMessageBody("Triple Smash"));

            return message;
        }
    }
}
