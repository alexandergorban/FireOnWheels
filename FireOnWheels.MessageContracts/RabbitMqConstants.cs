namespace FireOnWheels.Messaging
{
    public static class RabbitMqConstants
    {
        public const string RabbitMqUri = "rabbitmq://localhost/fireonwheels/";
        public const string UserName = "guest";
        public const string Password = "guest";
        public const string RegisterOrderServiceQueue = "registerorder.service";
        public const string NotificationServiceQueue = "notification.service";
        public const string SagaQueue = "saga.service";
    }
}
