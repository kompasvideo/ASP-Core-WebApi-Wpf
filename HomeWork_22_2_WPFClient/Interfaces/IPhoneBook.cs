using HomeWork_22_2_WPFClient.Models;
using System.Collections.Generic;

namespace HomeWork_22_2_WPFClient.Interfaces
{
    public interface IPhoneBook
    {
        IEnumerable<PhoneBook> phoneBooks { get; set; }
        IEnumerable<PhoneBook> GetPhoneBook();
        PhoneBook GetPhoneBookId( int id);
        void AddAndEditRecord(PhoneBook phoneBook);
        void DeleteRecord(int id);
    }
}
