
namespace MIniMedicalStoreManagementSystem.RestApi.Features.Medicines
{
    public interface IMedicineService
    {
        MedicineResponseModel CreateProduct(MedicineModel requestModel);

        List<MedicineModel> GetMedicines();

        MedicineModel GetMedicine(string id);

        MedicineResponseModel UpdateMedicine(MedicineModel requestModel);


        MedicineResponseModel DeleteMedicine(string id);
       
    }
}