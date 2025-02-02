namespace DotNetBatch14SNH.Login.Fearures.ProductList
{
    public class ProductListService
    {
        public ProductListService()
        {

        }

        public List<string> Execute()
        {
            var list = new List<string>();
            list.Add("Apple");
            list.Add("Banana");
            list.Add("Orange");

            return list;
        }
    }
}
