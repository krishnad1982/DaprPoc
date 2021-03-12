namespace Wow.DaprBlock.Dispatch.Configurations
{
    public class Setting
    {
        public string BaseUrl { get; set; }
        public DaprConfigurartion DaprConfigurartion { get; set; }
    }

    public class DaprConfigurartion
    {
        public string DaprPort { get; set; }
        public string DaprVersion { get; set; }
    }
}
