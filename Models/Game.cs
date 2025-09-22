

namespace juegoRolesMonstruos
{
    public class Game
    {
        private readonly Random rnd = new Random();
        private Hero? player;
        private int currentLevel = 1;
        private List<HeroTemplate> heroTemplates = new List<HeroTemplate>();

        public Game()
        {
            InitializeHeroTemplates();
        }

        private void InitializeHeroTemplates()
        {
            heroTemplates = new List<HeroTemplate>
            {
                new HeroTemplate("Arthas el Valiente", HeroClass.Warrior, 20, 100, "Noble con gran resistencia", "Espada Larga", "Martillo de Guerra", "Escudo y Espada"),
                new HeroTemplate("Thane Forjahierro", HeroClass.Warrior, 16, 125, "Enano feroz con gran fuerza", "Cuchillo de Combate", "Espada Corta", "Hacha Doble"),
                new HeroTemplate("Gandara la Sabia", HeroClass.Mage, 12, 100, "Maga experta en hechizos elementales", "Bastón de Sabiduría", "Vara Elemental", "Grimorio Antiguo"),
                new HeroTemplate("Merlin el Ancestral", HeroClass.Mage, 8, 140, "Mago ancestral de poder devastador", "Bastón del Caos", "Orbe del Vacío", "Vara de las Tormentas"),
                new HeroTemplate("Legolas Ojosagudos", HeroClass.Archer, 14, 110, "Arquero élfico con puntería perfecta", "Arco Largo Élfico", "Ballesta de Precisión", "Arco Recurvo Mágico")
            };
        }

        private Weapon CreateUniqueWeapon(string weaponName, HeroClass heroClass, int level, int damageMultiplier)
        {
            var baseDamage = level * 2;
            var multiplier = damageMultiplier / 100.0;
            
            return weaponName switch
            {
                // Armas de Guerrero
                "Espada Larga" => new Weapon("Espada Larga", (int)(2 * multiplier), (int)(6 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Corte Rápido", (int)(2 * multiplier), (int)(4 * multiplier), AttackSpeed.Fast, StatusEffect.None, 0, 'Q'),
                        new Attack("Estocada", (int)(3 * multiplier), (int)(6 * multiplier), AttackSpeed.Normal, StatusEffect.None, 0, 'W'),
                        new Attack("Tajo Poderoso", (int)(4 * multiplier), (int)(8 * multiplier), AttackSpeed.Slow, StatusEffect.Bleeding, 2, 'E')
                    }
                },
                "Martillo de Guerra" => new Weapon("Martillo de Guerra", (int)(3 * multiplier), (int)(7 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Golpe Aplastante", (int)(3 * multiplier), (int)(5 * multiplier), AttackSpeed.Normal, StatusEffect.None, 0, 'Q'),
                        new Attack("Martillazo", (int)(4 * multiplier), (int)(7 * multiplier), AttackSpeed.Slow, StatusEffect.Stunned, 1, 'W'),
                        new Attack("Terremoto", (int)(2 * multiplier), (int)(6 * multiplier), AttackSpeed.Slow, StatusEffect.Stunned, 2, 'E')
                    }
                },
                "Escudo y Espada" => new Weapon("Escudo y Espada", (int)(2 * multiplier), (int)(5 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Ataque Defensivo", (int)(2 * multiplier), (int)(4 * multiplier), AttackSpeed.Normal, StatusEffect.None, 0, 'Q'),
                        new Attack("Embestida", (int)(3 * multiplier), (int)(5 * multiplier), AttackSpeed.Normal, StatusEffect.Stunned, 1, 'W'),
                        new Attack("Golpe de Escudo", (int)(1 * multiplier), (int)(3 * multiplier), AttackSpeed.Fast, StatusEffect.Stunned, 1, 'E')
                    }
                },
                "Cuchillo de Combate" => new Weapon("Cuchillo de Combate", (int)(2 * multiplier), (int)(4 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Puñalada", (int)(2 * multiplier), (int)(4 * multiplier), AttackSpeed.Fast, StatusEffect.Bleeding, 2, 'Q'),
                        new Attack("Corte Venenoso", (int)(1 * multiplier), (int)(3 * multiplier), AttackSpeed.Normal, StatusEffect.Poisoned, 3, 'W'),
                        new Attack("Ataque Furtivo", (int)(3 * multiplier), (int)(6 * multiplier), AttackSpeed.Normal, StatusEffect.None, 0, 'E')
                    }
                },
                "Espada Corta" => new Weapon("Espada Corta", (int)(2 * multiplier), (int)(5 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Corte Veloz", (int)(2 * multiplier), (int)(4 * multiplier), AttackSpeed.Fast, StatusEffect.None, 0, 'Q'),
                        new Attack("Combo Doble", (int)(1 * multiplier), (int)(3 * multiplier), AttackSpeed.Fast, StatusEffect.None, 0, 'W'),
                        new Attack("Lanzamiento", (int)(3 * multiplier), (int)(5 * multiplier), AttackSpeed.Normal, StatusEffect.None, 0, 'E')
                    }
                },
                "Hacha Doble" => new Weapon("Hacha Doble", (int)(3 * multiplier), (int)(8 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Tajo Salvaje", (int)(3 * multiplier), (int)(6 * multiplier), AttackSpeed.Normal, StatusEffect.Bleeding, 1, 'Q'),
                        new Attack("Giro Letal", (int)(4 * multiplier), (int)(8 * multiplier), AttackSpeed.Slow, StatusEffect.Bleeding, 3, 'W'),
                        new Attack("Hacha Giratoria", (int)(2 * multiplier), (int)(5 * multiplier), AttackSpeed.Fast, StatusEffect.None, 0, 'E')
                    }
                },

                // Armas de Mago
                "Bastón de Sabiduría" => new Weapon("Bastón de Sabiduría", (int)(2 * multiplier), (int)(5 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Misil Mágico", (int)(2 * multiplier), (int)(4 * multiplier), AttackSpeed.Fast, StatusEffect.None, 0, 'Q'),
                        new Attack("Rayo de Energía", (int)(3 * multiplier), (int)(5 * multiplier), AttackSpeed.Normal, StatusEffect.None, 0, 'W'),
                        new Attack("Orbe de Poder", (int)(4 * multiplier), (int)(7 * multiplier), AttackSpeed.Slow, StatusEffect.Stunned, 1, 'E')
                    }
                },
                "Vara Elemental" => new Weapon("Vara Elemental", (int)(2 * multiplier), (int)(6 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Bola de Fuego", (int)(3 * multiplier), (int)(5 * multiplier), AttackSpeed.Normal, StatusEffect.Burning, 2, 'Q'),
                        new Attack("Rayo de Hielo", (int)(2 * multiplier), (int)(4 * multiplier), AttackSpeed.Normal, StatusEffect.Stunned, 1, 'W'),
                        new Attack("Descarga Eléctrica", (int)(4 * multiplier), (int)(6 * multiplier), AttackSpeed.Fast, StatusEffect.None, 0, 'E')
                    }
                },
                "Grimorio Antiguo" => new Weapon("Grimorio Antiguo", (int)(3 * multiplier), (int)(7 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Hechizo Sombrio", (int)(3 * multiplier), (int)(6 * multiplier), AttackSpeed.Normal, StatusEffect.Poisoned, 2, 'Q'),
                        new Attack("Invocación Menor", (int)(2 * multiplier), (int)(5 * multiplier), AttackSpeed.Slow, StatusEffect.None, 0, 'W'),
                        new Attack("Maldición", (int)(1 * multiplier), (int)(4 * multiplier), AttackSpeed.Normal, StatusEffect.Poisoned, 3, 'E')
                    }
                },
                "Bastón del Caos" => new Weapon("Bastón del Caos", (int)(4 * multiplier), (int)(8 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Caos Primordial", (int)(4 * multiplier), (int)(7 * multiplier), AttackSpeed.Normal, StatusEffect.Stunned, 1, 'Q'),
                        new Attack("Vórtice Destructor", (int)(5 * multiplier), (int)(8 * multiplier), AttackSpeed.Slow, StatusEffect.Burning, 3, 'W'),
                        new Attack("Rayo del Vacío", (int)(3 * multiplier), (int)(6 * multiplier), AttackSpeed.Fast, StatusEffect.None, 0, 'E')
                    }
                },
                "Orbe del Vacío" => new Weapon("Orbe del Vacío", (int)(3 * multiplier), (int)(6 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Absorción Vital", (int)(2 * multiplier), (int)(4 * multiplier), AttackSpeed.Normal, StatusEffect.None, 0, 'Q'),
                        new Attack("Implosión", (int)(4 * multiplier), (int)(6 * multiplier), AttackSpeed.Slow, StatusEffect.Stunned, 2, 'W'),
                        new Attack("Teletransporte Ofensivo", (int)(3 * multiplier), (int)(5 * multiplier), AttackSpeed.Fast, StatusEffect.None, 0, 'E')
                    }
                },
                "Vara de las Tormentas" => new Weapon("Vara de las Tormentas", (int)(3 * multiplier), (int)(7 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Relámpago", (int)(3 * multiplier), (int)(5 * multiplier), AttackSpeed.Fast, StatusEffect.Stunned, 1, 'Q'),
                        new Attack("Tormenta Eléctrica", (int)(4 * multiplier), (int)(7 * multiplier), AttackSpeed.Slow, StatusEffect.Stunned, 2, 'W'),
                        new Attack("Rayo Divino", (int)(5 * multiplier), (int)(8 * multiplier), AttackSpeed.Slow, StatusEffect.Burning, 1, 'E')
                    }
                },

                // Armas de Arquero
                "Arco Largo Élfico" => new Weapon("Arco Largo Élfico", (int)(2 * multiplier), (int)(6 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Disparo Certero", (int)(2 * multiplier), (int)(5 * multiplier), AttackSpeed.Normal, StatusEffect.None, 0, 'Q'),
                        new Attack("Flecha Perforante", (int)(3 * multiplier), (int)(6 * multiplier), AttackSpeed.Normal, StatusEffect.Bleeding, 2, 'W'),
                        new Attack("Lluvia de Flechas", (int)(1 * multiplier), (int)(4 * multiplier), AttackSpeed.Fast, StatusEffect.None, 0, 'E')
                    }
                },
                "Ballesta de Precisión" => new Weapon("Ballesta de Precisión", (int)(3 * multiplier), (int)(7 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Virote Pesado", (int)(3 * multiplier), (int)(6 * multiplier), AttackSpeed.Slow, StatusEffect.None, 0, 'Q'),
                        new Attack("Disparo Explosivo", (int)(4 * multiplier), (int)(7 * multiplier), AttackSpeed.Slow, StatusEffect.Burning, 2, 'W'),
                        new Attack("Virote Envenenado", (int)(2 * multiplier), (int)(5 * multiplier), AttackSpeed.Normal, StatusEffect.Poisoned, 3, 'E')
                    }
                },
                "Arco Recurvo Mágico" => new Weapon("Arco Recurvo Mágico", (int)(2 * multiplier), (int)(5 * multiplier), level)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Flecha Mágica", (int)(2 * multiplier), (int)(4 * multiplier), AttackSpeed.Fast, StatusEffect.None, 0, 'Q'),
                        new Attack("Flecha de Hielo", (int)(3 * multiplier), (int)(5 * multiplier), AttackSpeed.Normal, StatusEffect.Stunned, 1, 'W'),
                        new Attack("Flecha de Fuego", (int)(3 * multiplier), (int)(6 * multiplier), AttackSpeed.Normal, StatusEffect.Burning, 2, 'E')
                    }
                },

                // Arma por defecto
                _ => new Weapon("Arma Básica", 1, 3, 1)
                {
                    Attacks = new List<Attack>
                    {
                        new Attack("Ataque Básico", 1, 3, AttackSpeed.Normal, StatusEffect.None, 0, 'Q')
                    }
                }
            };
        }

        private void WriteColoredText(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        private void WriteColoredLine(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private void AnimateText(string text, ConsoleColor color = ConsoleColor.White, int delay = 50)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        private void ShowDamageAnimation(int damage, bool isCritical = false)
        {
            if (isCritical)
                WriteColoredText("💥 ¡CRÍTICO! ", ConsoleColor.Yellow);

            WriteColoredText($"💢 {damage} daño", damage > 5 ? ConsoleColor.Red : ConsoleColor.Magenta);
            Console.WriteLine();
        }

        public void Start()
        {
            ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                WriteColoredLine("╔══════════════════════════════════════════════════════════╗", ConsoleColor.Cyan);
                WriteColoredLine("║           🏰 JUEGO DE ROL - HÉROES VS MONSTRUOS 🐉        ║", ConsoleColor.Yellow);
                WriteColoredLine("╚══════════════════════════════════════════════════════════╝", ConsoleColor.Cyan);
                Console.WriteLine();
                WriteColoredLine("⚔️  1. Nuevo Juego (Modo Historia)", ConsoleColor.Green);
                WriteColoredLine("🏟️  2. Modo Arena", ConsoleColor.Blue);
                WriteColoredLine("💀 3. Modo Supervivencia", ConsoleColor.Red);
                WriteColoredLine("🚪 4. Salir", ConsoleColor.Gray);
                Console.WriteLine();
                WriteColoredText("🎮 Selecciona una opción: ", ConsoleColor.White);

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        StartNewGame(GameMode.Story);
                        break;
                    case "2":
                        StartNewGame(GameMode.Arena);
                        break;
                    case "3":
                        StartNewGame(GameMode.Survival);
                        break;
                    case "4":
                        return;
                    default:
                        WriteColoredLine("❌ Opción inválida. Presiona cualquier tecla...", ConsoleColor.Red);
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void StartNewGame(GameMode mode)
        {
            CreateHero();
            currentLevel = 1;

            switch (mode)
            {
                case GameMode.Story:
                    PlayStoryMode();
                    break;
                case GameMode.Arena:
                    PlayArenaMode();
                    break;
                case GameMode.Survival:
                    PlaySurvivalMode();
                    break;
            }
        }

        private void CreateHero()
        {
            Console.Clear();
            WriteColoredLine("╔══════════════════════════════════════════╗", ConsoleColor.Cyan);
            WriteColoredLine("║        🦸 SELECCIÓN DE HÉROE 🦸           ║", ConsoleColor.Yellow);
            WriteColoredLine("╚══════════════════════════════════════════╝", ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColoredLine("✨ Elige tu héroe del catálogo:", ConsoleColor.White);
            Console.WriteLine();
            
            for (int i = 0; i < heroTemplates.Count; i++)
            {
                var template = heroTemplates[i];
                string classIcon = template.Class switch
                {
                    HeroClass.Warrior => "⚔️",
                    HeroClass.Mage => "🔮",
                    HeroClass.Archer => "🏹",
                    _ => "❓"
                };
                
                WriteColoredText($"{i + 1}. {classIcon} ", ConsoleColor.Yellow);
                WriteColoredText($"{template.Name}", ConsoleColor.Cyan);
                WriteColoredText($" ({template.Class})", ConsoleColor.Gray);
                Console.WriteLine();
                WriteColoredText($"   ❤️ HP: {template.MaxHp}", ConsoleColor.Red);
                WriteColoredText($" 💪 Daño: {template.DamageMultiplier}%", ConsoleColor.Green);
                Console.WriteLine();
                WriteColoredText($"   📝 {template.Description}", ConsoleColor.White);
                Console.WriteLine();
                WriteColoredText($"   🗡️ Armas: ", ConsoleColor.Yellow);
                WriteColoredLine(string.Join(", ", template.UniqueWeapons), ConsoleColor.Magenta);
                Console.WriteLine();
            }
            
            WriteColoredText("🎯 Selecciona tu héroe (1-5): ", ConsoleColor.White);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= heroTemplates.Count)
            {
                var template = heroTemplates[choice - 1];
                player = new Hero(template);
                
                // Crear armas únicas basadas en el template
                player.Weapons.Clear();
                foreach (string weaponName in template.UniqueWeapons)
                {
                    player.Weapons.Add(CreateUniqueWeapon(weaponName, template.Class, 1, template.DamageMultiplier));
                }
                player.CurrentWeapon = player.Weapons[0];
            }
            else
            {
                var template = heroTemplates[0];
                player = new Hero(template);
                player.Weapons.Clear();
                foreach (string weaponName in template.UniqueWeapons)
                {
                    player.Weapons.Add(CreateUniqueWeapon(weaponName, template.Class, 1, template.DamageMultiplier));
                }
                player.CurrentWeapon = player.Weapons[0];
            }
            
            SelectWeapon();
            
            Console.WriteLine();
            AnimateText($"✨ ¡{player.Name} ha sido seleccionado! ✨", ConsoleColor.Green, 30);
            WriteColoredText($"🦸 Clase: ", ConsoleColor.White);
            WriteColoredText($"{player.Class}", ConsoleColor.Cyan);
            WriteColoredText($" ❤️ HP: ", ConsoleColor.White);
            WriteColoredText($"{player.CurrentHp}", ConsoleColor.Red);
            WriteColoredText($" ⚔️ Arma: ", ConsoleColor.White);
            WriteColoredLine($"{player.CurrentWeapon.Name}", ConsoleColor.Yellow);
            WriteColoredLine("\n🎮 Presiona cualquier tecla para continuar...", ConsoleColor.Gray);
            Console.ReadKey();
        }

        private void SelectWeapon()
        {
            Console.WriteLine();
            WriteColoredLine($"⚔️ Selecciona el arma inicial para {player.Name}:", ConsoleColor.Yellow);
            Console.WriteLine();
            
            for (int i = 0; i < player.Weapons.Count; i++)
            {
                var weapon = player.Weapons[i];
                WriteColoredText($"{i + 1}. ", ConsoleColor.White);
                WriteColoredText($"{weapon.Name}", ConsoleColor.Cyan);
                WriteColoredText($" (💥 {weapon.MinDamage}-{weapon.MaxDamage})", ConsoleColor.Red);
                Console.WriteLine();
                WriteColoredText($"   🎯 Ataques: ", ConsoleColor.Yellow);
                
                var attackList = weapon.Attacks.Select(a => 
                {
                    string speedIcon = a.Speed switch
                    {
                        AttackSpeed.Fast => "⚡",
                        AttackSpeed.Slow => "🐌",
                        _ => "🔄"
                    };
                    return $"{a.Name} ({a.HotKey}){speedIcon}";
                });
                WriteColoredLine(string.Join(", ", attackList), ConsoleColor.Magenta);
                Console.WriteLine();
            }
            
            WriteColoredText("🎯 Elige tu arma (1-3): ", ConsoleColor.White);
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= player.Weapons.Count)
            {
                player.CurrentWeapon = player.Weapons[choice - 1];
            }
        }

        private void PlayStoryMode()
        {
            if (player == null) return;
            
            Console.Clear();
            WriteColoredLine("╔═══════════════════════════════════════╗", ConsoleColor.Cyan);
            WriteColoredLine("║         📖 MODO HISTORIA 📖            ║", ConsoleColor.Yellow);
            WriteColoredLine("╚═══════════════════════════════════════╝", ConsoleColor.Cyan);
            Console.WriteLine();
            AnimateText("🎯 ¡Derrota 10 monstruos para convertirte en leyenda!", ConsoleColor.Green, 30);
            Console.WriteLine();
            
            for (int battle = 1; battle <= 10; battle++)
            {
                WriteColoredLine($"\n⚔️ --- Batalla {battle}/10 ---", ConsoleColor.Yellow);
                
                // Dificultad progresiva
                int monsterLevel = CalculateStoryModeLevel(battle);
                Monster monster = GenerateStoryMonster(battle, monsterLevel);
                
                if (!Battle(monster))
                {
                    Console.WriteLine();
                    AnimateText("💀 ¡GAME OVER! El héroe ha caído en batalla...", ConsoleColor.Red, 50);
                    WriteColoredLine("🎮 Presiona cualquier tecla para volver al menú...", ConsoleColor.Gray);
                    Console.ReadKey();
                    return;
                }
                
                // Ganar experiencia y posible level up
                player.Experience += monster.ExperienceReward;
                if (player.Experience >= player.Level * 50)
                {
                    player.Experience = 0;
                    player.LevelUp();
                    currentLevel++;
                }

                if (battle < 10)
                {
                    WriteColoredLine("⏭️ Presiona cualquier tecla para la siguiente batalla...", ConsoleColor.Gray);
                    Console.ReadKey();
                }
            }
            
            Console.WriteLine();
            AnimateText("🏆 ¡FELICIDADES! ¡Has completado el modo historia! 🏆", ConsoleColor.Yellow, 50);
            WriteColoredLine("🎮 Presiona cualquier tecla para volver al menú...", ConsoleColor.Gray);
            Console.ReadKey();
        }

        private void PlayArenaMode()
        {
            if (player == null) return;
            
            Console.WriteLine("\n=== MODO ARENA ===");
            Console.WriteLine("¡Lucha contra monstruos de diferentes niveles!");
            
            while (player.CurrentHp > 0)
            {
                Console.WriteLine($"\nSelecciona tu oponente:");
                Console.WriteLine("1. Goblin (Fácil)");
                Console.WriteLine("2. Orc (Medio)");
                Console.WriteLine("3. Dragon (Difícil)");
                Console.WriteLine("4. Undead (Especial)");
                Console.WriteLine("5. Volver al menú");
                
                string? choice = Console.ReadLine();
                if (choice == "5") return;
                
                MonsterType type = choice switch
                {
                    "1" => MonsterType.Goblin,
                    "2" => MonsterType.Orc,
                    "3" => MonsterType.Dragon,
                    "4" => MonsterType.Undead,
                    _ => MonsterType.Goblin
                };
                
                Monster monster = new Monster(type, currentLevel);
                if (!Battle(monster))
                {
                    Console.WriteLine("\n¡Has sido derrotado en la arena!");
                    Console.WriteLine("Presiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    return;
                }
            }
        }

        private void PlaySurvivalMode()
        {
            Console.WriteLine("\n=== MODO SUPERVIVENCIA ===");
            Console.WriteLine("¡Sobrevive tanto como puedas!");
            
            int battlesWon = 0;
            while (player.CurrentHp > 0)
            {
                battlesWon++;
                Console.WriteLine($"\n--- Oleada {battlesWon} ---");
                
                Monster monster = GenerateMonster(1 + battlesWon / 3);
                if (!Battle(monster))
                {
                    Console.WriteLine($"\n¡GAME OVER! Sobreviviste {battlesWon - 1} oleadas.");
                    Console.WriteLine("Presiona cualquier tecla para volver al menú...");
                    Console.ReadKey();
                    return;
                }
                
                // Curación parcial entre batallas
                player.CurrentHp = Math.Min(player.MaxHp, player.CurrentHp + 2);
                Console.WriteLine("Presiona cualquier tecla para la siguiente oleada...");
                Console.ReadKey();
            }
        }

        private Monster GenerateMonster(int level)
        {
            MonsterType[] types = { MonsterType.Goblin, MonsterType.Orc, MonsterType.Dragon, MonsterType.Undead };
            MonsterType randomType = types[rnd.Next(types.Length)];
            return new Monster(randomType, level);
        }

        private int CalculateStoryModeLevel(int battle)
        {
            return battle switch
            {
                1 => 1,           // Muy fácil
                2 or 3 => 2,      // Fácil
                4 or 5 or 6 => 3, // Medio
                7 or 8 => 4,      // Difícil
                9 or 10 => 5,     // Muy difícil
                _ => 1
            };
        }

        private Monster GenerateStoryMonster(int battle, int level)
        {
            // Reducir HP y daño para las primeras batallas
            MonsterType[] types = { MonsterType.Goblin, MonsterType.Orc, MonsterType.Dragon, MonsterType.Undead };
            MonsterType randomType = types[rnd.Next(types.Length)];
            
            var monster = new Monster(randomType, level);
            
            // Ajustar dificultad según la batalla
            float difficultyMultiplier = battle switch
            {
                1 => 0.6f,        // 40% menos HP/daño
                2 or 3 => 0.8f,   // 20% menos HP/daño
                4 or 5 or 6 => 1.0f, // Normal
                7 or 8 => 1.2f,   // 20% más HP/daño
                9 or 10 => 1.4f,  // 40% más HP/daño
                _ => 1.0f
            };
            
            monster.MaxHp = (int)(monster.MaxHp * difficultyMultiplier);
            monster.CurrentHp = monster.MaxHp;
            
            // Ajustar daño de ataques
            foreach (var attack in monster.Attacks)
            {
                attack.MinDamage = (int)(attack.MinDamage * difficultyMultiplier);
                attack.MaxDamage = (int)(attack.MaxDamage * difficultyMultiplier);
            }
            
            return monster;
        }

        private bool Battle(Monster monster)
        {
            if (player == null) return false;
            
            Console.WriteLine();
            AnimateText($"👹 ¡Un {monster.Name} aparece!", ConsoleColor.Red, 30);
            WriteColoredText($"❤️ HP: {monster.CurrentHp}", ConsoleColor.Red);
            Console.WriteLine();
            Thread.Sleep(1000);
            
            while (player.CurrentHp > 0 && monster.CurrentHp > 0)
            {
                // Procesar efectos de estado
                player.ProcessStatusEffect();
                monster.ProcessStatusEffect();
                
                if (player.CurrentHp <= 0) return false;
                if (monster.CurrentHp <= 0) return true;
                
                // Mostrar estado actual
                Console.WriteLine();
                WriteColoredText("🦸 ", ConsoleColor.Cyan);
                WriteColoredText($"{player.Name}", ConsoleColor.Cyan);
                WriteColoredText($" (❤️ {player.CurrentHp})", ConsoleColor.Red);
                WriteColoredText(" VS ", ConsoleColor.White);
                WriteColoredText($"👹 {monster.Name}", ConsoleColor.Magenta);
                WriteColoredText($" (❤️ {monster.CurrentHp})", ConsoleColor.Red);
                Console.WriteLine();
                
                // Turno del héroe
                if (player.CurrentEffect != StatusEffect.Stunned)
                {
                    var (heroTurns, monsterTurns) = ProcessHeroTurn(monster);
                    
                    if (monster.CurrentHp <= 0)
                    {
                        AnimateText($"🏆 ¡{monster.Name} ha sido derrotado!", ConsoleColor.Green, 30);
                        return true;
                    }
                    
                    // Turno del monstruo (puede ser múltiple si héroe usó ataque lento)
                    ProcessMonsterTurns(monster, monsterTurns);
                }
                else
                {
                    WriteColoredLine($"😵 {player.Name} está aturdido y pierde el turno!", ConsoleColor.Yellow);
                    // Monstruo ataca normalmente
                    ProcessMonsterTurns(monster, 1);
                }
                
                if (player.CurrentHp <= 0) return false;
                
                WriteColoredLine("─────────────────────────────────────", ConsoleColor.Gray);
                Thread.Sleep(1500);
            }
            
            return player.CurrentHp > 0;
        }

        private (int heroTurns, int monsterTurns) ProcessHeroTurn(Monster monster)
        {
            WriteColoredText($"⚔️ Arma actual: ", ConsoleColor.Yellow);
            WriteColoredLine($"{player.CurrentWeapon.Name}", ConsoleColor.Cyan);
            WriteColoredLine("🎯 Selecciona tu ataque:", ConsoleColor.White);
            
            foreach (var attack in player.CurrentWeapon.Attacks)
            {
                string speedIcon = attack.Speed switch
                {
                    AttackSpeed.Fast => "⚡",
                    AttackSpeed.Slow => "🐌",
                    _ => "🔄"
                };
                string effectText = attack.Effect != StatusEffect.None ? $" + {attack.Effect}" : "";
                WriteColoredText($"  {attack.HotKey} - ", ConsoleColor.Yellow);
                WriteColoredText($"{speedIcon} {attack.Name}", ConsoleColor.Cyan);
                WriteColoredText($" (💥 {attack.MinDamage}-{attack.MaxDamage}{effectText})", ConsoleColor.Red);
                Console.WriteLine();
            }
            WriteColoredLine("  R - 🔄 Cambiar arma", ConsoleColor.Gray);
            
            char input = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            
            if (input == 'R')
            {
                ChangeWeapon();
                return (0, 0); // Sin turno
            }
            
            var selectedAttack = player.CurrentWeapon.Attacks.FirstOrDefault(a => a.HotKey == input);
            if (selectedAttack != null)
            {
                return ExecuteHeroAttack(selectedAttack, monster);
            }
            else
            {
                WriteColoredLine("❌ Ataque inválido, pierdes el turno!", ConsoleColor.Red);
                return (0, 1);
            }
        }

        private (int heroTurns, int monsterTurns) ExecuteHeroAttack(Attack attack, Monster monster)
        {
            int heroTurns = attack.Speed == AttackSpeed.Fast ? 2 : 1;
            int monsterTurns = attack.Speed == AttackSpeed.Slow ? 2 : 1;
            
            for (int i = 0; i < heroTurns; i++)
            {
                if (monster.CurrentHp <= 0) break;
                
                int heroDamage = rnd.Next(attack.MinDamage, attack.MaxDamage + 1);
                int actualDamage = monster.TakeDamage(heroDamage, player.Class);
                
                WriteColoredText($"💥 {player.Name} usa ", ConsoleColor.Green);
                WriteColoredText($"{attack.Name}", ConsoleColor.Yellow);
                WriteColoredText("! ", ConsoleColor.Green);
                ShowDamageAnimation(actualDamage, heroDamage == attack.MaxDamage);
                
                if (attack.Effect != StatusEffect.None && monster.CurrentHp > 0)
                {
                    monster.ApplyStatusEffect(attack.Effect, attack.EffectDuration);
                }
                
                Thread.Sleep(800);
            }
            
            return (heroTurns, monsterTurns);
        }

        private void ProcessMonsterTurns(Monster monster, int turns)
        {
            if (monster.CurrentEffect == StatusEffect.Stunned)
            {
                WriteColoredLine($"😵 {monster.Name} está aturdido y pierde el turno!", ConsoleColor.Yellow);
                return;
            }
            
            for (int i = 0; i < turns && player.CurrentHp > 0; i++)
            {
                var (damage, effect, duration) = monster.Attack(rnd);
                player.CurrentHp = Math.Max(0, player.CurrentHp - damage);
                
                WriteColoredText($"💀 ", ConsoleColor.Red);
                ShowDamageAnimation(damage);
                WriteColoredText($"❤️ HP de {player.Name}: ", ConsoleColor.White);
                WriteColoredLine($"{player.CurrentHp}", ConsoleColor.Red);
                
                if (effect != StatusEffect.None && player.CurrentHp > 0)
                {
                    player.ApplyStatusEffect(effect, duration);
                }
                
                Thread.Sleep(800);
            }
        }

        private void ChangeWeapon()
        {
            Console.WriteLine();
            WriteColoredLine("🔄 Cambiar arma:", ConsoleColor.Yellow);
            for (int i = 0; i < player.Weapons.Count; i++)
            {
                var weapon = player.Weapons[i];
                string current = weapon == player.CurrentWeapon ? " 👈 (ACTUAL)" : "";
                WriteColoredText($"{i + 1}. ", ConsoleColor.White);
                WriteColoredText($"{weapon.Name}", ConsoleColor.Cyan);
                WriteColoredLine($"{current}", ConsoleColor.Green);
            }
            
            WriteColoredText("🎯 Selecciona arma: ", ConsoleColor.White);
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= player.Weapons.Count)
            {
                player.CurrentWeapon = player.Weapons[choice - 1];
                WriteColoredLine($"✅ Cambiaste a {player.CurrentWeapon.Name}", ConsoleColor.Green);
            }
        }
    }
}