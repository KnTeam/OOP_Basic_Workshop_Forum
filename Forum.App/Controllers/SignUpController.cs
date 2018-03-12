namespace Forum.App.Controllers
{
	using Forum.App;
	using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;

	public class SignUpController : IController, IReadUserInfoController
	{
		private const string DETAILS_ERROR = "Invalid Username or Password!";
		private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        public string Username { get; private set; }

        private string Password { get; set; }

        private string ErrorMessage { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Login;
                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Login;
                case Command.SignUp:
                    // TODO: try signup
                    return MenuState.Error;
                case Command.Back:
                    this.ResetSignUp();
                    return MenuState.Back;
            }

            throw new System.InvalidOperationException("Invalid command!");
        }

        public IView GetView(string userName)
        {
            return new SignUpView(this.ErrorMessage);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        private void ResetSignUp()
        {
            this.ErrorMessage = string.Empty;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }

        private enum Command
        {
            ReadUsername, ReadPassword, SignUp, Back
        }

        private enum SignUpStatus
        {
            Success, DetailsError, UsernameTaken
        }
    }
}
