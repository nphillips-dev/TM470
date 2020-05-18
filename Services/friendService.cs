using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM470.Data.Database_Context;

namespace TM470.Services
{
    public class friendService : IFriendRespository, IUserRepository
    {
        private readonly IFriendRespository _friendRespository;
        private readonly IUserRepository _userRepository;

        public friendService(IFriendRespository friendRespository, IUserRepository userRepository)
        {
            _friendRespository = friendRespository;
            _userRepository = userRepository;
        }

        public int addFriend(string userId, string friendId)
        {
            string userIdOfFriend = getUserIdByFriendId(friendId);
            return _friendRespository.addFriend(userId, userIdOfFriend);
        }

        public string getUserFriendId(string userId)
        {
            return _userRepository.getUserFriendId(userId);
        }

        public string getUserIdByFriendId(string friendId)
        {
            return _userRepository.getUserIdByFriendId(friendId);
        }

        public int removeFriend(string userId, string friendId)
        {
            string userIdOfFriend = getUserIdByFriendId(friendId);
            return _friendRespository.removeFriend(userId, userIdOfFriend);
        }
    }
}
