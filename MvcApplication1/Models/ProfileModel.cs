namespace MvcApplication1.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class ProfileModel
    {
        public ProfileModel()
        {

        }

        public ProfileModel(string userId, string emailAddress, string creationDate, string theme)
        {
            this.UserId = userId;
            this.EmailAddress = emailAddress;
            this.CreationDate = creationDate;
            this.Theme = theme;
        }

        public string UserId { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email address")]
        public string EmailAddress { get; set; }

        public string CreationDate { get; set; }

        public string Theme { get; set; }
    }
}