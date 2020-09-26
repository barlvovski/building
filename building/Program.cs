using System;

namespace building
{
    class Room
    {
        private int type;
        private int len;
        private int width;


        public Room(int mytype, int mylen, int mywidth)
        {
             type = mytype;
             len = mylen;
            width = mywidth;
        }
        public Room(Room r)
        {
            this.type = r.type;
            this.len = r.len;
            this.width = r.width;
        }
        public int getarea()
        {
            return (this.len * this.width);
        }
        

    }
    class Apartment
    {
        private string own;
        private Room[] rooms;


        public Apartment(string myown)
        {
            Random myRandom = new Random();
            own = myown;
            int myNumRooms = myRandom.Next(0, 9);
            rooms = new Room[myNumRooms];
            for (int j = 0; j < myNumRooms; j++)
            {
                int roomType = myRandom.Next(1, 4);
                int roomLen = myRandom.Next(4, 8);
                int roomWidth = myRandom.Next(3, 6);
                Room r = new Room(roomType, roomLen, roomWidth);
                rooms[j] = r;
            
            }
            
        }
        public string getowner()
        {
            return (own);
        }
        public string getsize()
        {
            int a = 0;
            for (int i = 0; i < this.rooms.Length; i++)
            {
                a += this.rooms[i].getarea();
            }
            if (a <= 70)
                return ("small");
            if (a <= 110)
                return ("medium");
            return ("large");
        }

    }
    class Address
    {
        private string street;
        private int num;
        private string city;


        public Address (string mystreet, string mycity, int mynum)
        {
            street = mystreet;
            num = mynum;
            city = mycity;
        }
        public string getAdddress()
        {
            return street + num.ToString() + " , " + city;
        }

    }


    class Building
    {
        private Address add;
        private Apartment[] apps;


        public Building(string mystreet, int mynum, string mycity)
        {
            Random myRandom = new Random();
            int numApps = myRandom.Next(0, 99);
            apps = new Apartment[numApps];
            Address myadd = new Address(mystreet,  mycity , mynum);
            add = myadd;
            

            
            for (int i = 0; i < numApps; i++)
            {
                apps = new Apartment[numApps];
                
                
                Apartment app = new Apartment("Cohen");
                this.apps[i] = app;

            }



        }

        public int getkamutbysize(string size)


        {
            int zover = 0;
            for (int i = 0; i < apps.Length; i++)
            {
             if (apps[i].getsize() == size)
                {
                    zover += 1;
                }
             
            }
            return (zover);
        }

        public string[] ownersbysize(string size)
        {
            string[] owners = new string[100];
            int iowner = 0 ;
            for (int i = 0; i < apps.Length; i++)
            {
                if (apps[i].getsize() == size)
                {
                    owners[i] = apps[i].getowner();
                    iowner++;
                }

            }
            return (owners);
        }
        public string getAdddress()
        {
            return add.getAdddress();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int MAX_IN_STREET = 113;
            Building[] buildings = new Building[MAX_IN_STREET];
            for (int i = 0; i < MAX_IN_STREET; i++)
            {
                Building mybuild = new Building("David Ha Melech", i, "Ramat Gan");
                buildings[i] = mybuild;
            }

            //int [] indofmax = new int[MAX_IN_STREET];
            int max = 0;
            int indofmax = 0;
            int[] arrmaxB = new int[MAX_IN_STREET];
            for (int i = 0; i < MAX_IN_STREET; i++)
            {
                int d = buildings[i].getkamutbysize("large"); 
                if(d > max)
                {
                    max = d;
                    indofmax = 0;
                    arrmaxB[indofmax] = i;
                    
                }
                if( d == max)
                {
                    indofmax++;
                    arrmaxB[indofmax] = i;
                }

            }
                
           


        }
    }
}

