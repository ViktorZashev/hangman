using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Hangman
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> dym = new List<string>(){///The dictionary
				"Aardvark","Abyssinian","Affenpinscher","Akbash","Akita","Albatross","Alligator","Alpaca","Angelfish","Ant","Anteater","Antelope","Ape","Armadillo","Ass","Avocet","Axolotl","Baboon","Badger","Balinese","Bandicoot","Barb","Barnacle","Barracuda","Bat","Beagle","Bear","Beaver","Bee","Beetle","Binturong","Bird","Birman","Bison","Bloodhound","Boar","Bobcat","Bombay","Bongo","Bonobo","Booby","Budgerigar","Buffalo","Bulldog","Bullfrog","Burmese","Butterfly","Caiman","Camel","Capybara","Caracal","Caribou","Cassowary","Cat","Caterpillar","Catfish","Cattle","Centipede",
				"Chameleon","Chamois","Cheetah","Chicken","Chihuahua","Chimpanzee","Chinchilla","Chinook","Chipmunk","Chough","Cichlid","Clam","Coati","Cobra","Cockroach","Cod","Collie","Coral","Cormorant","Cougar","Cow","Coyote","Crab","Crane","Crocodile","Crow","Curlew","Cuscus","Cuttlefish","Dachshund","Dalmatian","Deer","Dhole","Dingo","Dinosaur","Discus","Dodo","Dog","Dogfish","Dolphin","Donkey","Dormouse","Dotterel","Dove","Dragonfly","Drever","Duck","Dugong","Dunker","Dunlin","Eagle","Earwig","Echidna","Eel","Eland","Elephant","Elephant seal","Elk","Emu","Falcon","Ferret",
				"Finch","Fish","Flamingo","Flounder","Fly","Fossa","Fox","Frigatebird","Frog","Galago","Gar","Gaur","Gazelle","Gecko","Gerbil","Gharial","Giant Panda","Gibbon","Giraffe","Gnat","Gnu","Goat","Goldfinch","Goldfish","Goose","Gopher","Gorilla","Goshawk","Grasshopper","Greyhound","Grouse","Guanaco","Guinea fowl","Guinea pig","Gull","Guppy","Hamster","Hare","Harrier","Havanese","Hawk","Hedgehog","Heron","Herring","Himalayan","Hippopotamus","Hornet","Horse","Human","Hummingbird","Hyena","Ibis","Iguana","Impala","Indri","Insect","Jackal","Jaguar","Javanese","Jay","Jay, Blue",
				"Jellyfish","Kakapo","Kangaroo","Kingfisher","Kiwi","Koala","Komodo dragon","Kouprey","Kudu","Labradoodle","Ladybird","Lapwing","Lark","Lemming","Lemur","Leopard","Liger","Lion","Lionfish","Lizard","Llama","Lobster","Locust","Loris","Louse","Lynx","Lyrebird","Macaw","Magpie","Mallard","Maltese","Manatee","Mandrill","Markhor","Marten","Mastiff","Mayfly","Meerkat","Millipede","Mink","Mole","Molly","Mongoose","Mongrel","Monkey","Moorhen","Moose","Mosquito","Moth","Mouse","Mule","Narwhal","Neanderthal","Newfoundland","Newt","Nightingale","Numbat","Ocelot","Octopus","Okapi",
				"Olm","Opossum","Orang-utan","Oryx","Ostrich","Otter","Owl","Ox","Oyster","Pademelon","Panther","Parrot","Partridge","Peacock","Peafowl","Pekingese","Pelican","Penguin","Persian","Pheasant","Pig","Pigeon","Pika","Pike","Piranha","Platypus","Pointer","Pony","Poodle","Porcupine","Porpoise","Possum","Prairie Dog","Prawn","Puffin","Pug","Puma","Quail","Quelea","Quetzal","Quokka","Quoll","Rabbit","Raccoon","Ragdoll","Rail","Ram","Rat","Rattlesnake","Raven","Red deer","Red panda","Reindeer","Rhinoceros","Robin","Rook","Rottweiler","Ruff","Salamander","Salmon","Sand Dollar","Sandpiper",
				"Saola","Sardine","Scorpion","Sea lion","Sea Urchin","Seahorse","Seal","Serval","Shark","Sheep","Shrew","Shrimp","Siamese","Siberian","Skunk","Sloth","Snail","Snake","Snowshoe","Somali","Sparrow","Spider","Sponge","Squid","Squirrel","Starfish","Starling","Stingray","Stinkbug","Stoat","Stork","Swallow","Swan","Tang","Tapir","Tarsier","Termite","Tetra","Tiffany","Tiger","Toad","Tortoise","Toucan","Tropicbird","Trout","Tuatara","Turkey","Turtle","Uakari","Uguisu","Umbrellabird","Vicuña","Viper","Vulture","Wallaby","Walrus","Warthog","Wasp","Water buffalo","Weasel","Whale","Whippet",
				"Wildebeest","Wolf","Wolverine","Wombat","Woodcock","Woodlouse","Woodpecker","Worm","Wrasse","Wren","Yak","Zebra","Zebu","Zonkey","Zorse"
			};
			char[,] hangman =
			{
			{' ','_','_','_',' ',' '},
			{'|',' ',' ',' ','|',' '},
			{'|',' ',' ',' ','o',' '},
			{'|',' ',' ','/','0','\\'},
			{'|',' ',' ','/',' ','\\'},
			{'|',' ',' ',' ','=',' '}
			};
			int mistakes = 0;
			int n = dym.Count();///getting the size of the dictionary
								///Generating a random number
			Random rnd = new Random();
			int rand = rnd.Next(0, n);
			///Getting the size of the selected random word
			string real = dym[rand];
			int nd = dym[rand].Length;
			string view = "";
			string wrong = "";
			List<char> submitted = new List<char>();
			for (int i = 0; i < nd; i++)
			{
				if (real[i] == ' ') { view = view + ' '; }
				else view = view + '?';
			}
			while (view != real)
			{
				for (int i = 0; i < 6; i++)
				{
					for (int j = 0; j < 6; j++)
					{
						if (mistakes >= 1 && ((i == 1 && j == 0) || (i == 2 && j == 0) || (i == 3 && j == 0) || (i == 4 && j == 0) || (i == 5 && j == 0)))
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 2 && ((i == 0 && j == 1) || (i == 0 && j == 2) || (i == 0 && j == 3)))
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 3 && i == 1 && j == 4)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 4 && i == 2 && j == 4)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 5 && i == 3 && j == 4)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 6 && i == 3 && j == 3)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 7 && i == 3 && j == 5)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 8 && i == 4 && j == 3)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 9 && i == 4 && j == 5)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes >= 10 && i == 5 && j == 4)
						{
							Console.Write(hangman[i, j]);
						}
						else if (mistakes == 11)
						{
							Console.Clear();
							Console.WriteLine("You lost");
							Console.Write("The word was:");
							Console.WriteLine(real);
							Thread.Sleep(4000);
							return;
						}
						else Console.Write(" ");

					}
					///Printing the word
					Console.Write("  ");
					if (i == 0) Console.Write(view);
					if (i == 5) Console.Write(wrong);
					Console.WriteLine();
				}

				char byk = Convert.ToChar(Console.ReadLine().Trim().Replace(Environment.NewLine, "").Substring(0, 1));
				if (submitted.Contains(byk))
				{
					Console.Clear();
					continue;
				}
				submitted.Add(byk);
				bool flag = false;
				for (int i = 0; i < nd; i++)
				{
					if (real[i] == Char.ToLower(byk) || real[i] == Char.ToUpper(byk))
					{ if (i == 0)
						{
							byk = Char.ToUpper(byk);
						}
						var aStringBuilder = new StringBuilder(view);
						aStringBuilder[i] = byk;
						view = aStringBuilder.ToString();
						flag = true;
						byk = Char.ToLower(byk);
					}
				}
				if (!flag)
				{
					wrong = wrong + byk;
					mistakes++;
				}
				Console.Clear();
				if (view == real) break;
			}
			Console.WriteLine("You Won!");
			Console.WriteLine("Congratulations");
			Thread.Sleep(4000);
			return;
		}

	}
}
