using System;

namespace Wow.DaprBlock.Core
{
    public static class EndPoints
    {
        public static string PublishToOrderTopic = "publish/wowpublish/order";
        public static string StateMangement = "statestore";
        public static string SecretMangement = "secrets/secretstore";
    }
}
