using Microsoft.EntityFrameworkCore;

namespace MIniMedicalStoreManagementSystem.RestApi.Features.Medicines
{
    public class MedicineService :  IMedicineService
    {
        private readonly AppDbContext _db;
        public MedicineService()
        {
            _db = new AppDbContext();
        }

        public MedicineResponseModel CreateProduct(MedicineModel requestModel)
        {
            _db.Medicine.Add(requestModel);
            var result = _db.SaveChanges();

            string message = result > 0 ? "Create Successful" : "Create Failed";
            MedicineResponseModel model = new MedicineResponseModel();
            model.IsSuccess = true;
            model.Message = message;
            return model;
        }

        public List<MedicineModel> GetMedicines()

            
        {
            List<MedicineModel> lst = _db.Medicine.ToList();
            return lst;

        }

        public MedicineModel GetMedicine(string id)
        {
            var item = _db.Medicine.AsNoTracking().FirstOrDefault(x => x.MedicineId == id);
            return item;
        }

        public MedicineResponseModel UpdateMedicine(MedicineModel requestModel)
        {
            MedicineResponseModel model = new MedicineResponseModel();

            var item = _db.Medicine.AsNoTracking().FirstOrDefault(x => x.MedicineId == requestModel.MedicineId);
            if (item is null)
            {
                model = CreateProduct(requestModel);
                return model;
            }

            if (!string.IsNullOrEmpty(requestModel.MedicineName))
            {
                item.MedicineName = requestModel.MedicineName;
            }
            if (!string.IsNullOrEmpty(requestModel.MedicinePrice))
            {
                item.MedicinePrice = requestModel.MedicinePrice;
            }
            if (!string.IsNullOrEmpty(requestModel.MedicineQuantity))
            {
                item.MedicineQuantity = requestModel.MedicineQuantity;
            }


            _db.Entry(item).State = EntityState.Modified;

            var result = _db.SaveChanges();

            string message = result > 0 ? "Updating Successful" : "UPdating Failed";
            model.IsSuccess = true;
            model.Message = message;
            return model;
        }

        public MedicineResponseModel DeleteMedicine(string id)
        {
            var item = _db.Medicine.AsNoTracking().FirstOrDefault(x => x.MedicineId == id);
            if (item is null)
            {
                return new MedicineResponseModel
                {
                    IsSuccess = false,
                    Message = "No data found",
                };
            }


            _db.Entry(item).State = EntityState.Deleted;
            var result = _db.SaveChanges();

            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            MedicineResponseModel model = new MedicineResponseModel();
            model.IsSuccess = true;
            model.Message = message;
            return model;
        }


    }
}
