using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.TheHeiganDance
{
    class TheHeiganDance
    {
        class Player
        {
            public int Health { get; set; } = 18500;
            public decimal Damage { get; set; }
            public int[] Coordinates = new int[2];
            public string CauseOfDeath { get; set; }

            public void HitMonster(Heigan monster)
            {
                monster.Health -= this.Damage;
            }
        }

        class Heigan
        {
            public decimal Health { get; set; } = 3000000;
            public List<int[]> PlagueCloudCoordinates { get; set; }
            public List<int[]> EruptionCoordinates { get; set; }

            public void PlagueCloud(Player player)
            {
                player.Health -= 3500;
            }

            public void Eruption(Player player)
            {
                player.Health -= 6000;
            }
        }

        static void Main()
        {
            Player player = CreateNewPlayer();
            Heigan monster = new Heigan();

            bool isPlayerDead = false;
            bool isMonsterDead = false;
            bool isCloudActive = false;
            while (true)
            {
                // Player hits first
                player.HitMonster(monster);
                if (monster.Health <= 0)
                {
                    isMonsterDead = true;
                }

                // Aplly DOT if active
                if (isCloudActive)
                {
                    monster.PlagueCloud(player);
                    if (player.Health <= 0)
                    {
                        isPlayerDead = true;
                        player.CauseOfDeath = "Plague Cloud";
                    }

                    isCloudActive = false;
                }

                if (isMonsterDead || isPlayerDead)
                {
                    break;
                }
                // Monster attacks
                string input = Console.ReadLine();
                string typeOfAttack = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).First();

                // Cloud attack
                if (typeOfAttack == "Cloud")
                {
                    // Check Cloud attack coordinates
                    monster.PlagueCloudCoordinates = GetAttackCoordinates(monster, input);
                    if (monster.PlagueCloudCoordinates.Any(c => c[0] == player.Coordinates[0] && c[1] == player.Coordinates[1]))
                    {
                        int[] currentPlayerPosition = new int[] { player.Coordinates[0], player.Coordinates[1] };
                        MovePlayerToNewPosition(player, monster, typeOfAttack);
                        if (player.Coordinates[0] == currentPlayerPosition[0] && player.Coordinates[1] == currentPlayerPosition[1])
                        {
                            // Successful attack
                            monster.PlagueCloud(player);
                            isCloudActive = true;
                            if (player.Health <= 0)
                            {
                                isPlayerDead = true;
                                player.CauseOfDeath = "Plague Cloud";
                                break;
                            }
                        }
                        monster.PlagueCloudCoordinates.Clear();
                        
                    }
                }

                // Eruption attack
                if (typeOfAttack == "Eruption")
                {
                    // Check Eruption attack coordinates
                    monster.EruptionCoordinates = GetAttackCoordinates(monster, input);
                    if (monster.EruptionCoordinates.Any(c => c[0] == player.Coordinates[0] && c[1] == player.Coordinates[1]))
                    {
                        int[] currentPlayerPosition = new int[] { player.Coordinates[0], player.Coordinates[1] };
                        MovePlayerToNewPosition(player, monster, typeOfAttack);
                        if (player.Coordinates[0] == currentPlayerPosition[0] && player.Coordinates[1] == currentPlayerPosition[1])
                        {
                            // Successful attack on player
                            monster.Eruption(player);
                            if (player.Health <= 0)
                            {
                                isPlayerDead = true;
                                player.CauseOfDeath = "Eruption";
                                break;
                            }
                        }
                        monster.EruptionCoordinates.Clear();
                    }
                }
            }


            if (isMonsterDead)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {monster.Health:f2}");
            }

            if (isPlayerDead)
            {
                Console.WriteLine($"Player: Killed by {player.CauseOfDeath}");
            }
            else
            {
                Console.WriteLine($"Player: {player.Health}");
            }
            Console.WriteLine($"Final position: {player.Coordinates[0]}, {player.Coordinates[1]}");
        }

        private static void MovePlayerToNewPosition(Player player, Heigan monster, string typeOfAttack)
        {
            int[] positionUp = { player.Coordinates[0] - 1, player.Coordinates[1] };
            int[] positionRight = { player.Coordinates[0], player.Coordinates[1] + 1 };
            int[] positionDown = { player.Coordinates[0] + 1, player.Coordinates[1] };
            int[] positionLeft = { player.Coordinates[0], player.Coordinates[1] - 1 };

            List<int[]> AttackCoordinates = typeOfAttack == "Cloud" ? monster.PlagueCloudCoordinates : monster.EruptionCoordinates;
            if (!AttackCoordinates.Any(c => c[0] == positionUp[0] && c[1] == positionUp[1]) && IsInTheMatrix(positionUp[0], positionUp[1]))
            {
                player.Coordinates = positionUp;
            }
            else if (!AttackCoordinates.Any(c => c[0] == positionRight[0] && c[1] == positionRight[1]) && IsInTheMatrix(positionRight[0], positionRight[1]))
            {
                player.Coordinates = positionRight;
            }
            else if (!AttackCoordinates.Any(c => c[0] == positionDown[0] && c[1] == positionDown[1]) && IsInTheMatrix(positionDown[0], positionDown[1]))
            {
                player.Coordinates = positionDown;
            }
            else if (!AttackCoordinates.Any(c => c[0] == positionLeft[0] && c[1] == positionLeft[1]) && IsInTheMatrix(positionLeft[0], positionLeft[1]))
            {
                player.Coordinates = positionLeft;
            }
        }

        private static List<int[]> GetAttackCoordinates(Heigan monster, string input)
        {
            List<int[]> AttackCoordinates = new List<int[]>();
            int row = int.Parse(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).First());
            int col = int.Parse(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Skip(2).First());

            for (int colIndex = col - 1; colIndex <= col + 1; colIndex++)
            {
                if (IsInTheMatrix(row - 1, colIndex))
                {
                    var cell = new int[] { row - 1, colIndex };
                    AttackCoordinates.Add(cell);
                }

                if (IsInTheMatrix(row, colIndex))
                {
                    var cell = new int[] { row, colIndex };
                    AttackCoordinates.Add(cell);
                }

                if (IsInTheMatrix(row + 1, colIndex))
                {
                    var cell = new int[] { row + 1, colIndex };
                    AttackCoordinates.Add(cell);
                }
            }

            return AttackCoordinates;
        }

        private static bool IsInTheMatrix(int row, int col)
        {
            return row >= 0 && row < 15 && col >= 0 && col < 15;
        }

        private static Player CreateNewPlayer()
        {
            Player player = new Player();
            player.Coordinates[0] = 7;
            player.Coordinates[1] = 7;
            player.Damage = decimal.Parse(Console.ReadLine());
            return player;
        }
    }
}
