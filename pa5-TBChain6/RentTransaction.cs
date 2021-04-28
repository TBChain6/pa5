using System;

namespace pa5_TBChain6
{
    public class RentTransaction
    {
        private string listingID;
        private string renterName;
        private string renterEmail;
        private double rentalAmt;
        private DateTime rentalDate;
        private DateTime checkOutDate;
        private string ownerEmail;
        private static int count;
        public RentTransaction(string listingID, string renterName, string renterEmail, double rentalAmt, DateTime rentalDate, DateTime checkOutDate, string ownerEmail)
        {
            this.listingID = listingID;
            this.renterName = renterName;
            this.renterEmail = renterEmail;
            this.rentalAmt = rentalAmt;
            this.rentalDate = rentalDate;
            this.checkOutDate = checkOutDate;
            this.ownerEmail = ownerEmail;
        }
        public void SetListingID(string listingID)
        {
            this.listingID = listingID;
        }
        public string GetListingID()
        {
            return listingID;
        }
        public void SetRenterName(string renterName)
        {
            this.renterName = renterName;
        }
        public string GetRenterName()
        {
            return renterName;
        }
        public void SetRenterEmail(string renterEmail)
        {
            this.renterEmail = renterEmail;
        }
        public string GetRenterEmail()
        {
            return renterEmail;
        }
        public void SetRentalAmt(double rentalAmt)
        {
            this.rentalAmt = rentalAmt;
        }
        public double GetRentalAmt()
        {
            return rentalAmt;
        }
        public void SetRentalDate(DateTime rentalDate)
        {
            this.rentalDate = rentalDate;
        }
        public DateTime GetRentalDate()
        {
            return rentalDate;
        }
        public void SetCheckOutDate(DateTime checkOutDate)
        {
            this.checkOutDate = checkOutDate;
        }
        public DateTime GetCheckOutDate()
        {
            return checkOutDate;
        }
        public void SetOwnerEmail(string ownerEmail)
        {
            this.ownerEmail = ownerEmail;
        }
        public string GetOwnerEmail()
        {
            return ownerEmail;
        }
        public static void SetCount(int count)
        {
            RentTransaction.count = count;
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
            return listingID + "\t" + renterName + "\t" + renterEmail + "\t" + rentalAmt + "\t" + rentalDate + "\t" + checkOutDate + "\t" + ownerEmail;
        }
        public string ToFile() // method for writing to file
        {
            return listingID.ToString() + '#' + renterName + '#' + renterEmail + '#' + rentalAmt + '#' + rentalDate + '#' + checkOutDate + '#' + ownerEmail;
        }
        public static RentTransaction[] LeaseCondo(Listing[] myListings, RentTransaction[] myTransactions) // method for leasing a condo
        {
            Listing.PrintListingID(myListings);
            Console.WriteLine("Please enter the listing ID for the condo you would like to lease.");
            int iD = Listing.SelectListing(myListings, Console.ReadLine());
            Console.WriteLine("Please enter your name.");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter your email.");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter the amount being paid for the condo.");
            double amt = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter today's date. Format: mm/dd/yyyy");
            DateTime today = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your expected check out date. Format: mm/dd/yyyy");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the owner's email.");
            string owner = Console.ReadLine();
            string totalTransaction = iD.ToString() + '#' + name + '#' + email + '#' + amt + '#' + today + '#' + checkOut + '#' + owner;
            string[] temp = totalTransaction.Split('#');
            temp[0] = myListings[iD].GetListingID();
            myListings[iD].SetAvailable(false); // updates availability of lease
            myTransactions[count] = new RentTransaction(temp[0], temp[1], temp[2], double.Parse(temp[3]), DateTime.Parse(temp[4]), DateTime.Parse(temp[5]), temp[6]);
            return myTransactions;
        }
        public static void PrintTransactions(RentTransaction[] myTransactions) // method for printing transactions
        {
            Console.WriteLine("ID nCustomer  Customer Email  Lease  Amount  Date Lease Signed  Check Out Date  Owner Contact\n");

            for(int i = 0; i < RentTransaction.GetCount(); i++)
            {
                Console.WriteLine(myTransactions[i].ToString());
            }
        }
    }
}