

using SiliconWebbApp.Models.Form;

namespace SiliconWebbApp.Models.Views
{
    public class SignInViewModel
    {
        public string Title { get; set; } = "Sign In";

        public SignInModel Form { get; set; } = new SignInModel();

      
    }
}
