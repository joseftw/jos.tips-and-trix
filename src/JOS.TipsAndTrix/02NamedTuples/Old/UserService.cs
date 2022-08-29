namespace JOS.TipsAndTrix._02NamedTuples.Old
{
    public class UserService
    {
        public (string, string) GetUser()
        {
            var firstName = "Josef";
            var country = "Sweden";
            return (firstName, country);
        }
    }
}
