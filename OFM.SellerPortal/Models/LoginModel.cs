using System.ComponentModel.DataAnnotations;

namespace OFM.SellerPortal.Models
{
    public class LoginModel
    {
        [Required(
            ErrorMessageResourceType = typeof(Resources.App),
            ErrorMessageResourceName = nameof(Resources.App.LoginPage_LabelUsername))]
        [EmailAddress]
        public string UserName { get; set; } = string.Empty;

        [Required(
            ErrorMessageResourceType = typeof(Resources.App),
            ErrorMessageResourceName = nameof(Resources.App.LoginPage_LabelPasswordRequired))]
        [MinLength(
            6,
            ErrorMessageResourceType = typeof(Resources.App),
            ErrorMessageResourceName = nameof(Resources.App.LoginPage_LabelPasswordRequired))]
        public string Password { get; set; } = string.Empty;
    }
}
