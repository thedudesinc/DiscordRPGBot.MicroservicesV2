using DiscordRPGBot.BusinessLogic.Abstractions.Repositories;
using DiscordRPGBot.BusinessLogic.Abstractions.Services;
using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordRPGBot.BusinessLogic.Concretes.Services
{
    public class ActionService : IActionService
    {
        private readonly IPlayerCharacterRepository _playerCharacterRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationActionRepository _locationActionRepository;
        private readonly IItemActionRepository _itemActionRepository;

        public ActionService(
            IPlayerCharacterRepository playerCharacterRepository,
            IUserRepository userRepository,
            ILocationActionRepository locationActionRepository,
            IItemActionRepository itemActionRepository
        )
        {
            _playerCharacterRepository = playerCharacterRepository;
            _userRepository = userRepository;
            _locationActionRepository = locationActionRepository;
            _itemActionRepository = itemActionRepository;
        }

        public async Task<string> DoActionAsync(string discordId, int actionNumber)
        {
            var outcome = "";
            var actions = await GetActionsForPlayerCharacterAsync(discordId);
            var pc = await _userRepository.GetActivePlayerCharacterByDiscordIdAsync(discordId);

            if (actions.Count() > 0 && actions.ElementAtOrDefault(actionNumber - 1) != null)
            {
                var selectedActionDescription = actions[actionNumber - 1];

                var locationAction = await _locationActionRepository.GetByDescription(selectedActionDescription);
                var itemAction = await _itemActionRepository.GetByDescription(selectedActionDescription);

                if (locationAction != null)
                {
                    outcome = await DoLocationAction(locationAction, pc);
                }
                else if (itemAction != null)
                {
                    outcome = await DoItemAction(itemAction, pc);
                }
                else
                {
                    throw new Exception("Action not found! Please verify you are passing the right number.");
                }

                return outcome;
            }
            else
            {
                throw new Exception("Uh oh! We ran into an issue. The action you specified was not found/recognized.");
            }
        }

        public async Task<List<string>> GetActionsForPlayerCharacterAsync(string discordId)
        {
            var user = await _userRepository.GetByDiscordIdAsync(discordId);

            if (user.ActiveCharacter != null)
            {
                var actions = new List<LocationAction>();
                var pc = await _playerCharacterRepository.GetAsync(user.ActiveCharacter.Value);

                if (pc.Location.IsHostile)
                {
                    // actions.AddRange(await _actionRepository.GetAllByLocationIdAsync(pc.LocationId));
                }
                else
                {
                    actions.AddRange(await _locationActionRepository.GetAllByLocationIdAsync(pc.LocationId));
                }

                return actions.OrderBy(a => a.Description).Select(a => a.Description).ToList();
            }
            else
            {
                throw new Exception("User does not have an active character!");
            }
        }

        private async Task<string> DoLocationAction(LocationAction action, PlayerCharacter pc)
        {
            pc.LocationId = action.RelocateToId.Value;
            await _playerCharacterRepository.UpdateAsync(pc.Id, pc);
            return action.SuccessMessageTemplate;
        }

        private async Task<string> DoItemAction(ItemAction action, PlayerCharacter pc)
        {
            if (action.Effect == EffectType.Heal)
            {
                pc.CurrentHP += action.Value;

                if (pc.CurrentHP > pc.MaxHP)
                {
                    pc.CurrentHP = pc.MaxHP;
                }
            }

            if (action.Effect == EffectType.Damage)
            {
                // get battle instance
                // deal damage to target enemy
                // TODO
            }

            await _playerCharacterRepository.UpdateAsync(pc.Id, pc);
            return action.SuccessMessageTemplate;
        }
    }
}
