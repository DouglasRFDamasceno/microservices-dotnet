using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductAPI.Model.Base
{
    /// <summary>
    /// Entidade Base
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [Column("id")]
        public long Id { get; set; }

    }
}
