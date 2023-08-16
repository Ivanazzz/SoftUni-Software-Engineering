namespace FastFood.Web.ViewModels.Positions
{
    using System.ComponentModel.DataAnnotations;

    using Common.EntityConfiguration;

    public class CreatePositionInputModel
    {
        //[StringLength(ViewModelsValidation.PositionNameMaxLength, MinimumLength = ViewModelsValidation.PositionNameMinLength, ErrorMessage = )]
        [MinLength(ViewModelsValidation.PositionNameMinLength)]
        [MaxLength(ViewModelsValidation.PositionNameMaxLength)]
        public string PositionName { get; set; } = null!;
    }
}