using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Controllers
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            string input = Console.ReadLine();


            while (true)
            {
                if (this.dungeonMaster.IsGameOver())
                {
                    break;
                }

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                try
                {
                    string[] args = input.Split();
                    string command = args[0];

                    switch (command)
                    {
                        case "JoinParty":
                            Console.WriteLine(this.dungeonMaster.JoinParty(args.Skip(1).ToArray()));
                            break;

                        case "AddItemToPool":
                            Console.WriteLine(this.dungeonMaster.AddItemToPool(args.Skip(1).ToArray()));
                            break;

                        case "PickUpItem":
                            Console.WriteLine(this.dungeonMaster.PickUpItem(args.Skip(1).ToArray()));
                            break;

                        case "UseItem":
                            Console.WriteLine(this.dungeonMaster.UseItem(args.Skip(1).ToArray()));
                            break;

                        case "UseItemOn":
                            Console.WriteLine(this.dungeonMaster.UseItemOn(args.Skip(1).ToArray()));
                            break;

                        case "GiveCharacterItem":
                            Console.WriteLine(this.dungeonMaster.GiveCharacterItem(args.Skip(1).ToArray()));
                            break;

                        case "Attack":
                            Console.WriteLine(this.dungeonMaster.Attack(args.Skip(1).ToArray()));
                            break;

                        case "Heal":
                            Console.WriteLine(this.dungeonMaster.Heal(args.Skip(1).ToArray()));
                            break;
                        case "GetStats":
                            Console.WriteLine(this.dungeonMaster.GetStats());
                            break;
                        case "EndTurn":
                            Console.WriteLine(this.dungeonMaster.EndTurn(args.Skip(1).ToArray()));
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Parameter Error: " + ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("Invalid Operation: " + ioe.Message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(this.dungeonMaster.GetStats());
        }
    }
}
