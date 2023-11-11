using _0_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operationResult = new OperationResult();

            if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            var category = new ArticleCategory(command.Name);
            _articleCategoryRepository.CreateAndSave(category);
            _articleCategoryRepository.SaveChanges();
            return operationResult.Successful();
        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operationResult = new OperationResult();
            var category = _articleCategoryRepository.GetBy(command.Id);

            if (_articleCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            if (category == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            category.Edit(command.Name);
            _articleCategoryRepository.SaveChanges();
            return operationResult.Successful();
        }

        public List<AtricleCategoryViewModel> GetAll()
        {
            return _articleCategoryRepository.GetAll();
        }

        public EditArticleCategory GetDetailsBy(long id)
        {
            return _articleCategoryRepository.GetDetailsBy(id);
        }
    }
}