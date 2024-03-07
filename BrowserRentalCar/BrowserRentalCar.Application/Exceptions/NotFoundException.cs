namespace BrowserRentalCar.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        //Manejador de Excepciones para las entidades Key= id de registro que se esta buscando, name= entidad clase
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) no fue encontrado")
        {
        }
    }
}