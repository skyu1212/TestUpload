 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using KomodoBadges_Repository;
namespace KomodoBadges
{
    class Badges
    {
        int badgeId;
        List<string> doorname = new List<string>();
        //List<int> BadgeName = new List<int>();
        // string badgeName;
        int doorNumber = 0;
        string userresponse;
        BadgesRepository MyBadges = new BadgesRepository();

        public Badges()
        {
            MyBadges.ReadFromDataBase();
        }

        public void createNewBadge()
        {
            
            Console.WriteLine("What is the number on the badge?");
            badgeId = int.Parse(Console.ReadLine()); 
            Console.WriteLine("List a door that it needs access to.");
            string dooraccess = Console.ReadLine();
             
                doorname.Add(dooraccess); 

            Console.WriteLine("Any other doors(y/n)?");
            string response = Console.ReadLine();
            while(response != "n")
            {
                Console.WriteLine("List a door that it needs access to.");
                dooraccess = Console.ReadLine();
                
                doorname.Add(dooraccess);
                Console.WriteLine("Any other doors(y/n)?");
                response = Console.ReadLine();
            }
            if(response=="n")
            { 
                    MyBadges.Badges.Add(badgeId, doorname);
               

                Console.WriteLine("return to main nenu.");
            }
        } 

        public void listAllBadges()
        {
            /*string build = "";
            foreach (var myaccess in MyBadges.Badges.Keys)
             {
               // Console.WriteLine(myaccess);
                foreach (var Listchild in MyBadges.Badges[myaccess])
                 {
                    build += " " + Listchild.ToString();
                    Console.WriteLine("Badge: " + myaccess + " Door: " + build);
                }
               
            }*/
            foreach (var contents in MyBadges.Badges.Keys)
            {

                foreach (var listMember in MyBadges.Badges[contents])
                {
                    Console.WriteLine("Key : " + contents + " member :" + listMember);
                }
            }

            /*foreach (KeyValuePair<int, List<string>> Show in MyBadges.Badges)
            {
                
                foreach (var Listchild in Show.Value)
                {

                    build += " " + Listchild.ToString();
                }
                Console.WriteLine(build.ToString());
            }*/
        }

        public void UpdateBadge()
        {
            int count = 0;
            Console.WriteLine("\nWhat is the badge number to update?");
            userresponse = Console.ReadLine(); 
            string build = "";
            foreach (var myaccess in MyBadges.Badges.Keys)
            {
                foreach (var Listchild in MyBadges.Badges[myaccess])
                {                    
                    if (myaccess.ToString() == userresponse)
                    {
                        if (count > 0)
                        {
                            build += " & ";
                            build += Listchild;                           
                        }
                        else
                        {
                            build += Listchild;
                        }
                        count++;
                    }                   
                }
                if (myaccess.ToString() == userresponse)
                {
                    Console.WriteLine("Badge: " + myaccess + " has access to Door: " + build);
                }
               
            }           
            Console.WriteLine("What would you like to do?\n1. Remove a door\n2. Add a door");
            int response = int.Parse(Console.ReadLine());
            switch (response)
            {
                case 1:
                    Console.WriteLine("Which door would you like to remove?");
                    string removedoor = Console.ReadLine();
                    int Id = int.Parse(userresponse); 
                    MyBadges.Badges[Id].Remove(removedoor);
                    listAllBadges();                                                             
                    break;
                case 2:
                    Console.WriteLine("Which door would you like to add?");
                    int Id1 = int.Parse(userresponse);
                    string adddoor = Console.ReadLine();
                    MyBadges.Badges[Id1].Add(adddoor);
                    listAllBadges();
                    break; 
            }
        } 

        // Creating properties to be used outside the class
        public int _badgId
        {
            get
            {
                return badgeId;
            }
            set
            {
                badgeId = value;
            }
        }
        
            // Creating properties to be used outside the class

       
        public List<string> _doorname
        {
            get
            {
                return doorname;
            }
            set
            {
                doorname = value;
            }
        }
    }
}
