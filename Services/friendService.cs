using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM470.Data.Database_Context;
using TM470.Data.Models;

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

        public int addFriend(string userId, friends friend)
        {
            int result = 0;
            friend.user_id = getUserIdByFriendId(friend.friend_id);
            if (!string.IsNullOrEmpty(friend.user_id))
            {
                result = _friendRespository.addFriend(userId, friend);
            }
            return result;
        }

        public List<friends> GetFriends(string userId)
        {
            return _friendRespository.GetFriends(userId);
        }

        public string getUserFriendId(string userId)
        {
            return _userRepository.getUserFriendId(userId);
        }

        public string getUserIdByFriendId(string friendId)
        {
            return _userRepository.getUserIdByFriendId(friendId);
        }

        public int removeFriend(string userId, string friendUserId)
        {
            return _friendRespository.removeFriend(userId, friendUserId);
        }
    }
}
