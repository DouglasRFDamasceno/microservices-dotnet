using GeekShopping.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Model
{
    /// <summary>
    /// Classe de produtos
    /// </summary>
    [Table("product")]
    public class Product : BaseEntity
    {
        /// <summary>
        /// Nome
        /// </summary>
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        /// <summary>
        /// Preço
        /// </summary>
        [Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        /// <summary>
        /// Descrição
        /// </summary>
        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Nome da categoria
        /// </summary>
        [Column("category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; } = string.Empty;

        /// <summary>
        /// URL da imagem
        /// </summary>
        [Column("image_url")]
        [StringLength(300)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
