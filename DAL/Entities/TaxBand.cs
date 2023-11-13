using Data.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class TaxBand : IHasId<int>
    {
        [Key]
        public int Id { get; set; }
        public int Rate { get; set; }
        public int BottomLimit { get; set; }
        public int UpperLimit { get; set; }
        public TaxBandCategory Category { get; set; }
    }
}