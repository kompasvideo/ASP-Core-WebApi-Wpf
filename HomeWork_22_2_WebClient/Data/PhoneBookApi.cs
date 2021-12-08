using Newtonsoft.Json;
using System.Text;

namespace HomeWork_22_2_WebClient.Data
{
    public class PhoneBookApi : IPhoneBook
    {
        private HttpClient httpClient { get; set; }

        public IEnumerable<PhoneBook> phoneBooks { get; set; }
        PhoneBook phoneBooksRecord { get; set; }

        public PhoneBookApi()
        {
            httpClient = new HttpClient();
        }

        public IEnumerable<PhoneBook> GetPhoneBook()
        {
            string url = @"https://localhost:5001/PhoneBook";

            string json = httpClient.GetStringAsync(url).Result;

            phoneBooks = JsonConvert.DeserializeObject<IEnumerable<PhoneBook>>(json);
            return phoneBooks;
        }

        public PhoneBook GetPhoneBookId(int id)
        {
            string url = @"https://localhost:5001/PhoneBook/" + id.ToString();

            string json = httpClient.GetStringAsync(url).Result;

            phoneBooksRecord = JsonConvert.DeserializeObject<PhoneBook>(json);
            return phoneBooksRecord;
        }

        public void AddAndEditRecord(PhoneBook phoneBook)
        {
            string url = @"https://localhost:5001/PhoneBook";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(phoneBook), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }

        public void DeleteRecord(int id)
        {
            string url = @"https://localhost:5001/PhoneBook/" + id.ToString();

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(id.ToString(), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }
    }
}
