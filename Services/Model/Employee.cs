namespace Services.Model
{
    public class Employee : User
    {
        public string Department {  get; set; }
        public DateTime DateOfJoining { get; set; }
        public int Experience { get; set; }
    }
}
