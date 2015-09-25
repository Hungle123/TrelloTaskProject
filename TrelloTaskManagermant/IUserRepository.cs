
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace TrelloTaskManagermant
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserRepository" in both code and config file together.
    [ServiceContract]
    public interface IUserRepository
    {
        [OperationContract]
        List<Users> GetUserRepository();

        [OperationContract]
        string InsertUserRepository(Users userObj);

        [OperationContract]
        string UpdateUserRepository(Users userObj);

        [OperationContract]
        string DeleteUserRepository(int userId);
    }
    [DataContract]
    public class Users
    {
        private int _userId;
        private string _userName;
        private string _password;
        private string _address;
        private string _phoneNumber;
        private string _avarta;


        public Users(int userId, string userName, string password, string address, string phoneNumber, string avarta)
        {
            _userId = userId;
            _userName = userName;
            _password = password;
            _address = address;
            _phoneNumber = phoneNumber;
            _avarta = avarta;
        }

        public Users()
        {
            
        }

        [DataMember]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [DataMember]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        [DataMember]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        [DataMember]
        public string Avarta
        {
            get { return _avarta; }
            set { _avarta = value; }
        }
    }
}
