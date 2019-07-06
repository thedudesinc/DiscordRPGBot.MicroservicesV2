using DiscordRPGBot.BusinessLogic.Abstractions.Repositories;
using DiscordRPGBot.BusinessLogic.Abstractions.Services;
using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Models.Request;
using DiscordRPGBot.BusinessLogic.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Concretes.Services
{
    public class PlayerCharacterService : IPlayerCharacterService
    {
        private readonly IPlayerCharacterRepository _playerCharacterRepository;
        private readonly IUserRepository _userRepository;
        private readonly IClassRepository _classRepository;
        private readonly IRaceRepository _raceRepository;

        public PlayerCharacterService(
            IPlayerCharacterRepository playerCharacterRepository, 
            IUserRepository userRepository,
            IClassRepository classRepository,
            IRaceRepository raceRepository
        )
        {
            _playerCharacterRepository = playerCharacterRepository;
            _userRepository = userRepository;
            _classRepository = classRepository;
            _raceRepository = raceRepository;
        }

        public async Task<long> CreateAsync(PlayerCharacterCreateRequest pc)
        {
            bool createdUser = false;
            var user = await _userRepository.GetByDiscordIdAsync(pc.DiscordId);

            if (user == null)
            {
                var userId = await _userRepository.CreateAsync(new User
                {
                    DiscordId = pc.DiscordId,
                    CreatedOn = DateTimeOffset.Now,
                    UpdatedOn = DateTimeOffset.Now
                });

                user = await _userRepository.GetAsync(userId);

                createdUser = true;
            }

            var newCharacter = new PlayerCharacter
            {
                Name = pc.Name,
                Class = await _classRepository.GetByNameAsync(pc.Class),
                Race = await _raceRepository.GetByNameAsync(pc.Race),
                CurrentHP = 10,
                CurrentLevel = 1,
                CurrentXP = 0,
                Gold = 10,
                MaxHP = 10,
                User = user,
                CreatedOn = DateTimeOffset.Now,
                UpdatedOn = DateTimeOffset.Now
            };

            var id = await _playerCharacterRepository.CreateAsync(newCharacter);

            if (createdUser)
            {
                await _userRepository.AddCharacterToUserAsync(user.Id, newCharacter);
            }

            return id;
        }

        public async Task CreateAsync(IEnumerable<PlayerCharacter> pcs)
        {
            await _playerCharacterRepository.CreateAsync(pcs);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var deleted = await _playerCharacterRepository.DeleteAsync(id);

            return deleted;
        }

        public async Task<PlayerCharacterGetResponse> GetAsync(string discordId)
        {
            var user = await _userRepository.GetByDiscordIdAsync(discordId);

            if (user.ActiveCharacter != null)
            {
                var pc = await _playerCharacterRepository.GetAsync(user.ActiveCharacter.Value);

                var pcSummary = new PlayerCharacterGetResponse
                {
                    Name = pc.Name,
                    Race = pc.Race.Name,
                    Class = pc.Class.Name,
                    CurrentHP = pc.CurrentHP,
                    CurrentLevel = pc.CurrentLevel,
                    CurrentXP = pc.CurrentXP,
                    Gold = pc.Gold,
                    MaxHP = pc.MaxHP,
                    ProfileImageUrl = pc.ProfileImageUrl,
                    TotalFastMod = pc.Race.FastMod + pc.Class.FastMod,
                    TotalSmartMod = pc.Race.SmartMod + pc.Class.SmartMod,
                    TotalStrongMod = pc.Race.StrongMod + pc.Class.StrongMod,
                    TotalToughMod = pc.Race.ToughMod + pc.Class.ToughMod,
                    ClassThumbnail = pc.Class.ImageUrl
                };

                return pcSummary;
            }
            else
            {
                throw new Exception("User does not have an active character!");
            }
        }

        public async Task<IEnumerable<PlayerCharacterGetResponse>> GetAsync(IEnumerable<long> ids)
        {
            var pcs = await _playerCharacterRepository.GetAsync(ids);
            var foundCharacters = new List<PlayerCharacterGetResponse>();

            if (pcs != null)
            {
                foreach (var pc in pcs)
                {

                    var pcSummary = new PlayerCharacterGetResponse
                    {
                        Name = pc.Name,
                        Race = pc.Race.Name,
                        Class = pc.Class.Name,
                        CurrentHP = pc.CurrentHP,
                        CurrentLevel = pc.CurrentLevel,
                        CurrentXP = pc.CurrentXP,
                        Gold = pc.Gold,
                        MaxHP = pc.MaxHP,
                        ProfileImageUrl = pc.ProfileImageUrl,
                        TotalFastMod = pc.Race.FastMod + pc.Class.FastMod,
                        TotalSmartMod = pc.Race.SmartMod + pc.Class.SmartMod,
                        TotalStrongMod = pc.Race.StrongMod + pc.Class.StrongMod,
                        TotalToughMod = pc.Race.ToughMod + pc.Class.ToughMod
                    };

                    foundCharacters.Add(pcSummary);
                }

                return foundCharacters;
            }
            else
            {
                throw new Exception("No characters found!");
            }
        }

        public async Task UpdateAsync(long id, PlayerCharacter pc)
        {
            await _playerCharacterRepository.UpdateAsync(id, pc);
        }
    }
}
