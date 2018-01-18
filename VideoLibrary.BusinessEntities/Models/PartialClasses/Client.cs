namespace VideoLibrary.BusinessEntities.Models.Model
{
    public partial class Client
    {

        public string Name { get { return FirstName + " " + LastName; } }
    }
}
