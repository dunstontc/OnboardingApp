
namespace OnboardingApp
{
    public class User
    {
        public string First { get; set; }
        public string Last { get; set; }

        private bool _isAccountOwner;
        public bool IsAccountOwner
        {
            get { return _isAccountOwner; }
            set { _isAccountOwner = value; }
        }

        private int _pinNumber;
        public int PinNumber
        {
            get { return _pinNumber; }
            set { _pinNumber = value; }
        }


        private string FullName
        {
            get
            {
                if (First.Length > 1 || Last.Length > 1)
                {
                    return string.Join(" ", First, Last);
                }

                return "This user has no name.";
            }
        }


        private string IsOwner()
        {
            return IsAccountOwner ? "Account owner" : "Not account owner";
        }

        private string getPin()
        {
            return PinNumber.ToString().Length == 4 ? "****" : "This user has yet to set up a PIN numner";
        }

        public string DescribeUser()
        {
            var userString = "User: " + FullName;
            var ownerString = "Permissions: " + IsOwner();
            var pinString = "PIN Number: " + getPin();
            
        return string.Join("\n", userString, ownerString, pinString);
        }
    }
}
