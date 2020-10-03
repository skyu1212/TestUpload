using KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoConsoleChallenge
{
    public class Menu
    {
        const int _SIZE = 5;
        
        int _mealnumber=0;
        string _mealname;
        string _mealdescription;
        string _ingredients;
        string check;
        double _price;
        CafeRepository Cafe = new CafeRepository();
        public Menu()
        {
             Cafe.DeleteDataBase();
            _mealname = "thismeal";
            _mealdescription = "thisdescription";
            _ingredients = "thisingredient";
            _price = 1.00;
            for (int i = 0; i < _SIZE; i++)
            {

                Cafe._MenuItems[i] = string.Format("{0}: {1}\n{2}\n{3}\nprice: {4}\n", i+1, _mealname, _mealdescription, _ingredients, _price++);
                _mealnumber=i+1;
                Cafe.CreateDataBase(_mealnumber.ToString(), _mealname, _mealdescription, _ingredients, (_price).ToString());
            }
            Cafe.ReadFromDataBase();
        }

        public void add()
        {
            Console.WriteLine("Do you want to add or modify the menu? Press 1 to add or 2 to modify.");
            string choice = Console.ReadLine();
            if(choice=="1")
            {
                Console.WriteLine("Enter the name for the meal");
                _mealname = Console.ReadLine();
                Console.WriteLine("Enter the meal description");
                _mealdescription = Console.ReadLine();
                Console.WriteLine("Enter the meal ingredients");
                _ingredients = Console.ReadLine();
                Console.WriteLine("Enter the price for the meal");
                double value = 0;
                check = Console.ReadLine();
                while (!(double.TryParse(check, out value)))
                {
                    Console.WriteLine("Wrong value type. Please re-type the correct value.");
                    check = Console.ReadLine();
                }
                _price = double.Parse(check);
                string[] temparray = new string[Cafe._MenuItems.Length + 1];
                for (int i = 0; i < _SIZE; i++)
                {
                    temparray[i] = Cafe._MenuItems[i];
                }
                _mealnumber++;
                temparray[temparray.Length - 1] = string.Format("{0}: {1}\n{2}\n{3}\nprice: {4}\n", _mealnumber, _mealname, _mealdescription, _ingredients, _price);

                Cafe._MenuItems = temparray;
                
            }
            else if(choice=="2")
            {
                Console.WriteLine("Enter the menu item you would like to modify");
                int choice1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the name for the meal");
                _mealname = Console.ReadLine();
                Console.WriteLine("Enter the meal description");
                _mealdescription = Console.ReadLine();
                Console.WriteLine("Enter the meal ingredients");
                _ingredients = Console.ReadLine();
                Console.WriteLine("Enter the price for the meal");
                double value = 0;
                check = Console.ReadLine();
                while (!(double.TryParse(check, out value)))
                {
                    Console.WriteLine("Wrong value type. Please re-type the correct value.");
                    check = Console.ReadLine();
                }
                _price = double.Parse(check);
                Cafe._MenuItems[choice1-1] = string.Format("{0}: {1}\n{2}\n{3}\nprice: {4}\n", choice1, _mealname, _mealdescription, _ingredients, _price);
            }
            populatemenu();
        }

        public void delete()
        {
            Console.WriteLine("Enter the number of the menu item you would like deleted.");
            int delete = int.Parse(Console.ReadLine());
            Cafe._MenuItems[delete] = string.Format("{0}: blank\nblank\nblank\nprice: blank\n", delete+1);
            populatemenu();
            
        }

        public void populatemenu()
        {
            for (int i = 0; i < Cafe._MenuItems.Length; i++)
            {
                Console.WriteLine(Cafe._MenuItems[i]);
            }
            
        }

        public void showmenu()
        {
            Console.Write("Welcome to Komodo Cafe. Every meal is served with ten-grain toast or whole wheat buttermilk biscuit,");
            Console.WriteLine("whipped honey butter and homemade fruit puree.");
            for (int i=0; i < _SIZE; i++)
            {
                Console.WriteLine(Cafe._MenuItems[i]);
            }
        }

        public int mealnumber
        {
            get
            {
                return _mealnumber;

            }
            set
            {
                _mealnumber = value;
            }
        }

        public string mealname
        {
            get
            {
                return _mealname;

            }
            set
            {
                _mealname = value;
            }
        }

        public string mealdescription
        {
            get
            {
                return _mealdescription;

            }
            set
            {
                _mealdescription = value;
            }
        }

        public double price
        {
            get
            {
                return _price;

            }
            set
            {
                _price = value;
            }
        }
    }
}
