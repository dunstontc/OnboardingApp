
namespace OnboardingApp
{
    public class User
    {
        public string First { get; set; }
        public string Last { get; set; }
        
        public bool IsAccount { get; set; }
        
        public int PinNumber { get; set; }

        public string FullName()
        {
            return string.Join(" ", First, Last);
        }
    }
}
