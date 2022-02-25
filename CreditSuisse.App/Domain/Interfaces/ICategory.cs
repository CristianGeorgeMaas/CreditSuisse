
namespace CreditSuisse.App.Domain.Interfaces
{
    internal interface ICategory
    {
        string Name { get; }
        void added(string name);   
        void removed(string name); 
        void modified(string name);
    }
}
