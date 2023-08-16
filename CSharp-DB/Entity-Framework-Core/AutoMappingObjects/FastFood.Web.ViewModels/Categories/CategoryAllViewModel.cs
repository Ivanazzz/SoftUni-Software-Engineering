namespace FastFood.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using Common.EntityConfiguration;

    public class CategoryAllViewModel
    {
        [MinLength(ViewModelsValidation.CategoryNameMinLength)]
        [MaxLength(ViewModelsValidation.CategoryNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
