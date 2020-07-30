namespace TM470.Data.Database_Context
{
    public interface IUserRepository
    {
       public string getUserIdByFriendId(string friendId);
       public string getUserFriendId(string userId);
    }
}
