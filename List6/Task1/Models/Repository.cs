using Task1.Models;

namespace MeetingApplication.Models
{
    public static class Repository
    {

        static Repository()
        {
            Console.WriteLine("REPO CREATED------------------------------------");
            _users.Add(new BusinessCardViewModel()
            {
                Name = "Rifki",
                Surname = "Kesepara",
                Age = 20,
                IdNumber= "sds133441",
                Country= "Turkey",
                City="Istanbul",
                Street="Sariyer",
                HouseApartmentNumber=18,
                FontSize=20,
                Typeface="",
                BackgroundColor="green",
                IsBold=true,
                IsUnderlined=true,
                IsItalic=true,

            });
        }
        private static List<BusinessCardViewModel> _users = new();

        public static List<BusinessCardViewModel> users
        {
            get
            {
                return _users;
            }
        }

        public static void CreateUser(BusinessCardViewModel user)
        {
            _users.Add(user);
        }

        //public static BusinessCardViewModel? GetById(int Id)
        //{
        //    return _users.FirstOrDefault(user => user.id == Id);
        //}
    }

}
