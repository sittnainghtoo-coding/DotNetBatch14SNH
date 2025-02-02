namespace DotNetBatch14SNH.Login.Fearures.CategoryList
{
    public class CategoryListService
    {
        public List<string> Execute()
        {
            var list = new List<string>();
            list.Add("Foods");
            list.Add("Drinks");
            list.Add("Toys");

            return list;
        }
    }
}
