namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Views;
    using System.Linq;

    public class AddReplyController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;
        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        public ReplyViewModel Reply { get; private set; }
        public PostViewModel Post { get; private set; }
        public TextArea TextArea { get; set; }
        public bool Error { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.AddContent:
                    this.ReadContent();
                    return MenuState.AddReply;
                case Command.Write:
                    this.TextArea.Write();
                    this.Reply.Content = this.TextArea
                                                .Lines.ToList();
                    return MenuState.AddReply;
                case Command.Reply:
                    //bool validPost = PostService.TryAddReply(this.Reply);
                    //if (!validPost)
                    //{
                    //    this.Error = true;
                    //    return MenuState.Rerender;
                    //}
                    return MenuState.ReplyAdded;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.Post.Author = userName;
            this.Reply.Author = userName;
            return new AddReplyView(this.Post, this.Reply, this.TextArea, this.Error);
        }

        public void ReadContent()
        {
            //this.Reply.Content = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ResetReply()
        {
            this.Error = false;
            this.Reply = new ReplyViewModel();
            this.TextArea = new TextArea(centerLeft - 18, centerTop - 7, TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }

        private enum Command
        {
            AddContent, Write, Reply
        }
    }
}
