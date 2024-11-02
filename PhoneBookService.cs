using System;
using System.ComponentModel.DataAnnotations;
namespace ADVOOP
{
    public class PhoneBookService
    {
        FileHandler fileHandler = new FileHandler(); 
        LoggingBroker logBroker = new LoggingBroker();
        private List <Contact> contacts = new List<Contact> ();
         
        public void AddContact(string name, string phone)
        {  
             contacts =  fileHandler.ReadContactsFromFile();

            if (isPhoneNumber(phone))
            {
                if(!string.IsNullOrEmpty(name))
                {
                    if(contacts.Find(c => c.Phone == phone) == null) //Check if there is registered phone number
                    {
                        Contact newContact = new Contact(name, phone);
                        contacts.Add(newContact);
                        System.Console.WriteLine($"Added. Name: {name}\nPhone Number: {phone}");
                        fileHandler.WriteContactsToFile(contacts);
                    }
                    else
                    {
                        System.Console.WriteLine($"Phone number is exist with {contacts.Find(c => c.Phone == phone).Name}. You can change it in Edit section .");
                    }
                }
                else
                {
                    if(contacts.Find(c => c.Phone == phone) == null) //Check if there is registered phone number
                    {
                        Contact newContact = new Contact(phone);
                        contacts.Add(newContact);
                        fileHandler.WriteContactsToFile(contacts);
                        System.Console.WriteLine($"Added. Name: Unknown\nPhone Number: {phone}");
                    }
                    else
                    {
                        System.Console.WriteLine($"Phone number is exist with {contacts.Find(c => c.Phone == phone).Name}. You can change it in Edit section .");
                    }
                }  
            }
            
        System.Console.WriteLine("Press Enter to continue...");
        Console.ReadKey();
        }
        
        //Method for deleting
        public void RemoveContact()
        {
            ViewAllContacts();
            System.Console.Write("Please enter phone number you want to delete: ");
            string phone = Console.ReadLine();
            if(phone != null && isPhoneNumber(phone))
            {
                contacts.Remove(contacts.Find(c => c.Phone == phone));
                fileHandler.WriteContactsToFile(contacts);
                System.Console.WriteLine("Deleted.");
            }
            else if(string.IsNullOrEmpty(phone))
            {
                System.Console.WriteLine("Input was empty.");
            }
            else
            {
                System.Console.WriteLine("Wrong input.");
            }

        }

        //Method for Edit
        public void EditContact()
        {
           System.Console.WriteLine("Choose option:");
           System.Console.WriteLine("1. Edit by Name");
           System.Console.WriteLine("2. Edit by Phone Number");
           if(int.TryParse(Console.ReadLine(), out int temp))
           {
            switch(temp)
            {
                case 1: //Edit by Name
                {
                    ViewAllContacts();
                    System.Console.Write("Enter Name to edit: ");
                    string name =  Console.ReadLine();
                    var contact = contacts.Find(c => c.Name == name);
                    var holdForDeleteting = contact; //Need to delete because it changes during method
                    if(contact != null)
                    {
                        System.Console.WriteLine($"Enter new name for {contact.Phone}: ");
                       //fields
                        string updatedName = Console.ReadLine();
                        contact.Name = updatedName; 
                        //methods to call
                        contacts.Add(contact);
                        contacts.Remove(holdForDeleteting);
                        fileHandler.WriteContactsToFile(contacts);
                        //result
                        System.Console.WriteLine($"Done.\nUpdated: {contact.Name} {contact.Phone}");
                    }
                    else
                    {
                        System.Console.WriteLine("Not found.");
                    }
                    
                    break;
                }
                case 2: //Edit by Phone number
                {
                    ViewAllContacts();
                    System.Console.Write("Enter Phone Number to edit: ");
                    string phone = Console.ReadLine();
                    if(phone != null && isPhoneNumber(phone)) //Check with isPhoneNumber method
                    {
                        var contact = contacts.Find(c => c.Phone == phone);
                        if(contact != null) //If contact has result
                        {
                        System.Console.Write($"Enter a new Phone number for {contact.Name}: ");
                        
                        //fields
                        string updatedPhone = Console.ReadLine();
                        var holdForDeleteting = contact;
                        contact.Phone = updatedPhone;

                        //methods to call
                        contacts.Remove(holdForDeleteting);
                        contacts.Add(contact);
                        fileHandler.WriteContactsToFile(contacts);

                        }
                        fileHandler.WriteContactsToFile(contacts); //Updating File
                        System.Console.WriteLine($"Done.\nUpdated: {contact.Name} {contact.Phone}"); //result
                    }
                    break;
                }
                default:
                {
                    System.Console.WriteLine("Incorrect input. Try Again.");
                    EditContact();
                    break;
                }
                
            }
           }
        }

        //View all contacts
        public void ViewAllContacts()
        {
            contacts = fileHandler.ReadContactsFromFile();
            int i = 0;
            System.Console.WriteLine("List of Contacts: ");
            foreach(Contact contact in contacts)
            {
                i++;
                System.Console.WriteLine(i+ ") " + contact.Name.PadRight(15) + contact.Phone);
            }
        }

        //Search by Name
        public void ViewByName()
        {
            Console.Clear();
            int i = 0;
            System.Console.WriteLine("List of Contact(by Name)");
            foreach (Contact contact in contacts)
            {
                i++;
                System.Console.WriteLine(i + ") " + contact.Name);
            }
            System.Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        public bool isPhoneNumber(string phone)
        {
            char[] variables = phone.ToCharArray();

           try{
            if(!string.IsNullOrEmpty(phone))
            {
                if(phone.StartsWith("+"))
                {
                  for(int i = 1; i < variables.Length; i++)
                    {
                        if(!char.IsDigit(variables[i]))
                        {
                            return false;
                        }
                    }
                } 
                else
                {
                    for(int i = 0; i < variables.Length; i++)
                    {
                        if(!char.IsDigit(variables[i]))
                        {
                            return false;
                        }
                    }
                } 
                return true;
            }
            else
            {
               throw new Exception("checking phone number: Input was empty.");
               
            }
           }
           catch(Exception ex)
           {
               
                LoggingBroker.LogError(ex);
                 return false;
           }
        }
        //Uses 

    }
}