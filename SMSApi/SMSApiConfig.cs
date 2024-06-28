namespace SMSApi
{
    public class SMSApiConfig
    {
        public LoggerConfig LoggerConfig { get; set; }
        public SMSProviderConfigs SMSProviderConfigs { get; set; }
    }

    public class LoggerConfig
    {
        public string GrayLogAddress { get; set; }
        public int GrayLogPort { get; set; }
    }
    public class SMSProviderConfigs
    {
        public string ProviderSelector { get; set; }
        public TwilioConfig Twilio { get; set; }
        public MagtiConfig Magti { get; set; }
        public GeocellConfig Geocell { get; set; }
        public ProviderWeightsConfig ProviderWeights { get; set; }
    }

    public class ProviderWeightsConfig
    {
        public int TwilioWeight { get; set; }
        public int MagtiWeight { get; set; }
        public int GeocellWeight { get; set; }
    }

    public class TwilioConfig
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class GeocellConfig
    {
        //Some specific config (?)
    }

    public class MagtiConfig
    {
        //Some specific config (?)
    }
}
