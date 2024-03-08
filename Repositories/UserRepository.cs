using ToDoApp.Constants;
using ToDoApp.Models;
using ToDoApp.Repositories.Abstract;

namespace ToDoApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>()
        {
            new User(1, "user", "FAA29212E184CC04CC166E86DB321FA5BAE3869050CC723E8216FEAE3F59F61A9A8359D25B09790A9C2560D632EA801FB6C882AF507AD6EC8648D29C853AFE52", new String("187 221 228 223 243 85 159 141 156 187 79 25 25 175 44 214 109 242 220 21 250 249 51 54 93 254 37 2 73 26 220 58 209 27 148 154 19 14 164 226 173 20 60 209 110 240 119 25 14 153 184 27 189 121 90 56 145 149 36 121 56 17 125 83").Split(" ").Select(b => Convert.ToByte(b)).ToArray(), nameof(RoleTypes.User)),
            new User(2, "admin", "4B097AF55E20B59FA8FBA4C7FA78321B82881C9186DACB27B51E13E09FAD213017A788436FE5522800923DF1F1CAAE00E3508D32489DEB9C0E3840B3E3570AE3", new String("55 155 219 241 241 190 234 128 108 176 211 13 218 52 138 217 222 186 142 253 42 120 137 111 97 234 151 152 244 2 11 44 246 193 44 160 17 39 205 228 86 198 29 170 218 172 38 196 223 180 88 194 234 211 236 218 49 240 184 22 70 89 108 129").Split(" ").Select(b => Convert.ToByte(b)).ToArray(), nameof(RoleTypes.Admin)),
        };

        public Task CreateOneAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOneAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await Task.Run(() =>
            {
                return _users.FirstOrDefault(u => u.Username == username);
            });
        }

        public Task UpdateByIdAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
