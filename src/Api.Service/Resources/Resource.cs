using System.Resources;

namespace Api.CrossCutting.Languages
{
    public class Resource
    {
          ResourceManager rm = new ResourceManager("rmc",
                            typeof(Resource).Assembly);
        public string hello => rm.GetString("hello");

        public string userNotFound => rm.GetString("userNotFound");

        public string passNotFound => rm.GetString("passNotFound");

        public string sessionLimit => rm.GetString("sessionLimit");

        public string authenticateFailed => rm.GetString("authenticateFailed");

        public string authenticateSuccessful => rm.GetString("authenticateSuccessful");

    }
}
