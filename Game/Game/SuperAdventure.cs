 public class SuperAdventure
{
     public Monster CurrentMonster;
     public Player ThePlayer;

     public SuperAdventure(Monster currentmonster, Player theplayer)
     {
        CurrentMonster = currentmonster;
        ThePlayer = theplayer;
     }

     public bool FightMonster()
     {
         var w = new World();
         w.Text_Display($"\nFight started between {ThePlayer.Name} and {CurrentMonster.Name}.");
         CurrentMonster.HP = CurrentMonster.MaxHP;
         while(true)
         {
            w.Text_Display($"(1) Use {ThePlayer.Weapon.Name}\n(2) Use Potion");
            int choice = Convert.ToChar(Console.ReadLine());

            if (choice == '1')
            {
               ThePlayer.AttackWeapon(CurrentMonster);
               if (CurrentMonster.HP <= 0)
               {
                  w.Text_Display($"{CurrentMonster.Name} has been defeated");
                  w.Text_Display("You won the battle");
                  ThePlayer.DropMonsterItem(CurrentMonster);
                  ThePlayer.LevelUp();
                  ThePlayer.Balance += 25;
                  CurrentMonster.HP = CurrentMonster.MaxHP;
                  return false;
               }
            }
            if (choice == '1')
            {
               if (ThePlayer.SmallPotionInventory.PotionQuantity == 0 && ThePlayer.BigPotionInventory.PotionQuantity == 0)
               {
                  w.Text_Display("No potions in inventory");
               }
               else
               {
                  w.Text_Display($"(1) Use Small Health Potion, Amount left: {ThePlayer.SmallPotionInventory.PotionQuantity}");
                  w.Text_Display($"(2) Use Big Health Potion, Amount left: {ThePlayer.BigPotionInventory.PotionQuantity}");
                  int potion_choise = Convert.ToChar(Console.ReadLine());
                  if(potion_choise == '1')
                  {
                     if(ThePlayer.SmallPotionInventory.PotionQuantity == 0){w.Text_Display("No Small Health Potions left");}
                     else
                     {
                     ThePlayer.HP += ThePlayer.SmallPotionInventory.PotionEffect;
                     if(ThePlayer.HP > ThePlayer.Max_hp){ThePlayer.HP = ThePlayer.Max_hp;}
                     ThePlayer.SmallPotionInventory.PotionQuantity -= 1;
                     w.Text_Display($"Potion Consumed, Current HP: {ThePlayer.HP}, {ThePlayer.SmallPotionInventory.Name} left: {ThePlayer.SmallPotionInventory.PotionQuantity}");
                     }
                  }
                  if(potion_choise == '2')
                  {
                     if(ThePlayer.BigPotionInventory.PotionQuantity == 0){w.Text_Display("No Big Health Potions left");}
                     else
                     {
                        ThePlayer.HP += ThePlayer.BigPotionInventory.PotionEffect;
                        if(ThePlayer.HP > ThePlayer.Max_hp){ThePlayer.HP = ThePlayer.Max_hp;}
                        ThePlayer.BigPotionInventory.PotionQuantity -= 1;
                        w.Text_Display($"Potion Consumed, Current HP: {ThePlayer.HP}, {ThePlayer.BigPotionInventory.Name} left: {ThePlayer.BigPotionInventory.PotionQuantity}");
                     }
                  }
               }
            }    
            CurrentMonster.AttackWeapon(ThePlayer);
            if(ThePlayer.HP <= 0)
            {
               w.Text_Display($"You have lost");
               w.Text_Display($"You have a {CurrentMonster.ItemDrop.Name}");
               CurrentMonster.ItemDrop.DropQuantity -= 1;
               if (CurrentMonster.ItemDrop.DropQuantity < 0){CurrentMonster.ItemDrop.DropQuantity = 0;}
               ThePlayer.WipeOut();
               return false;
            }  
         }
     }

     public void InfiniteMode()
     {
      Console.WriteLine("You are gonna fight Knights untill you lose the will get increasingly stronger");
      bool gamestate = true;

      while(gamestate == true)
      {
         FightMonster();
         if(ThePlayer.Location == "Your House")
         {
            gamestate = false;
         }
         if(gamestate == true)
         {
         CurrentMonster.MaxHP += 10;
         CurrentMonster.Weapon.MaxDamage += 10;
         ThePlayer.ChangeWeapon();
         }
      }
     }
}