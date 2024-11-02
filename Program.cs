using System;
using System.ComponentModel.Design;
namespace ADVOOP
{
    public class Program
    {
        static void Main(string[] args)
        {
            PhoneBookService contactController = new();
            bool isCalledExit = false;
            Console.Clear();
            contactController.ViewAllContacts();
            while(!isCalledExit)
            {
                System.Console.WriteLine("Please select option: ");
                System.Console.WriteLine("1. Create Contact");
                System.Console.WriteLine("2. Remove Contact ");
                System.Console.WriteLine("3. Show List");
                System.Console.WriteLine("4. Edit Contact");
                System.Console.WriteLine("5. View Contacts(by Name)");
                System.Console.WriteLine("6. Exit");
                try
                {
                    if(int.TryParse(Console.ReadLine(), out int option))
                    {
                    
                        switch(option)
                        {
                            case 1:
                            {
                            Console.Clear();
                            System.Console.Write("Enter Name to add: ");
                            string input1 = Console.ReadLine();

                            System.Console.Write("Enter Phone number to add: ");
                            string input2 = Console.ReadLine();

                            contactController.AddContact(input1, input2);
                            break;
                            }
                            case 2:
                            {
                                contactController.RemoveContact();
                                break;
                            }
                            case 3:
                            {
                                contactController.ViewAllContacts();
                                System.Console.WriteLine("Press Enter to continue...");
                                Console.ReadKey();
                                break;
                            }
                            case 4:
                            {
                                contactController.EditContact();
                                break;
                            }
                            case 5:
                            {
                                contactController.ViewByName();
                                break;
                            }
                            case 6:
                            {
                                System.Console.WriteLine("Closing app....");
                                isCalledExit = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Menu option: Error input. Try again!");
                    }
                }
                catch(Exception ex)
                {
                       LoggingBroker.LogError(ex);
                     //  LoggingBroker.ReadError();
                }

                
            }
        }
     
       
    }
}