namespace Travelling.Service
{
    public class ConfigurationService
    {
        #region SingleTon
        /*-------------------------------------- SingleTon START ----------------------------------------*/
        public static ConfigurationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationService();
                }
                return instance;
            }
        }
        private static ConfigurationService instance { get; set; }

        private ConfigurationService()
        {
        }

        /*-------------------------------------- SingleTon END ------------------------------------------*/
        #endregion
    }
}
