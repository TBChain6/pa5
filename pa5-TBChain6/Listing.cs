using System;

namespace pa5_TBChain6
{
    public class Listing
    {
        private string listingID;
        private string address;
        private DateTime listingEndDate;
        private double listPrice;
        private string ownerEmail;
        private bool available;
        private static int count;
        public Listing(string listingID, string address, DateTime listingEndDate, double listPrice, string ownerEmail, bool available)
        {
            this.listingID = listingID;
            this.address = address;
            this.listingEndDate = listingEndDate;
            this.listPrice = listPrice;
            this.ownerEmail = ownerEmail;
            this.available = available;
        }
        public void SetListingID(string listingID)
        {
            this.listingID = listingID;
        }
        public string GetListingID()
        {
            return listingID;
        }
        public void SetAddress(string address)
        {
            this.address = address;
        }
        public string GetAddress()
        {
            return address;
        }
        public void SetListingEndDate(DateTime listingEndDate)
        {
            this.listingEndDate = listingEndDate;
        }
        public DateTime GetListingEndDate()
        {
            return listingEndDate;
        }
        public void SetListPrice(double listPrice)
        {
            this.listPrice = listPrice;
        }
        public double GetListPrice()
        {
            return listPrice;
        }
        public void SetOwnerEmail(string ownerEmail)
        {
            this.ownerEmail = ownerEmail;
        }
        public string GetOwnerEmail()
        {
            return ownerEmail;
        }
        public void SetAvailable(bool available)
        {
            this.available = available;
        }
        public bool GetAvailable()
        {
            return available;
        }
        public static void SetCount(int count)
        {
            Listing.count = count;
        }
        public static int GetCount()
        {
            return count;
        }
        public static void IncCount()
        {
            count++;
        }
        public override string ToString() // method for concatonating all variables into a string
        {
            return address + "  " + listingEndDate + "  " + listPrice + "\t" + ownerEmail;
        }
        public string ToFile() // method for writing to file
        {
            return listingID.ToString() + '#' + address + '#' + listingEndDate + '#' + listPrice + '#' + ownerEmail + '#' + available;
        }
        public static Listing[] AddAListing(Listing[] myListings) // method for adding a listing
        {
            Console.Clear();
            Console.WriteLine("Please enter a listing address.");
            string listAddress = Console.ReadLine();
            Console.WriteLine("Please enter a listing end date. Format: mm/dd/yyyy");
            DateTime listEnd = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a price for your listing.");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the owner's email.");
            string email = Console.ReadLine();
            bool available = true;
            Guid iD = Guid.NewGuid();
            string totalListing = iD.ToString() + '#' + listAddress + '#' + listEnd + '#' + price + '#' + email + '#' + available;
            string[] temp = totalListing.Split('#');
            myListings[GetCount()] = new Listing(iD.ToString(), temp[1], DateTime.Parse(temp[2]), double.Parse(temp[3]), temp[4], true);
            IncCount();
            return myListings;
        }
        public static void PrintAvlbListings(Listing[] myListings) // prints available listings in report format
        {
            Console.WriteLine("Address\tEnd Date\tPrice\tOwner Email\n");

            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(myListings[i].GetAvailable() == true)
                {
                    Console.WriteLine(myListings[i].ToString());
                }
            }
        }
        public static void RevenueReport(Listing[] myListings) // prints all revenue in report
        {
            double sum = myListings[0].GetListPrice();
        
            for (int i = 1; i < Listing.GetCount(); i++)
            {
                sum += myListings[i].GetListPrice();
            }

            Console.WriteLine($"The total revenue is ${sum}.");
        }
        public static Listing[] EditListings(Listing[] myListings) // editing a listing
        {
            PrintListingID(myListings);
            Console.WriteLine("Please enter the listing ID for the listing you would like to edit.");
            int iD = SelectListing(myListings, Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Please enter a listing address.");
            string listAddress = Console.ReadLine();
            Console.WriteLine("Please enter a listing end date. Format: mm/dd/yyyy");
            DateTime listEnd = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a price for your listing.");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the owner's email.");
            string email = Console.ReadLine();
            bool available = true;
            string totalListing = iD.ToString() + '#' + listAddress + '#' + listEnd + '#' + price + '#' + email + '#' + available;
            string[] temp = totalListing.Split('#');
            temp[0] = myListings[iD].GetListingID();
            myListings[iD] = new Listing(temp[0], temp[1], DateTime.Parse(temp[2]), double.Parse(temp[3]), temp[4], true);
            return myListings;
        }
        public static Listing[] RemoveListings(Listing[] myListings) // removing a listing
        {
            PrintListingID(myListings);
            Console.WriteLine("Please enter the listing ID for the listing you would like to edit.");
            int iD = SelectListing(myListings, Console.ReadLine());
            myListings[iD].SetAvailable(false);
            return myListings;
        }
        public static void PrintListingID(Listing[] myListings) // prints listing along with id
        {
            Console.WriteLine("ID\t\t\t\t\t Address\tEnd Date\tPrice Owner Email\n");

            for (int i = 0; i < GetCount(); i++)
            {
                if (myListings[i].GetAvailable() == true)
                {
                    Console.WriteLine(myListings[i].GetListingID() + "\t" + myListings[i].ToString());
                }
            }
        }
        public static int SelectListing(Listing[] myListings, string selection) // select a specific listing based on ID with this search
        {
            int location = 0;
            for (int i = 0; i < GetCount(); i++)
            {
                string compare = myListings[i].GetListingID();
                if (compare.Contains(selection))
                {
                    location = i;
                }
            }
            return location;
        }
    }
}