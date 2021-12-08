using HomeWork_22_2_WebClient;

namespace HomeWork_22_2_WebClient.Interfaces
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
