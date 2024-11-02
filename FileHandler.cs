using System;
namespace ADVOOP
{
    internal class FileHandler
    {
        private string FilePath = "./Contacts/Contacts.txt";

        //Read text from file
        public List<Contact> ReadContactsFromFile()
        {
            //Fields
            List<Contact> contacts1 = new List<Contact>();
            string name = "";
            string phone = "";
            string temp = File.ReadAllText(FilePath);
            
             if(!string.IsNullOrEmpty(temp))
             {
               string[] splittedString = temp.Split();
               
               //Iteration for split string and add to List
               foreach(string str in splittedString)
               {
                    if(str != null && str != "" && str != " " && str.Any(char.IsLetterOrDigit))
                    {
                        if(str.Any(char.IsLetter))
                        {
                           name = str;
                        }
                        else if(str.Any(char.IsDigit))
                        {
                            phone = str;
                        }                    
                    }
                    if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone))
                    {
                        contacts1.Add(new Contact(name, phone));
                        name = "";
                        phone = "";
                    }   
               }
                
             }
             else
                    {
                        System.Console.WriteLine("List is Empty.");
                    }
                    
                    return contacts1;
        }
        
        //Write to file 
        //Manages File Operations
        public void WriteContactsToFile(List <Contact> contacts)
        {
            try
            {
                 File.WriteAllText(FilePath, "");
                 foreach(Contact contact in contacts)
            {
                File.AppendAllText(FilePath, $"{contact.Name.PadRight(15)}{contact.Phone}{Environment.NewLine}");
            }
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory("Contacts");
                WriteContactsToFile(contacts);
            }
           
        }
        
    }
}