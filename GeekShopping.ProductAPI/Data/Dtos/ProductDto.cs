namespace GeekShopping.ProductAPI.Data.Dtos
{
    /// <summary>
    /// Classe de produtos DTO
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get ; set; } = string.Empty;
        /// <summary>
        /// Preço
        /// </summary>
        public decimal Price { get; set; } = decimal.Zero;
        /// <summary>
        /// Descrição
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Nome da categoria
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;
        /// <summary>
        /// URL da imagem
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
    }
}
