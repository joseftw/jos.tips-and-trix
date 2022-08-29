namespace JOS.TipsAndTrix._02NamedTuples
{
    public class UserService
    {
        public (string FirstName, string Country) GetUser()
        {
            var firstName = "Josef";
            var country = "Sweden";
            return (firstName, country);
        }
    }
}
