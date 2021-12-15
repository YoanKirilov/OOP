using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OOP_Ass_011
{
    class App
    {
        Room room = new Room(13, 20);
        Inventory inventory = new Inventory();
        Pet pet = null;
        Store store;

        public void Run()
        {
            Console.WriteLine("Choose an Animal");
            Console.WriteLine("1.Land Animal");
            Console.WriteLine("2.UnderWater Animal");
            string input = Console.ReadLine();
            Console.WriteLine("Choose Prefered temperature");
            string input1 = Console.ReadLine();

            if (input == "1")
            {
                pet = new LandAnimal(int.Parse(input1));
            }
            else if (input == "2")
            {
                pet = new UnderWaterAnimal(int.Parse(input1));
            }
            while (true)
            {
                Thread.Sleep(1000);
                Console.Clear();

                inventory.Coins++;
                pet.Hunger++;
                pet.Thirst++;
                pet.Mood--;
                room.Adjust_Temperature();
                pet.Feed();

                pet.Display_Stat();
                room.Display_Temperature();
                inventory.Display();
                Console.WriteLine();

                if (pet.Hunger > 70) { pet.Health--; Warning("Current Hunger level is too high for your pet!"); }
                if (pet.Thirst > 70) { pet.Health--; Warning("Current Thirst level is too high for your pet!"); }
                if (Math.Abs(pet.Prefered_temperature - room.Current_temperature) > 5)
                {
                    pet.Health--;
                    Warning("Current temperature is too far from the recommended temperature for your pet!");
                    Warning("Please adjust the temperature with point 7 from the menu.");
                }
                if (pet.Health <= 0) System.Environment.Exit(1);

                Console.WriteLine("Choose what you want to do with the pet:");
                Console.WriteLine("1.Feed Pet");
                Console.WriteLine("2.Hydrate Pet");
                Console.WriteLine("3.Play with Pet");
                Console.WriteLine("4.Action");
                Console.WriteLine("5.Tend to Pet");
                Console.WriteLine("6.Shop");
                Console.WriteLine("7.Adjust temperature");
                Console.WriteLine("8.Skip");
                Console.WriteLine("9.Exit");
                input = Console.ReadLine();
                Console.Clear();

                switch (int.Parse(input))
                {
                    case 1:
                        //In this case first we are checking if there is food in the inventory
                        Food food = (Food)inventory.Contains("Food");
                        if (food == null)
                        {
                            Warning("No Food in Inventory!");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            //Then it displays every food in the inventory and prompts the user to choose one 
                            Console.WriteLine("Choose a Food to use:");
                            inventory.Display("Food");
                            input = Console.ReadLine();
                            food = (Food)inventory.Use(int.Parse(input), "Food");
                            //And after the user has chosen a food we remove it from the inventory and add its stats to the pet 
                            pet.Feeding += food.Food_uses;
                            pet.Mood += food.Mood;
                            inventory.Remove_Item(food);
                            Successful("Pet successfully feeded!");
                        }
                        break;

                    case 2:
                        //In this case first we are checking if there is drink in the inventory
                        Drink drink = (Drink)inventory.Contains("Drink");
                        if (drink == null)
                        {
                            Warning("No drink in Inventory!");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            //Then it displays every drink in the inventory and prompts the user to choose one 
                            Console.WriteLine("Choose a Drink to use:");
                            inventory.Display("Drink");
                            input = Console.ReadLine();
                            drink = (Drink)inventory.Use(int.Parse(input), "Drink");
                            //And after the user has chosen a drink we remove it from the inventory and add its stats to the pet 
                            pet.Thirst -= drink.Hydration;
                            pet.Mood += drink.Mood;
                            inventory.Remove_Item(drink);
                            Successful("Pet successfully hydrated!");
                        }
                        break;

                    case 3:
                        //In this case first we are checking if there is a toy in the inventory
                        Toy toy = (Toy)inventory.Contains("Toy");
                        if (toy == null)
                        {
                            Warning("No Toy in Inventory!");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            //Then it displays every toy in the inventory and prompts the user to choose one 
                            Console.WriteLine("Choose a toy to play with:");
                            inventory.Display("Toy");
                            input = Console.ReadLine();
                            toy = (Toy)inventory.Use(int.Parse(input), "Toy");
                            //And after the user has chosen a toy we check if it is usable by this type of pet 
                            if (toy.Usable_by.Contains(pet.GetType().Name))
                            {
                                toy.Uses--;
                                if (toy.Uses == 0)
                                {
                                    inventory.Remove_Item(toy);
                                }

                                pet.Mood += toy.Mood_increase;
                            }
                            else
                            {
                                Warning("This Toy is not usable by this type of Pet!");
                                Thread.Sleep(1000);
                            }
                        }
                        break;

                    case 4:
                        if (pet.GetType().Name == "LandAnimal")
                        {
                            //If the pet is Land Animal type the pet will be able to use the action Run
                            Console.WriteLine("Choose an Action:");
                            Console.WriteLine("1.Run");
                            input = Console.ReadLine();
                            if (int.Parse(input) == 1)
                            {
                                pet.Run();
                            }
                        }
                        else if (pet.GetType().Name == "UnderWaterAnimal")
                        {
                            //If the pet is UnderWater Animal type the pet will be able to use the action Swim
                            Console.WriteLine("Choose an Action:");
                            Console.WriteLine("1.Swim");
                            input = Console.ReadLine();
                            if (int.Parse(input) == 1)
                            {
                                pet.Swim();
                            }
                        }
                        break;

                    case 5:
                        //In this case first we are checking if there is medicine in the inventory
                        Medicine medicine = (Medicine)inventory.Contains("Medicine");
                        if (medicine == null)
                        {
                            Warning("No Medicine in Inventory!");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            //Then it displays every medicine in the inventory and prompts the user to choose one 
                            Console.WriteLine("Choose a Medicine to use:");
                            inventory.Display("Medicine");
                            input = Console.ReadLine();
                            medicine = (Medicine)inventory.Use(int.Parse(input), "Medicine");
                            //And after the user has chosen a food we remove it from the medicine and add its stats to the pet 
                            pet.Health += medicine.Health;
                            pet.Hunger += medicine.Hunger;
                            pet.Thirst += medicine.Thirst;
                            inventory.Remove_Item(medicine);
                            Successful("Pet successfully tended to!");
                        }
                        break;

                    case 6:
                        store = new Store();
                        //Until the input is over than the size of the store the user will have to buy again
                        while (int.Parse(input) <= store.Size())
                        {
                            Console.WriteLine("Choose what you want to buy:");
                            store.Display_Items();
                            input = Console.ReadLine();
                            //Checks if the input is valid 

                            if (int.Parse(input) <= store.Size())
                            {
                                Storeable item = store.Shop(int.Parse(input));
                                //If the user has enough coins the item is addres to their inventory and its price is deducted from the user's balance
                                if (inventory.Coins >= item.Price)
                                {
                                    inventory.Add_Item(item);
                                    inventory.Coins -= item.Price;
                                    Successful("Item succesfuly bought!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                                else
                                {
                                    Warning("Insufficient coins");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                            }
                            store = new Store();
                        }
                        break;

                    case 7:
                        //It allows you to ajust the temperature of the room by either cooling or warming it  
                        room.Display_Temperature();
                        Console.WriteLine("Do you want to:" + "\n1.Cool" + "\n2.Warm");
                        input = Console.ReadLine();
                        Console.WriteLine("With how much degrees do you want to change the temperature:");
                        double input2 = double.Parse(Console.ReadLine());
                        if (input == "1")
                        {
                            room.Current_temperature -= input2;
                        }
                        else if (input == "2")
                        {
                            room.Current_temperature += input2;
                        }
                        break;

                    case 9:
                        //With this case you exit the program
                        System.Environment.Exit(1);
                        break;

                    default:
                        break;

                }
            }
        }
        public void Successful(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
