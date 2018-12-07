using System.ComponentModel.DataAnnotations;

namespace Sentry1.Models.AccountViewModels
{
    public class LoginWithRecoveryCodeViewModel
    {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Taastamise kood")]
            public string RecoveryCode { get; set; }
    }
}
