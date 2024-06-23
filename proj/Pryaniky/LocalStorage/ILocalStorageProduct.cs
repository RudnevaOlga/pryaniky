namespace Pryaniky.LocalStorage
{
    public interface ILocalStorageProduct
    {
        public void SetProduct(int id);

        public void RemoveStorage();

        public List<int> GetProducts();
    }
}
