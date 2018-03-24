using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Contracts;

namespace DungeonsAndCodeWizards.Controllers
{
    public class DungeonMaster
    {
        private List<Character> characterParty;
        private Stack<Item> poolOfItems;
        private int consecutiveRound;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.characterParty = new List<Character>();
            this.poolOfItems = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string type = args[1];
            string name = args[2];
            Character newCharacter = characterFactory.CreateCharacter(faction, type, name);
            characterParty.Add(newCharacter);

            return $"{newCharacter.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            Item newItem = itemFactory.CreateItem(args[0]);
            poolOfItems.Push(newItem);

            return $"{args[0]} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string charName = args[0];
            if (this.PoolOfItems.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            Item item = PoolOfItems.Pop();
            Character character = FindCharacter(charName);
            character.ReceiveItem(item);

            return $"{character.Name} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string charName = args[0];
            string itemName = args[1];

            Character ch = FindCharacter(charName);
            Item item = FindItemOnCharacter(ch, itemName);
            ch.UseItem(item);

            return $"{ch.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemN = args[2];

            Character giver = this.CharacterParty.FirstOrDefault(x => x.Name == giverName);
            Character receiver = this.CharacterParty.FirstOrDefault(x => x.Name == receiverName);
            Item item = giver.Bag.GetItem(itemN);
            giver.UseItemOn(item, receiver);

            return $"{giver.Name} used {itemN} on {receiver.Name}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemN = args[2];

            Character giver = FindCharacter(giverName);
            Character receiver = FindCharacter(receiverName);

            Item item = FindItemOnCharacter(giver, itemN);
            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {item.GetType().Name}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ch in this.CharacterParty.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine(ch.ToString());
            }
            string result = sb.ToString().TrimEnd();

            return result;
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = FindCharacter(attackerName);
            Character receiver = FindCharacter(receiverName);

            StringBuilder sb = new StringBuilder();

            if (!(attacker is IAttackable attackingChar))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attackingChar.Attack(receiver);
            sb.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }
            string result = sb.ToString().TrimEnd();

            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = FindCharacter(healerName);
            Character receiver = FindCharacter(receiverName);

            if (!(healer is IHealable healingChar))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }
            healingChar.Heal(receiver);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");


            string result = sb.ToString().TrimEnd();

            return result;
        }

        public string EndTurn(string[] args)
        {

            StringBuilder sb = new StringBuilder();
            int numAliveChar = 0;
            foreach (var ch in this.CharacterParty)
            {
                if (ch.IsAlive)
                {
                    double healthBefore = ch.Health;
                    ch.Rest();
                    double healthAfter = ch.Health;

                    sb.AppendLine($"{ch.Name} rests ({healthBefore} => {healthAfter})");
                    numAliveChar++;
                }
            }

            if (numAliveChar <= 1)
            {
                this.consecutiveRound++;
            }
            string result = sb.ToString().TrimEnd();

            return result;
        }

        public bool IsGameOver()
        {
            // TODO add 1 or 0 survivors left
            int numAliveCharacters = 0;
            foreach (var character in CharacterParty)
            {
                if (character.IsAlive)
                {
                    numAliveCharacters++;
                }
            }

            if (this.consecutiveRound > 1 && numAliveCharacters <= 1)
            {
                return true;
            }

            return false;
        }

        public Stack<Item> PoolOfItems
        {
            get { return this.poolOfItems; }
            set
            {
                this.poolOfItems = value;
            }
        }

        public List<Character> CharacterParty
        {
            get { return this.characterParty; }

            set
            {
                this.characterParty = value;
            }
        }

        private Character FindCharacter(string name)
        {
            var character = this.characterParty.FirstOrDefault(e => e.Name == name);

            if (character == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            return character;
        }

        private Item FindItemOnCharacter(Character ch, string itemName)
        {
            Item item = ch.Bag.Items.FirstOrDefault(x => x.GetType().Name == itemName);
            if (ch.Bag.Items.Count == 0 )
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            if (item == null)
            {
                throw new ArgumentException($"No item with name {itemName} in bag!");
            }

            return item;
        }
    }
}
