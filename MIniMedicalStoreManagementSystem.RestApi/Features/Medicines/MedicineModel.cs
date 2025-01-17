using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MIniMedicalStoreManagementSystem.RestApi.Features.Medicines
{
    
        [Table("MedicineStore")]
        public class MedicineModel
        {
            [Key]
            public string? MedicineId { get; set; }

            public string? MedicineName { get; set; }

            public decimal? MedicinePrice { get; set; }
            public int? MedicineQuantity { get; set; }
        }


        public class MedicineResponseModel
        {
            public bool IsSuccess { get; set; }
            public string? Message { get; set; }
        }
}
