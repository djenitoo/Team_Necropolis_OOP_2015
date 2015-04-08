namespace TaskManager.Task
{
    using System;

    using Interfaces;
    using Validation;
    using User.Interfaces;

    public class Note : IComment
    {
        private readonly ICommentValidation validation;

        private string content;

        public Note(string initContent, IPerson author)
        {
            this.Content = initContent;
            this.DateCreated = DateTime.Now;
            this.Author = author;

            this.validation = new CommentValidation();
        }

        public string Content
        {
            get
            {
                return this.content;
            }

            private set
            {
                this.validation.ValidateContent(value, "Content length");

                this.content = value;
            }
        }

        public DateTime DateCreated { get; private set; }

        public IPerson Author { get; private set; }
    }
}
