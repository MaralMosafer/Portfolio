using _0_Framework.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader)
        {
            _articleRepository = articleRepository;
            _fileUploader = fileUploader;
        }

        public void Active(long id)
        {
            var article = _articleRepository.GetBy(id);
            article.Active();
            _articleRepository.SaveChanges();
        }

        public OperationResult Create(CreateArticle command)
        {
            var operationResult = new OperationResult();

            if (_articleRepository.Exists(x => x.Title == command.Title))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            var file = _fileUploader.Upload(command.Picture, "Blog");
            var article = new Article(command.Title, command.Description, file, command.PictureAlt, command.Title, command.CategoryId);
            _articleRepository.CreateAndSave(article);
            _articleRepository.SaveChanges();
            return operationResult.Successful();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operationResult = new OperationResult();
            var article = _articleRepository.GetBy(command.Id);

            if (_articleRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            if (article == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            var file = _fileUploader.Upload(command.Picture, "Blog");
            article.Edit(command.Title, command.Description, file, command.PictureAlt, command.Title, command.CategoryId);
            _articleRepository.SaveChanges();
            return operationResult.Successful();
        }

        public List<ArticleViewModel> GetAll()
        {
            return _articleRepository.GetAll();
        }

        public EditArticle GetDetailsBy(long id)
        {
            return _articleRepository.GetDetailsBy(id);
        }

        public void Remove(long id)
        {
            var article = _articleRepository.GetBy(id);
            article.Remove();
            _articleRepository.SaveChanges();
        }
    }
}
