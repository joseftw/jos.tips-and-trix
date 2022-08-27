namespace JOS.TipsAndTrix._01Covariant.Old
{
    public class HamburgerMessageBody
    {
        public HamburgerMessageBody(string name)
        {
            Name = name ?? throw new System.ArgumentNullException(nameof(name));
        }

        public string Name { get; }
    }
}
