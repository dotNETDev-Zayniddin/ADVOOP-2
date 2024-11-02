using System;
using System.ComponentModel.DataAnnotations;
namespace ADVOOP
{
    public class Contact
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; }
        public Contact(string name, string phone)   
        {
            Name = name;
            Phone = phone;
        }
        public Contact(string phone)   
        {
            Name = "Unknown";
            Phone = phone;
        }
    }
}