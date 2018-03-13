namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using System;

    public class PostDetailsController : IController, IUserRestrictedController
    {
        public bool LoggedInUser { get; private set; }

        public int PostId { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Back:
                    ForumViewEngine.ResetBuffer();
                    return MenuState.Back;
                case Command.AddReply:

                    return MenuState.AddReplyToPost;
            }

            throw new InvalidCastException();
        }

        public IView GetView(string userName)
        {
            //var pvm = PostService.GetPostViewModel(this.PostId);
            //return new PostDetailsController(pvm, this.LoggedInUser);
            throw new System.NotImplementedException();
        }

        public void UserLogIn()
        {
            this.LoggedInUser = true;
        }

        public void UserLogOut()
        {
            this.LoggedInUser = false;
        }

        public void SetPostId(int postId)
        {
            this.PostId = postId;
        }

        private enum Command
        {
            Back, AddReply
        }
    }
}
