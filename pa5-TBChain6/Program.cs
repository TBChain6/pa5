using System;

namespace pa5_TBChain6
{
    class Program
    {
      public static Listing[] myListings;
      public static RentTransaction[] myTransactions;
        static void Main(string[] args)
        {
            OpeningStatement(); // calls method for introduction to program
            myListings = ListingFile.GetAllListings(); // reads listings
            myTransactions = RentTransactionFile.GetAllRentTransactions(); // reads transactions

            string menu = ""; // priming read
            while(menu != "6") // condition check
            {
                menu = GetMenuChoice(); // update read
                Selection(menu, myListings, myTransactions); // menu selection
                InvalidResponse(menu); // error checking
                ListingFile.WriteListings(myListings); // writes listings
                RentTransactionFile.WriteTransactions(myTransactions); // writes transactions
            }

            Goodbye(); // calls method for message leaving program
        }
        static void OpeningStatement() // method for introducing RentMyPlace.com
        {
          Console.Clear();
            Console.WriteLine("Hello. This is RentMyPlace.com!\nYou will have multiple options that will meet all of your renting and leasing needs.\nWe hope you have an exceptional experience.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        static string GetMenuChoice() // methhod for picking menu choice
        {
          Console.Clear();
          Console.WriteLine("Welcome to RentMyPlace.com\n");
          Console.WriteLine("1) Add a Listing\n2) Edit a Listing\n3) Delete a Listing\n4) Lease a Condo\n5) Run Reports\n6) Exit");
          return Console.ReadLine();
        }
        static void Selection(string menu, Listing[] myListings, RentTransaction[] myTransactions) // method for menu selection
        {
            Console.Clear();
            if(menu == "1") // menu choice calls method for adding a listing
              {
                AddAListing(myListings);
              }
            if(menu == "2") // menu choice calls method for editing a listing
              {
                EditAListing(myListings);
              }
            if(menu == "3") // menu choice calls method for deleting a listing
              {
                DeleteAListing(myListings);
              }
            if(menu == "4") // menu choice calls method for leasing a condo
              {
                LeaseACondo(myListings, myTransactions);
              }
            if(menu == "5") // menu choice calls method for running reports
              {
                RunReports(myListings, myTransactions);
              }
        }
        static void InvalidResponse(string menu) // method for menu error checking
        {
            int choice = int.Parse(menu); // priming read
            if (choice < 1 || choice > 6) // condition check
            {
                Console.WriteLine("Invalid choice, please try again");
            }
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static void Goodbye() // method for bidding a user farewell
        {
            Console.Clear();
            Console.WriteLine("Thank you for using RentMyPlace.com!");
        }
        static void AddAListing(Listing[] myListings) // method for adding a listing
        {
            string menu = ""; // priming read
            while(menu != "2") // condition check
            {
              menu = GetMenuChoiceForAdding(); // update read
              AddingSelection(menu, myListings); // menu selection
              CombinedInvalidResponse(menu); // error checking
            }
        }
        static void EditAListing(Listing[] myListings) // method for editing a listing
        {
            string menu = ""; // priming read
            while(menu != "2") // condition check
            {
              menu = GetMenuChoiceForEditing(); // update read
              EditingSelection(menu, myListings); // menu selection
              CombinedInvalidResponse(menu); // error checking
            }
        }
        static void DeleteAListing(Listing[] myListings) // method for deleting a listing
        {
            string menu = ""; // priming read
            while(menu != "2") // condition check
            {
              menu = GetMenuChoiceForDeleting(); // update read
              DeletingSelection(menu, myListings); // menu selection
              CombinedInvalidResponse(menu); // error checking
            }
        }
        static void LeaseACondo(Listing[] myListings, RentTransaction[] myTransactions) // method for leasing a condo
        {
            string menu = ""; // priming read
            while(menu != "2") // condition check
            {
              menu = GetMenuChoiceForLeasing(); // update read
              LeasingSelection(menu, myListings, myTransactions); // menu selection
              CombinedInvalidResponse(menu); // error checking
            }
        }
        static void RunReports(Listing[] myListings, RentTransaction[] myTransactions) // method for running reports
        {
            string menu = ""; // priming read
            while(menu != "4") // condition check
            {
              menu = GetMenuChoiceForRunReports(); // update read
              RunReportsSelection(menu, myListings, myTransactions); // menu selection
              RunReportsInvalidResponse(menu); // error checking
            }
        }
        static string GetMenuChoiceForAdding()
        {
          Console.Clear();
          Console.WriteLine("Please select either:\n1) Add Listing\n2) Exit");
          return Console.ReadLine();
        }
        static string GetMenuChoiceForEditing()
        {
          Console.Clear();
          Console.WriteLine("Please select either:\n1) Edit Listing\n2) Exit");
          return Console.ReadLine();
        }
        static void AddingSelection(string menu, Listing[] myListings) // method for menu selection
        {
            Console.Clear();
            if(menu == "1") // menu choice calls method for editing a listing
              {
                myListings = Listing.AddAListing(myListings);
                Console.Clear();
                Console.WriteLine("Your listing has been created.\n");
              }
        }
        static void EditingSelection(string menu, Listing[] myListings) // method for menu selection
        {
            Console.Clear();
            if(menu == "1") // menu choice calls method for editing a listing
              {
                myListings = Listing.EditListings(myListings);
                Console.Clear();
                Console.WriteLine("Your listing has been edited.\n");
              }
        }
        static void CombinedInvalidResponse(string menu) // method for menu error checking
        {
            int choice = int.Parse(menu); // priming read
            if (choice < 1 || choice > 2) // condition check
            {
              Console.WriteLine("Invalid choice, please try again");
            }
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
        static string GetMenuChoiceForDeleting() // method for menu choice in deleting
        {
          Console.Clear();
          Console.WriteLine("Please select either:\n1) Delete Listing\n2) Exit");
          return Console.ReadLine();
        }
        static void DeletingSelection(string menu, Listing[] myListings) // method for menu selection
        {
            Console.Clear();
            if(menu == "1") // menu choice calls method for deleting a listing
              {
                myListings = Listing.RemoveListings(myListings);
                Console.Clear();
                Console.WriteLine("Your listing has been removed.\n");
              }
        }
        static string GetMenuChoiceForLeasing() // method for menu choice in leasing
        {
          Console.Clear();
          Console.WriteLine("Please select either:\n1) View Available Leases\n2) Exit");
          return Console.ReadLine();
        }
        static void LeasingSelection(string menu, Listing[] myListings, RentTransaction[] myTransactions) // method for menu selection
        {
            Console.Clear();
            if(menu == "1") // menu choice calls method for viewing available leases
              {
                myTransactions = RentTransaction.LeaseCondo(myListings, myTransactions);
                Console.Clear();
                Console.WriteLine("Your transaction has been recorded.\n");
              }
        }
        static string GetMenuChoiceForRunReports() // method for menu choice in reporting
        {
          Console.Clear();
          Console.WriteLine("Please select either:\n1) Print Available Listings\n2) Historical Customer Rentals\n3) Historical Revenue Report\n4) Exit");
          return Console.ReadLine();
        }
        static void RunReportsSelection(string menu, Listing[] myListings, RentTransaction[] myTransactions) // method for menu selection
        {
            Console.Clear();
            if(menu == "1") // menu choice calls method for displaying available listings
              {
                Listing.PrintAvlbListings(myListings);
              }
            if(menu == "2") // menu choice calls method for displaying historical customer rentals
              {
                RentTransaction.PrintTransactions(myTransactions);
              }
            if(menu == "3") // menu choice calls method for displaying historical revenue report
              {
                Listing.RevenueReport(myListings);
              }
        }
        static void RunReportsInvalidResponse(string menu) // method for menu error checking
        {
            int choice = int.Parse(menu); // priming read
            if (choice < 1 || choice > 4) // condition check
            {
              Console.WriteLine("Invalid choice, please try again");
            }
            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}