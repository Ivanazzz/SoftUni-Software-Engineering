namespace Boardgames.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class BoardgameSeller
    {
        [ForeignKey(nameof(Boardgame))]
        public int BoardgameId { get; set; }

        public virtual Boardgame Boardgame { get; set; } = null!;

        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }

        public Seller Seller { get; set; } = null!;
    }
}
