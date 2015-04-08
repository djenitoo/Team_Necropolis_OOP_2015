
namespace TaskManager.Task.Validation
{
    using Common;

    public class CommentValidation : CommonValidation, ICommentValidation
    {
        private const int MaxContentLength = 600;
        private const int MinContentLenght = 10;

        public void ValidateContent(string value, string param)
        {
            this.NotNullable(value, param);

            this.StringLengthMinMax(value, param, MaxContentLength, MinContentLenght);
        }
    }
}
