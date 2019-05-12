
namespace ImagoCore.Models.Strategies
{
    public interface IFertigkeitVeraendernService
    {
        void SteigereFertigkeit(ref SteigerbareFertigkeitBase fertigkeit);
        void ReduziereFertigkeit(ref SteigerbareFertigkeitBase fertigkeit);
    }
}
