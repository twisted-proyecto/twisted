using Norm;

namespace MvcApplication1.Contract
{
    public interface IUniqueIdentifier
    {
        ObjectId Id { get; set; }
    }
}